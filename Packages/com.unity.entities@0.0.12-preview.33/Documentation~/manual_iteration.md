# Manual iteration

You can also request all the chunks explicitly in a NativeArray and process them with a Job such as `IJobParallelFor`. This method is recommended if you need to manage chunks in some way that is not appropriate for the simplified model of simply iterating over all the Chunks in a EntityQuery. As in:

```c#
public class RotationSpeedSystem : JobComponentSystem
{
   [BurstCompile]
   struct RotationSpeedJob : IJobParallelFor
   {
       [DeallocateOnJobCompletion] public NativeArray<ArchetypeChunk> Chunks;
       public ArchetypeChunkComponentType<RotationQuaternion> RotationType;
       [ReadOnly] public ArchetypeChunkComponentType<RotationSpeed> RotationSpeedType;
       public float DeltaTime;

       public void Execute(int chunkIndex)
       {
           var chunk = Chunks[chunkIndex];
           var chunkRotation = chunk.GetNativeArray(RotationType);
           var chunkSpeed = chunk.GetNativeArray(RotationSpeedType);
           var __instanceCount __= chunk.Count;

           for (int i = 0; i < instanceCount; i++)
           {
               var rotation = chunkRotation[i];
               var speed = chunkSpeed[i];
               rotation.Value = math.mul(math.normalize(rotation.Value), quaternion.AxisAngle(math.up(), speed.RadiansPerSecond * DeltaTime));
               chunkRotation[i] = rotation;
           }
       }
   }
   
   EntityQuery m_group;   

   protected override void OnCreate()
   {
       var query = new EntityQueryDesc
       {
           All = new ComponentType[]{ typeof(RotationQuaternion), ComponentType.ReadOnly<RotationSpeed>() }
       };

       m_group = GetEntityQuery(query);
   }

   protected override JobHandle OnUpdate(JobHandle inputDeps)
   {
       var rotationType = GetArchetypeChunkComponentType<RotationQuaternion>();
       var rotationSpeedType = GetArchetypeChunkComponentType<RotationSpeed>(true);
       var chunks = m_group.CreateArchetypeChunkArray(Allocator.__TempJob__);
       
       var rotationsSpeedJob = new RotationSpeedJob
       {
           Chunks = chunks,
           RotationType = rotationType,
           RotationSpeedType = rotationSpeedType,
           DeltaTime = Time.deltaTime
       };
       return rotationsSpeedJob.Schedule(chunks.Length,32,inputDeps);
   }
}
```

## Iterating manually in a ComponentSystem

Although not a generally recommended practice, you can use the EntityManager class to manually iterate through the entities or chunks. These iteration methods should only be used in test or debugging code (or when you are just experimenting) or in an isolated World in which you have a perfectly controlled set of entities.

For example, the following snippet iterates through all of the entities in the active World:

``` c#
var entityManager = World.Active.EntityManager;
var allEntities = entityManager.GetAllEntities();
foreach (var entity in allEntities)
{
   //...
}
allEntities.Dispose();
```

 While this snippet iterates through all of the chunks in the active World:

``` c#
var entityManager = World.Active.EntityManager;
var allChunks = entityManager.GetAllChunks();
foreach (var chunk in allChunks)
{
   //...
}
allChunks.Dispose();
```
