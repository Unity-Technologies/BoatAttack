# Using ComponentSystem

You can use a ComponentSystem to process your data. ComponentSystem methods run on the main thread and thus don’t take advantage of multiple CPU cores. Use ComponentSystems in the following circumstances:

* Debugging or exploratory development — sometimes it is easier to observe what is going on when the code is running on the main thread. You can, for example, log debug text and draw debug graphics.
* When the system needs to access or interface with other APIs that can only run on the main thread — this can help you gradually convert your game systems to ECS rather than having to rewrite everything from the start.
* The amount of work the system performs is less than the small overhead of creating and scheduling a Job.

__Important:__ Making structural changes forces the completion of all Jobs. This event is called a *sync point* and can lead to a drop in performance because the system cannot take advantage of all the available CPU cores while it waits for the sync point. In a ComponentSystem, you should use a post-update command buffer. The sync point still occurs, but all the structural changes happen in a batch, so it has a slightly lower impact. For maximum efficiency, use a JobComponentSystem and an entity command buffer. When creating a large number of entities, you can also use a separate World to create the entities and then transfer those entities to the main game world.

## Iterating with ForEach delegates

The ComponentSystem provides an Entities.ForEach function that simplifies the task of iterating over a set of entities. Call ForEach in the system’s OnUpdate() function passing in a lambda function that takes the relevant components as parameters and whose function body performs the necessary work.

The following example, from the HelloCube ForEach sample, animates the rotation for any entities that have both a RotationQuaternion and a RotationSpeed component:

    public class RotationSpeedSystem : ComponentSystem
    {
       protected override void OnUpdate()
       {
           Entities.ForEach( (ref RotationSpeed rotationSpeed, ref RotationQuaternion rotation) =>
           {
               var deltaTime = Time.deltaTime;
               rotation.Value = math.mul(math.normalize(rotation.Value),
                   quaternion.AxisAngle(math.up(), rotationSpeed.RadiansPerSecond * deltaTime));
           });
       }

You can use ForEach lambda functions with up to six types of components.

If you need to make structural changes to existing entities, you can add an Entity component to your lambda function parameters and use it to add the commands to your `ComponentSystem`'s `PostUpdateCommands` buffer. (If you were allowed to make structural changes inside the lambda function, you might change the layout of the data in the arrays you are iterating over, leading to bugs or other undefined behavior.)

For example, if you wanted to remove the RotationSpeed component form any entities whose rotation speed is currently zero, you could alter your ForEach function as follows:

``` c#
Entities.ForEach( (Entity entity, ref RotationSpeed rotationSpeed, ref RotationQuaternion rotation) =>
{
   var __deltaTime __= Time.deltaTime;
   rotation.Value = math.mul(math.normalize(rotation.Value),
       quaternion.AxisAngle(math.up(), rotationSpeed.RadiansPerSecond * __deltaTime__));
  
   if(math.abs(rotationSpeed.RadiansPerSecond) <= float.Epsilon) //Speed effectively zero
       PostUpdateCommands.RemoveComponent(entity, typeof(RotationSpeed));               
});
```

The system executes the commands in the post-update buffer after the OnUpdate() function is finished.

## Fluent Queries

You can use a [fluent-style](https://en.wikipedia.org/wiki/Fluent_interface) query to constrain a ForEach lambda such that it executes on a specific set of entities satisfying some constraints. These queries can specify whether the work should be done on entities that have any, all or none of a set of components. Constraints can be chained together and should look very familiar to users of C#'s LINQ system.

Note that any components passed as parameters to the ForEach lambda function are automatically included in the WithAll set and must not be included explicitly in the WithAll, WithAny, or WithNone portions of the query.

A **WithAll** constraint allows you to specify that an entity have all of a set of components. For example, with the following query, the ComponentSystem executes a lambda function for all entities that have the Rotation and Scale component:

```csharp
Entities.WithAll<Rotation, Scale>().ForEach( (Entity e) =>
{
    // do stuff
});
```

Use WithAll for components that must exist on an entity, but which you do not need to read or write (add components that you want to access, as parameters of the ForEach lambda function). For example:

```csharp
Entities.WithAll<SpinningTag>().ForEach( (Entity e, ref Rotation r) =>
{
    // do stuff
});
```

A **WithAny** constraint allows you to specify that an entity must have at least one of a set of components. The ComponentSystem executes the following lambda function for all entities that have both Rotation and Scale, AND either RenderDataA or RenderDataB (or both):

```csharp
Entities.WithAll<Rotation, Scale>().WithAny<RenderDataA, RenderDataB>().ForEach( (Entity e) =>
{
    // do stuff
});
```

Note that there is no way to know which components in the WithAny set exist for a specific entity. If you need to treat entities differently depending on which of these components exist, you must either create a specific query for each situation, or use a JobComponentSystem with [IJobChunk](chunk_iteration_job.md).

A **WithNone** constraint allows you to exclude entities that have at least one of a set of components. The ComponentSystem executes the following lambda function for all entities that do not have a Rotation component:

```csharp
Entities.WithNone<Rotation>().ForEach( (Entity e) =>
{
    // do stuff
});
```

Additionally, you can specify `WithAnyReadOnly` and `WithAllReadOnly` to filter for entities with any, or all (respectively) of a set of components; but also ensure that they are queried as read only components.  This will ensure that they are not marked as written and their chunk IDs changed.

### Options

You can also specify a number of options for a query using **With**:

| Option | Description |
|---|---|
| Default | No options specified. |
| IncludePrefab | The query does not implicitly exclude entities with the special Prefab component. |
| IncludeDisabled | The query does not implicitly exclude entities with the special Disabled component. |
| FilterWriteGroup | The query should filter selected entities based on the WriteGroupAttribute settings of the components specified in the query. |

The ComponentSystem executes the following lambda function for all entities that do not have a Rotation component, including those that do have the special Disabled component:

```csharp
Entities.WithNone<Rotation>().With(EntityQueryOptions.IncludeDisabled).ForEach( (Entity e) =>
{
    // do stuff
});
```
