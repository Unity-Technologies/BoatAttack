using System;
using System.Reflection;

using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Scripting;

namespace Unity.Entities
{
    public static class EntityQueryExtensionsForComponentArray
    {
        public static T[] ToComponentArray<T>(this EntityQuery group) where T : Component
        {
            int length = group.CalculateLength();
            ComponentChunkIterator iterator = group.GetComponentChunkIterator();
            var indexInComponentGroup = group.GetIndexInEntityQuery(TypeManager.GetTypeIndex<T>());

            iterator.IndexInEntityQuery = indexInComponentGroup;

            var arr = new T[length];
            var cache = default(ComponentChunkCache);
            for (int i = 0; i < length; ++i)
            {
                if (i < cache.CachedBeginIndex || i >= cache.CachedEndIndex)
                    iterator.MoveToEntityIndexAndUpdateCache(i, out cache, true);

                arr[i] = (T)iterator.GetManagedObject(group.ManagedComponentStore, cache.CachedBeginIndex, i);
            }

            return arr;
        }
    }
}
