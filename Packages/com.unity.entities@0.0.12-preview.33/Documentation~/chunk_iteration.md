---
uid: ecs-iteration
---
# Accessing entity data

Iterating over your data is one of the most common tasks you will perform when implementing an ECS system. ECS systems typically process a set of entities, reading data from one or more components, performing a calculation, and then writing the result to another component.

In general, the most efficient way to iterate over your entities and components is in a parallelizable Job that processes the components in order. This takes advantage of processing power from all available cores and data locality to avoid CPU cache misses. 

The ECS API provides a number of ways to accomplish iteration, each with its own performance implications and restrictions. You can iterate over ECS data in the following ways:

* [IJobForEach](entity_iteration_job.md) — the simplest efficient way to process component data entity by entity.

* [IJobForEachWithEntity](entity_iteration_job.md#with-entity) — slightly more complex than IJobForEach, giving you access to the entity handle and array index of the entity you are processing.

* [IJobChunk](chunk_iteration_job.md) — iterates over the eligible blocks of memory (called a *Chunk*) containing matching entities. Your Job Execute() function can iterate over the Elements inside each chunk using a for loop. You can use IJobChunk for more complex situations than supported by IJobForEach, while maintaining maximum efficiency. 

* [ComponentSystem](entity_iteration_foreach.md) — the ComponentSystem offers the Entities.ForEach delegate functions to help iterate over your entities. However, ForEach runs on the main thread, so typically, you should only use ComponentSystem implementations for tasks that must be carried out on the main thread anyway. 

* [Manual iteration](manual_iteration.md) — if the previous methods are insufficient, you can manually iterate over entities or chunks. For example, you can get a NativeArray containing entities or the chunks of the entities that you want to process and iterate over them using a Job, such as IJobParallelFor.

The [EntityQuery](component_group.md) class provides a way to construct a view of your data that contains only the specific data you need for a given algorithm or process. Many of the iteration methods in the list above use a EntityQuery, either explicitly or internally.