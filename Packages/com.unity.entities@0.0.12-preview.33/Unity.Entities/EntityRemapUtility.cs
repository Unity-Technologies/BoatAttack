using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using EntityOffsetInfo = Unity.Entities.TypeManager.EntityOffsetInfo;

namespace Unity.Entities
{
    public static unsafe class EntityRemapUtility
    {
        public struct EntityRemapInfo
        {
            public int SourceVersion;
            public Entity Target;
        }

        public struct SparseEntityRemapInfo
        {
            public Entity Src;
            public Entity Target;
        }

        public static void GetTargets(out NativeArray<Entity> output, NativeArray<EntityRemapInfo> remapping)
        {
            NativeArray<Entity> temp = new NativeArray<Entity>(remapping.Length, Allocator.TempJob);
            var outputs = 0;
            for (var i = 0; i < remapping.Length; ++i)
                if (remapping[i].Target != Entity.Null)
                    temp[outputs++] = remapping[i].Target;
            output = new NativeArray<Entity>(outputs, Allocator.Persistent);
            UnsafeUtility.MemCpy(output.GetUnsafePtr(), temp.GetUnsafePtr(), sizeof(Entity) * outputs);
            temp.Dispose();
        }

        public static void AddEntityRemapping(ref NativeArray<EntityRemapInfo> remapping, Entity source, Entity target)
        {
            remapping[source.Index] = new EntityRemapInfo { SourceVersion = source.Version, Target = target };
        }

        public static Entity RemapEntity(ref NativeArray<EntityRemapInfo> remapping, Entity source)
        {
            if (source.Version == remapping[source.Index].SourceVersion)
                return remapping[source.Index].Target;
            else
            {
                // When moving whole worlds, we do not allow any references that aren't in the new world
                // to avoid any kind of accidental references
                return Entity.Null;
            }
        }

        public static Entity RemapEntityForPrefab(SparseEntityRemapInfo* remapping, int remappingCount, Entity source)
        {
            // When instantiating prefabs,
            // internal references are remapped.
            for (int i = 0; i != remappingCount; i++)
            {
                if (source == remapping[i].Src)
                    return remapping[i].Target;
            }
            
            // And external references are kept.
            return source;
        }
        
        public struct EntityPatchInfo
        {
            public int Offset;
            public int Stride;
        }

        public struct BufferEntityPatchInfo
        {
            // Offset within chunk where first buffer header can be found
            public int BufferOffset;
            // Stride between adjacent buffers that need patching
            public int BufferStride;
            // Offset (from base pointer of array) where entities live
            public int ElementOffset;
            // Stride between adjacent buffer elements
            public int ElementStride;
        }

#if NET_DOTS
        // @TODO TINY -- Need to use UnsafeArray to provide a view of the data in sEntityOffsetArray in the static type manager
        public static EntityOffsetInfo[] CalculateEntityOffsets<T>()
        {
            return null;
        }
#else
        public static EntityOffsetInfo[] CalculateEntityOffsets<T>()
        {
            return CalculateEntityOffsets(typeof(T));
        }

        public static bool HasEntityMembers(Type type)
        {
            if (type == typeof(Entity))
                return true;

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var field in fields)
            {
                if (field.FieldType.IsValueType && !field.FieldType.IsPrimitive)
                {
                    if (HasEntityMembers(field.FieldType))
                        return true;
                }
            }

            return false;
        }

        public static EntityOffsetInfo[] CalculateEntityOffsets(Type type)
        {
            var offsets = new List<EntityOffsetInfo>();
            CalculateEntityOffsetsRecurse(ref offsets, type, 0);
            if (offsets.Count > 0)
                return offsets.ToArray();
            else
                return null;
        }

        static void CalculateEntityOffsetsRecurse(ref List<EntityOffsetInfo> offsets, Type type, int baseOffset)
        {
            if (type == typeof(Entity))
            {
                offsets.Add(new EntityOffsetInfo { Offset = baseOffset });
            }
            else
            {
                var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (var field in fields)
                {
                    if (field.FieldType.IsValueType && !field.FieldType.IsPrimitive)
                        CalculateEntityOffsetsRecurse(ref offsets, field.FieldType, baseOffset + UnsafeUtility.GetFieldOffset(field));
                }
            }
        }
#endif

