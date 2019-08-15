# System Update Order

Use Component System Groups to specify the update order of your systems. You can place a systems in a group using the [UpdateInGroup] attribute on the system’s class declaration. You can then use [UpdateBefore] and [UpdateAfter] attributes to specify the update order within the group. 

The ECS framework creates a set of [default system groups](#default-system-groups) that you can use to update your systems in the correct phase of a frame. You can nest one group inside another so that all systems in your group update in the correct phase and, then, also update according to the order within their group.

## Component System Groups

The ComponentSystemGroup class represents a list of related component systems that should be updated together in a specific order. ComponentSystemGroup is derived from ComponentSystemBase, so it acts like a component system in all the important ways -- it can be ordered relative to other systems, has an OnUpdate() method, etc. Most relevantly, this means component system groups can be nested in other component system groups, forming a hierarchy.

By default, when a ComponentSystemGroup’s `Update()` method is called, it calls Update() on each system in its sorted list of member systems. If any member systems are themselves system groups, they will recursively update their own members. The resulting system ordering follows a depth-first traversal of a tree.

## System Ordering Attributes

The existing system ordering attributes are maintained, with slightly different semantics and restrictions.

* [UpdateInGroup] — specifies a ComponentSystemGroup that this system should be a member of. If this attribute is omitted, the system is automatically added to the default World’s SimulationSystemGroup (see below).
* [UpdateBefore] and [UpdateAfter] — order systems relative to other systems. The system type specified for these attributes must be a member of the same group. Ordering across group boundaries is handled at the appropriate deepest group containing both systems:
    * __Example:__ if SystemA is in GroupA and SystemB is in GroupB, and GroupA and GroupB are both members of GroupC, then the ordering of GroupA and GroupB implicitly determines the relative ordering of SystemA and SystemB; no explicit ordering of the systems is necessary.
* [DisableAutoCreation] — prevents the system from being created during default world initialization. You must explicitly create and update the system. However, you can add a system with this tag to a ComponentSystemGroup’s update list, and it will then be automatically updated just like the other systems in that list.

<a name="default-system-groups"></a>
## Default System Groups

The default World contains a hierarchy of ComponentSystemGroup instances. Only three root-level system groups are added to the Unity player loop (the following list also shows the pre-defined member systems in each group):

* InitializationSystemGroup (updated at the end of the `Initialization` phase of the player loop)
    * BeginInitializationEntityCommandBufferSystem
    * CopyInitialTransformFromGameObjectSystem
    * SubSceneLiveLinkSystem
    * SubSceneStreamingSystem
    * EndInitializationEntityCommandBufferSystem
* SimulationSystemGroup (updated at the end of the `Update` phase of the player loop)
    * BeginSimulationEntityCommandBufferSystem
    * TransformSystemGroup
        * EndFrameParentSystem
        * CopyTransformFromGameObjectSystem
        * EndFrameTRSToLocalToWorldSystem
        * EndFrameTRSToLocalToParentSystem
        * EndFrameLocalToParentSystem
        * CopyTransformToGameObjectSystem
    * LateSimulationSystemGroup
    * EndSimulationEntityCommandBufferSystem
* PresentationSystemGroup (updated at the end of the `PreLateUpdate` phase of the player loop)
    * BeginPresentationEntityCommandBufferSystem
    * CreateMissingRenderBoundsFromMeshRenderer
    * RenderingSystemBootstrap
    * RenderBoundsUpdateSystem
    * RenderMeshSystem
    * LODGroupSystemV1
    * LodRequirementsUpdateSystem
    * EndPresentationEntityCommandBufferSystem

Note that the specific contents of this list is subject to change.

## Multiple Worlds

You can create multiple Worlds, in addition to (or instead of) the default World described above. The same component system class can be instantiated in more than one World, and each instance can be updated at different rates from different points in the update order.

There is currently no way to manually update every system in a given World; instead, you can control which systems are created in which World, and which of the existing system groups they should be added to. Thus, a custom WorldB could instantiate SystemX and SystemY, adding SystemX to the default World’s SimulationSystemGroup, and adding SystemY to the default World’s PresentationSystemGroup. These systems can order themselves relative to their group siblings as usual, and will be updated along with the corresponding group.

To support this use case, a new ICustomBootstrap interface is now available:

``` c#
public interface ICustomBootstrap
{
    // Returns the systems which should be handled by the default bootstrap process.
    // If null is returned the default world will not be created at all.
    // Empty list creates default world and entrypoints
    List<Type> Initialize(List<Type> systems);
}
```

When you implement this interface, the full list of component system types will be passed to the classes `Initialize()` method, prior to default world initialization. A custom bootstrapper can iterate through this list and create systems in whatever World it wants. You can return a list of systems from the Initialize() method and they will be created as part of the normal, default world initialization.

For example, here’s the typical procedure of a custom `MyCustomBootstrap.Initialize()` implementation:

1. Create any additional Worlds and their top-level ComponentSystemGroups.
2. For each Type in the system Type list:
    1. Traverse upward through the ComponentSystemGroup hierarchy to find this system Type’s top-level group.
    2. If it’s one of the groups created in step 1, create the system in that World and add it to the hierarchy with `group.AddSystemToUpdateList()`.
    3. If not, append this Type to the List to return to DefaultWorldInitialization.
3. Call group.SortSystemUpdateList() on new top-level groups.
    4. Optionally add them to one of the default world groups
4. Return list of unhandled systems to DefaultWorldInitialization.

**Note:** the ECS framework finds your ICustomBootstrap implementation by reflection.

## Tips and Best Practices

* __Use [UpdateInGroup] to specify the system group for each system you write.__ If not specified, the implicit default group is SimulationSystemGroup.
* __Use manually-ticked ComponentSystemGroups to update systems elsewhere in the Unity player loop.__ Adding the [DisableAutoCreation] attribute to a component system (or system group) prevents it from being created or added to the default system groups. You can still manually create the system with World.GetOrCreateSystem<MySystem>() and update it by calling manually calling MySystem.Update() from the main thread. This is an easy way to insert systems elsewhere in the Unity player loop (for example, if you have a system that should run later or earlier in the frame).
* __Use the existing `EntityCommandBufferSystem`s instead of adding new ones, if possible.__ An `EntityCommandBufferSystem` represents a sync point where the main thread waits for worker threads to complete before processing any outstanding `EntityCommandBuffer`s. Reusing one of the predefined Begin/End systems in each root-level system group is less likely to introduce a new "bubble" into the frame pipeline than creating a new one.
* __Avoid putting custom logic in `ComponentSystemGroup.OnUpdate()`__. Since `ComponentSystemGroup` is functionally a component system itself, it may be tempting to add custom processing to its OnUpdate() method, to perform some work, spawn some jobs, etc. We advise against this in general, as it’s not immediately clear from the outside whether the custom logic is executed before or after the group’s members are updated. It’s preferable to keep system groups limited to a grouping mechanism, and to implement the desired logic in a separate component system, explicitly ordered relative to the group.
