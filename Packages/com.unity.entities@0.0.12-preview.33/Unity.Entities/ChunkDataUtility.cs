using System;
using System.Diagnostics;
using Unity.Assertions;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
    internal static unsafe class ChunkDataUtility
    {
        public static int GetIndexInTypeArray(Archetype* archetype, int typeIndex)
        {
            var types = archetype->Types;
            var typeCount = archetype->TypesCount;
            for (var i = 0; i != typeCount; i++)
                if (typeIndex == types[i].TypeIndex)
                    return i;

            return -1;
        }
        public static int GetTypeIndexFromType(Archetype* archetype, Type componentType)
        {
            var types = archetype->Types;
            var typeCount = archetype->TypesCount;
            for (var i = 0; i != typeCount; i++)
                if (componentType.IsAssignableFrom(TypeManager.GetType(types[i].TypeIndex)))
                    return types[i].TypeIndex;

            return -1;
        }


        public static void GetIndexInTypeArray(Archetype* archetype, int typeIndex, ref int typeLookupCache)
        {
            var types = archetype->Types;
            var typeCount = archetype->TypesCount;

            if (typeLookupCache < typeCount && types[typeLookupCache].TypeIndex == typeIndex)
                return;

            for (var i = 0; i != typeCount; i++)
            {
                if (typeIndex != types[i].TypeIndex)
                    continue;

                typeLookupCache = i;
                return;
            }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            throw new InvalidOperationException("Shouldn't happen");
#endif
        }

        public static int GetSizeInChunk(Chunk* chunk, int typeIndex, ref int typeLookupCache)
        {
            var archetype = chunk->Archetype;
            GetIndexInTypeArray(archetype, typeIndex, ref typeLookupCache);
            var indexInTypeArray = typeLookupCache;

            var sizeOf = archetype->SizeOfs[indexInTypeArray];

            return sizeOf;
        }

        public static byte* GetComponentDataWithTypeRO(Chunk* chunk, int index, int typeIndex, ref int typeLookupCache)
        {
            var archetype = chunk->Archetype;
            GetIndexInTypeArray(archetype, typeIndex, ref typeLookupCache);
            var indexInTypeArray = typeLookupCache;

            var offset = archetype->Offsets[indexInTypeArray];
            var sizeOf = archetype->SizeOfs[indexInTypeArray];

            return chunk->Buffer + (offset + sizeOf * index);
        }

        public static byte* GetComponentDataWithTypeRW(Chunk* chunk, int index, int typeIndex, uint globalSystemVersion,
            ref int typeLookupCache)
        {
            var archetype = chunk->Archetype;
            GetIndexInTypeArray(archetype, typeIndex, ref typeLookupCache);
            var indexInTypeArray = typeLookupCache;

            var offset = archetype->Offsets[indexInTypeArray];
            var sizeOf = archetype->SizeOfs[indexInTypeArray];

            chunk->SetChangeVersion(indexInTypeArray, globalSystemVersion);

            return chunk->Buffer + (offset + sizeOf * index);
        }

        public static byte* GetComponentDataWithTypeRO(Chunk* chunk, int index, int typeIndex)
        {
            var indexInTypeArray = GetIndexInTypeArray(chunk->Archetype, typeIndex);

            var offset = chunk->Archetype->Offsets[indexInTypeArray];
            var sizeOf = chunk->Archetype->SizeOfs[indexInTypeArray];

            return chunk->Buffer + (offset + sizeOf * index);
        }

        public static byte* GetComponentDataWithTypeRW(Chunk* chunk, int index, int typeIndex, uint globalSystemVersion)
        {
            var indexInTypeArray = GetIndexInTypeArray(chunk->Archetype, typeIndex);

            var offset = chunk->Archetype->Offsets[indexInTypeArray];
            var sizeOf = chunk->Archetype->SizeOfs[indexInTypeArray];

            chunk->SetChangeVersion(indexInTypeArray, globalSystemVersion);

            return chunk->Buffer + (offset + sizeOf * index);
        }

        public static byte* GetComponentDataRO(Chunk* chunk, int index, int indexInTypeArray)
        {
            var offset = chunk->Archetype->Offsets[indexInTypeArray];
            var sizeOf = chunk->Archetype->SizeOfs[indexInTypeArray];

            return chunk->Buffer + (offset + sizeOf * index);
        }

        public static byte* GetComponentDataRW(Chunk* chunk, int index, int indexInTypeArray, uint globalSystemVersion)
        {
            var offset = chunk->Archetype->Offsets[indexInTypeArray];
            var sizeOf = chunk->Archetype->SizeOfs[indexInTypeArray];

            chunk->SetChangeVersion(indexInTypeArray, globalSystemVersion);

            return chunk->Buffer + (offset + sizeOf * index);
        }

        public static void Copy(Chunk* srcChunk, int srcIndex, Chunk* dstChunk, int dstIndex, int count)
        {
            Assert.IsTrue(srcChunk->Archetype == dstChunk->Archetype);

            var arch = srcChunk->Archetype;
            var srcBuffer = srcChunk->Buffer;
            var dstBuffer = dstChunk->Buffer;
            var offsets = arch->Offsets;
            var sizeOfs = arch->SizeOfs;
            var typesCount = arch->TypesCount;

            for (var t = 0; t < typesCount; t++)
            {
                var offset = offsets[t];
                var sizeOf = sizeOfs[t];
                var src = srcBuffer + (offset + sizeOf * srcIndex);
                var dst = dstBuffer + (offset + sizeOf * dstIndex);

                UnsafeUtility.MemCpy(dst, src, sizeOf * count);
            }
        }

        public static void SwapComponents(Chunk* srcChunk, int srcIndex, Chunk* dstChunk, int dstIndex, int count, uint srcGlobalSystemVersion, uint dstGlobalSystemVersion)
        {
            var srcArch = srcChunk->Archetype;
            var typesCount = srcArch->TypesCount;


#if UNITY_ASSERTIONS
            // This function is used to swap data between different world so assert that the layout is identical if
            // the archetypes dont match
            var dstArch = dstChunk->Archetype;
            if (srcArch != dstArch)
            {
                Assert.AreEqual(typesCount, dstChunk->Archetype->TypesCount);
                for (int i = 0; i < typesCount; ++i)
                {
                    Assert.AreEqual(srcArch->Types[i], dstArch->Types[i]);
                    Assert.AreEqual(srcArch->Offsets[i], dstArch->Offsets[i]);
                    Assert.AreEqual(srcArch->SizeOfs[i], dstArch->SizeOfs[i]);
                }
            }
#endif

            var srcBuffer = srcChunk->Buffer;
            var dstBuffer = dstChunk->Buffer;
            var offsets = srcArch->Offsets;
            var sizeOfs = srcArch->SizeOfs;

            for (var t = 1; t < typesCount; t++) // Only swap component data, not Entity
            {
                var offset = offsets[t];
                var sizeOf = sizeOfs[t];
                var src = srcBuffer + (offset + sizeOf * srcIndex);
                var dst = dstBuffer + (offset + sizeOf * dstIndex);
                Byte* buffer = stackalloc Byte[sizeOf * count];

                dstChunk->SetChangeVersion(t, dstGlobalSystemVersion);
                srcChunk->SetChangeVersion(t, srcGlobalSystemVersion);

                UnsafeUtility.MemCpy(buffer, src, sizeOf * count);
                UnsafeUtility.MemCpy(src, dst, sizeOf * count);
                UnsafeUtility.MemCpy(dst, buffer, sizeOf * count);
            }
        }

        public static void InitializeComponents(Chunk* dstChunk, int dstIndex, int count)
        {
            var arch = dstChunk->Archetype;

            var offsets = arch->Offsets;
            var sizeOfs = arch->SizeOfs;
            var bufferCapacities = arch->BufferCapacities;
            var dstBuffer = dstChunk->Buffer;
            var typesCount = arch->TypesCount;
            var types = arch->Types;

            for (var t = 1; t != typesCount; t++)
            {
                var offset = offsets[t];
                var sizeOf = sizeOfs[t];
                var dst = dstBuffer + (offset + sizeOf * dstIndex);

                if (types[t].IsBuffer)
                {
                    for (var i = 0; i < count; ++i)
                    {
                        BufferHeader.Initialize((BufferHeader*)dst, bufferCapacities[t]);
                        dst += sizeOf;
                    }
                }
                else
                {
                    UnsafeUtility.MemClear(dst, sizeOf * count);
                }
            }
        }

        public static void ReplicateComponents(Chunk* srcChunk, int srcIndex, Chunk* dstChunk, int dstBaseIndex, int count)
        {
            var srcArchetype        = srcChunk->Archetype;
            var srcBuffer           = srcChunk->Buffer;
            var dstBuffer           = dstChunk->Buffer;
            var dstArchetype        = dstChunk->Archetype;
            var srcOffsets          = srcArchetype->Offsets;
            var srcSizeOfs          = srcArchetype->SizeOfs;
            var srcBufferCapacities = srcArchetype->BufferCapacities;
            var srcTypesCount       = srcArchetype->TypesCount;
            var srcTypes            = srcArchetype->Types;
            var dstTypes            = dstArchetype->Types;
            var dstOffsets          = dstArchetype->Offsets;
            var dstTypeIndex        = 1;
            // type[0] is always Entity, and will be patched up later, so just skip
            for (var srcTypeIndex = 1; srcTypeIndex != srcTypesCount; srcTypeIndex++)
            {
                var srcType   = srcTypes[srcTypeIndex];
                var dstType   = dstTypes[dstTypeIndex];

                // Type does not exist in destination. Skip it.
                if (srcType.TypeIndex != dstType.TypeIndex)
                    continue;

                var srcOffset = srcOffsets[srcTypeIndex];
                var srcSizeOf = srcSizeOfs[srcTypeIndex];

                var dstOffset = dstOffsets[dstTypeIndex];

                var src = srcBuffer + (srcOffset + srcSizeOf * srcIndex);
                var dst = dstBuffer + (dstOffset + srcSizeOf * dstBaseIndex);

                if (!srcType.IsBuffer)
                {
                    UnsafeUtility.MemCpyReplicate(dst, src, srcSizeOf, count);
                }
                else
                {
                    var srcBufferCapacity = srcBufferCapacities[srcTypeIndex];
                    var alignment = 8; // TODO: Need a way to compute proper alignment for arbitrary non-generic types in TypeManager
                    var elementSize = TypeManager.GetTypeInfo(srcType.TypeIndex).ElementSize;
                    for (int i = 0; i < count; ++i)
                    {
                        BufferHeader* srcHdr = (BufferHeader*) src;
                        BufferHeader* dstHdr = (BufferHeader*) dst;
                        BufferHeader.Initialize(dstHdr, srcBufferCapacity);
                        BufferHeader.Assign(dstHdr, BufferHeader.GetElementPointer(srcHdr), srcHdr->Length, elementSize, alignment);

                        dst += srcSizeOf;
                    }
                }

                dstTypeIndex++;
            }
        }

        public static void Convert(Chunk* srcChunk, int srcIndex, Chunk* dstChunk, int dstIndex, int count)
        {
            var srcArch = srcChunk->Archetype;
            var dstArch = dstChunk->Archetype;

            //Debug.Log($"Convert {EntityManager.EntityManagerDebug.GetArchetypeDebugString(srcArch)} to {EntityManager.EntityManagerDebug.GetArchetypeDebugString(dstArch)}");

            var srcI = 0;
            var dstI = 0;
            while (srcI < srcArch->NonZeroSizedTypesCount && dstI < dstArch->NonZeroSizedTypesCount)
            {
                var srcStride = srcArch->SizeOfs[srcI];
                var dstStride = dstArch->SizeOfs[dstI];
                var src = srcChunk->Buffer + srcArch->Offsets[srcI] + srcIndex * srcStride;
                var dst = dstChunk->Buffer + dstArch->Offsets[dstI] + dstIndex * dstStride;

                if (srcArch->Types[srcI] < dstArch->Types[dstI])
                {
                    // Clear any buffers we're not going to keep.
                    if (srcArch->Types[srcI].IsBuffer)
                    {
                        var srcPtr = src;
                        for(int i = 0; i < count; i++)
                        {
                            BufferHeader.Destroy((BufferHeader*)srcPtr);
                            srcPtr += srcStride;
                        }
                    }

                    ++srcI;
                }
                else if (srcArch->Types[srcI] > dstArch->Types[dstI])
                {
                    // Clear components in the destination that aren't copied

                    if (dstArch->Types[dstI].IsBuffer)
                    {
                        var bufferCapacity = dstArch->BufferCapacities[dstI];
                        var dstPtr = dst;
                        for(int i = 0; i < count; i++)
                        {
                            BufferHeader.Initialize((BufferHeader*)dstPtr, bufferCapacity);
                            dstPtr += dstStride;
                        }

                    }
                    else
                    {
                        UnsafeUtility.MemClear(dst, count * dstStride);
                    }

                    ++dstI;
                }
                else
                {
                    UnsafeUtility.MemCpy(dst, src, count * srcStride);

                    // Poison source buffer to make sure there is no aliasing.
                    if (srcArch->Types[srcI].IsBuffer)
                    {
                        var bufferCapacity = srcArch->BufferCapacities[srcI];
                        var srcPtr = src;
                        for(int i = 0; i < count; i++)
                        {
                            BufferHeader.Initialize((BufferHeader*)srcPtr, bufferCapacity);
                            srcPtr += srcStride;
                        }
                    }

                    ++srcI;
                    ++dstI;
                }
            }

            // Handle remaining components in the source that aren't copied
            for (; srcI < srcArch->NonZeroSizedTypesCount; ++srcI)
            {
                var srcStride = srcArch->SizeOfs[srcI];
                var src = srcChunk->Buffer + srcArch->Offsets[srcI] + srcIndex * srcStride;
                if (srcArch->Types[srcI].IsBuffer)
                {
                    var srcPtr = src;
                    for(int i = 0; i < count; i++)
                    {
                        BufferHeader.Destroy((BufferHeader*)srcPtr);
                        srcPtr += srcStride;
                    }
                }
            }

            // Clear remaining components in the destination that aren't copied
            for (; dstI < dstArch->NonZeroSizedTypesCount; ++dstI)
            {
                var dstStride = dstArch->SizeOfs[dstI];
                var dst = dstChunk->Buffer + dstArch->Offsets[dstI] + dstIndex * dstStride;
                if (dstArch->Types[dstI].IsBuffer)
                {
                    var bufferCapacity = dstArch->BufferCapacities[dstI];
                    var dstPtr = dst;
                    for (int i = 0; i < count; i++)
                    {
                        BufferHeader.Initialize((BufferHeader*)dstPtr, bufferCapacity);
                        dstPtr += dstStride;
                    }
                }
                else
                {
                    UnsafeUtility.MemClear(dst, count * dstStride);
                }
            }
        }

        public static void Convert(Chunk* srcChunk, int srcIndex, Chunk* dstChunk, int dstIndex)
        {
            var srcArch = srcChunk->Archetype;
            var dstArch = dstChunk->Archetype;

            //Debug.Log($"Convert {EntityManager.EntityManagerDebug.GetArchetypeDebugString(srcArch)} to {EntityManager.EntityManagerDebug.GetArchetypeDebugString(dstArch)}");

            var srcI = 0;
            var dstI = 0;
            while (srcI < srcArch->TypesCount && dstI < dstArch->TypesCount)
            {
                var src = srcChunk->Buffer + srcArch->Offsets[srcI] + srcIndex * srcArch->SizeOfs[srcI];
                var dst = dstChunk->Buffer + dstArch->Offsets[dstI] + dstIndex * dstArch->SizeOfs[dstI];

                if (srcArch->Types[srcI] < dstArch->Types[dstI])
                {
                    // Clear any buffers we're not going to keep.
                    if (srcArch->Types[srcI].IsBuffer)
                    {
                        BufferHeader.Destroy((BufferHeader*)src);
                    }

                    ++srcI;
                }
                else if (srcArch->Types[srcI] > dstArch->Types[dstI])
                {
                    // Clear components in the destination that aren't copied

                    if (dstArch->Types[dstI].IsBuffer)
                    {
                        BufferHeader.Initialize((BufferHeader*)dst, dstArch->BufferCapacities[dstI]);
                    }
                    else
                    {
                        UnsafeUtility.MemClear(dst, dstArch->SizeOfs[dstI]);
                    }

                    ++dstI;
                }
                else
                {
                    UnsafeUtility.MemCpy(dst, src, srcArch->SizeOfs[srcI]);

                    // Poison source buffer to make sure there is no aliasing.
                    if (srcArch->Types[srcI].IsBuffer)
                    {
                        BufferHeader.Initialize((BufferHeader*)src, srcArch->BufferCapacities[srcI]);
                    }

                    ++srcI;
                    ++dstI;
                }
            }

            // Handle remaining components in the source that aren't copied
            for (; srcI < srcArch->TypesCount; ++srcI)
            {
                var src = srcChunk->Buffer + srcArch->Offsets[srcI] + srcIndex * srcArch->SizeOfs[srcI];
                if (srcArch->Types[srcI].IsBuffer)
                {
                    BufferHeader.Destroy((BufferHeader*)src);
                }
            }

            // Clear remaining components in the destination that aren't copied
            for (; dstI < dstArch->TypesCount; ++dstI)
            {
                var dst = dstChunk->Buffer + dstArch->Offsets[dstI] + dstIndex * dstArch->SizeOfs[dstI];
                if (dstArch->Types[dstI].IsBuffer)
                {
                    BufferHeader.Initialize((BufferHeader*)dst, dstArch->BufferCapacities[dstI]);
                }
                else
                {
                    UnsafeUtility.MemClear(dst, dstArch->SizeOfs[dstI]);
                }
            }
        }

        public static void MemsetUnusedChunkData(Chunk* chunk, byte value)
        {
            var arch = chunk->Archetype;
            var bufferSize = Chunk.GetChunkBufferSize();
            var buffer = chunk->Buffer;
            var count = chunk->Count;

            for (int i = 0; i<arch->TypesCount-1; ++i)
            {
                var index = arch->TypeMemoryOrder[i];
                var nextIndex = arch->TypeMemoryOrder[i + 1];
                var startOffset = arch->Offsets[index] + count * arch->SizeOfs[index];
                var endOffset = arch->Offsets[nextIndex];
                UnsafeUtilityEx.MemSet(buffer + startOffset, value, endOffset - startOffset);
            }
            var lastIndex = arch->TypeMemoryOrder[arch->TypesCount - 1];
            var lastStartOffset = arch->Offsets[lastIndex] + count * arch->SizeOfs[lastIndex];
            UnsafeUtilityEx.MemSet(buffer + lastStartOffset, value, bufferSize - lastStartOffset);
        }

        public static bool AreLayoutCompatible(Archetype* a, Archetype* b)
        {
            if ((a == null) || (b == null))
                return false;

            var typeCount = a->NonZeroSizedTypesCount;
            if (typeCount != b->NonZeroSizedTypesCount)
                return false;

            for (int i = 0; i < typeCount; ++i)
            {
                if (a->Types[i] != b->Types[i])
                    return false;
            }

            return true;
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        public static void AssertAreLayoutCompatible(Archetype* a, Archetype* b)
        {
            Assert.IsTrue(AreLayoutCompatible(a,b));
            Assert.AreEqual(a->BytesPerInstance, b->BytesPerInstance);
            Assert.AreEqual(a->ChunkCapacity, b->ChunkCapacity);

            var typeCount = a->NonZeroSizedTypesCount;

            //If types are identical; SizeOfs, Offsets and BufferCapacities should match
            for (int i = 0; i < typeCount; ++i)
            {
                Assert.AreEqual(a->SizeOfs[i], b->SizeOfs[i]);
                Assert.AreEqual(a->Offsets[i], b->Offsets[i]);
                Assert.AreEqual(a->BufferCapacities[i], b->BufferCapacities[i]);
            }
        }
        
        public static void DeallocateBuffers(Chunk* chunk)
        {
            var archetype = chunk->Archetype;

            for (var ti = 0; ti < archetype->TypesCount; ++ti)
            {
                var type = archetype->Types[ti];

                if (!type.IsBuffer)
                    continue;

                var basePtr = chunk->Buffer + archetype->Offsets[ti];
                var stride = archetype->SizeOfs[ti];

                for (int i = 0; i < chunk->Count; ++i)
                {
                    byte* bufferPtr = basePtr + stride * i;
                    BufferHeader.Destroy((BufferHeader*) bufferPtr);
                }
            }
        }
    }
}