        public static EntityPatchInfo* AppendEntityPatches(EntityPatchInfo* patches, EntityOffsetInfo* offsets, int offsetCount, int baseOffset, int stride)
        {
            if (offsets == null)
                return patches;

              for (int i = 0; i < offsetCount; i++)
                 patches[i] = new EntityPatchInfo { Offset = baseOffset + offsets[i].Offset, Stride = stride };
             return patches + offsetCount;
        }

        public static BufferEntityPatchInfo* AppendBufferEntityPatches(BufferEntityPatchInfo* patches, EntityOffsetInfo* offsets, int offsetCount, int bufferBaseOffset, int bufferStride, int elementStride)
        {
            if (offsets == null)
                return patches;

            for (int i = 0; i < offsetCount; i++)
            {
                patches[i] = new BufferEntityPatchInfo
                {
                    BufferOffset = bufferBaseOffset,
                    BufferStride = bufferStride,
                    ElementOffset = offsets[i].Offset,
                    ElementStride = elementStride,
                };
            }

            return patches + offsetCount;
        }

        public static void PatchEntities(EntityOffsetInfo[] scalarPatches, byte* data, ref NativeArray<EntityRemapInfo> remapping)
        {
            // Patch scalars (single components) with entity references.
            for (int i = 0; i < scalarPatches.Length; i++)
            {
                byte* entityData = data + scalarPatches[i].Offset;
                Entity* entity = (Entity*)entityData;
                *entity = RemapEntity(ref remapping, *entity);
            }
        }

        public static void PatchEntities(EntityPatchInfo* scalarPatches, int scalarPatchCount, BufferEntityPatchInfo* bufferPatches, int bufferPatchCount, byte* data, int entityCount, ref NativeArray<EntityRemapInfo> remapping)
        {
            // Patch scalars (single components) with entity references.
            for (int p = 0; p < scalarPatchCount; p++)
            {
                byte* entityData = data + scalarPatches[p].Offset;
                for (int i = 0; i != entityCount; i++)
                {
                    Entity* entity = (Entity*)entityData;
                    *entity = RemapEntity(ref remapping, *entity);
                    entityData += scalarPatches[p].Stride;
                }
            }

            // Patch buffers that contain entity references
            for (int p = 0; p < bufferPatchCount; ++p)
            {
                byte* bufferData = data + bufferPatches[p].BufferOffset;

                for (int i = 0; i != entityCount; ++i)
                {
                    BufferHeader* header = (BufferHeader*) bufferData;

                    byte* elemsBase = BufferHeader.GetElementPointer(header) + bufferPatches[p].ElementOffset;
                    int elemCount = header->Length;

                    for (int k = 0; k != elemCount; ++k)
                    {
                        Entity* entityPtr = (Entity*) elemsBase;
                        *entityPtr = RemapEntity(ref remapping, *entityPtr);
                        elemsBase += bufferPatches[p].ElementStride;
                    }

                    bufferData += bufferPatches[p].BufferStride;
                }
            }
        }
        
        public static void PatchEntitiesForPrefab(EntityPatchInfo* scalarPatches, int scalarPatchCount, BufferEntityPatchInfo* bufferPatches, int bufferPatchCount, byte* data, int indexInChunk, int entityCount, SparseEntityRemapInfo* remapping, int remappingCount)
        {
            // Patch scalars (single components) with entity references.
            for (int p = 0; p < scalarPatchCount; p++)
            {
                byte* entityData = data + scalarPatches[p].Offset;
                for (int e = 0; e != entityCount; e++)
                {
                    Entity* entity = (Entity*)(entityData + scalarPatches[p].Stride * (e + indexInChunk));
                    *entity = RemapEntityForPrefab(remapping + e * remappingCount, remappingCount, *entity);
                }
            }

            // Patch buffers that contain entity references
            for (int p = 0; p < bufferPatchCount; ++p)
            {
                byte* bufferData = data + bufferPatches[p].BufferOffset;

                for (int e = 0; e != entityCount; e++)
                {
                    BufferHeader* header = (BufferHeader*) (bufferData + bufferPatches[p].BufferStride * (e + indexInChunk));

                    byte* elemsBase = BufferHeader.GetElementPointer(header) + bufferPatches[p].ElementOffset;
                    int elemCount = header->Length;

                    for (int k = 0; k != elemCount; ++k)
                    {
                        Entity* entityPtr = (Entity*) elemsBase;
                        *entityPtr = RemapEntityForPrefab(remapping + e * remappingCount, remappingCount, *entityPtr);
                        elemsBase += bufferPatches[p].ElementStride;
                    }
                }
            }

        }
    }
}
