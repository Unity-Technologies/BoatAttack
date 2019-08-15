using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
	[StructLayout(LayoutKind.Sequential)]
	[NativeContainer]
    public unsafe struct DynamicBuffer<T> where T : struct
    {
        [NativeDisableUnsafePtrRestriction]
        BufferHeader* m_Buffer;

        // Stores original internal capacity of the buffer header, so heap excess can be removed entirely when trimming.
        private int m_InternalCapacity;

#if ENABLE_UNITY_COLLECTIONS_CHECKS
	    internal AtomicSafetyHandle m_Safety0;
	    internal AtomicSafetyHandle m_Safety1;
        internal int m_SafetyReadOnlyCount;
        internal int m_SafetyReadWriteCount;
        internal bool m_IsReadOnly;
#endif

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        internal DynamicBuffer(BufferHeader* header, AtomicSafetyHandle safety, AtomicSafetyHandle arrayInvalidationSafety, bool isReadOnly, int internalCapacity)
        {
            m_Buffer = header;
            m_Safety0 = safety;
            m_Safety1 = arrayInvalidationSafety;
            m_SafetyReadOnlyCount = isReadOnly ? 2 : 0;
            m_SafetyReadWriteCount = isReadOnly ? 0 : 2;
            m_IsReadOnly = isReadOnly;
            m_InternalCapacity = internalCapacity;
        }
#else
        internal DynamicBuffer(BufferHeader* header, int internalCapacity)
        {
            m_Buffer = header;
            m_InternalCapacity = internalCapacity;
        }
#endif

        /// <summary>
        /// The number of elements the buffer holds.
        /// </summary>
        public int Length
        {
            get
            {
                CheckReadAccess();
                return m_Buffer->Length;
            }
        }

        /// <summary>
        /// The number of elements the buffer can hold.
        /// </summary>
        public int Capacity
        {
            get
            {
                CheckReadAccess();
                return m_Buffer->Capacity;
            }
        }

        public bool IsCreated
        {
            get
            {
                return m_Buffer != null;
            }
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        void CheckBounds(int index)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if ((uint)index >= (uint)Length)
                throw new IndexOutOfRangeException($"Index {index} is out of range in DynamicBuffer of '{Length}' Length.");
#endif
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        void CheckReadAccess()
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            AtomicSafetyHandle.CheckReadAndThrow(m_Safety0);
            AtomicSafetyHandle.CheckReadAndThrow(m_Safety1);
#endif
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        void CheckWriteAccess()
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            AtomicSafetyHandle.CheckWriteAndThrow(m_Safety0);
            AtomicSafetyHandle.CheckWriteAndThrow(m_Safety1);
#endif
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        void CheckWriteAccessAndInvalidateArrayAliases()
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            AtomicSafetyHandle.CheckWriteAndThrow(m_Safety0);
            AtomicSafetyHandle.CheckWriteAndBumpSecondaryVersion(m_Safety1);
#endif
        }

        public T this [int index]
        {
            get
            {
                CheckReadAccess();
                CheckBounds(index);
                return UnsafeUtility.ReadArrayElement<T>(BufferHeader.GetElementPointer(m_Buffer), index);
            }
            set
            {
                CheckWriteAccess();
                CheckBounds(index);
                UnsafeUtility.WriteArrayElement<T>(BufferHeader.GetElementPointer(m_Buffer), index, value);
            }
        }

        /// <summary>
        /// Increases the buffer capacity and length.
        /// </summary>
        /// <param name="length">The new length of the buffer.</param>
        public void ResizeUninitialized(int length)
        {
            Reserve(length);
            m_Buffer->Length = length;
        }

        /// <summary>
        /// Increases the buffer capacity without increasing its length.
        /// </summary>
        /// <param name="length">The new buffer capacity.</param>
        public void Reserve(int length)
        {
            CheckWriteAccessAndInvalidateArrayAliases();
            BufferHeader.EnsureCapacity(m_Buffer, length, UnsafeUtility.SizeOf<T>(), UnsafeUtility.AlignOf<T>(), BufferHeader.TrashMode.RetainOldData);
        }

        public void Clear()
        {
            CheckWriteAccessAndInvalidateArrayAliases();

            m_Buffer->Length = 0;
        }

        public void TrimExcess()
        {
            CheckWriteAccessAndInvalidateArrayAliases();

            byte* oldPtr = m_Buffer->Pointer;
            int length = m_Buffer->Length;

            if (length == Capacity || oldPtr == null)
                return;

            int elemSize = UnsafeUtility.SizeOf<T>();
            int elemAlign = UnsafeUtility.AlignOf<T>();

            bool isInternal;
            byte* newPtr;

            // If the size fits in the internal buffer, prefer to move the elements back there.
            if (length <= m_InternalCapacity)
            {
                newPtr = (byte*) (m_Buffer + 1);
                isInternal = true;
            }
            else
            {
                newPtr = (byte*) UnsafeUtility.Malloc((long) elemSize * length, elemAlign, Allocator.Persistent);
                isInternal = false;
            }

            UnsafeUtility.MemCpy(newPtr, oldPtr, (long)elemSize * length);

            m_Buffer->Capacity = Math.Max(length, m_InternalCapacity);
            m_Buffer->Pointer = isInternal ? null : newPtr;

            UnsafeUtility.Free(oldPtr, Allocator.Persistent);
        }

        public void Add(T elem)
        {
            CheckWriteAccess();
            int length = Length;
            ResizeUninitialized(length + 1);
            this[length] = elem;
        }

        public void Insert(int index, T elem)
        {
            CheckWriteAccess();
            int length = Length;
            ResizeUninitialized(length + 1);
            CheckBounds(index); //CheckBounds after ResizeUninitialized since index == length is allowed
            int elemSize = UnsafeUtility.SizeOf<T>();
            byte* basePtr = BufferHeader.GetElementPointer(m_Buffer);
            UnsafeUtility.MemMove(basePtr + (index + 1) * elemSize, basePtr + index * elemSize, (long)elemSize * (length - index));
            this[index] = elem;
        }

        public void AddRange(NativeArray<T> newElems)
        {
            CheckWriteAccess();
            int elemSize = UnsafeUtility.SizeOf<T>();
            int oldLength = Length;
            ResizeUninitialized(oldLength + newElems.Length);

            byte* basePtr = BufferHeader.GetElementPointer(m_Buffer);
            UnsafeUtility.MemCpy(basePtr + (long)oldLength * elemSize, newElems.GetUnsafeReadOnlyPtr<T>(), (long)elemSize * newElems.Length);
        }

        public void RemoveRange(int index, int count)
        {
            CheckWriteAccess();
            CheckBounds(index + count - 1);

            int elemSize = UnsafeUtility.SizeOf<T>();
            byte* basePtr = BufferHeader.GetElementPointer(m_Buffer);

            UnsafeUtility.MemMove(basePtr + index * elemSize, basePtr + (index + count) * elemSize, (long)elemSize * (Length - count - index));

            m_Buffer->Length -= count;
        }

        public void RemoveAt(int index)
        {
            RemoveRange(index, 1);
        }

        public void* GetUnsafePtr()
        {
            CheckWriteAccess();
            return BufferHeader.GetElementPointer(m_Buffer);
        }

        public DynamicBuffer<U> Reinterpret<U>() where U: struct
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (UnsafeUtility.SizeOf<U>() != UnsafeUtility.SizeOf<T>())
                throw new InvalidOperationException($"Types {typeof(U)} and {typeof(T)} are of different sizes; cannot reinterpret");
#endif
            // NOTE: We're forwarding the internal capacity along to this aliased, type-punned buffer.
            // That's OK, because if mutating operations happen they are all still the same size.
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            return new DynamicBuffer<U>(m_Buffer, m_Safety0, m_Safety1, m_IsReadOnly, m_InternalCapacity);
#else
            return new DynamicBuffer<U>(m_Buffer, m_InternalCapacity);
#endif
        }

        /// <summary>
        /// Return a native array that aliases the buffer contents. The array is only legal to access as long as the buffer is not reallocated.
        /// </summary>
        public NativeArray<T> AsNativeArray()
        {
            CheckReadAccess();

            var shadow = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>(BufferHeader.GetElementPointer(m_Buffer), Length, Allocator.Invalid);
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            var handle = m_Safety1;
            AtomicSafetyHandle.UseSecondaryVersion(ref handle);
            NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref shadow, handle);

