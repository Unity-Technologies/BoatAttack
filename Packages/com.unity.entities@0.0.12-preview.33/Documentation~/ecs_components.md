---
uid: ecs-components
---
# Components

<!--
> Synopsis:componentsin detail
> What a componenti s...
> How components are managed
> General approaches for accessing components> ComponentData struct
> SharedComponentData struct
> SystemStateComponent and SystemStateSharedComponent
> BufferComponent
> ChunkComponent
> Prefab and Disabled IComponentData
> EntityQuery and filtering
-->

Components are one of the three principle elements of an Entity Component System architecture. They represent the data of your game or program. [Entities](ecs_entities.md) are essentially identifiers that index your collections of components [Systems](ecs_systems.md) provide the behavior. 

Concretely, a component in ECS is a struct with one of the following "marker interfaces":

* IComponentData
* ISharedComponentData
* ISystemStateComponentData
* ISharedSystemStateComponentData

The EntityManager organizes unique combinations of components appearing on your entities into **Archetypes**. It stores the components of all entities with the same archetype together in blocks of memory called **Chunks**. The entities in a given Chunk all have the same component archetype.

Shared components are a special kind of data component that you can use to subdivide entities based on the specific values in the shared component (in addition to their archetype). When you add a shared component to an entity, the EntityManager places all entities with the same shared data values into the same Chunk. Shared components allow your systems to process like entities  together. For example, the shared component `Rendering.RenderMesh`, which is part of the Hybrid.rendering package, defines several fields, including **mesh**, **material**, **receiveShadows**, etc. When rendering, it is most efficient to process all the 3D objects that all have the same value for those fields together. Because these properties are specified in a shared component the EntityManager places the matching entities together in memory so the rendering system can efficiently iterate over them. 

**Note:** Over using shared components can lead to poor Chunk utilization since it involves a combinatorial expansion of the number of memory Chunks required based on archetype and every unique value of each shared component field. Avoid adding unnecessary fields to a shared component Use the [Entity Debugger](ecs_debugging.md) to view the current Chunk utilization.
 
If you add or remove a component from an entity, or change the value of a SharedComponent, The EntityManager moves the entity to a different Chunk, creating a new Chunk if necessary.

System state components behave like normal components or shared components with the exception that when you destroy entities, the EntityManager does not remove any system state components and does not recycle the entity ID until they are removed. This difference in behavior allows a system to cleanup its internal state or free resources when an entity is destroyed.

