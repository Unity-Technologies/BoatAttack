using System;
using System.Runtime.InteropServices;

namespace Unity.Entities
{
    [Flags]
    internal enum ChunkFlags
    {
        None = 0,
        Locked = 1 << 0,
        LockedEntityOrder = 1 << 1,
        TempAssertWillDestroyAllInLinkedEntityGroup = 1 << 2
    }

    [StructLayout(LayoutKind.Explicit)]
    internal unsafe struct Chunk
    {
        // Chunk header START
        [FieldOffset(0)]
        public Archetype* Archetype;
        // 4-byte padding on 32-bit architectures here

        [FieldOffset(8)]
        public Entity metaChunkEntity;

        // This is meant as read-only.
        // EntityComponentStore.SetChunkCount should be used to change the count.
        [FieldOffset(16)]
        public int Count;
        [FieldOffset(20)]
        public int Capacity;

        // In hybrid mode, archetypes can contain non-ECS-type components which are managed objects.
        // In order to access them without a lot of overhead we conceptually store an Object[] in each chunk which contains the managed components.
        // The chunk does not really own the array though since we cannot store managed references in unmanaged memory,
        // so instead the ManagedComponentStore has a list of Object[]s and the chunk just has an int to reference an Object[] by index in that list.
        [FieldOffset(24)]
        public int ManagedArrayIndex;

        [FieldOffset(28)]
        public int ListIndex;
        [FieldOffset(32)]
        public int ListWithEmptySlotsIndex;
        
        // Special chunk behaviors
        [FieldOffset(36)]
        public uint Flags;

        // Incrementing automatically for each chunk
        [FieldOffset(40)]
        public ulong SequenceNumber;

        // Chunk header END

        // Component data buffer
        // This is where the actual chunk data starts.
        // It's declared like this so we can skip the header part of the chunk and just get to the data.
        public const int kBufferOffset = 48; // (must be multiple of 16)
        [FieldOffset(kBufferOffset)]
        public fixed byte Buffer[4];

        public const int kChunkSize = 16 * 1024 - 256; // allocate a bit less to allow for header overhead
        public const int kMaximumEntitiesPerChunk = kChunkSize / 8;

        public uint GetChangeVersion(int typeIndex)
        {
            return Archetype->Chunks.GetChangeVersion(typeIndex, ListIndex);
        }

        public void SetChangeVersion(int typeIndex, uint version)
        {
            Archetype->Chunks.SetChangeVersion(typeIndex, ListIndex, version);
        }

        public void SetAllChangeVersions(uint version)
        {
            Archetype->Chunks.SetAllChangeVersion(ListIndex, version);
        }

        public int GetSharedComponentValue(int typeOffset)
        {
            return Archetype->Chunks.GetSharedComponentValue(typeOffset, ListIndex);
        }

        public SharedComponentValues SharedComponentValues => Archetype->Chunks.GetSharedComponentValues(ListIndex);

        public static int GetChunkBufferSize()
        {
            // The amount of available space in a chunk is the max chunk size, kChunkSize,
            // minus the size of the Chunk's metadata stored in the fields preceding Chunk.Buffer
            return kChunkSize - kBufferOffset;
        }

        public bool MatchesFilter(MatchingArchetype* match, ref EntityQueryFilter filter)
        {
            if ((filter.Type & FilterType.SharedComponent) != 0)
            {
                var sharedComponentsInChunk = SharedComponentValues;
                var filteredCount = filter.Shared.Count;

                fixed (int* indexInEntityQueryPtr = filter.Shared.IndexInEntityQuery, sharedComponentIndexPtr =
                    filter.Shared.SharedComponentIndex)
                {
                    for (var i = 0; i < filteredCount; ++i)
                    {
                        var indexInEntityQuery = indexInEntityQueryPtr[i];
                        var sharedComponentIndex = sharedComponentIndexPtr[i];
                        var componentIndexInArcheType = match->IndexInArchetype[indexInEntityQuery];
                        var componentIndexInChunk = componentIndexInArcheType - match->Archetype->FirstSharedComponent;
                        if (sharedComponentsInChunk[componentIndexInChunk] != sharedComponentIndex)
                            return false;
                    }
                }

                return true;
            }

            if ((filter.Type & FilterType.Changed) != 0)
            {
                var changedCount = filter.Changed.Count;

                var requiredVersion = filter.RequiredChangeVersion;
                fixed (int* indexInEntityQueryPtr = filter.Changed.IndexInEntityQuery)
                {
                    for (var i = 0; i < changedCount; ++i)
                    {
                        var indexInArchetype = match->IndexInArchetype[indexInEntityQueryPtr[i]];

                        var changeVersion = GetChangeVersion(indexInArchetype);
                        if (ChangeVersionUtility.DidChange(changeVersion, requiredVersion))
                            return true;
                    }
                }

                return false;
            }

            return true;
        }

        public int GetSharedComponentIndex(MatchingArchetype* match, int indexInEntityQuery)
        {
            var componentIndexInArcheType = match->IndexInArchetype[indexInEntityQuery];
            var componentIndexInChunk = componentIndexInArcheType - match->Archetype->FirstSharedComponent;
            return GetSharedComponentValue(componentIndexInChunk);
        }

        /// <summary>
        /// Returns true if Chunk is Locked
        /// </summary>
        public bool Locked => (Flags & (uint) ChunkFlags.Locked) != 0;
        public bool LockedEntityOrder => (Flags & (uint) ChunkFlags.LockedEntityOrder) != 0;
    }
}