#endif
            return shadow;
        }

        public NativeArray<T> ToNativeArray(Allocator allocator)
        {
            return new NativeArray<T>(AsNativeArray(), allocator);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use AsNativeArray or ToNativeArray with specific allocator", true)]
        public NativeArray<T> ToNativeArray()
        {
            return AsNativeArray();
        }

        public void CopyFrom(NativeArray<T> v)
        {
            ResizeUninitialized(v.Length);
            AsNativeArray().CopyFrom(v);
        }

        public void CopyFrom(DynamicBuffer<T> v)
        {
            ResizeUninitialized(v.Length);

            v.CheckReadAccess();
            CheckWriteAccess();

            UnsafeUtility.MemCpy(BufferHeader.GetElementPointer(m_Buffer),
                BufferHeader.GetElementPointer(v.m_Buffer), Length * UnsafeUtility.SizeOf<T>());
        }

        public void CopyFrom(T[] v)
        {
            if(v == null)
                throw new ArgumentNullException(nameof(v));

#if NET_DOTS
            Clear();
            foreach (var d in v)
            {
                Add(d);
            }
#else
            ResizeUninitialized(v.Length);
            CheckWriteAccess();

            GCHandle gcHandle = GCHandle.Alloc((object) v, GCHandleType.Pinned);
            IntPtr num = gcHandle.AddrOfPinnedObject();

            UnsafeUtility.MemCpy(BufferHeader.GetElementPointer(m_Buffer),
                (void*)num, Length * UnsafeUtility.SizeOf<T>());
            gcHandle.Free();
#endif
        }
    }
}
