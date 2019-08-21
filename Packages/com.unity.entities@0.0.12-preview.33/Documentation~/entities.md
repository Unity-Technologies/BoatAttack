# Entity

`Entity` is an ID. You can think of it as a super lightweight [GameObject](https://docs.unity3d.com/Manual/class-GameObject.html) that does not even have a name by default.

You can add and remove components from entities at runtime. entity ID's are stable. They are the only stable way to store a reference to another component or entity.

You can add and remove components from entities at runtime in much the same way as a `GameObject`. Entities can be created from [Prefabs](https://docs.unity3d.com/Manual/Prefabs.html) by using `ComponentDataProxy`. The `EntityManager` will parse the Prefab for [ComponentData](component_data.md) and add it when it creates the entity. 

## Iterating entities

Iterating over all entities that have a matching set of components, is at the center of the ECS architecture.

