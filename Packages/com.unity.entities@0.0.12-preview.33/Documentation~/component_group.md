---
uid: ecs-component-group
---
# Querying for data using a EntityQuery

The first step to reading or writing data is finding that data. Data in the ECS framework is stored in components, which are grouped together in memory according to the archetype of the entity to which they belong. To define a view into your ECS data that contains only the specific data you need for a given algorithm or process, you can construct a EntityQuery. 

After creating a EntityQuery, you can 

* Run a Job to process the entities and components selected for the view
* Get a NativeArray containing all the selected entities
* Get NativeArrays of the selected components (by component type)

The entity and component arrays returned by a EntityQuery are guaranteed to be "parallel", that is, the same index value always applies to the same entity in any array.

**Note:** that the `ComponentSystem.Entites.ForEach` delegates and IJobForEach create internal EntityQueries based on the component types and attributes you specify for these APIs. 

<!-- TODO: (In an IJobForEach Job, you can override the EntityQuery to use a more complex query than the default setup supports.) -->

## Defining a query

A EntityQuery query defines the set of component types that an archetype must contain in order for its chunks and entities to be included in the view. You can also exclude archetypes that contain specific types of components.  

For simple queries, you can create a EntityQuery based on an array of component types. The following example defines a EntityQuery that finds all entities with both RotationQuaternion and RotationSpeed components. 

``` c#
EntityQuery m_Group = GetEntityQuery(typeof(RotationQuaternion), ComponentType.ReadOnly<RotationSpeed>());
````

The query uses `ComponentType.ReadOnly<T>`  instead of the simpler `typeof` expression to designate that the system does not write to RotationSpeed. Always specify read only when possible, since there are fewer constraints on read access to data, which can help the Job scheduler execute your Jobs more efficiently. 

### EntityQueryDesc

For more complex queries, you can use an EntityQueryDesc to create the EntityQuery. An EntityQueryDesc provides a flexible query mechanism to specify which archetypes to select based on the following sets of components:

* `All` = All component types in this array must exist in the archetype
* `Any` = At least one of the component types in this array must exist in the archetype
* `None` = None of the component types in this array can exist in the archetype

For example, the following query includes archetypes containing the RotationQuaternion and RotationSpeed components, but excludes any archetypes containing the Frozen component:

``` c#
var query = new EntityQueryDesc
{
   None = new ComponentType[]{ typeof(Frozen) },
   All = new ComponentType[]{ typeof(RotationQuaternion), ComponentType.ReadOnly<RotationSpeed>() }
}
EntityQuery m_Group = GetEntityQuery(query);
```

**Note:** Do not include completely optional components in the EntityQueryDesc. To handle optional components, use the `ArchetypeChunk.Has<T>()` method to determine whether a chunk contains the optional component or not. Since all entities within the same chunk have the same components, you only need to check whether an optional component exists once per chunk -- not once per entity.

### Query options

When you create an EntityQueryDesc, you can set its `Options` variable. The options allow for specialized queries (normally you do not need to set them):

* Default — no options set; the query behaves normally.
* IncludePrefab — includes archetypes containing the special Prefab tag component.
* IncludeDisabled — includes archetypes containing the special Disabled tag component.
* FilterWriteGroup — considers the WriteGroup of any components in the query.

When you set the FilterWriteGroup option, only entities with those components in a Write Group that are explicitly included in the query will be included in the view. Entities that have any additional components from the same WriteGroup are excluded.

For example, suppose C2 and C3 are components in the same Write Group based on C1, and you created a query using the FilterWriteGroup option that requires C1 and C3:

``` c#
public struct C1: IComponentData{}

[WriteGroup(C1)]
public struct C2: IComponentData{}

[WriteGroup(C1)]
public struct C3: IComponentData{}

// ... In a system:
var query = new EntityQueryDesc{
    All = new ComponentType{typeof(C1), ComponentType.ReadOnly<C3>()},
    Options = EntityQueryDescOptions.FilterWriteGroup
};
var m_group = GetEntityQuery(query);
```

This query excludes any entities with both C2 and C3 because C2 is not explicitly included in the query. While you could design this into the query using `None`, doing it through a Write Group provides an important benefit: you don't need to alter the queries used by other systems (as long as these systems also use Write Groups). 

Write Groups are a mechanism that allow you to extend existing systems. For example, if C1 and C2 are defined in another system (perhaps part of a library that you don't control), you could put C3 into the same Write Group as C2 in order to change how C1 is updated. For any entities to which you add your C3 component, your system will update C1 and the original system will not. For other entities without C3, the original system will update C1 as before.

See [Write Groups](ecs_write_groups.md) for more information.

### Combining queries

You can combine multiple queries by passing an array of EntityQueryDesc objects rather than a single instance. Each query is combined using a logical OR operation. The following example selects an archetypes that contain a RotationQuaternion component or a RotationSpeed component (or both):

``` c#
var query0 = new EntityQueryDesc
{
   All = new ComponentType[] {typeof(RotationQuaternion)}
};

