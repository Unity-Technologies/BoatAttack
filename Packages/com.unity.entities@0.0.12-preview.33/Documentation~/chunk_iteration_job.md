# Using IJobChunk

You can implement IJobChunk inside a JobComponentSystem to iterate through your data by chunk. The JobComponentSystem calls your Execute() function once for each chunk that contains the entities that you want the system to process. You can then process the data inside each chunk, entity by entity.

Iterating with IJobChunk requires more code setup than does IJobForEach, but is also more explicit and represents the most direct access to the data, as it is actually stored. 

Another benefit of using iterating by chunks is that you can check whether an optional component is present in each chunk (with Archetype.Has<T>) and process all the entities in the chunk accordingly.

The steps involved in implementing an IJobChunk Job include:

1. Identify the entities that you want to process by creating a EntityQuery.
2. Defining the Job struct, including fields for ArchetypeChunkComponentType objects to identifying the types of components the Job directly accesses, specifying whether the Job reads or writes to those components.
3. Instantiating the Job struct and scheduling the Job in the system OnUpdate() function.
4. In the Execute() function, getting the NativeArray instances for the components the Job reads or writes and, finally, iterating over the current chunk to perform the desired work.

The [ECS samples repository](https://github.com/Unity-Technologies/EntityComponentSystemSamples) contains a simple HelloCube example that demonstrates how to use IJobChunk.

## Query for data with a EntityQuery

A EntityQuery defines the set of component types that an archetype must contain for the system to process its associated chunks and entities. An archetype can have additional components as well, but it must have at least those defined by the EntityQuery. You can also exclude archetypes that contain specific types of components.  

For simple queries, you can use the JobComponentSystem.GetEntityQuery() function, passing in the component types:

``` c#
public class RotationSpeedSystem : JobComponentSystem
{
   private EntityQuery m_Group;
   protected override void OnCreate()
   {
       m_Group = GetEntityQuery(typeof(RotationQuaternion), ComponentType.ReadOnly<RotationSpeed>());
   }
   //…
}
````

For more complex situations, you can use an EntityQueryDesc. An EntityQueryDesc provides a flexible query mechanism to specify the component types:

* `All` = All component types in this array must exist in the archetype
* `Any` = At least one of the component types in this array must exist in the archetype
* `None` = None of the component types in this array can exist in the archetype

For example, the following query includes archetypes containing the RotationQuaternion and RotationSpeed components, but excludes any archetypes containing the Frozen component:

``` c#
protected override void OnCreate()
{
   var query = new EntityQueryDesc
   {
       None = new ComponentType[]{ typeof(Frozen) },
       All = new ComponentType[]{ typeof(RotationQuaternion), ComponentType.ReadOnly<RotationSpeed>() }
}
   };
   m_Group = GetEntityQuery(query);
}
```

The query uses `ComponentType.ReadOnly<T>`  instead of the simpler `typeof` expression to designate that the system does not write to RotationSpeed.

You can also combine multiple queries by passing an array of EntityQueryDesc objects rather than a single instance. Each query is combined using a logical OR operation. The following example selects an archetypes that contain a RotationQuaternion component or a RotationSpeed component (or both):

``` c#
protected override void OnCreate()
{
   var query0 = new EntityQueryDesc
   {
       All = new ComponentType[] {typeof(RotationQuaternion)}
   };

   var query1 = new EntityQueryDesc
   {
       All = new ComponentType[] {typeof(RotationSpeed)}
   };

   m_Group = GetEntityQuery(new EntityQueryDesc[] {query0, query1});
}
```

**Note:** Do not include completely optional components in the EntityQueryDesc. To handle optional components, use the `chunk.Has<T>()` method inside `IJobChunk.Execute()` to determine whether the current ArchetypeChunk has the optional component or not. Since all entities within the same chunk have the same components, you only need to check whether an optional component exists once per chunk -- not once per entity.

For efficiency and to avoid needless creation of garbage-collected reference types, you should create the EntityQueries for a system in the system’s OnCreate() function and store the result in an instance variable. (In the above examples, the `m_Group` variable is used for this purpose.)

### ## Define the IJobChunk struct

The IJobChunk struct defines fields for the data the Job needs when it runs, as well as the Job’s Execute() method.

In order to access the component arrays inside the chunks that the system passes to your Execute() method, you must create an ArchetypeChunkComponentType<T> object for each type of component that the Job reads or writes. These objects allow you to get instances of the NativeArrays providing access to the components of an entity. Include all the components referenced in the Job’s EntityQuery that the Execute method reads or writes. You can also provide ArchetypeChunkComponentType variables for optional component types that you do not include in the EntityQuery. (You must check to make sure that the current chunk has an optional component before trying to access it.)

For example, the HelloCube IJobChunk example declares a Job struct that defines ArchetypeChunkComponentType<T> variables for two components, RotationQuaternion and RotationSpeed:

``` c#
[BurstCompile]
struct RotationSpeedJob : IJobChunk
{
   public float DeltaTime;
   public ArchetypeChunkComponentType<RotationQuaternion> RotationType;
   [ReadOnly] public ArchetypeChunkComponentType<RotationSpeed> RotationSpeedType;

