using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Unity.Assertions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Unity.Entities.Serialization
{
    public static class SerializeUtility
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct BufferPatchRecord
        {
            public int ChunkOffset;
            public int AllocSizeBytes;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct BlobAssetRefPatchRecord
        {
            public int ChunkOffset;
            public int BlobDataOffset;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SharedComponentRecord
        {
            public ulong StableTypeHash;
            public int HashCode;
            public int ComponentSize;
        }

        public static int CurrentFileFormatVersion = 19;

        public static unsafe void DeserializeWorld(ExclusiveEntityTransaction manager, BinaryReader reader, int numSharedComponents)
        {
            if (manager.EntityComponentStore->CountEntities() != 0)
            {
                throw new ArgumentException(
                    $"DeserializeWorld can only be used on completely empty EntityManager. Please create a new empty World and use EntityManager.MoveEntitiesFrom to move the loaded entities into the destination world instead.");
            }
            int storedVersion = reader.ReadInt();
            if (storedVersion != CurrentFileFormatVersion)
            {
                throw new ArgumentException(
                    $"Attempting to read a entity scene stored in an old file format version (stored version : {storedVersion}, current version : {CurrentFileFormatVersion})");
            }

            var types = ReadTypeArray(reader);
            int totalEntityCount;
            var archetypeChanges = manager.EntityComponentStore->BeginArchetypeChangeTracking();

            var archetypes = ReadArchetypes(reader, types, manager, out totalEntityCount);

            var changedArchetypes = manager.EntityComponentStore->EndArchetypeChangeTracking(archetypeChanges);
            manager.EntityGroupManager.AddAdditionalArchetypes(changedArchetypes);

            int sharedComponentArraysLength = reader.ReadInt();
            var sharedComponentArrays = new NativeArray<int>(sharedComponentArraysLength, Allocator.Temp);
            reader.ReadArray(sharedComponentArrays, sharedComponentArraysLength);

            manager.AllocateConsecutiveEntitiesForLoading(totalEntityCount);

            int totalChunkCount = reader.ReadInt();
            var chunksWithMetaChunkEntities = new NativeList<ArchetypeChunk>(totalChunkCount, Allocator.Temp);

            int totalBlobAssetSize = reader.ReadInt();
            byte* allBlobAssetData = null;

            NativeList<ArchetypeChunk> blobAssetRefChunks = new NativeList<ArchetypeChunk>();
            var blobAssetOwner = default(BlobAssetOwner);
            if (totalBlobAssetSize != 0)
            {
                allBlobAssetData = (byte*)UnsafeUtility.Malloc(totalBlobAssetSize, 16, Allocator.Persistent);
                reader.ReadBytes(allBlobAssetData, totalBlobAssetSize);
                blobAssetOwner = new BlobAssetOwner(allBlobAssetData, totalBlobAssetSize);
                blobAssetRefChunks = new NativeList<ArchetypeChunk>(32, Allocator.Temp);
                var end = allBlobAssetData + totalBlobAssetSize;
                var header = (BlobAssetHeader*)allBlobAssetData;
                while (header < end)
                {
                    header->ValidationPtr = header + 1;
                    header = (BlobAssetHeader*)OffsetFromPointer(header+1, header->Length);
                }
            }

            int sharedComponentArraysIndex = 0;
            for (int i = 0; i < totalChunkCount; ++i)
            {
                var chunk = (Chunk*) UnsafeUtility.Malloc(Chunk.kChunkSize, 64, Allocator.Persistent);
                reader.ReadBytes(chunk, Chunk.kChunkSize);

                var archetype = chunk->Archetype = archetypes[(int)chunk->Archetype].Archetype;
                var numSharedComponentsInArchetype = chunk->Archetype->NumSharedComponents;
                int* sharedComponentValueArray = (int*)sharedComponentArrays.GetUnsafePtr() + sharedComponentArraysIndex;

                for (int j = 0; j < numSharedComponentsInArchetype; ++j)
                {
                    // The shared component 0 is not part of the array, so an index equal to the array size is valid.
                    if (sharedComponentValueArray[j] > numSharedComponents)
                    {
                        throw new ArgumentException(
                            $"Archetype uses shared component at index {sharedComponentValueArray[j]} but only {numSharedComponents} are available, check if the shared scene has been properly loaded.");
                    }
                }

                var remapedSharedComponentValues = stackalloc int[archetype->NumSharedComponents];
                RemapSharedComponentIndices(remapedSharedComponentValues, archetype, sharedComponentValueArray);

                sharedComponentArraysIndex += numSharedComponentsInArchetype;

                // Allocate additional heap memory for buffers that have overflown into the heap, and read their data.
                int bufferAllocationCount = reader.ReadInt();
                if (bufferAllocationCount > 0)
                {
                    var bufferPatches = new NativeArray<BufferPatchRecord>(bufferAllocationCount, Allocator.Temp);
                    reader.ReadArray(bufferPatches, bufferPatches.Length);

                    // TODO: PERF: Batch malloc interface.
                    for (int pi = 0; pi < bufferAllocationCount; ++pi)
                    {
                        var target = (BufferHeader*)OffsetFromPointer(chunk->Buffer, bufferPatches[pi].ChunkOffset);

                        // TODO: Alignment
                        target->Pointer = (byte*) UnsafeUtility.Malloc(bufferPatches[pi].AllocSizeBytes, 8, Allocator.Persistent);

                        reader.ReadBytes(target->Pointer, bufferPatches[pi].AllocSizeBytes);
                    }

                    bufferPatches.Dispose();
                }

                if (totalBlobAssetSize != 0 && archetype->ContainsBlobAssetRefs)
                {
                    blobAssetRefChunks.Add(new ArchetypeChunk(chunk, manager.EntityComponentStore));
                    PatchBlobAssetsInChunkAfterLoad(chunk, allBlobAssetData);
                }
                
                EntityManagerMoveEntitiesUtility.AddExistingChunk(chunk, remapedSharedComponentValues,
                    manager.EntityComponentStore, manager.ManagedComponentStore);

                if (chunk->metaChunkEntity != Entity.Null)
                {
                    chunksWithMetaChunkEntities.Add(new ArchetypeChunk(chunk, manager.EntityComponentStore));
                }
            }
            
            if (totalBlobAssetSize != 0)
            {
                manager.AddSharedComponent(blobAssetRefChunks.AsArray(), blobAssetOwner);
                blobAssetRefChunks.Dispose();
            }

            for (int i = 0; i < chunksWithMetaChunkEntities.Length; ++i)
            {
                var chunk = chunksWithMetaChunkEntities[i].m_Chunk;
                manager.SetComponentData(chunk->metaChunkEntity, new ChunkHeader{ArchetypeChunk = chunksWithMetaChunkEntities[i]});
            }
            

            chunksWithMetaChunkEntities.Dispose();
            sharedComponentArrays.Dispose();
            archetypes.Dispose();
            types.Dispose();
        }

        private static unsafe NativeArray<EntityArchetype> ReadArchetypes(BinaryReader reader, NativeArray<int> types, ExclusiveEntityTransaction entityManager,
            out int totalEntityCount)
        {
            int archetypeCount = reader.ReadInt();
            var archetypes = new NativeArray<EntityArchetype>(archetypeCount, Allocator.Temp);
            totalEntityCount = 0;
            var tempComponentTypes = new NativeList<ComponentType>(Allocator.Temp);
            for (int i = 0; i < archetypeCount; ++i)
            {
                var archetypeEntityCount = reader.ReadInt();
                totalEntityCount += archetypeEntityCount;
                int archetypeComponentTypeCount = reader.ReadInt();
                tempComponentTypes.Clear();
                for (int iType = 0; iType < archetypeComponentTypeCount; ++iType)
                {
                    int typeHashIndexInFile = reader.ReadInt();
                    int typeHashIndexInFileNoFlags = typeHashIndexInFile & TypeManager.ClearFlagsMask;
                    int typeIndex = types[typeHashIndexInFileNoFlags];
                    if (TypeManager.IsChunkComponent(typeHashIndexInFile))
                        typeIndex = TypeManager.MakeChunkComponentTypeIndex(typeIndex);

                    tempComponentTypes.Add(ComponentType.FromTypeIndex(typeIndex));
                }

                archetypes[i] = entityManager.CreateArchetype((ComponentType*) tempComponentTypes.GetUnsafePtr(),
                    tempComponentTypes.Length);
            }

            tempComponentTypes.Dispose();
            return archetypes;
        }

        private static NativeArray<int> ReadTypeArray(BinaryReader reader)
        {
            int typeCount = reader.ReadInt();
            var typeHashBuffer = new NativeArray<ulong>(typeCount, Allocator.Temp);

            reader.ReadArray(typeHashBuffer, typeCount);

            var types = new NativeArray<int>(typeCount, Allocator.Temp);
            for (int i = 0; i < typeCount; ++i)
            {
                var typeIndex = TypeManager.GetTypeIndexFromStableTypeHash(typeHashBuffer[i]);
                if (typeIndex < 0)
                    throw new ArgumentException($"Cannot find TypeIndex for type hash '{typeHashBuffer[i]:X8}'. Ensure your runtime depends on all assemblies defining the Component types your data uses.");

                types[i] = typeIndex;
            }

            typeHashBuffer.Dispose();
            return types;
        }

        internal static unsafe void GetAllArchetypes(EntityComponentStore* entityComponentStore, out NativeHashMap<EntityArchetype, int> archetypeToIndex, out EntityArchetype[] archetypeArray)
        {
            var archetypeList = new List<EntityArchetype>();
            for (var i = entityComponentStore->m_Archetypes.Count - 1; i >= 0; --i)
            {
                var archetype = entityComponentStore->m_Archetypes.p[i];
                if (archetype->EntityCount >= 0)
                    archetypeList.Add(new EntityArchetype{Archetype = archetype});
            }
            //todo: sort archetypes to get deterministic indices
            archetypeToIndex = new NativeHashMap<EntityArchetype, int>(archetypeList.Count, Allocator.Temp);
            for (int i = 0; i < archetypeList.Count; ++i)
            {
                archetypeToIndex.TryAdd(archetypeList[i],i);
            }

            archetypeArray = archetypeList.ToArray();
        }

        private static void ValidateTypeForSerialization(TypeManager.TypeInfo typeInfo)
        {
            // Shared Components are expected to be handled specially and are not requiredto be blittable
            if (typeInfo.Category == TypeManager.TypeCategory.ISharedComponentData)
                return;

            if (!typeInfo.IsSerializable)
            {
                throw new ArgumentException($"Blittable component type '{typeInfo.Type}' contains a (potentially nested) pointer field. " +
                    $"Serializing bare pointers will likely lead to runtime errors. Remove this field and consider serializing the data " +
                    $"it points to another way such as by using a BlobAssetReference or a [Serializable] ISharedComponent. If for whatever " +
                    $"reason the pointer field should in fact be serialized, add the [ChunkSerializable] attribute to your type to bypass this error.");
            }
        }

        public static unsafe void SerializeWorld(EntityManager entityManager, BinaryWriter writer, out int[] sharedComponentsToSerialize)
        {
            var entityRemapInfos = new NativeArray<EntityRemapUtility.EntityRemapInfo>(entityManager.EntityCapacity, Allocator.Temp);
            SerializeWorld(entityManager, writer, out sharedComponentsToSerialize, entityRemapInfos);
            entityRemapInfos.Dispose();
        }

        public static unsafe void SerializeWorld(EntityManager entityManager, BinaryWriter writer, out int[] sharedComponentsToSerialize, NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapInfos)
        {
            writer.Write(CurrentFileFormatVersion);
            var entityComponentStore = entityManager.EntityComponentStore;

            NativeHashMap<EntityArchetype, int> archetypeToIndex;
            EntityArchetype[] archetypeArray;
            GetAllArchetypes(entityComponentStore, out archetypeToIndex, out archetypeArray);

            var typeHashes = new NativeHashMap<ulong, int>(1024, Allocator.Temp);
            foreach (var archetype in archetypeArray)
            {
                for (int iType = 0; iType < archetype.Archetype->TypesCount; ++iType)
                {
                    var typeIndex = archetype.Archetype->Types[iType].TypeIndex;
                    var typeInfo = TypeManager.GetTypeInfo(typeIndex);
                    var hash = typeInfo.StableTypeHash;
                    ValidateTypeForSerialization(typeInfo);
                    typeHashes.TryAdd(hash, 0);
                }
            }
            var typeHashSet = typeHashes.GetKeyArray(Allocator.Temp);

            writer.Write(typeHashSet.Length);
            foreach (ulong hash in typeHashSet)
            {
                writer.Write(hash);
            }

            var typeHashToIndexMap = new NativeHashMap<ulong, int>(typeHashSet.Length, Allocator.Temp);
            for (int i = 0; i < typeHashes.Length; ++i)
            {
                typeHashToIndexMap.TryAdd(typeHashSet[i], i);
            }

            WriteArchetypes(writer, archetypeArray, typeHashToIndexMap);
            var sharedComponentMapping = GatherSharedComponents(archetypeArray, out var sharedComponentArraysTotalCount);
            var sharedComponentArrays = new NativeArray<int>(sharedComponentArraysTotalCount, Allocator.Temp);
            FillSharedComponentArrays(sharedComponentArrays, archetypeArray, sharedComponentMapping);
            writer.Write(sharedComponentArrays.Length);
            writer.WriteArray(sharedComponentArrays);
            sharedComponentArrays.Dispose();

            //TODO: ensure chunks are defragged?

            var bufferPatches = new NativeList<BufferPatchRecord>(128, Allocator.Temp);
            var totalChunkCount = GenerateRemapInfo(entityManager, archetypeArray, entityRemapInfos);

            writer.Write(totalChunkCount);

            GatherAllUsedBlobAssets(archetypeArray, out var blobAssetRefs, out var blobAssets);

            var blobAssetOffsets = new NativeArray<int>(blobAssets.Length, Allocator.Temp);
            int totalBlobAssetSize = 0;

            int Align16(int x) => (x+15)&~15;

            for(int i = 0; i<blobAssets.Length; ++i)
            {
                totalBlobAssetSize += sizeof(BlobAssetHeader);
                blobAssetOffsets[i] = totalBlobAssetSize;
                totalBlobAssetSize += Align16(blobAssets[i].header->Length);
            }

            writer.Write(totalBlobAssetSize);

            var zeroBytes = int4.zero;
            for(int i = 0; i<blobAssets.Length; ++i)
            {
                var blobAssetLength = blobAssets[i].header->Length;
                BlobAssetHeader header = new BlobAssetHeader
                    {ValidationPtr = null, Allocator = Allocator.None, Length = Align16(blobAssetLength)};
                writer.WriteBytes(&header, sizeof(BlobAssetHeader));
                writer.WriteBytes(blobAssets[i].header + 1, blobAssetLength);
                writer.WriteBytes(&zeroBytes, header.Length - blobAssetLength);
            }

            var tempChunk = (Chunk*)UnsafeUtility.Malloc(Chunk.kChunkSize, 16, Allocator.Temp);

            for(int archetypeIndex = 0; archetypeIndex < archetypeArray.Length; ++archetypeIndex)
            {
                var archetype = archetypeArray[archetypeIndex].Archetype;
                for (var ci = 0; ci < archetype->Chunks.Count; ++ci)
                {
                    var chunk = archetype->Chunks.p[ci];
                    bufferPatches.Clear();

                    UnsafeUtility.MemCpy(tempChunk, chunk, Chunk.kChunkSize);
                    tempChunk->metaChunkEntity = EntityRemapUtility.RemapEntity(ref entityRemapInfos, tempChunk->metaChunkEntity);

                    // Prevent patching from touching buffers allocated memory
                    BufferHeader.PatchAfterCloningChunk(tempChunk);

                    byte* tempChunkBuffer = tempChunk->Buffer;
                    EntityRemapUtility.PatchEntities(archetype->ScalarEntityPatches, archetype->ScalarEntityPatchCount, archetype->BufferEntityPatches, archetype->BufferEntityPatchCount, tempChunkBuffer, tempChunk->Count, ref entityRemapInfos);
                    if(archetype->ContainsBlobAssetRefs)
                        PatchBlobAssetsInChunkBeforeSave(tempChunk, chunk, blobAssetOffsets, blobAssetRefs);

                    FillPatchRecordsForChunk(chunk, bufferPatches);

                    ClearChunkHeaderComponents(tempChunk);
                    ChunkDataUtility.MemsetUnusedChunkData(tempChunk, 0);
                    tempChunk->Archetype = (Archetype*) archetypeIndex;

                    if (archetype->NumManagedArrays != 0)
                    {
                        throw new ArgumentException("Serialization of GameObject components is not supported for pure entity scenes");
                    }

                    writer.WriteBytes(tempChunk, Chunk.kChunkSize);

                    writer.Write(bufferPatches.Length);

                    if (bufferPatches.Length > 0)
                    {
                        writer.WriteList(bufferPatches);

                        // Write heap backed data for each required patch.
                        // TODO: PERF: Investigate static-only deserialization could manage one block and mark in pointers somehow that they are not indiviual
                        for (int i = 0; i < bufferPatches.Length; ++i)
                        {
                            var patch = bufferPatches[i];
                            var header = (BufferHeader*)OffsetFromPointer(tempChunk->Buffer, patch.ChunkOffset);
                            writer.WriteBytes(header->Pointer, patch.AllocSizeBytes);
                            BufferHeader.Destroy(header);
                        }
                    }
                }
            }

            blobAssetRefs.Dispose();
            blobAssets.Dispose();

            bufferPatches.Dispose();
            UnsafeUtility.Free(tempChunk, Allocator.Temp);

            sharedComponentsToSerialize = new int[sharedComponentMapping.Length-1];

            using (var keyArray = sharedComponentMapping.GetKeyArray(Allocator.Temp))
            foreach (var key in keyArray)
            {
                if (key == 0)
                    continue;

                if (sharedComponentMapping.TryGetValue(key, out var val))
                    sharedComponentsToSerialize[val - 1] = key;
            }

            archetypeToIndex.Dispose();
            typeHashes.Dispose();
            typeHashSet.Dispose();
            typeHashToIndexMap.Dispose();
        }

#if !NET_DOTS
        public static unsafe void SerializeSharedComponents(EntityManager entityManager, BinaryWriter writer, in int[] sharedComponentsToSerialize)
        {
            writer.Write(CurrentFileFormatVersion);
            writer.Write(sharedComponentsToSerialize.Length);

            foreach (var i in sharedComponentsToSerialize)
            {
                object obj = entityManager.ManagedComponentStore.GetSharedComponentDataNonDefaultBoxed(i);

                Type type = obj.GetType();
                Assert.IsTrue(type.IsValueType, "Trying to serialize a non-value type SharedComponent is not supported");

                var typeIndex = TypeManager.GetTypeIndex(type);
                var typeInfo = TypeManager.GetTypeInfo(typeIndex);
                int hash = TypeManager.GetHashCode(obj, typeIndex);
                int size = UnsafeUtility.SizeOf(type);              

                var record = new SharedComponentRecord() { StableTypeHash = typeInfo.StableTypeHash, HashCode = hash, ComponentSize = size };
                writer.WriteBytes(&record, sizeof(SharedComponentRecord));

                var dataPtr = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out ulong handle);
                dataPtr += TypeManager.ObjectOffset;

                writer.WriteBytes(dataPtr, size);

                UnsafeUtility.ReleaseGCObject(handle);
            }
        }
#endif

        public static unsafe int DeserializeSharedComponents(EntityManager entityManager, BinaryReader reader)
        {
            int storedVersion = reader.ReadInt();
            if (storedVersion != CurrentFileFormatVersion)
            {
                throw new ArgumentException(
                    $"Attempting to read a entity scene stored in an old file format version (stored version : {storedVersion}, current version : {CurrentFileFormatVersion})");
            }

            int numSharedComponents = reader.ReadInt();

            for (int i = 0; i < numSharedComponents; ++i)
            {
                SharedComponentRecord record = new SharedComponentRecord();
                reader.ReadBytes(&record, sizeof(SharedComponentRecord));

                var buffer = new byte[record.ComponentSize];
                reader.ReadBytes(UnsafeUtility.AddressOf(ref buffer[0]), record.ComponentSize);

                var typeIndex = TypeManager.GetTypeIndexFromStableTypeHash(record.StableTypeHash);
                var data = TypeManager.ConstructComponentFromBuffer(typeIndex, UnsafeUtility.AddressOf(ref buffer[0]));

                // TODO: this recalculation should be removed once we merge the NET_DOTS and non NET_DOTS hashcode calculations
                var hashCode = TypeManager.GetHashCode(data, typeIndex); // record.hashCode;
                int index = entityManager.ManagedComponentStore.InsertSharedComponentAssumeNonDefault(typeIndex, hashCode, data);
                Assert.AreEqual(i + 1, index);
            }

            return numSharedComponents;
        }

        unsafe struct BlobAssetRefKey : IEquatable<BlobAssetRefKey>
        {
            public Chunk* chunk;
            public int offsetInBuffer;


            public bool Equals(BlobAssetRefKey other)
            {
                return chunk == other.chunk && offsetInBuffer == other.offsetInBuffer;
            }
        }

        unsafe struct BlobAssetPtr : IEquatable<BlobAssetPtr>
        {
            public BlobAssetPtr(BlobAssetHeader* header)
            {
                this.header = header;
            }
            public readonly BlobAssetHeader* header;
            public bool Equals(BlobAssetPtr other)
            {
                return header == other.header;
            }

            public override int GetHashCode()
            {
                BlobAssetHeader* onStack = header;
                return (int)math.hash(&onStack, sizeof(BlobAssetHeader*));
            }
        }

        private static unsafe void GatherAllUsedBlobAssets(EntityArchetype[] archetypeArray, out NativeHashMap<BlobAssetRefKey, int> blobAssetRefs, out NativeList<BlobAssetPtr> blobAssets)
        {
            var blobAssetMap = new NativeHashMap<BlobAssetPtr, int>(100, Allocator.Temp);

            blobAssetRefs = new NativeHashMap<BlobAssetRefKey, int>(100, Allocator.Temp);
            blobAssets = new NativeList<BlobAssetPtr>(100, Allocator.Temp);
            for (int archetypeIndex = 0; archetypeIndex < archetypeArray.Length; ++archetypeIndex)
            {
                var archetype = archetypeArray[archetypeIndex].Archetype;
                if (!archetype->ContainsBlobAssetRefs)
                    continue;

                var typeCount = archetype->TypesCount;
                for (var ci = 0; ci < archetype->Chunks.Count; ++ci)
                {
                    var chunk = archetype->Chunks.p[ci];
                    var entityCount = chunk->Count;
                    for (var unordered_ti = 0; unordered_ti < typeCount; ++unordered_ti)
                    {
                        var ti = archetype->TypeMemoryOrder[unordered_ti];
                        var type = archetype->Types[ti];
                        if(type.IsZeroSized)
                            continue;

                        var ct = TypeManager.GetTypeInfo(type.TypeIndex);
                        var blobAssetRefCount = ct.BlobAssetRefOffsetCount;
                        if(blobAssetRefCount == 0)
                            continue;

                        var chunkBuffer = chunk->Buffer;

                        if (type.IsBuffer)
                        {

                        }
                        else if (blobAssetRefCount > 0)
                        {
                            int subArrayOffset = archetype->Offsets[ti];
                            byte* componentArrayStart = OffsetFromPointer(chunkBuffer , subArrayOffset);
                            int size = archetype->SizeOfs[ti];
                            byte* end = componentArrayStart + size * entityCount;
                            for (var componentData = componentArrayStart; componentData < end; componentData += size)
                            {
                                for (int i = 0; i < blobAssetRefCount; ++i)
                                {
                                    var offset = ct.BlobAssetRefOffsets[i].Offset;
                                    var blobAssetRefPtr = (BlobAssetReferenceData*)(componentData + offset);
                                    if(blobAssetRefPtr->m_Ptr == null)
                                        continue;

                                    var blobAssetPtr = new BlobAssetPtr((*(BlobAssetHeader**)blobAssetRefPtr)-1);
                                    var key = new BlobAssetRefKey { chunk = chunk, offsetInBuffer = (int)((byte*)blobAssetRefPtr - chunkBuffer)};


                                    if (!blobAssetMap.TryGetValue(blobAssetPtr, out var blobAssetIndex))
                                    {
                                        blobAssetIndex = blobAssets.Length;
                                        blobAssets.Add(blobAssetPtr);
                                        blobAssetMap.TryAdd(blobAssetPtr, blobAssetIndex);
                                    }
                                    blobAssetRefs.TryAdd(key, blobAssetIndex);
                                }
                            }
                        }
                    }
                }
            }
            blobAssetMap.Dispose();
        }

        private static unsafe void PatchBlobAssetsInChunkBeforeSave(Chunk* tempChunk, Chunk* originalChunk,
            NativeArray<int> blobAssetOffsets, NativeHashMap<BlobAssetRefKey, int> blobAssetRefs)
        {
            var archetype = originalChunk->Archetype;
            var typeCount = archetype->TypesCount;
            var entityCount = originalChunk->Count;
            for (var unordered_ti = 0; unordered_ti < typeCount; ++unordered_ti)
            {
                var ti = archetype->TypeMemoryOrder[unordered_ti];
                var type = archetype->Types[ti];
                if(type.IsZeroSized)
                    continue;

                var ct = TypeManager.GetTypeInfo(type.TypeIndex);
                var blobAssetRefCount = ct.BlobAssetRefOffsetCount;
                if(blobAssetRefCount == 0)
                    continue;

                var chunkBuffer = tempChunk->Buffer;

                if (type.IsBuffer)
                {
                    throw new InvalidOperationException("BlobAssetReferences are not supported inside DynamicBuffer components");
                }
                else if (blobAssetRefCount > 0)
                {
                    int subArrayOffset = archetype->Offsets[ti];
                    byte* componentArrayStart = OffsetFromPointer(chunkBuffer , subArrayOffset);
                    int size = archetype->SizeOfs[ti];
                    byte* end = componentArrayStart + size * entityCount;
                    for (var componentData = componentArrayStart; componentData < end; componentData += size)
                    {
                        for (int i = 0; i < blobAssetRefCount; ++i)
                        {
                            var offset = ct.BlobAssetRefOffsets[i].Offset;
                            var blobAssetRefPtr = (BlobAssetReferenceData*)(componentData + offset);
                            int value = -1;
                            if (blobAssetRefPtr->m_Ptr != null)
                            {
                                var blobAssetPtr = new BlobAssetPtr((*(BlobAssetHeader**)blobAssetRefPtr)-1);
                                var key = new BlobAssetRefKey { chunk = originalChunk, offsetInBuffer = (int)((byte*)blobAssetRefPtr - chunkBuffer)};

                                bool found = blobAssetRefs.TryGetValue(key, out value);
                                value = blobAssetOffsets[value];
                                Assert.IsTrue(found);
                            }
                            blobAssetRefPtr->m_Ptr = (byte*)value;
                        }
                    }
                }
            }
        }

        private static unsafe void PatchBlobAssetsInChunkAfterLoad(Chunk* chunk, byte* allBlobAssetData)
        {
            var blobAssetMap = new NativeHashMap<BlobAssetPtr, int>(100, Allocator.Temp);

            var archetype = chunk->Archetype;
            var typeCount = archetype->TypesCount;
            var entityCount = chunk->Count;
            for (var unordered_ti = 0; unordered_ti < typeCount; ++unordered_ti)
            {
                var ti = archetype->TypeMemoryOrder[unordered_ti];
                var type = archetype->Types[ti];
                if(type.IsZeroSized)
                    continue;

                var ct = TypeManager.GetTypeInfo(type.TypeIndex);
                var blobAssetRefCount = ct.BlobAssetRefOffsetCount;
                if(blobAssetRefCount == 0)
                    continue;

                var chunkBuffer = chunk->Buffer;

                if (type.IsBuffer)
                {
                    throw new InvalidOperationException("BlobAssetReferences are not supported inside DynamicBuffer components");
                }
                else if (blobAssetRefCount > 0)
                {
                    int subArrayOffset = archetype->Offsets[ti];
                    byte* componentArrayStart = OffsetFromPointer(chunkBuffer , subArrayOffset);
                    int size = archetype->SizeOfs[ti];
                    byte* end = componentArrayStart + size * entityCount;
                    for (var componentData = componentArrayStart; componentData < end; componentData += size)
                    {
                        for (int i = 0; i < blobAssetRefCount; ++i)
                        {
                            var offset = ct.BlobAssetRefOffsets[i].Offset;
                            var blobAssetRefPtr = (BlobAssetReferenceData*)(componentData + offset);
                            int value = (int) blobAssetRefPtr->m_Ptr;
                            byte* ptr = null;
                            if (value != -1)
                            {
                                ptr = allBlobAssetData + value;
                            }
                            blobAssetRefPtr->m_Ptr = ptr;
                        }
                    }
                }
            }
        }

        private static unsafe void FillPatchRecordsForChunk(Chunk* chunk, NativeList<BufferPatchRecord> bufferPatches)
        {
            var archetype = chunk->Archetype;
            byte* tempChunkBuffer = chunk->Buffer;
            int entityCount = chunk->Count;

            // Find all buffer pointer locations and work out how much memory the deserializer must allocate on load.
            for (int ti = 0; ti < archetype->TypesCount; ++ti)
            {
                int index = archetype->TypeMemoryOrder[ti];
                var type = archetype->Types[index];
                if(type.IsZeroSized)
                    continue;

                if (type.IsBuffer)
                {
                    var ct = TypeManager.GetTypeInfo(type.TypeIndex);
                    int subArrayOffset = archetype->Offsets[index];
                    BufferHeader* header = (BufferHeader*) OffsetFromPointer(tempChunkBuffer, subArrayOffset);
                    int stride = archetype->SizeOfs[index];
                    var elementSize = ct.ElementSize;

                    for (int bi = 0; bi < entityCount; ++bi)
                    {
                        if (header->Pointer != null)
                        {
                            int capacityInBytes = elementSize * header->Capacity;
                            bufferPatches.Add(new BufferPatchRecord
                            {
                                ChunkOffset = (int) (((byte*) header) - tempChunkBuffer),
                                AllocSizeBytes = capacityInBytes
                            });
                        }

                        header = (BufferHeader*) OffsetFromPointer(header, stride);
                    }
                }
            }
        }

        static unsafe void FillSharedComponentIndexRemap(int* remapArray, Archetype* archetype)
        {
            int i = 0;
            for (int iType = 1; iType < archetype->TypesCount; ++iType)
            {
                int orderedIndex = archetype->TypeMemoryOrder[iType] - archetype->FirstSharedComponent;
                if (0 <= orderedIndex && orderedIndex < archetype->NumSharedComponents)
                    remapArray[i++] = orderedIndex;
            }
        }

        static unsafe void RemapSharedComponentIndices(int* destValues, Archetype* archetype, int* sourceValues)
        {
            int i = 0;
            for (int iType = 1; iType < archetype->TypesCount; ++iType)
            {
                int orderedIndex = archetype->TypeMemoryOrder[iType] - archetype->FirstSharedComponent;
                if (0 <= orderedIndex && orderedIndex < archetype->NumSharedComponents)
                    destValues[orderedIndex] = sourceValues[i++];
            }
        }

        private static unsafe void FillSharedComponentArrays(NativeArray<int> sharedComponentArrays, EntityArchetype[] archetypeArray, NativeHashMap<int, int> sharedComponentMapping)
        {
            int index = 0;
            for (int iArchetype = 0; iArchetype < archetypeArray.Length; ++iArchetype)
            {
                var archetype = archetypeArray[iArchetype].Archetype;
                int numSharedComponents = archetype->NumSharedComponents;
                if(numSharedComponents==0)
                    continue;
                var sharedComponentIndexRemap = stackalloc int[numSharedComponents];
                FillSharedComponentIndexRemap(sharedComponentIndexRemap, archetype);
                for (int iChunk = 0; iChunk < archetype->Chunks.Count; ++iChunk)
                {
                    var sharedComponents = archetype->Chunks.p[iChunk]->SharedComponentValues;
                    for (int iType = 0; iType < numSharedComponents; iType++)
                    {
                        int remappedIndex = sharedComponentIndexRemap[iType];
                        sharedComponentArrays[index++] = sharedComponentMapping[sharedComponents[remappedIndex]];
                    }
                }
            }
            Assert.AreEqual(sharedComponentArrays.Length,index);
        }

        private static unsafe NativeHashMap<int, int> GatherSharedComponents(EntityArchetype[] archetypeArray, out int sharedComponentArraysTotalCount)
        {
            sharedComponentArraysTotalCount = 0;
            var sharedIndexToSerialize = new NativeHashMap<int, int>(1024, Allocator.Temp);
            sharedIndexToSerialize.TryAdd(0, 0); // All default values map to 0
            int nextIndex = 1;
            for (int iArchetype = 0; iArchetype < archetypeArray.Length; ++iArchetype)
            {
                var archetype = archetypeArray[iArchetype].Archetype;
                sharedComponentArraysTotalCount += archetype->Chunks.Count * archetype->NumSharedComponents;

                int numSharedComponents = archetype->NumSharedComponents;
                for (int iType = 0; iType < numSharedComponents; iType++)
                {
                    var sharedComponents = archetype->Chunks.GetSharedComponentValueArrayForType(iType);
                    for (int iChunk = 0; iChunk < archetype->Chunks.Count; ++iChunk)
                    {
                        int sharedComponentIndex = sharedComponents[iChunk];
                        if (!sharedIndexToSerialize.TryGetValue(sharedComponentIndex, out var val))
                        {
                            sharedIndexToSerialize.TryAdd(sharedComponentIndex, nextIndex++);
                        }
                    }
                }
            }

            return sharedIndexToSerialize;
        }

        private static unsafe void ClearChunkHeaderComponents(Chunk* chunk)
        {
            int chunkHeaderTypeIndex = TypeManager.GetTypeIndex<ChunkHeader>();
            var archetype = chunk->Archetype;
            var typeIndexInArchetype = ChunkDataUtility.GetIndexInTypeArray(chunk->Archetype, chunkHeaderTypeIndex);
            if (typeIndexInArchetype == -1)
                return;

            var buffer = chunk->Buffer;
            var length = chunk->Count;
            var startOffset = archetype->Offsets[typeIndexInArchetype];
            var chunkHeaders = (ChunkHeader*)(buffer + startOffset);
            for (int i = 0; i < length; ++i)
            {
                chunkHeaders[i] = ChunkHeader.Null;
            }
        }

        static unsafe byte* OffsetFromPointer(void* ptr, int offset)
        {
            return ((byte*)ptr) + offset;
        }

        static unsafe void WriteArchetypes(BinaryWriter writer, EntityArchetype[] archetypeArray, NativeHashMap<ulong, int> typeHashToIndexMap)
        {
            writer.Write(archetypeArray.Length);

            foreach (var archetype in archetypeArray)
            {
                writer.Write(archetype.Archetype->EntityCount);
                writer.Write(archetype.Archetype->TypesCount - 1);
                for (int i = 1; i < archetype.Archetype->TypesCount; ++i)
                {
                    var componentType = archetype.Archetype->Types[i];
                    int flag = componentType.IsChunkComponent ? TypeManager.ChunkComponentTypeFlag : 0;
                    var hash = TypeManager.GetTypeInfo(componentType.TypeIndex).StableTypeHash;
                    writer.Write(typeHashToIndexMap[hash] | flag);
                }
            }
        }

        static unsafe int GenerateRemapInfo(EntityManager entityManager, EntityArchetype[] archetypeArray, NativeArray<EntityRemapUtility.EntityRemapInfo> entityRemapInfos)
        {
            int nextEntityId = 1; //0 is reserved for Entity.Null;

            int totalChunkCount = 0;
            for (int archetypeIndex = 0; archetypeIndex < archetypeArray.Length; ++archetypeIndex)
            {
                var archetype = archetypeArray[archetypeIndex].Archetype;
                for (int i = 0; i < archetype->Chunks.Count; ++i)
                {
                    var chunk = archetype->Chunks.p[i];
                    for (int iEntity = 0; iEntity < chunk->Count; ++iEntity)
                    {
                        var entity = *(Entity*)ChunkDataUtility.GetComponentDataRO(chunk, iEntity, 0);
                        EntityRemapUtility.AddEntityRemapping(ref entityRemapInfos, entity, new Entity { Version = 0, Index = nextEntityId });
                        ++nextEntityId;
                    }

                    totalChunkCount += 1;
                }
            }

            return totalChunkCount;
        }
    }
}
