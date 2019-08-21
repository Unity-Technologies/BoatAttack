using System.Runtime.InteropServices;
using Unity.Assertions;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct Archetype
    {
        public ArchetypeChunkData Chunks;
        public ChunkList ChunksWithEmptySlots;

        public ChunkListMap FreeChunksBySharedComponents;

        public int EntityCount;
        public int ChunkCapacity;
        public int BytesPerInstance;

        public ComponentTypeInArchetype* Types;
        public int TypesCount;
        public int NonZeroSizedTypesCount;

        // Index matches archetype types
        public int* Offsets;
        public int* SizeOfs;
        public int* BufferCapacities;

        // TypesCount indices into Types/Offsets/SizeOfs in the order that the
        // components are laid out in memory.
        public int* TypeMemoryOrder;

        public int* ManagedArrayOffset;
        public int NumManagedArrays;

        public int FirstSharedComponent;
        public int NumSharedComponents;

        public Archetype* InstantiableArchetype;
        public Archetype* SystemStateResidueArchetype;
        public Archetype* MetaChunkArchetype;

        public EntityRemapUtility.EntityPatchInfo* ScalarEntityPatches;
        public int                                 ScalarEntityPatchCount;

        public EntityRemapUtility.BufferEntityPatchInfo* BufferEntityPatches;
        public int                                       BufferEntityPatchCount;

        public bool SystemStateCleanupComplete;
        public bool SystemStateCleanupNeeded;
        public bool Disabled;
        public bool Prefab;
        public bool HasChunkComponents;
        public bool HasChunkHeader;
        public bool ContainsBlobAssetRefs;

        public override string ToString()
        {
            var info = "";
            for (var i = 0; i < TypesCount; i++)
            {
                var componentTypeInArchetype = Types[i];
                info += $"  - {componentTypeInArchetype}";
            }

            return info;
        }

        public ref UnsafePtrList ChunksWithEmptySlotsUnsafePtrList
        {
            get { return ref *(UnsafePtrList*)UnsafeUtility.AddressOf(ref ChunksWithEmptySlots); }
        }

        public void AddToChunkList(Chunk *chunk, SharedComponentValues sharedComponentIndices, uint changeVersion)
        {
            chunk->ListIndex = Chunks.Count;
            if (Chunks.Count == Chunks.Capacity)
            {
                int newCapacity = Chunks.Capacity == 0 ? 1 : Chunks.Capacity * 2;
                if (Chunks.data <= sharedComponentIndices.firstIndex &&
                    sharedComponentIndices.firstIndex < Chunks.data + Chunks.Count)
                {
                    int sourceChunk = (int)(sharedComponentIndices.firstIndex - Chunks.data);
                    // The shared component indices we are inserting belong to the same archetype so they need to be adjusted after reallocation
                    Chunks.Grow(newCapacity);
                    sharedComponentIndices = Chunks.GetSharedComponentValues(sourceChunk);
                }
                else
                    Chunks.Grow(newCapacity);
            }

            Chunks.Add(chunk, sharedComponentIndices);
        }

        public void RemoveFromChunkList(Chunk *chunk)
        {
            Chunks.RemoveAtSwapBack(chunk->ListIndex);
            var chunkThatMoved = Chunks.p[chunk->ListIndex];
            chunkThatMoved->ListIndex = chunk->ListIndex;
        }
        public void AddToChunkListWithEmptySlots(Chunk *chunk)
        {
            chunk->ListWithEmptySlotsIndex = ChunksWithEmptySlots.Count;
            ChunksWithEmptySlotsUnsafePtrList.Add(chunk);
        }
        public void RemoveFromChunkListWithEmptySlots(Chunk *chunk)
        {
            ChunksWithEmptySlotsUnsafePtrList.RemoveAtSwapBack(chunk->ListWithEmptySlotsIndex, chunk);
            if (chunk->ListWithEmptySlotsIndex < ChunksWithEmptySlots.Count)
            {
                var chunkThatMoved = ChunksWithEmptySlots.p[chunk->ListWithEmptySlotsIndex];
                chunkThatMoved->ListWithEmptySlotsIndex = chunk->ListWithEmptySlotsIndex;
            }
        }
        
        /// <summary>
        /// Remove chunk from archetype tracking of chunks with available slots.
        /// - Does not check if chunk has space.
        /// - Does not check if chunk is locked.
        /// </summary>
        /// <param name="chunk"></param>
        internal void EmptySlotTrackingRemoveChunk(Chunk* chunk)
        {
            if (NumSharedComponents == 0)
                RemoveFromChunkListWithEmptySlots(chunk);
            else
                FreeChunksBySharedComponents.Remove(chunk);
        }

        /// <summary>
        /// Add chunk to archetype tracking of chunks with available slots.
        /// - Does not check if chunk has space.
        /// - Does not check if chunk is locked.
        /// </summary>
        /// <param name="chunk"></param>
        internal void EmptySlotTrackingAddChunk(Chunk* chunk)
        {
            if (NumSharedComponents == 0)
                AddToChunkListWithEmptySlots(chunk);
            else
                FreeChunksBySharedComponents.Add(chunk);
        }

        internal Chunk* GetExistingChunkWithEmptySlots(SharedComponentValues sharedComponentValues)
        {
            if (NumSharedComponents == 0)
            {
                if (ChunksWithEmptySlots.Count != 0)
                {
                    var chunk = ChunksWithEmptySlots.p[0];
                    Assert.AreNotEqual(chunk->Count, chunk->Capacity);
                    return chunk;
                }
            }
            else
            {
                var chunk = FreeChunksBySharedComponents.TryGet(sharedComponentValues, NumSharedComponents);
                if (chunk != null)
                {
                    return chunk;
                }
            }

            return null;
        }

    }
}
