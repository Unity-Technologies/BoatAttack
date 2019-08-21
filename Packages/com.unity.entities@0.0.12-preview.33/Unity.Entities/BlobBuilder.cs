using System;
using System.Diagnostics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Assertions;


namespace Unity.Entities
{
    public unsafe ref struct BlobBuilderArray<T> where T : struct
    {
        private void* m_data;
        private int m_length;

        public BlobBuilderArray(void* data, int length)
        {
            m_data = data;
            m_length = length;
        }

        public ref T this[int index]
        {
            get
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if(0 > index || index >= m_length)
                    throw new IndexOutOfRangeException(string.Format("Index {0} is out of range of '{1}' Length.", (object) index, (object) this.m_length));
#endif
                return ref UnsafeUtilityEx.ArrayElementAsRef<T>(m_data, index);
            }
        }

        public int Length
        {
            get { return m_length; }
        }
    }

    unsafe public struct BlobBuilder : IDisposable
    {
        Allocator m_allocator;
        NativeList<BlobAllocation> m_allocations;
        NativeList<OffsetPtrPatch> m_patches;
        int m_currentChunkIndex;
        int m_chunkSize;

        struct BlobAllocation
        {
            public int size;
            public byte* p;
        }

        struct BlobDataRef
        {
            public int allocIndex;
            public int offset;
        }

        struct OffsetPtrPatch
        {
            public int* offsetPtr;
            public BlobDataRef target;
            public int length; // if length != 0 this is an array patch and the length should be patched
        }

        public BlobBuilder(Allocator allocator, int chunkSize = 65536)
        {
            m_allocator = allocator;
            m_allocations = new NativeList<BlobAllocation>(16, m_allocator);
            m_patches = new NativeList<OffsetPtrPatch>(16, m_allocator);
            m_chunkSize = chunkSize;
            m_currentChunkIndex = -1;
        }

        public ref T ConstructRoot<T>() where T : struct
        {
            var allocation = Allocate(UnsafeUtility.SizeOf<T>(), UnsafeUtility.AlignOf<T>());
            return ref UnsafeUtilityEx.AsRef<T>(AllocationToPointer(allocation));
        }

        public BlobBuilderArray<T> Allocate<T>(int length, ref BlobArray<T> ptr) where T : struct
        {
            if(length <= 0)
                throw new ArgumentException("BlobArray length must be greater than 0");

            var offsetPtr = (int*)UnsafeUtility.AddressOf(ref ptr.m_OffsetPtr);

            ValidateAllocation(offsetPtr);

            var allocation = Allocate(UnsafeUtility.SizeOf<T>() * length, UnsafeUtility.AlignOf<T>());

            var patch = new OffsetPtrPatch
            {
                offsetPtr = offsetPtr,
                target = allocation,
                length = length
            };

            m_patches.Add(patch);
            return new BlobBuilderArray<T>(AllocationToPointer(allocation), length);
        }

        public ref T Allocate<T>(ref BlobPtr<T> ptr) where T : struct
        {
            var offsetPtr = (int*)UnsafeUtility.AddressOf(ref ptr.m_OffsetPtr);

            ValidateAllocation(offsetPtr);

            var allocation = Allocate(UnsafeUtility.SizeOf<T>(), UnsafeUtility.AlignOf<T>());

            var patch = new OffsetPtrPatch
            {
                offsetPtr = offsetPtr,
                target = allocation,
                length = 0
            };

            m_patches.Add(patch);
            return ref UnsafeUtilityEx.AsRef<T>(AllocationToPointer(allocation));
        }

        struct SortedIndex : IComparable<SortedIndex>
        {
            public byte* p;
            public int index;
            public int CompareTo(SortedIndex other)
            {
                return ((ulong)p).CompareTo((ulong)other.p);
            }
        }

        public BlobAssetReference<T> CreateBlobAssetReference<T>(Allocator allocator) where T : struct
        {
            Assert.AreEqual(16, sizeof(BlobAssetHeader));
            NativeArray<int> offsets = new NativeArray<int>(m_allocations.Length + 1, m_allocator);

            var sortedAllocs = new NativeArray<SortedIndex>(m_allocations.Length, m_allocator);

            offsets[0] = 0;
            for (int i = 0; i < m_allocations.Length; ++i)
            {
                offsets[i+1] = offsets[i] + m_allocations[i].size;
                sortedAllocs[i] = new SortedIndex {p = m_allocations[i].p, index = i};
            }
            int dataSize = offsets[m_allocations.Length];

            sortedAllocs.Sort();
            var sortedPatches = new NativeArray<SortedIndex>(m_patches.Length, m_allocator);
            for (int i = 0; i < m_patches.Length; ++i)
                sortedPatches[i] = new SortedIndex {p = (byte*)m_patches[i].offsetPtr, index = i};
            sortedPatches.Sort();

            byte* buffer = (byte*) UnsafeUtility.Malloc(sizeof(BlobAssetHeader) + dataSize, 16, allocator);
            byte* data = buffer + sizeof(BlobAssetHeader);

            for (int i = 0; i < m_allocations.Length; ++i)
                UnsafeUtility.MemCpy(data + offsets[i], m_allocations[i].p, m_allocations[i].size);

            int iAlloc = 0;
            var allocStart = m_allocations[sortedAllocs[0].index].p;
            var allocEnd = allocStart + m_allocations[sortedAllocs[0].index].size;

            for (int i = 0; i < m_patches.Length; ++i)
            {
                int patchIndex = sortedPatches[i].index;
                int* offsetPtr = (int*)sortedPatches[i].p;

                while (offsetPtr > allocEnd)
                {
                    ++iAlloc;
                    allocStart = m_allocations[sortedAllocs[iAlloc].index].p;
                    allocEnd = allocStart + m_allocations[sortedAllocs[iAlloc].index].size;
                }

                var patch = m_patches[patchIndex];

                int offsetPtrInData = offsets[sortedAllocs[iAlloc].index] + (int)((byte*)offsetPtr - allocStart);
                int targetPtrInData = offsets[patch.target.allocIndex] + patch.target.offset;

                *(int*) (data + offsetPtrInData) = targetPtrInData - offsetPtrInData;
                if (patch.length != 0)
                {
                    *(int*) (data + offsetPtrInData + 4) = patch.length;
                }
            }

            sortedPatches.Dispose();
            sortedAllocs.Dispose();

            BlobAssetHeader* header = (BlobAssetHeader*) buffer;
            *header = new BlobAssetHeader();
            header->Length = (int)dataSize;
            header->Allocator = allocator;

            BlobAssetReference<T> blobAssetReference;
            header->ValidationPtr = blobAssetReference.m_data.m_Ptr = buffer + sizeof(BlobAssetHeader);

            return blobAssetReference;
        }

        internal static int AlignUp(int value, int alignment)
        {
            int mask = alignment - 1;
            if ((value & ~mask) == 0)
                return value;
            return (value + mask) & ~mask;
        }

        void* AllocationToPointer(BlobDataRef blobDataRef)
        {
            return m_allocations[blobDataRef.allocIndex].p + blobDataRef.offset;
        }

        BlobAllocation EnsureEnoughRoomInChunk(int size, int alignment)
        {
            if (m_currentChunkIndex == -1)
                return AllocateNewChunk();

            var alloc = m_allocations[m_currentChunkIndex];
            int startOffset = AlignUp(alloc.size, alignment);
            if (startOffset + size > m_chunkSize)
                return AllocateNewChunk();

            UnsafeUtility.MemClear(alloc.p + alloc.size, startOffset-alloc.size);

            alloc.size = startOffset;
            return alloc;
        }

        BlobDataRef Allocate(int size, int alignment)
        {
            if (size > m_chunkSize)
            {
                size = AlignUp(size, 16);
                var allocIndex = m_allocations.Length;
                var mem = (byte*) UnsafeUtility.Malloc(size, alignment, m_allocator);
                UnsafeUtility.MemClear(mem, size);
                m_allocations.Add(new BlobAllocation {p = mem, size = size});
                return new BlobDataRef {allocIndex = allocIndex, offset = 0};
            }

            BlobAllocation alloc = EnsureEnoughRoomInChunk(size, alignment);

            var offset = alloc.size;
            UnsafeUtility.MemClear(alloc.p + alloc.size, size);
            alloc.size += size;
            m_allocations[m_currentChunkIndex] = alloc;
            return new BlobDataRef {allocIndex = m_currentChunkIndex, offset = offset};
        }

        BlobAllocation AllocateNewChunk()
        {
            // align size of last chunk to 16 bytes so chunks can be concatenated without breaking alignment
            if(m_currentChunkIndex != -1)
            {
                var currentAlloc = m_allocations[m_currentChunkIndex];
                currentAlloc.size = AlignUp(currentAlloc.size, 16);
                m_allocations[m_currentChunkIndex] = currentAlloc;
            }

            m_currentChunkIndex = m_allocations.Length;
            var alloc = new BlobAllocation {p = (byte*) UnsafeUtility.Malloc(m_chunkSize, 16, m_allocator), size = 0};
            m_allocations.Add(alloc);
            return alloc;
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        void ValidateAllocation(void* p)
        {
            // ValidateAllocation is most often called with data in recently allocated allocations
            // so this searches backwards
            for (int i = m_allocations.Length-1; i >= 0; --i)
            {
                if (m_allocations[i].p <= p && p < m_allocations[i].p + m_allocations[i].size)
                    return;
            }

            throw new InvalidOperationException("The BlobArray passed to Allocate was not allocated by this BlobBuilder or the struct that embeds it was copied by value instead of by ref.");
        }

        public void Dispose()
        {
            for(int i=0;i<m_allocations.Length;++i)
                UnsafeUtility.Free(m_allocations[i].p, m_allocator);
            m_allocations.Dispose();
            m_patches.Dispose();
        }
    }
}
