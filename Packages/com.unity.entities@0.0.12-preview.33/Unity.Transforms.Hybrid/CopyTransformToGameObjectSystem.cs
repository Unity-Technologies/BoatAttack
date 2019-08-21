using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace Unity.Transforms
{
    [UnityEngine.ExecuteAlways]
    [UpdateInGroup(typeof(TransformSystemGroup))]
    [UpdateAfter(typeof(EndFrameLocalToParentSystem))]
    public class CopyTransformToGameObjectSystem : JobComponentSystem
    {
        [BurstCompile]
        struct CopyTransforms : IJobParallelForTransform
        {
            [DeallocateOnJobCompletion]
            [ReadOnly] public NativeArray<LocalToWorld> LocalToWorlds;

            public void Execute(int index, TransformAccess transform)
            {
                var value = LocalToWorlds[index];
                transform.position = value.Position;
                transform.rotation = new quaternion(value.Value);
            }
        }

        EntityQuery m_TransformGroup;

        protected override void OnCreate()
        {
            m_TransformGroup = GetEntityQuery(ComponentType.ReadOnly(typeof(CopyTransformToGameObject)), ComponentType.ReadOnly<LocalToWorld>(), typeof(UnityEngine.Transform));
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var transforms = m_TransformGroup.GetTransformAccessArray();
            var copyTransformsJob = new CopyTransforms
            {
                LocalToWorlds = m_TransformGroup.ToComponentDataArray<LocalToWorld>(Allocator.TempJob, out inputDeps),
            };

            return copyTransformsJob.Schedule(transforms, inputDeps);
        }
    }
}