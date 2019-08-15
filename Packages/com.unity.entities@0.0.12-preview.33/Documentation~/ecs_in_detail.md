---
uid: ecs-in-detail
---
# ECS features in detail

> **Note**: The main content of this page has migrated to the Unity Data-Oriented reference. ECS related features are listed below in alphabetical order, with a short description and links to further information about it. This page is not an exhaustive list and can be added to over time as ECS, and its related documentation expands. If you spot something that is out-of-date or broken links, then make sure to let us know in the [forums](http://unity3d.com/performance-by-default) or as an [issue](https://github.com/Unity-Technologies/EntityComponentSystemSamples/issues/new) in the repository.

## EntityCommandBufferSystem

When using jobs, you must request command buffers from an entity command buffer system on the main thread, and pass them to the jobs. When the `EntityCommandBufferSystem` updates, the command buffers playback on the main thread in the order they were created. This extra step is required so that memory management can be centralized and determinism of the generated entities and components can be guaranteed.

For more information, see the [EntityCommandBuffer](xref:Unity.Entities.EntityCommandBuffer) reference page.

## Chunk

A `Chunk` contains the `ComponentData` for each entity. All entities in one `Chunk` follow the same memory layout. When iterating over components, memory access of components within a `Chunk` is always completely linear, with no waste loaded into cache lines. This is a hard guarantee.

For more information, see the [Chunk](chunk_iteration.md) reference page.

## ComponentDataFromEntity

If you need to access `ComponentData` on another entity, the only stable way of referencing that component data is via the entity ID. `EntityManager` provides a simple get & set `ComponentData` API for it. However, you can't use the `EntityManager` in a C# job. `ComponentDataFromEntity` gives you a simple API that you can also safely use in a job.

For more information, see the [ComponentDataFromEntity](xref:Unity.Entities.ComponentDataFromEntity`1) reference page.

## EntityQuery

The `EntityQuery` is the foundation class on top of which all iteration methods are built `foreach`, `IJobForEach`, etc.). Essentially a `EntityQuery` is constructed with a set of required components and or subtractive components. `EntityQuery` lets you extract individual arrays of entities based on their components.

For more information, see the [EntityQuery](xref:Unity.Entities.EntityQuery) reference page.

## Entity

An entity is an ID. You can think of it as a super lightweight [GameObject](https://docs.unity3d.com/Manual/GameObjects.html) that does not even have a name by default.

You can add and remove components from entities at runtime. entity ID's are stable. They are the only stable way to store a reference to another component or entity.

For more information, see the [Entity](xref:Unity.Entities.Entity) reference page.

## EntityArchetype

An `EntityArchetype` is a unique array of `ComponentType` structs. The `EntityManager` uses `EntityArchetype`structs to group all entities using the same `ComponentType` structs into `Chunks`.

For more information, see the [EntityArchetype](xref:Unity.Entities.EntityArchetype) reference page.

## EntityCommandBuffer

The `EntityCommandBuffer` abstraction allows you to queue up changes (from either a job or from the main thread) so that they can take effect later on the main thread. 

For more information, see the [EntityCommandBuffer](xref:Unity.Entities.EntityCommandBuffer) reference page.

## EntityManager

`EntityManager` is where you find APIs to create entities, check if an entity is still alive, instantiate entities and add or remove components.

For more information, see the [EntityManager](xref:Unity.Entities.EntityManager) reference page.

## ExclusiveEntityTransaction

`ExclusiveEntityTransaction` is an API to create & destroy entities from a job. The purpose is to enable procedural generation scenarios where instantiation on a big scale must happen in jobs. As the name implies, it is exclusive to any other access to the `EntityManager`.

For more information, see the [ExclusiveEntityTransaction](xref:Unity.Entities.ExclusiveEntityTransaction) reference page.


## IComponentData

`IComponentData` is a pure ECS-style component, meaning that it defines no behavior, only data. `IComponentData` is a struct rather than a class, meaning that it is copied [by value instead of by reference](https://stackoverflow.com/questions/373419/whats-the-difference-between-passing-by-reference-vs-passing-by-value?answertab=votes#tab-top) by default. 

For more information, see the [ComponentData](xref:Unity.Entities.IComponentData) reference page - see "IComponentData."


## JobComponentSystem (Automatic job dependency management)

Managing dependencies is hard, which is why the `JobComponentSystem` does it automatically for you.  The rules are simple: jobs from different systems can read from IComponentData of the same type in parallel. If one of the jobs is writing to the data, then they can't run in parallel and will be scheduled with a dependency between the jobs.

For more information, see the [JobComponentSystem](xref:Unity.Entities.JobComponentSystem) reference page.

## Shared ComponentData

`ISharedComponentData` is useful when many entities have something in common, for example in the `Boid` demo we instantiate many entities from the same [Prefab](https://docs.unity3d.com/Manual/Prefabs.html), and thus the `RenderMesh` between many `Boid` entities is the same. 

For more information, see the [SharedComponentData](xref:Unity.Entities.ISharedComponentData) reference page.

## SystemStateComponentData

The purpose of `SystemStateComponentData` is to allow you to track resources internal to a system and have the opportunity to appropriately create and destroy those resources as needed without relying on individual callbacks.

For more information, see the [SystemStateComponent](xref:Unity.Entities.ISystemStateComponentData) reference page.

## System update order

In ECS all systems are updated on the main thread. Systems update based on a set of constraints and an optimization pass, which tries to order the systems in a way so that the time between scheduling a job and waiting for it is as long as possible.

For more information, see the [System update order](system_update_order.md) reference page.

## World

A `World` owns both an `EntityManager` and a set of `ComponentSystems`. You can create as many `World` objects as you like. Commonly you would create a simulation `World` and rendering or presentation `World`.

For more information, see the [World](xref:Unity.Entities.World) reference page.

