---
uid: ecs-job-extensions
---
# Job extensions

The Unity C# Job System lets you run code on multiple threads. The system provides scheduling, 
parallel processing, and multi-threaded safety. The Job System is a core Unity module that provides 
the general purpose interfaces and classes for creating and running jobs (whether or not you are using ECS). 
These interfaces include:

* [IJob](https://docs.unity3d.com/ScriptReference/Unity.Jobs.IJob.html) — create a Job that runs on any thread or core, as determined by the Job System scheduler.
* [IJobParallelFor](https://docs.unity3d.com/ScriptReference/Unity.Jobs.IJobParallelFor.html) — create a Job that can run on multiple threads in parallel to process the elements of a [NativeContainer](https://docs.unity3d.com/Manual/JobSystemNativeContainer.html).
* [IJobExtensions](https://docs.unity3d.com/ScriptReference/Unity.Jobs.IJobExtensions.html) — provides extension methods for running IJobs.
* [IJobParalllelForExtensions](https://docs.unity3d.com/ScriptReference/Unity.Jobs.IJobParallelForExtensions.html)— provides extension methods for running IJobParallelFor jobs.
* [JobHandle](https://docs.unity3d.com/ScriptReference/Unity.Jobs.JobHandle.html) — a handle for accessing a scheduled job. `JobHandle` instances also allow you to specify dependencies between Jobs.

For an overview of the Jobs System see [C# Job System](https://docs.unity3d.com/Manual/JobSystemSafetySystem.html) in the Unity Manual.

The Jobs package extends the Job System to support ECS. It contains:

* [IJobParallelForDeferExtensions](https://docs.unity3d.com/Packages/com.unity.jobs@0.0/api/Unity.Jobs.IJobParallelForDeferExtensions.html)
* [IJobParallelForFilter](https://docs.unity3d.com/Packages/com.unity.jobs@0.0/api/Unity.Jobs.IJobParallelForFilter.html)
* [JobParallelIndexListExtensions](https://docs.unity3d.com/Packages/com.unity.jobs@0.0/api/Unity.Jobs.JobParallelIndexListExtensions.html)
* [Job​Struct​Produce<T>](https://docs.unity3d.com/Packages/com.unity.jobs@0.0/api/Unity.Jobs.JobParallelIndexListExtensions.JobStructProduce-1.html)

