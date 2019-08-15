using System.Diagnostics;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
    [DebuggerTypeProxy(typeof(ArchetypeListDebugView))]
    internal unsafe struct ArchetypeList
    {
        [NativeDisableUnsafePtrRestriction]
        public Archetype** p;        
        public int Count;
        public int Capacity;
    }
}
