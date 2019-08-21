# Using IJobForEach

You can define an `IJobForEach` Job in a JobComponentSystem to read and write component data. 

When the Job runs, the ECS framework finds all of the entities that have the required components and calls the Job’s Execute() function for each of them. The data is processed in the order it is laid out in memory and the Job runs in parallel, so a `IJobForEach` combines simplicity and efficiency.

The following example illustrates a simple system that uses `IJobForEach`. The Job reads a `RotationSpeed` component and writes to a `RotationQuaternion` component.

```c#
public class RotationSpeedSystem : JobComponentSystem
{
   // Use the [BurstCompile] attribute to compile a job with Burst.
   [BurstCompile]
   struct RotationSpeedJob : IJobForEach<RotationQuaternion, RotationSpeed>
   {
       public float DeltaTime;
       // The [ReadOnly] attribute tells the job scheduler that this job will not write to rotSpeed
       public void Execute(ref RotationQuaternion rotationQuaternion, [ReadOnly] ref RotationSpeed rotSpeed)
       {
           // Rotate something about its up vector at the speed given by RotationSpeed.  
           rotationQuaternion.Value = math.mul(math.normalize(rotationQuaternion.Value), quaternion.AxisAngle(math.up(), rotSpeed.RadiansPerSecond * DeltaTime));
       }
   }

// OnUpdate runs on the main thread.
// Any previously scheduled jobs reading/writing from Rotation or writing to RotationSpeed 
// will automatically be included in the inputDependencies.
protected override JobHandle OnUpdate(JobHandle inputDependencies)
   {
       var job = new RotationSpeedJob()
       {
           DeltaTime = Time.deltaTime
       };
       return job.Schedule(this, inputDependencies);
   }
}
```

