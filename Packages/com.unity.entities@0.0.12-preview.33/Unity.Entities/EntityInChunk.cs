using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Unity.Entities
{
    internal unsafe struct EntityInChunk : IComparable<EntityInChunk>, IEquatable<EntityInChunk>
    {
        public Chunk* Chunk;
        public int IndexInChunk;
        
        public int CompareTo(EntityInChunk other)
        {
            ulong lhs = (ulong) Chunk;
            ulong rhs = (ulong) other.Chunk;
            int chunkCompare = (int)(lhs - rhs);
            int indexCompare = IndexInChunk - other.IndexInChunk;
            return (lhs != rhs) ? chunkCompare : indexCompare;
        }
        
        public bool Equals(EntityInChunk other)
        {
            return CompareTo(other) == 0;
        }
    }
}