var query1 = new EntityQueryDesc
{
   All = new ComponentType[] {typeof(RotationSpeed)}
};

EntityQuery m_Group = GetEntityQuery(new EntityQueryDesc[] {query0, query1});
   ```

## Creating a EntityQuery

Outside a system class, you can create a EntityQuery with the `EntityManager.CreateEntityQuery()` function:

``` c#
EntityQuery m_Group = CreateEntityQuery(typeof(RotationQuaternion), ComponentType.ReadOnly<RotationSpeed>());
```

However, in a system class, you must use the `GetEntityQuery()` function: 

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
```

When you plan to reuse the same view, you should cache the EntityQuery instance, if possible, instead of creating a new one for each use. For example, in a system, you can create the EntityQuery in the system’s `OnCreate()` function and store the result in an instance variable. The `m_Group` variable in the above example is used for this purpose.

## Defining filters

In addition to defining which components must be included or excluded from the query, you can also filter the view. You can specify the following types of filters:
 
* Shared component values —filter the set of entities based on specific values of a shared component.
* Change filter — Filter the set of entities based on whether the value of a specific component type has potentially changed

### Shared component filters

To use a shared component filter, first include the shared component in the EntityQuery (along with other needed components), and then call the `SetFilter()` function, passing in a struct of the same ISharedComponent type that contains the values to select. All values must match. You can add up to two different shared components to the filter.

You can change the filter at any time, but changing the filter does not change any existing arrays of entities or components that you received from the group `ToComponentDataArray()` or `ToEntityArray()` functions. You must recreate these arrays.

The following example defines a shared component named SharedGrouping and a system that only processes entities that have the Group field set to 1.

```cs
struct SharedGrouping : ISharedComponentData
{
    public int Group;
}

class ImpulseSystem : ComponentSystem
{
    EntityQuery m_Group;

    protected override void OnCreate(int capacity)
    {
        m_Group = GetEntityQuery(typeof(Position), typeof(Displacement), typeof(SharedGrouping));
    }

    protected override void OnUpdate()
    {
        // Only iterate over entities that have the SharedGrouping data set to 1
        m_Group.SetFilter(new SharedGrouping { Group = 1 });
        
        var positions = m_Group.ToComponentDataArray<Position>(Allocator.Temp);
        var displacememnts = m_Group.ToComponentDataArray<Displacement>(Allocator.Temp);

        for (int i = 0; i != positions.Length; i++)
            positions[i].Value = positions[i].Value + displacememnts[i].Value;
    }
}
```

### Change filters

If you only need to update entities when a component value has changed, you can add that component to the EntityQuery filter using the `SetFilterChanged()` function. For example, the following EntityQuery only includes entities from chunks in which another system has already written to the Translation component: 

``` c#
protected override void OnCreate(int capacity)
{
    m_Group = GetEntityQuery(typeof(LocalToWorld), ComponentType.ReadOnly<Translation>());
    m_Group.SetFilterChanged(typeof(Translation));
}

```

Note that for efficiency, the change filter applies to whole chunks not individual entities. The change filter also only checks whether a system has run that declared write access to the component, not whether it actually changed any data. In other words, if a chunk has been accessed by another Job which had the ability to write to that type of component, then the change filter includes all entities in that chunk. (This is another reason to always declare read only access to components that you do not need to modify.)

## Executing the query

A EntityQuery executes its query when you use the EntityQuery in a Job or you call one of the EntityQuery methods that returns arrays of entities, components, or chunks in the view:

* `ToEntityArray()` returns an array of the selected entities.
* `ToComponentDataArray<T>` returns an array of the components of type T for the selected entities.
* `CreateArchetypeChunkArray()` returns all the chunks containing the selected entities. (Since a query operates on archetypes, shared component values, and change filters, which are all identical for all the entities in a chunk, the set of entities stored within the returned set of chunks is exactly the same as the set of entities returned by `ToEntityArray()`.) 

<!-- TODO: Discuss using the Job versions of these functions. -->

### In Jobs

In a JobComponentSystem, pass the EntityQuery object to the system's `Schedule()` method. In the following example, from the HelloCube IJobChunk sample, the `m_Group` argument is the EntityQuery object 

``` c#
// OnUpdate runs on the main thread.
protected override JobHandle OnUpdate(JobHandle inputDependencies)
{
    var rotationType = GetArchetypeChunkComponentType<Rotation>(false); 
    var rotationSpeedType = GetArchetypeChunkComponentType<RotationSpeed>(true);
    
    var job = new RotationSpeedJob()
    {
        RotationType = rotationType,
        RotationSpeedType = rotationSpeedType,
        DeltaTime = Time.deltaTime
    };

    return job.Schedule(m_Group, inputDependencies);
}
```

A EntityQuery uses Jobs internally to create the required arrays. When you pass the group to the `Schedule()` method, the EntityQuery Jobs are scheduled along with the system's own Jobs and can take advantage of parallel processing. 
 
