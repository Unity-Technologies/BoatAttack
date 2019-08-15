using System;
using System.Linq;
using System.Reflection;

using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.Scripting;

namespace Unity.Entities
{
    struct TransformAccessArrayState : IDisposable
    {
        public TransformAccessArray Data;
        public int OrderVersion;

        public void Dispose()
        {
            if (Data.isCreated)
                Data.Dispose();
        }
    }

    public static class EntityQueryExtensionsForTransformAccessArray
    {
        public static unsafe TransformAccessArray GetTransformAccessArray(this EntityQuery group)
        {
            var state = (TransformAccessArrayState?)group.m_CachedState ?? new TransformAccessArrayState();
            var orderVersion = group.EntityComponentStore->GetComponentTypeOrderVersion(TypeManager.GetTypeIndex<Transform>());

            if (state.Data.isCreated && orderVersion == state.OrderVersion)
                return state.Data;

            state.OrderVersion = orderVersion;

            UnityEngine.Profiling.Profiler.BeginSample("DirtyTransformAccessArrayUpdate");
            var trans = group.ToComponentArray<Transform>();
            if (!state.Data.isCreated)
                state.Data = new TransformAccessArray(trans);
            else
                state.Data.SetTransforms(trans);
            UnityEngine.Profiling.Profiler.EndSample();

            group.m_CachedState = state;

            return state.Data;
        }
    }
}