Note: the above system is based on the HelloCube IJobForEach sample in the [ECS Samples repository](https://github.com/Unity-Technologies/EntityComponentSystemSamples).


## Defining the IJobForEach signature

The `IJobForEach` struct signature identifies which components your system operates on:

    struct RotationSpeedJob : IJobForEach<RotationQuaternion, RotationSpeed>

You can also use the following attributes to modify which entities the Job selects:

* [ExcludeComponent(typeof(T)] — excludes entities whose Archetype contains the component of type T. 
* [RequireComponentTag(typeof(T)] — only include entities whose Archetype contains a component of type T. Use this attribute when a system does not read or write to a component that still must be associated with an entity. 

For example, the following Job definition selects entities that have archetypes containing Gravity, RotationQuaternion, and RotationSpeed components, but not a Frozen component:

    [ExcludeComponent(typeof(Frozen))]
    [RequireComponentTag(typeof(Gravity))]
    [BurstCompile]
    struct RotationSpeedJob : IJobForEach<RotationQuaternion, RotationSpeed>

If you need a more complex query to select the entities to operate upon, you can use an IJobChunk Job instead of IJobForEach.

## Writing the Execute() method

The JobComponentSystem calls your Execute() method for each eligible entity, passing in the components identified by the IJobForEach signature. Thus, the parameters of your Execute() function must match the generic arguments you defined for the struct.

For example, the following Execute() method reads a RotationSpeed component and reads and writes a RotationQuaternion component. (Read/write is the default, so no attribute is needed.)

    public void Execute(ref RotationQuaternion rotationQuaternion, [ReadOnly] ref RotationSpeed rotSpeed){}

You can add attributes to the function parameters to help ECS optimize your system:

* [ReadOnly] — use for components that the function reads, but does not write.
* [WriteOnly] — use for components that the function writes, but does not read.
* [ChangeFilter] — use when you only want to run the function on entities for which that component value may have changed since the last time your system ran. 

Identifying read-only and write-only components allows the Job scheduler to schedule your Jobs efficiently. For example, the scheduler won’t schedule a Job that writes to a component at the same time as a Job that reads that component, but it can run two Jobs in parallel if they only read the same components.

Note that for efficiency, the change filter works on whole chunks of entities; it does not track individual entities. If a chunk has been accessed by another Job which had the ability to write to that type of component, then the ECS framework considers that chunk to have changed and includes all of the entities in the Job. Otherwise, the ECS framework excludes the entities in that chunk entirely. 

<a name="with-entity"></a>
## Using IJobForEachWithEntity

The Jobs implementing the IJobForEachWithEntity interface behave much the same as those implementing IJobForEach. The difference is that the Execute() function signature in IJobForEachWithEntity provides you with the Entity object for the current entity and the index into the extended, parallel arrays of components.

### Using the Entity parameter

You can use the Entity object to add commands to an EntityCommandBuffer. For example, you can add commands to add or remove components on that entity or to destroy the entity — all operations that cannot be done directly inside a Job to avoid race conditions. Command buffers allow you to perform any, potentially costly, calculations on a worker thread, while queuing up the actual insertions and deletions to be performed later on the main thread.

The following system, based on the HelloCube SpawnFromEntity sample, uses a command buffer to instantiate entities after calculating their positions in a Job:

``` c#
public class SpawnerSystem : JobComponentSystem
{
   // EndFrameBarrier provides the CommandBuffer
   EndFrameBarrier m_EndFrameBarrier;

   protected override void OnCreate()
   {
       // Cache the EndFrameBarrier in a field, so we don't have to get it every frame
       m_EndFrameBarrier = World.GetOrCreateSystem<EndFrameBarrier>();
   }
   struct SpawnJob : IJobForEachWithEntity<Spawner, LocalToWorld>
   {
       public EntityCommandBuffer CommandBuffer;
       public void Execute(Entity entity, int index, [ReadOnly] ref Spawner spawner,
           [ReadOnly] ref LocalToWorld location)
       {
           for (int x = 0; x < spawner.CountX; x++)
           {
               for (int y = 0; y < spawner.CountY; y++)
               {
                   var __instance __= CommandBuffer.Instantiate(spawner.Prefab);
                   // Place the instantiated in a grid with some noise
                   var position = math.transform(location.Value,
                       new float3(x * 1.3F, noise.cnoise(new float2(x, y) * 0.21F) * 2, y * 1.3F));
                   CommandBuffer.SetComponent(instance, new Translation {Value = position});
               }
           }
           CommandBuffer.DestroyEntity(entity);
       }
   }

   protected override JobHandle OnUpdate(JobHandle inputDeps)
   {
       // Schedule the job that will add Instantiate commands to the EntityCommandBuffer.
       var job = new SpawnJob
       {
           CommandBuffer = m_EndFrameBarrier.CreateCommandBuffer()
       }.ScheduleSingle(this, inputDeps);

       // We need to tell the barrier system which job it needs to complete before it can play back the commands.
       m_EndFrameBarrier.AddJobHandleForProducer(job);
      
       return job;
   }
}
```

__Note:__ this example uses IJobForEach.ScheduleSingle(), which performs the Job on a single thread. If you used the Schedule() method instead, the system uses parallel jobs to process the entities. In the parallel case, you must use a concurrent entity command buffer (EntityCommandBuffer.Concurrent).

See the  [ECS samples repository](https://github.com/Unity-Technologies/EntityComponentSystemSamples) for the full example source code.

### Using the index parameter

You can use the index when adding a command to a concurrent command buffer. You use concurrent command buffers when running Jobs that process entities in parallel. In an IJobForEachWithEntity Job, the Job System process entities in parallel when you use the Schedule() method rather than the ScheduleSingle() method used in the example above. Concurrent command buffers should always be used for parallel Jobs to guarantee thread safety and deterministic execution of the buffer commands.

You can also use the index to reference the same entities across Jobs within the same system. For example, if you need to process a set of entities in multiple passes and collect temporary data along the way, you can use the index to insert the temporary data into a NativeArray in one Job and then use the index to access that data in a subsequent Job. (Naturally, you have to pass the same NativeArray to both Jobs.)
