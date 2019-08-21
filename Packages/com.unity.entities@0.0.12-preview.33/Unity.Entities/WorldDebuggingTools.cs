#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;

namespace Unity.Entities
{
    internal class WorldDebuggingTools
    {
        internal static void MatchEntityInEntityQueries(World world, Entity entity,
            List<Tuple<ComponentSystemBase, List<EntityQuery>>> matchList)
        {
            using (var entityComponentTypes =
                world.EntityManager.GetComponentTypes(entity, Allocator.Temp))
            {
                foreach (var system in World.Active.Systems)
                {
                    var queryList = new List<EntityQuery>();
                    if (system == null) continue;
                    foreach (var query in system.EntityQueries)
                        if (Match(query, entityComponentTypes))
                            queryList.Add(query);

                    if (queryList.Count > 0)
                        matchList.Add(
                            new Tuple<ComponentSystemBase, List<EntityQuery>>(system, queryList));
                }
            }
        }

        private static bool Match(EntityQuery query, NativeArray<ComponentType> entityComponentTypes)
        {
            foreach (var groupType in query.GetQueryTypes().Skip(1))
            {
                var found = false;
                foreach (var type in entityComponentTypes)
                {
                    if (type.TypeIndex != groupType.TypeIndex)
                        continue;
                    found = true;
                    break;
                }

                if (found == (groupType.AccessModeType == ComponentType.AccessMode.Exclude))
                    return false;
            }

            return true;
        }
    }
}
#endif
