---
uid: ecs-jobs
---
# Jobs in ECS

ECS uses the Job system to implement behavior -- the *System* part of ECS. An ECS System is concretely a Job created to transform the data stored in entity components 

For example, the following system updates positions:

    using Unity.Burst;
    using Unity.Collections;
    using Unity.Entities;
    using Unity.Jobs;
    using Unity.Transforms;
    using UnityEngine;
    
    public class MovementSpeedSystem : JobComponentSystem
    {
        [BurstCompile]
        struct MovementSpeedJob : IJobForEach<Position, MovementSpeed>
        {
            public float dT;
    
            public void Execute(ref Position Position, [ReadOnly] ref MovementSpeed movementSpeed)
            {
                float3 moveSpeed = movementSpeed.Value * dT;
                Position.Value = Position.Value + moveSpeed;
            }
        }
    
        // OnUpdate runs on the main thread.
        protected override JobHandle OnUpdate(JobHandle inputDependencies)
        {
            var job = new MovementSpeedJob()
            {
                dT = Time.deltaTime
            };
    
            return job.Schedule(this, inputDependencies);
        }
    }


For more information about systems, see [ECS Systems](ecs_systems.md).