   public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
   {
       //...
   }
}
```

The system assigns values to these variables in the OnUpdate() function. The variables are used inside the Execute() method when the ECS framework runs the Job.

The Job also uses the Unity delta time to animate the rotation of a 3D object. The example also passes this value to the Execute method using a struct field.  

### ## Writing the Execute method

The signature of the IJobChunk Execute method is:

``` c#
 public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
```

The `chunk` parameter is a handle to the block of memory containing the entities and components to be processed in this iteration of the Job. Since a chunk can only contain a single archetype, all the entities in a chunk have the same set of components. 

Use the `chunk` parameter to get the NativeArray instances for your components:

``` c#
var chunkRotations = chunk.GetNativeArray(RotationType);
var chunkRotationSpeeds = chunk.GetNativeArray(RotationSpeedType);
```

These arrays are aligned such that an entity has the same index in all of them. You can then iterate through the component arrays with a normal for loop. Use `chunk.Count` to get the number of entities stored in the current chunk:

``` c#
for (var i = 0; i < chunk.Count; i++)
{
   var rotation = chunkRotations[i];
   var rotationSpeed = chunkRotationSpeeds[i];

   // Rotate something about its up vector at the speed given by RotationSpeed.
   chunkRotations[i] = new RotationQuaternion
   {
       Value = math.mul(math.normalize(rotation.Value),
           quaternion.AxisAngle(math.up(), rotationSpeed.RadiansPerSecond * DeltaTime))
   };
}
```

If you the `Any` filter in your EntityQueryDesc or have completely optional components that don’t appear in the query at all, you can use the `ArchetypeChunk.Has<T>` function to test whether the current chunk contains the one of those components before using it:

    if (chunk.Has<OptionalComp>(OptionalCompType))
    {//...}

__Note:__ If you use a concurrent entity command buffer, pass the chunkIndex argument as the `jobIndex` parameter to the command buffer functions.

## Skipping chunks with unchanged entities

If you only need to update entities when a component value has changed, you can add that component type to the change filter of the EntityQuery used to select the entities and chunks for the job. For example, if you have a system that reads two components and only needs to update a third when one of the first two has changed, you could use a EntityQuery as follows:

``` c#
EntityQuery m_Group;
protected override void OnCreate()
{
   m_Group = GetEntityQuery(typeof(Output), 
                               ComponentType.ReadOnly<InputA>(), 
                               ComponentType.ReadOnly<InputB>());
   m_Group.SetFilterChanged(new ComponentType{ typeof(InputA), typeof(InputB)});
}
```

The EntityQuery change filter supports up to two components. If you want to check more or aren't using a EntityQuery, you can make the check manually. To make this check, compare the chunk’s change version for the component to the system’s LastSystemVersion using the `ArchetypeChunk.DidChange()` function. If this function returns false, you can skip the current chunk altogether since none of the components of that type have changed since the last time the system ran. 

The LastSystemVersion from the system must be passed into the Job using a struct field:

    [BurstCompile]
    struct UpdateJob : IJobChunk
    {
       public ArchetypeChunkComponentType<InputA> InputAType;
       public ArchetypeChunkComponentType<InputB> InputBType;
       [ReadOnly] public ArchetypeChunkComponentType<Output> OutputType;
       public uint LastSystemVersion;

       public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
       {
           var inputAChanged = chunk.DidChange(InputAType, LastSystemVersion);
           var inputBChanged = chunk.DidChange(InputBType, LastSystemVersion);
           if (!(inputAChanged || inputBChanged))
               return;
          //...
    }

As with all the Job struct fields, you must assign its value before scheduling the Job:

``` c#
   var job = new UpdateJob()
   {
        LastSystemVersion = this.LastSystemVersion,
        //… initialize other fields
   }
```

Note that for efficiency, the change version applies to whole chunks not individual entities. If a chunk has been accessed by another Job which had the ability to write to that type of component, then the change version for that component is incremented and the `DidChange()` function returns true.

## Instantiate and schedule the Job

To run an IJobChunk Job, you must create an instance of your Job struct, setting the struct fields, and then schedule the Job. When you do this in the OnUpdate() function of a JobComponentSystem, the system schedules the Job to run every frame.

``` c#
// OnUpdate runs on the main thread.
protected override JobHandle OnUpdate(JobHandle inputDependencies)
{           
   var job = new RotationSpeedJob()
   {
       RotationType = GetArchetypeChunkComponentType<RotationQuaternion>(false),
       RotationSpeedType = GetArchetypeChunkComponentType<RotationSpeed>(true),
       DeltaTime = Time.deltaTime
   };

   return job.Schedule(m_Group, inputDependencies);
}
```

When you call the GetArchetypeChunkComponentType<T> function to set your component type variables, make sure that you set the isReadOnly to true for components that the Job reads, but doesn’t write. Setting these parameters correctly can have a significant impact on how efficiently the ECS framework can schedule your Jobs. These access mode settings must match their equivalents in both the struct definition, and the EntityQuery. 

Do not cache the return value of GetArchetypeChunkComponentType<T> in a system  class variable. The function must be called every time the system runs and the updated value passed to the Job.
