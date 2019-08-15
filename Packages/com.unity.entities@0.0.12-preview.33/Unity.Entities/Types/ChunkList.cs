using System.Diagnostics;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
    [DebuggerTypeProxy(typeof(ChunkListDebugView))]
    internal unsafe struct ChunkList
    {
        [NativeDisableUnsafePtrRestriction]
        public Chunk** p;
        public int Count;
        public int Capacity;
    }
}
