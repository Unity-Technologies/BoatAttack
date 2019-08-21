using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Unity.Assertions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Entities
{
    [DebuggerTypeProxy(typeof(UintListDebugView))]
    internal unsafe struct UintList
    {
        [NativeDisableUnsafePtrRestriction]
        public uint* p;
        public int Count;
        public int Capacity;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct ChunkListMap : IDisposable
    {
        private const UInt32 kAValidHashCode = 0x00000001;
        private const UInt32 kSkipCode = 0xFFFFFFFF;

        static uint GetHashCode(SharedComponentValues sharedComponentValues, int numSharedComponents)
        {
            UInt32 result;
            if (sharedComponentValues.stride == sizeof(int))
            {
                result = math.hash(sharedComponentValues.firstIndex, numSharedComponents * sizeof(int));
            }
            else
            {
                int* indexArray = stackalloc int[numSharedComponents];
                for (int i = 0; i < numSharedComponents; ++i)
                    indexArray[i] = sharedComponentValues[i];
                result = math.hash(indexArray, numSharedComponents * sizeof(int));
            }

            if (result == 0 || result == kSkipCode)
                result = kAValidHashCode;
            return result;
        }

        private UintList hashes;
        private ChunkList chunks;

        public ref UnsafePtrList ChunksUnsafePtrList
        {
            get { return ref *(UnsafePtrList*)UnsafeUtility.AddressOf(ref chunks); }
        }

        public ref UnsafeList HashesPtrList
        {
            get { return ref *(UnsafeList*)UnsafeUtility.AddressOf(ref hashes); }
        }

        private int emptyNodes;
        private int skipNodes;


        public int Size
        {
            get => hashes.Count;
        }

        public int UnoccupiedNodes
        {
            get => emptyNodes + skipNodes;
        }

        public int OccupiedNodes
        {
            get => Size - UnoccupiedNodes;
        }

        public bool IsEmpty
        {
            get => OccupiedNodes == 0;
        }

        private int hashMask
        {
            get => Size - 1;
        }

        public int MinimumSize
        {
            get => 64 / sizeof(UInt32);
        }

        public void SetCapacity(int capacity)
        {
            if (capacity < MinimumSize)
                capacity = MinimumSize;
            ChunksUnsafePtrList.SetCapacity(capacity);
            HashesPtrList.SetCapacity<uint>(capacity);
        }

        public void Init(int count)
        {
            if (count < MinimumSize)
                count = MinimumSize;
            Assert.IsTrue(0 == (count & (count - 1)));
            HashesPtrList.Resize<uint>(count);
            ChunksUnsafePtrList.Resize(count);
            UnsafeUtility.MemClear(hashes.p, count * sizeof(uint));
            UnsafeUtility.MemClear(chunks.p, count * sizeof(Chunk*));
            emptyNodes = count;
            skipNodes = 0;
        }


        public void AppendFrom(ref ChunkListMap src)
        {
            for (int offset = 0; offset < src.Size; ++offset)
            {
                var hash = src.hashes.p[offset];
                if (hash != 0 && hash != kSkipCode)
                    Add(src.chunks.p[offset]);
            }
        }

        public Chunk* TryGet(SharedComponentValues sharedComponentValues, int numSharedComponents)
        {
            uint desiredHash = GetHashCode(sharedComponentValues, numSharedComponents);
            int offset = (int)(desiredHash & (uint)hashMask);
            int attempts = 0;
            while (true)
            {
                var hash = hashes.p[offset];
                if (hash == 0)
                    return null;
                if (hash == desiredHash)
                {
                    var chunk = chunks.p[offset];
                    if (sharedComponentValues.EqualTo(chunk->SharedComponentValues, numSharedComponents))
                        return chunk;
                }
                offset = (offset + 1) & hashMask;
                ++attempts;
                if (attempts == Size)
                    return null;
            }
        }

        public void Resize(int size)
        {
            if (size < MinimumSize)
                size = MinimumSize;
            if (size == Size)
                return;
            var temp = this;
            this = new ChunkListMap();
            Init(size);
            AppendFrom(ref temp);
            temp.Dispose();
        }

        public void PossiblyGrow()
        {
            if (UnoccupiedNodes < Size / 3)
                Resize(Size * 2);
        }

        public void PossiblyShrink()
        {
            if (OccupiedNodes < Size / 3)
                Resize(Size / 2);
        }

        public void Add(Chunk* chunk)
        {
            Assert.IsTrue(chunk != null);
            Assert.IsTrue(chunk->Archetype != null);
            var sharedComponentValues = chunk->SharedComponentValues;
            int numSharedComponents = chunk->Archetype->NumSharedComponents;
            uint desiredHash = GetHashCode(sharedComponentValues, numSharedComponents);
            int offset = (int)(desiredHash & (uint)hashMask);
            int attempts = 0;
            while (true)
            {
                var hash = hashes.p[offset];
                if (hash == 0)
                {
                    hashes.p[offset] = desiredHash;
                    chunks.p[offset] = chunk;
                    chunk->ListWithEmptySlotsIndex = offset;
                    --emptyNodes;
                    PossiblyGrow();
                    return;
                }

                if (hash == kSkipCode)
                {
                    hashes.p[offset] = desiredHash;
                    chunks.p[offset] = chunk;
                    chunk->ListWithEmptySlotsIndex = offset;
                    --skipNodes;
                    PossiblyGrow();
                    return;
                }

                offset = (offset + 1) & hashMask;
                ++attempts;
                Assert.IsTrue(attempts < Size);
            }
        }

        public void Remove(Chunk* chunk)
        {
            int offset = chunk->ListWithEmptySlotsIndex;
            chunk->ListWithEmptySlotsIndex = -1;
            Assert.IsTrue(offset != -1);
            Assert.IsTrue(chunks.p[offset] == chunk);
            hashes.p[offset] = kSkipCode;
            ++skipNodes;
            PossiblyShrink();
        }

        public bool Contains(Chunk* chunk)
        {
            var offset = chunk->ListWithEmptySlotsIndex;
            return offset != -1 && chunks.p[offset] == chunk;
        }

        public void Dispose()
        {
            HashesPtrList.Dispose<uint>();
            ChunksUnsafePtrList.Dispose();
            emptyNodes = 0;
            skipNodes = 0;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct ArchetypeListMap : IDisposable
    {
        private const UInt32 kAValidHashCode = 0x00000001;
        private const UInt32 kSkipCode = 0xFFFFFFFF;

        static uint GetHashCode(ComponentTypeInArchetype* type, int types)
        {
            UInt32 result = math.hash(type, types * sizeof(ComponentTypeInArchetype));
            if (result == 0 || result == kSkipCode)
                result = kAValidHashCode;
            return result;
        }

        public UintList hashes;
        public ArchetypeList archetypes;
        public int emptyNodes;
        public int skipNodes;


        public ref UnsafePtrList ArchetypeUnsafePtrList
        {
            get { return ref *(UnsafePtrList*)UnsafeUtility.AddressOf(ref archetypes); }
        }

        public ref UnsafeList HashesPtrList
        {
            get { return ref *(UnsafeList*)UnsafeUtility.AddressOf(ref hashes); }
        }


        public int Size
        {
            get => hashes.Count;
        }

        public int UnoccupiedNodes
        {
            get => emptyNodes + skipNodes;
        }

        public int OccupiedNodes
        {
            get => Size - UnoccupiedNodes;
        }

        public bool IsEmpty
        {
            get => OccupiedNodes == 0;
        }

        private int hashMask
        {
            get => Size - 1;
        }

        public int MinimumSize
        {
            get => 64 / sizeof(UInt32);
        }

        public void SetCapacity(int capacity)
        {
            if (capacity < MinimumSize)
                capacity = MinimumSize;
            ArchetypeUnsafePtrList.SetCapacity(capacity);
            HashesPtrList.SetCapacity<uint>(capacity);
        }

        public void Init(int count)
        {
            if (count < MinimumSize)
                count = MinimumSize;
            Assert.IsTrue(0 == (count & (count - 1)));
            HashesPtrList.Resize<uint>(count);
            ArchetypeUnsafePtrList.Resize(count);
            UnsafeUtility.MemClear(hashes.p, count * sizeof(uint));
            emptyNodes = count;
            skipNodes = 0;
        }

        public void AppendFrom(ArchetypeListMap* src)
        {
            for (int offset = 0; offset < src->Size; ++offset)
            {
                var hash = src->hashes.p[offset];
                if (hash != 0 && hash != kSkipCode)
                    Add(src->archetypes.p[offset]);
            }
            src->Dispose();
        }

        public Archetype* TryGet(ComponentTypeInArchetype* type, int types)
        {
            uint desiredHash = GetHashCode(type, types);
            int offset = (int)(desiredHash & (uint)hashMask);
            int attempts = 0;
            while (true)
            {
                var hash = hashes.p[offset];
                if (hash == 0)
                    return null;
                if (hash == desiredHash)
                {
                    var archetype = archetypes.p[offset];
                    if (archetype->TypesCount == types && 0 == UnsafeUtility.MemCmp(archetype->Types, type, types * sizeof(ComponentTypeInArchetype)))
                        return archetype;
                }
                offset = (offset + 1) & hashMask;
                ++attempts;
                if (attempts == Size)
                    return null;
            }
        }

        public Archetype* Get(ComponentTypeInArchetype* type, int types)
        {
            var result = TryGet(type, types);
            Assert.IsFalse(result == null);
            return result;
        }

        public void Resize(int size)
        {
            if (size < MinimumSize)
                size = MinimumSize;
            if (size == Size)
                return;
            var temp = this;
            this = new ArchetypeListMap();
            Init(size);
            AppendFrom(&temp);
            temp.Dispose();
        }

        public void PossiblyGrow()
        {
            if (UnoccupiedNodes < Size / 3)
                Resize(Size * 2);
        }

        public void PossiblyShrink()
        {
            if (OccupiedNodes < Size / 3)
                Resize(Size / 2);
        }

        public void Add(Archetype* archetype)
        {
            uint desiredHash = GetHashCode(archetype->Types, archetype->TypesCount);
            int offset = (int)(desiredHash & (uint)hashMask);
            int attempts = 0;
            while (true)
            {
                var hash = hashes.p[offset];
                if (hash == 0)
                {
                    hashes.p[offset] = desiredHash;
                    archetypes.p[offset] = archetype;
                    --emptyNodes;
                    PossiblyGrow();
                    return;
                }

                if (hash == kSkipCode)
                {
                    hashes.p[offset] = desiredHash;
                    archetypes.p[offset] = archetype;
                    --skipNodes;
                    PossiblyGrow();
                    return;
                }

                offset = (offset + 1) & hashMask;
                ++attempts;
                Assert.IsTrue(attempts < Size);
            }
        }

        public int IndexOf(Archetype* archetype)
        {
            uint desiredHash = GetHashCode(archetype->Types, archetype->TypesCount);
            int offset = (int)(desiredHash & (uint)hashMask);
            uint attempts = 0;
            while (true)
            {
                var hash = hashes.p[offset];
                if (hash == 0)
                    return -1;
                if (hash == desiredHash)
                {
                    var c = archetypes.p[offset];
                    if (c == archetype)
                        return offset;
                }
                offset = (offset + 1) & hashMask;
                ++attempts;
                if (attempts == Size)
                    return -1;
            }
        }

        public void Remove(Archetype* archetype)
        {
            int offset = IndexOf(archetype);
            Assert.IsTrue(offset != -1);
            hashes.p[offset] = kSkipCode;
            ++skipNodes;
            PossiblyShrink();
        }

        public bool Contains(Archetype* archetype)
        {
            return IndexOf(archetype) != -1;
        }

        public void Dispose()
        {
            HashesPtrList.Dispose<uint>();
            ArchetypeUnsafePtrList.Dispose();
            emptyNodes = 0;
            skipNodes = 0;
        }
    }
}
