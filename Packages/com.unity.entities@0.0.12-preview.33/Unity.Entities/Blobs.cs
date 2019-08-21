using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public unsafe struct BlobAssetOwner : ISharedComponentData, IDisposable
    {
        [FieldOffset(0)]
        private byte* data;
        [FieldOffset(8)]
        private int totalSize;

        public BlobAssetOwner(byte* data, int totalSize)
        {
            this.data = data;
            this.totalSize = totalSize;
        }

        public void Dispose()
        {
            var end = data + totalSize;
            var header = (BlobAssetHeader*)data;
            while (header < end)
            {
                header->Invalidate();
                header = (BlobAssetHeader*)(((byte*) (header+1)) + header->Length);
            }

            UnsafeUtility.Free(data, Allocator.Persistent);
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 16)]
    unsafe struct BlobAssetHeader
    {
        [FieldOffset(0)] public void* ValidationPtr;
        [FieldOffset(8)] public int Length;
        [FieldOffset(12)] public Allocator Allocator;

        public void Invalidate()
        {
            ValidationPtr = (void*)0xdddddddddddddddd;
        }
    }

    //@TODO: This requires [StructLayout(LayoutKind.Explicit, Size = 8)] but it currently crashes in Burst when used in Unity.Physics
    //       https://github.com/Unity-Technologies/dots/issues/2117
    #if NET_DOTS
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    #endif
    internal unsafe struct BlobAssetReferenceData
    {
        [NativeDisableUnsafePtrRestriction]
        #if NET_DOTS
        [FieldOffset(0)]
        #endif
        public byte* m_Ptr;
    
        internal BlobAssetHeader* Header
        {
            get { return ((BlobAssetHeader*) m_Ptr) - 1; }
        }

        
        [BurstDiscard]
        void ValidateNonBurst()
        {
            void* validationPtr = null;
            try
            {
                // Try to read ValidationPtr, this might throw if the memory has been unmapped
                validationPtr = Header->ValidationPtr;
            }
            catch(Exception)
            {
            }

            if (validationPtr != m_Ptr)
                throw new InvalidOperationException("The BlobAssetReference is not valid. Likely it has already been unloaded or released.");
        }

        void ValidateBurst()
        {
            void* validationPtr = Header->ValidationPtr;
            if(validationPtr != m_Ptr)
                throw new InvalidOperationException("The BlobAssetReference is not valid. Likely it has already been unloaded or released.");
        }

        
        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void ValidateNotNull()
        {
            if(m_Ptr == null)
                throw new InvalidOperationException("The BlobAssetReference is null.");

            ValidateNonBurst();
            ValidateBurst();
        }
        
        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public void ValidateAllowNull()
        {
            if (m_Ptr == null)
                return;

            ValidateNonBurst();
            ValidateBurst();
        }
    }

    [ChunkSerializable]
    public unsafe struct BlobAssetReference<T> : IEquatable<BlobAssetReference<T>> where T : struct
    {
        internal BlobAssetReferenceData m_data;
        public bool IsCreated
        {
            get { return m_data.m_Ptr != null; }
        }
        
        public void* GetUnsafePtr()
        {
            m_data.ValidateAllowNull();
            return m_data.m_Ptr;
        }

        public void Release()
        {
            m_data.ValidateNotNull();
            var header = m_data.Header;
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if(header->Allocator == Allocator.None)
                throw new InvalidOperationException("It's not possible to release a blob asset reference that was deserialized. It will be automatically released when the scene is unloaded ");
            m_data.Header->Invalidate();
#endif

            UnsafeUtility.Free(header, header->Allocator);
            m_data.m_Ptr = null;
        }

        public ref T Value
        {
            get
            {
                m_data.ValidateNotNull();
                return ref UnsafeUtilityEx.AsRef<T>(m_data.m_Ptr);
            }
        }

        
        public static BlobAssetReference<T> Create(void* ptr, int length)
        {
            byte* buffer =
                (byte*) UnsafeUtility.Malloc(sizeof(BlobAssetHeader) + length, 16, Allocator.Persistent);
            UnsafeUtility.MemCpy(buffer + sizeof(BlobAssetHeader), ptr, length);

            BlobAssetHeader* header = (BlobAssetHeader*) buffer;
            *header = new BlobAssetHeader();

            header->Length = length;
            header->Allocator = Allocator.Persistent;

            BlobAssetReference<T> blobAssetReference;
            header->ValidationPtr = blobAssetReference.m_data.m_Ptr = buffer + sizeof(BlobAssetHeader);
            return blobAssetReference;
        }

        public static BlobAssetReference<T> Create(byte[] data)
        {
            fixed (byte* ptr = &data[0])
            {
                return Create(ptr, data.Length);
            }
        }

        public static BlobAssetReference<T> Create(T value)
        {
            return Create(UnsafeUtility.AddressOf(ref value), UnsafeUtility.SizeOf<T>());
        }

        public static BlobAssetReference<T> Null => new BlobAssetReference<T>();

        public static bool operator ==(BlobAssetReference<T> lhs, BlobAssetReference<T> rhs)
        {
            return lhs.m_data.m_Ptr == rhs.m_data.m_Ptr;
        }

        public static bool operator !=(BlobAssetReference<T> lhs, BlobAssetReference<T> rhs)
        {
            return lhs.m_data.m_Ptr != rhs.m_data.m_Ptr;
        }

        public bool Equals(BlobAssetReference<T> other)
        {
            return m_data.Equals(other.m_data);
        }

        public override bool Equals(object obj)
        {
            return this == (BlobAssetReference<T>)obj;
        }

        public override int GetHashCode()
        {
            return m_data.GetHashCode();
        }
    }

    unsafe public struct BlobPtr<T> where T : struct
    {
        internal int m_OffsetPtr;

        public ref T Value
        {
            get
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if(m_OffsetPtr == 0)
                    throw new System.InvalidOperationException("The accessed BlobPtr hasn't been allocated.");
#endif
                fixed (int* thisPtr = &m_OffsetPtr)
                {
                    return ref UnsafeUtilityEx.AsRef<T>((byte*) thisPtr + m_OffsetPtr);
                }
            }
        }

        public void* GetUnsafePtr()
        {
            if (m_OffsetPtr == 0)
                return null;

            fixed (int* thisPtr = &m_OffsetPtr)
            {
                return (byte*) thisPtr + m_OffsetPtr;
            }
        }
    }

    unsafe public struct BlobArray<T> where T : struct
    {
        internal int m_OffsetPtr;
        internal int m_Length;

        public int Length
        {
            get { return m_Length; }
        }

        public void* GetUnsafePtr()
        {
            // for an unallocated array this will return an invalid pointer which is ok since it
            // should never be accessed as Length will be 0
            fixed (int* thisPtr = &m_OffsetPtr)
            {
                return (byte*) thisPtr + m_OffsetPtr;
            }
        }

        public ref T this[int index]
        {
            get
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if ((uint) index >= (uint) m_Length)
                    throw new System.IndexOutOfRangeException(string.Format("Index {0} is out of range Length {1}",
                        index, m_Length));
#endif

                fixed (int* thisPtr = &m_OffsetPtr)
                {
                    return ref UnsafeUtilityEx.ArrayElementAsRef<T>((byte*) thisPtr + m_OffsetPtr, index);
                }
            }
        }
    }
}
