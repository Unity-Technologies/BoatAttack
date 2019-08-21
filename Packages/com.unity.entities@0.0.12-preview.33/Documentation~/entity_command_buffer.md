---
uid: ecs-entity-command-buffer
---
# Entity Command Buffer

The `EntityCommandBuffer` class solves two important problems:

1. When you're in a job, you can't access the `EntityManager`.
2. When you access the `EntityManager` (to say, create an entity) you invalidate all injected arrays and `EntityQuery` objects.

The `EntityCommandBuffer` abstraction allows you to queue up changes (from either a job or from the main thread) so that they can take effect later on the main thread. There are two ways to use a `EntityCommandBuffer`:

`ComponentSystem` subclasses which update on the main thread have one available automatically called `PostUpdateCommands`. To use it, simply reference the attribute and queue up your changes. They will be automatically applied to the world immediately after you return from your system's `Update` function.

Here's an example:

```cs
PostUpdateCommands.CreateEntity(TwoStickBootstrap.BasicEnemyArchetype);
PostUpdateCommands.SetComponent(new Position2D { Value = spawnPosition });
PostUpdateCommands.SetComponent(new Heading2D { Value = new float2(0.0f, -1.0f) });
PostUpdateCommands.SetComponent(default(Enemy));
PostUpdateCommands.SetComponent(new Health { Value = TwoStickBootstrap.Settings.enemyInitialHealth });
PostUpdateCommands.SetComponent(new EnemyShootState { Cooldown = 0.5f });
PostUpdateCommands.SetComponent(new MoveSpeed { speed = TwoStickBootstrap.Settings.enemySpeed });
PostUpdateCommands.AddSharedComponent(TwoStickBootstrap.EnemyLook);
```

As you can see, the API is very similar to the `EntityManager` API. In this mode, it is helpful to think of the automatic `EntityCommandBuffer` as a convenience that allows you to prevent array invalidation inside your system while still making changes to the world.

For jobs, you must request `EntityCommandBuffer` from a entity command buffer system on the main thread, and pass them to jobs. When the `EntityCommandBufferSystem` updates, the command buffers will play back on the main thread in the order they were created. This extra step is required so that memory management can be centralized and determinism of the generated entities and components can be guaranteed.

Again let's look at the two stick shooter sample to see how this works in practice.

## Entity Command Buffer Systems

The default World initialization provides three system groups, for initialization, simulation, and presentation, that are updated in order each frame. Within a group, there is an entity command buffer system that runs before any other system in the group and another that runs after all other systems in the group. Preferably, you should use one of the existing command buffer systems rather than creating your own in order to minimize synchronization points. See [Default System Groups](system_update_order.md) for a list of the default groups and command buffer systems.

## Using EntityCommandBuffers from ParallelFor jobs

When using an `EntityCommandBuffer` to issue `EntityManager` commands from [ParallelFor jobs](https://docs.unity3d.com/Manual/JobSystemParallelForJobs.html), the `EntityCommandBuffer.Concurrent` interface is used to guarantee thread safety and deterministic playback. The public methods in this interface take an extra `jobIndex` parameter, which is used to playback the recorded commands in a deterministic order. The `jobIndex` must be a unique ID for each job. For performance reasons, `jobIndex` should be the (increasing) `index` values passed to `IJobParallelFor.Execute()`. Unless you *really* know what you're doing, using the `index` as `jobIndex` is the safest choice. Using other `jobIndex` values will produce the correct output, but can have severe performance implications in some cases.

