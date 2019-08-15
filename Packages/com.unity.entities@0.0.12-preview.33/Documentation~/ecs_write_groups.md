---
uid: ecs-writegroups
---

# WriteGroups

A common ECS pattern is for a system to read one set of *input* components and write to another, *output* component. However, you may want to override that system and update the output component based on your own set of inputs.

WriteGroups allow you to override whether a system writes to a component without having to change the overridden system. A WriteGroup identifies a set of components used as the source for writing to a particular component. The system defining that WriteGroup must also enable WriteGroup filtering on the EntityQuery objects it uses to select the entities to update.

Define a WriteGroup using the WriteGroup attribute. This attribute takes the type of the target, output component as a parameter. Place the attribute on every component used as a source when updating the target component. For example, the following declaration specifies that component A is part of the WriteGroup targeting component W:

```
[WriteGroup(typeof(W))]
public struct A : IComponentData{ public int Value; }
```

Note that the target component of the WriteGroup must be included in the query and accessed as writable. Otherwise, the WriteGroup is ignored for that query.

When you turn on WriteGroup filtering in a query, the query adds all components in a WriteGroup to the *None* list of the query unless you explicitly add them to the *All* or *Any* lists. As a result, the query only selects an entity if every component on that entity from a particular WriteGroup is explicitly required by the query. If an entity has one or more additional components from that WriteGroup, the query rejects it.

So far, WriteGroups don’t do anything that you couldn’t achieve by just rewriting the query. However, the benefit comes when you are working with a system that you cannot rewrite. You can add your own component to any WriteGroup defined by that system and, when you put that component on an entity along with the preexisting components, the system no longer selects and updates that entity. Your own system can then update the entity without contention from the other system.

**WriteGroup Example:**

Given:
* Components A and B in a WriteGroup targeting component W
* Query: 
  * All: A, W 
  * WriteGroup filtering enabled
* Entities:

  | Entity X | Entity Y |
  | :--------- | :---------- |
  | A           | A            |
  | W          | B           |
  |              | W          |

The query selects Entity X, but not Y. 

Entity Y is not selected because it has component B, which is part of the same WriteGroup, but is not required by the query. Enabling WriteGroup filtering changes the query to be:
* All: A, W
* None: B 

Without WriteGroup filtering, the query would select both Entity X and Y. 

**Note:** for more examples you can look at the Unity.Transforms code, which uses WriteGroups for every component it updates, including LocalToWorld.

## Creating WriteGroups

You can create WriteGroups by adding the WriteGroup attribute to the declarations of each component in the WriteGroup. The WriteGroup attribute takes one parameter, which is the type of component that the components in the group are used to update. A single component can be a member of more than one WriteGroup.

For example, if component W = A + B, then you would define a WriteGroup for W as follows:

```
public struct W : IComponentData
{
   public int Value;
}

[WriteGroup(typeof(W))]
public struct A : IComponentData
{
   public int Value;
}

[WriteGroup(typeof(W))]
public struct B : IComponentData
{
   public int Value;
}
```

Note that you do not add the target of the WriteGroup (struct W in the example above) to its own WriteGroup.

## Enabling WriteGroup filtering

To enable WriteGroup filtering, set the FilterWriteGroups flag on the query description object you use to create the query:

```
public class AddingSystem : JobComponentSystem
{
   private EntityQuery m_Query;

   protected override void OnCreate()
   {
       var queryDescription = new EntityQueryDesc
       {
           All = new ComponentType[] {typeof(A), typeof(B)},
           Options = EntityQueryOptions.FilterWriteGroup
       };
       m_Query = GetEntityQuery(queryDescription);
   }
   // Define Job and schedule...
}
```

## Overriding another system that uses WriteGroups

If a system defines WriteGroups for the components it writes to, you can override that system and write to those components using your own system. To override the system, add your own components to the WriteGroups defined by that system. Since WriteGroup filtering excludes any components in the WriteGroup that aren’t explicitly required by a query, any entities that have your components will then be ignored by the other system.

For example, if you wanted to set the orientation of your entities by specifying the angle and axis of rotation, you could create a component and a system to convert the angle and axis values into a quaternion and write that to the Unity.Transforms.Rotation component. To prevent the Unity.Transforms systems from updating Rotation, no matter what other components besides yours are present, you can put your component in the Rotation WriteGroup:

```
using System;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

[Serializable]
[WriteGroup(typeof(Rotation))]
public struct RotationAngleAxis : IComponentData
{
   public float Angle;
   public float3 Axis;
}

You can then update any entities containing RotationAngleAxis without contention:

using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Transforms;

public class RotationAngleAxisSystem : JobComponentSystem
{

   [BurstCompile]
   struct RotationAngleAxisSystemJob : IJobForEach<RotationAngleAxis, Rotation>
   {
       public void Execute([ReadOnly] ref RotationAngleAxis source, ref Rotation destination)
       {
           destination.Value = quaternion.AxisAngle(math.normalize(source.Axis), source.Angle);
       }
   }

   protected override JobHandle OnUpdate(JobHandle inputDependencies)
   {
       var job = new RotationAngleAxisSystemJob();
       return job.Schedule(this, inputDependencies);
   }
}
```

## Extending another system that uses WriteGroups

If you want to extend the other system rather than just override it, and further, you want to allow future systems to override or extend your system, then you can enable WriteGroup filtering on your own system. When you do this, however, no combinations of components will be handled by either system by default. You must explicitly query for and process each combination.

As an example, let’s return to the AddingSystem example described earlier, which defined a WriteGroup containing components A and B that targeted component W. If you simply add a new component, call it “C”, to the WriteGroup, then the new system that knows about C can query for entities containing C and it does not matter if those entities also have components A or B. However, if the new system also enables WriteGroup filtering, that is no longer true. If you only require component C, then WriteGroup filtering excludes any entities with either A or B. Instead, you must explicitly query for each combination of components that make sense. (You can use the “Any” clause of the query when appropriate.) 

```
var query = new EntityQueryDesc
{
   All = new ComponentType[] {ComponentType.ReadOnly<C>(), ComponentType.ReadWrite<W>()},
   Any = new ComponentType[] {ComponentType.ReadOnly<A>(), ComponentType.ReadOnly<B>()},
   Options = EntityQueryOptions.FilterWriteGroup
};
```

Any entities containing combinations of components in the WriteGroup that are not explicitly handled will not be handled by any system that writes to the target of the WriterGroup (and filters on WriteGroups). But then, it is most likely a logical error in the program to create such entities in the first place.

