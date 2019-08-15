using System.Diagnostics;
using Unity.Assertions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
    // Stores change version numbers, shared component indices, and entity count for all chunks belonging to an archetype in SOA layout
    [DebuggerTypeProxy(typeof(ArchetypeChunkDataDebugView))]
    internal unsafe struct ArchetypeChunkData
    {
        public Chunk** p;
        public int* data;
        public int Capacity;
        public int Count;
        public readonly int SharedComponentCount;
        public readonly int EntityCountIndex;
        public readonly int Channels;

        public ArchetypeChunkData(int componentTypeCount, int sharedComponentCount)
        {
            data = null;
            p = null;
            Capacity = 0;
            Count = 0;
            SharedComponentCount = sharedComponentCount;
            EntityCountIndex = componentTypeCount + sharedComponentCount;
            Channels = componentTypeCount + sharedComponentCount + 1; // +1 for entity count per-chunk
        }

        public void Grow(int newCapacity)
        {
            Assert.IsTrue(newCapacity > Capacity);
            Chunk** newChunkData = (Chunk**)UnsafeUtility.Malloc(newCapacity*(Channels*sizeof(int) + sizeof(Chunk*)), 16, Allocator.Persistent);
            var newData = (int*) (newChunkData + newCapacity);

            UnsafeUtility.MemCpy(newChunkData, p, sizeof(Chunk*)*Count);

            for(int i=0;i<Channels;++i)
                UnsafeUtility.MemCpy(newData + i*newCapacity, data + i*Capacity, sizeof(int)*Count);

            UnsafeUtility.Free(p, Allocator.Persistent);
            data = newData;
            p = newChunkData;
            Capacity = newCapacity;
        }

        // typeOffset 0 is first shared component
        public int GetSharedComponentValue(int typeOffset, int chunkIndex)
        {
            return data[typeOffset*Capacity+chunkIndex];
        }

        public int* GetSharedComponentValueArrayForType(int typeOffset)
        {
            return data + typeOffset*Capacity;
        }

        public void SetSharedComponentValue(int typeOffset, int chunkIndex, int value)
        {
            data[typeOffset*Capacity+chunkIndex] = value;
        }

        public SharedComponentValues GetSharedComponentValues(int iChunk)
        {
            return new SharedComponentValues
            {
                firstIndex = data + iChunk,
                stride = Capacity*sizeof(int)
            };
        }

        public uint GetChangeVersion(int typeOffset, int chunkIndex)
        {
            return (uint)data[(typeOffset+SharedComponentCount)*Capacity+chunkIndex];
        }
        public void SetChangeVersion(int typeOffset, int chunkIndex, uint version)
        {
            data[(typeOffset+SharedComponentCount)*Capacity+chunkIndex] = (int)version;
        }
        public uint* GetChangeVersionArrayForType(int typeOffset)
        {
            return (uint*)data + (typeOffset+SharedComponentCount)*Capacity;
        }

        public int GetChunkEntityCount(int chunkIndex)
        {
            return data[(EntityCountIndex)*Capacity+chunkIndex];
        }
        public void SetChunkEntityCount(int chunkIndex, int count)
        {
            data[(EntityCountIndex)*Capacity+chunkIndex] = (int)count;
        }
        public int* GetChunkEntityCountArray()
        {
            return data + (EntityCountIndex)*Capacity;
        }

        public void Add(Chunk* chunk, SharedComponentValues sharedComponentIndices)
        {
            var chunkIndex = Count++;

            p[chunkIndex] = chunk;

            int* dst = data + chunkIndex;
            int i = 0;
            for (; i < SharedComponentCount; ++i)
            {
                *dst = sharedComponentIndices[i];
                dst += Capacity;
            }

            for (; i < EntityCountIndex; ++i)
            {
                *dst = 0;
                dst += Capacity;
            }

            *dst = chunk->Count;
        }

        public void RemoveAtSwapBack(int iChunk)
        {
            if (iChunk == --Count)
                return;

            p[iChunk] = p[Count];

            int* dst = data + iChunk;
            int* src = data + Count;

            for (int i = 0; i < Channels; ++i)
            {
                *dst = *src;
                dst += Capacity;
                src += Capacity;
            }
        }

        public void Dispose()
        {
            UnsafeUtility.Free(p, Allocator.Persistent);
            p = null;
            data = null;
            Capacity = 0;
            Count = 0;
        }

        public void SetAllChangeVersion(int chunkIndex, uint version)
        {
            for (int i = SharedComponentCount; i < EntityCountIndex; ++i)
                data[i * Capacity + chunkIndex] = (int)version;
        }
    }

}
