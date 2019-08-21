using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Assertions;

namespace Unity.Entities
{
    [Obsolete("BlobAllocator is deprecated, please use BlobBuilder instead.")]
    unsafe public struct BlobAllocator : IDisposable
    {
        byte* m_RootPtr;
        byte* m_Ptr;

        long m_Size;

        //@TODO: handle alignment correctly in the allocator
        public BlobAllocator(int sizeHint)
        {
            //@TODO: Use virtual alloc to make it unnecessary to know the size ahead of time...
            // Should only need 256 MB on large mesh etc
#if UNITY_IPHONE || UNITY_ANDROID || UNITY_SWITCH
        int size = 1024 * 1024 * 16;
#else
            int size = 1024 * 1024 * 256;
#endif

            m_RootPtr = m_Ptr = (byte*) UnsafeUtility.Malloc(size, 16, Allocator.Persistent);
            m_Size = size;
        }

        public void Dispose()
        {
            UnsafeUtility.Free(m_RootPtr, Allocator.Persistent);
        }

        public ref T ConstructRoot<T>() where T : struct
        {
            byte* returnPtr = m_Ptr;
            m_Ptr += UnsafeUtility.SizeOf<T>();
            return ref UnsafeUtilityEx.AsRef<T>(returnPtr);
        }

        int Allocate(long size, void* ptrAddr)
        {
            long offset = (byte*) ptrAddr - m_RootPtr;
            if (m_Ptr - m_RootPtr > m_Size)
                throw new System.ArgumentException("BlobAllocator.preallocated size not large enough");

            if (offset < 0 || offset + size > m_Size)
                throw new System.ArgumentException("Ptr must be part of root compound");

            byte* returnPtr = m_Ptr;
            m_Ptr += size;

            long relativeOffset = returnPtr - (byte*) ptrAddr;
            if (relativeOffset > int.MaxValue || relativeOffset < int.MinValue)
                throw new System.ArgumentException("BlobPtr uses 32 bit offsets, and this offset exceeds it.");

            return (int) relativeOffset;
        }

        public void Allocate<T>(int length, ref BlobArray<T> ptr) where T : struct
        {
            ptr.m_OffsetPtr = Allocate(UnsafeUtility.SizeOf<T>() * length, UnsafeUtility.AddressOf(ref ptr));
            ptr.m_Length = length;
        }

        public void Allocate<T>(ref BlobPtr<T> ptr) where T : struct
        {
            ptr.m_OffsetPtr = Allocate(UnsafeUtility.SizeOf<T>(), UnsafeUtility.AddressOf(ref ptr));
        }

        public BlobAssetReference<T> CreateBlobAssetReference<T>(Allocator allocator) where T : struct
        {
            Assert.AreEqual(16, sizeof(BlobAssetHeader));

            long dataSize = (m_Ptr - m_RootPtr);
            Assertions.Assert.IsTrue(dataSize <= 0x7FFFFFFF);

            byte* buffer = (byte*) UnsafeUtility.Malloc(sizeof(BlobAssetHeader) + dataSize, 16, allocator);
            UnsafeUtility.MemCpy(buffer + sizeof(BlobAssetHeader), m_RootPtr, dataSize);

            BlobAssetHeader* header = (BlobAssetHeader*) buffer;
            *header = new BlobAssetHeader();
            header->Length = (int)dataSize;
            header->Allocator = allocator;

            BlobAssetReference<T> blobAssetReference;
            header->ValidationPtr = blobAssetReference.m_data.m_Ptr = buffer + sizeof(BlobAssetHeader);

            return blobAssetReference;
        }

        public long DataSize
        {
            get { return (m_Ptr - m_RootPtr); }
        }
    }
}