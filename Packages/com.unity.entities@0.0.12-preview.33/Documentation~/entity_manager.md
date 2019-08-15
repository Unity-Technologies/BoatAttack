---
uid: ecs-entity-manager
---
# EntityManager

The `EntityManager` owns `EntityData`, [EntityArchetypes](xref:Unity.Entities.EntityArchetype), [SharedComponentData](xref:Unity.Entities.ISharedComponentData) and [EntityQuery](xref:Unity.Entities.EntityQuery).

`EntityManager` is where you find APIs to create entities, check if an entity is still alive, instantiate entities and add or remove components.

```cs
// Create an entity with no components on it
var entity = EntityManager.CreateEntity();

// Adding a component at runtime
EntityManager.AddComponent(entity, new MyComponentData());

// Get the ComponentData
MyComponentData myData = EntityManager.GetComponentData<MyComponentData>(entity);

// Set the ComponentData
EntityManager.SetComponentData(entity, myData);

// Removing a component at runtime
EntityManager.RemoveComponent<MyComponentData>(entity);

// Does the entity exist and does it have the component?
bool has = EntityManager.HasComponent<MyComponentData>(entity);

// Is the entity still alive?
bool has = EntityManager.Exists(entity);

// Instantiate the entity
var instance = EntityManager.Instantiate(entity);

// Destroy the created instance
EntityManager.DestroyEntity(instance);
```

```cs
// EntityManager also provides batch APIs
// to create and destroy many entities in one call. 
// They are significantly faster 
// and should be used where ever possible
// for performance reasons.

// Instantiate 500 entities and write the resulting entity IDs to the instances array
var instances = new NativeArray<Entity>(500, Allocator.Temp);
EntityManager.Instantiate(entity, instances);

// Destroy all 500 entities
EntityManager.DestroyEntity(instances);
```

