using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Unity.Entities
{
    public static class EntityManagerExtensions
    {
        static readonly List<ComponentDataProxyBase> s_ReusableComponentList = new List<ComponentDataProxyBase>(32);

        public static unsafe Entity Instantiate(this EntityManager entityManager, GameObject srcGameObject)
        {
            srcGameObject.GetComponents(s_ReusableComponentList);
            var count = s_ReusableComponentList.Count;
            ComponentType* componentTypes = stackalloc ComponentType[count];

            for (var t = 0; t != count; ++t)
                componentTypes[t] = s_ReusableComponentList[t].GetComponentType();

            var srcEntity = entityManager.CreateEntity(entityManager.CreateArchetype(componentTypes, count));
            for (var t = 0; t != count; ++t)
                s_ReusableComponentList[t].UpdateComponentData(entityManager, srcEntity);

            s_ReusableComponentList.Clear();

            return srcEntity;
        }

        public static unsafe void Instantiate(this EntityManager entityManager, GameObject srcGameObject, NativeArray<Entity> outputEntities)
        {
            if (outputEntities.Length == 0)
                return;

            var entity = entityManager.Instantiate(srcGameObject);
            outputEntities[0] = entity;

            var entityPtr = (Entity*)outputEntities.GetUnsafePtr();
            entityManager.InstantiateInternal(entity, entityPtr + 1, outputEntities.Length - 1);
        }

        public static unsafe T GetComponentObject<T>(this EntityManager entityManager, Entity entity) where T : Component
        {
            var componentType = ComponentType.ReadWrite<T>();
            entityManager.EntityComponentStore->AssertEntityHasComponent(entity, componentType.TypeIndex);

            Chunk* chunk;
            int chunkIndex;
            entityManager.EntityComponentStore->GetChunk(entity, out chunk, out chunkIndex);
            return entityManager.ManagedComponentStore.GetManagedObject(chunk, componentType, chunkIndex) as T;
        }
    }
}
