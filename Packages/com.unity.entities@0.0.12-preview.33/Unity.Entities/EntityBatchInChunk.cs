using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine.Profiling;

namespace Unity.Entities
{
    internal unsafe struct EntityBatchInChunk
    {
        public Chunk* Chunk;
        public int StartIndex;
        public int Count;
    }
}
