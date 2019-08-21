using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Unity.Entities
{
    public sealed unsafe partial class EntityManager
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("CreateComponentGroup has been renamed to CreateEntityQuery. (UnityUpgradable) -> CreateEntityQuery(Unity.Entities.ComponentType[])", true)]
        public ComponentGroup CreateComponentGroup(params ComponentType[] requiredComponents)
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("CreateComponentGroup has been renamed to CreateEntityQuery. (UnityUpgradable) -> CreateEntityQuery(Unity.Entities.EntityQueryDesc[])", true)]
        public ComponentGroup CreateComponentGroup(params EntityArchetypeQuery[] queriesDesc)
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("UniversalGroup has been renamed to UniversalQuery. (UnityUpgradable) -> UniversalQuery", true)]
        public EntityQuery UniversalGroup => null;
    }

    [Obsolete("EntityArchetypeQuery has been renamed to EntityQueryDesc. (UnityUpgradable) -> EntityQueryDesc", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class EntityArchetypeQuery
    {
        public ComponentType[] Any = null;
        public ComponentType[] None = null;
        public ComponentType[] All = null;
        public EntityArchetypeQueryOptions Options = EntityArchetypeQueryOptions.Default;
    }

    [Flags]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("EntityArchetypeQueryOptions has been renamed to EntityQueryOptions. (UnityUpgradable) -> EntityQueryOptions", true)]
    public enum EntityArchetypeQueryOptions
    {
        Default = 0,
        IncludePrefab = 1,
        IncludeDisabled = 2,
        FilterWriteGroup = 4,
    }

    [Obsolete("ComponentGroupExtensionsForComponentArray has been renamed to EntityQueryExtensionsForComponentArray. (UnityUpgradable) -> EntityQueryExtensionsForComponentArray", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ComponentGroupExtensionsForComponentArray
    {
    }

    [Obsolete("ComponentGroupExtensionsForTransformAccessArray has been renamed to EntityQueryExtensionsForTransformAccessArray. (UnityUpgradable) -> EntityQueryExtensionsForTransformAccessArray", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ComponentGroupExtensionsForTransformAccessArray
    {
    }

    public unsafe abstract partial class ComponentSystemBase
    {
        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetComponentGroup has been renamed to GetEntityQuery. (UnityUpgradable) -> GetEntityQuery(Unity.Entities.ComponentType[])", true)]
        public ComponentGroup GetComponentGroup(params ComponentType[] componentTypes)
        {
            throw new NotImplementedException();
        }

        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetComponentGroup has been renamed to GetEntityQuery. (UnityUpgradable) -> GetEntityQuery(Unity.Collections.NativeArray<ComponentType>)", true)]
        public ComponentGroup GetComponentGroup(NativeArray<ComponentType> componentTypes)
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetComponentGroup has been renamed to GetEntityQuery. (UnityUpgradable) -> GetEntityQuery(Unity.Entities.EntityQueryDesc[])", true)]
        public ComponentGroup GetComponentGroup(params EntityArchetypeQuery[] queryDesc)
        {
            throw new NotImplementedException();
        }
    }

#if !NET_DOTS
    // tHe script updater cannot handle interface updates, but we can make things work
    // by inheriting from the new ones (with an obsolete warning)
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("IJobProcessComponentData has been renamed to IBaseJobForEach")]
    public interface IBaseJobProcessComponentData : JobForEachExtensions.IBaseJobForEach
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("IJobProcessComponentData has been renamed to IJobForEach")]
    public interface IJobProcessComponentData<U0> : IJobForEach<U0>
            where U0 : struct, IComponentData
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("IJobProcessComponentDataWithEntity has been renamed to IJobForEachWithEntity")]
    public interface IJobProcessComponentDataWithEntity<U0> : IJobForEachWithEntity<U0>
            where U0 : struct, IComponentData
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("IJobProcessComponentData has been renamed to IJobForEach")]
    public interface IJobProcessComponentData<U0, U1> : IJobForEach<U0, U1>
            where U0 : struct, IComponentData
            where U1 : struct, IComponentData
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("IJobProcessComponentDataWithEntity has been renamed to IJobForEachWithEntity")]
    public interface IJobProcessComponentDataWithEntity<U0, U1> : IJobForEachWithEntity<U0, U1>
            where U0 : struct, IComponentData
            where U1 : struct, IComponentData
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("IJobProcessComponentData has been renamed to IJobForEach")]
    public interface IJobProcessComponentData<U0, U1, U2> : IJobForEach<U0, U1, U2>
            where U0 : struct, IComponentData
            where U1 : struct, IComponentData
            where U2 : struct, IComponentData
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("IJobProcessComponentDataWithEntity has been renamed to IJobForEachWithEntity")]
    public interface IJobProcessComponentDataWithEntity<U0, U1, U2> : IJobForEachWithEntity<U0, U1, U2>
            where U0 : struct, IComponentData
            where U1 : struct, IComponentData
            where U2 : struct, IComponentData
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("IJobProcessComponentData has been renamed to IJobForEach")]
    public interface IJobProcessComponentData<U0, U1, U2, U3> : IJobForEach<U0, U1, U2, U3>
            where U0 : struct, IComponentData
            where U1 : struct, IComponentData
            where U2 : struct, IComponentData
            where U3 : struct, IComponentData
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("IJobProcessComponentDataWithEntity has been renamed to IJobForEachWithEntity")]
    public interface IJobProcessComponentDataWithEntity<U0, U1, U2, U3> : IJobForEachWithEntity<U0, U1, U2, U3>
            where U0 : struct, IComponentData
            where U1 : struct, IComponentData
            where U2 : struct, IComponentData
            where U3 : struct, IComponentData
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("IJobProcessComponentData has been renamed to IJobForEach")]
    public interface IJobProcessComponentData<U0, U1, U2, U3, U4> : IJobForEach<U0, U1, U2, U3, U4>
            where U0 : struct, IComponentData
            where U1 : struct, IComponentData
            where U2 : struct, IComponentData
            where U3 : struct, IComponentData
            where U4 : struct, IComponentData
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("IJobProcessComponentDataWithEntity has been renamed to IJobForEachWithEntity")]
    public interface IJobProcessComponentDataWithEntity<U0, U1, U2, U3, U4> : IJobForEachWithEntity<U0, U1, U2, U3, U4>
            where U0 : struct, IComponentData
            where U1 : struct, IComponentData
            where U2 : struct, IComponentData
            where U3 : struct, IComponentData
            where U4 : struct, IComponentData
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("IJobProcessComponentData has been renamed to IJobForEach")]
    public interface IJobProcessComponentData<U0, U1, U2, U3, U4, U5> : IJobForEach<U0, U1, U2, U3, U4, U5>
            where U0 : struct, IComponentData
            where U1 : struct, IComponentData
            where U2 : struct, IComponentData
            where U3 : struct, IComponentData
            where U4 : struct, IComponentData
            where U5 : struct, IComponentData
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("IJobProcessComponentDataWithEntity has been renamed to IJobForEachWithEntity")]
    public interface IJobProcessComponentDataWithEntity<U0, U1, U2, U3, U4, U5> : IJobForEachWithEntity<U0, U1, U2, U3, U4, U5>
            where U0 : struct, IComponentData
            where U1 : struct, IComponentData
            where U2 : struct, IComponentData
            where U3 : struct, IComponentData
            where U4 : struct, IComponentData
            where U5 : struct, IComponentData
    {
    }

    // The script updater does not seem to handle extension methods?
    public static partial class JobForEachExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetComponentGroupForIJobProcessComponentData has been renamed to GetEntityQueryForIJobForEach.")]
        public static EntityQuery GetComponentGroupForIJobProcessComponentData(this ComponentSystemBase system, Type jobType)
        {
            return system.GetEntityQueryForIJobForEach(jobType);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("PrepareComponentGroup has been renamed to PrepareEntityQuery.")]
        public static void PrepareComponentGroup<T>(this T jobData, ComponentSystemBase system)
            where T : struct, JobForEachExtensions.IBaseJobForEach
        {
            jobData.PrepareEntityQuery(system);
        }

        // these could be useful, but the script updater will make the ComponentGroup -> EntityQuery change without seeing these,
        // so we have to have methods that have EntityQuery as the param, not ComponentGroup
#if false
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("GetComponentGroupForIJobProcessComponentData has been renamed to GetEntityQueryForIJobForEach. (UnityUpgradable) -> GetEntityQueryForIJobForEach(*)")]
        public static ComponentGroup GetComponentGroupForIJobProcessComponentData(this ComponentSystemBase system, Type jobType)
        {
            return system.GetEntityQueryForIJobForEach(jobType);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ScheduleGroup has been renamed to Schedule. (UnityUpgradable) -> Schedule<T>(*)", true)]
        public static JobHandle ScheduleGroup<T>(this T jobData, ComponentGroup cg, JobHandle dependsOn = default(JobHandle))
            where T : struct, JobForEachExtensions.IBaseJobForEach
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ScheduleGroupSingle has been renamed to ScheduleSingle. (UnityUpgradable) -> ScheduleSingle<T>(*)", true)]
        public static JobHandle ScheduleGroupSingle<T>(this T jobData, ComponentGroup cg, JobHandle dependsOn = default(JobHandle))
            where T : struct, JobForEachExtensions.IBaseJobForEach
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("RunGroup has been renamed to Run. (UnityUpgradable) -> Run<T>(*)", true)]
        public static JobHandle RunGroup<T>(this T jobData, ComponentGroup cg, JobHandle dependsOn = default(JobHandle))
            where T : struct, JobForEachExtensions.IBaseJobForEach
        {
            throw new NotImplementedException();
        }
#endif

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ScheduleGroup has been renamed to Schedule.")]
        public static JobHandle ScheduleGroup<T>(this T jobData, EntityQuery cg, JobHandle dependsOn = default(JobHandle))
            where T : struct, JobForEachExtensions.IBaseJobForEach
        {
            return jobData.Schedule(cg, dependsOn);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ScheduleGroupSingle has been renamed to ScheduleSingle.")]
        public static JobHandle ScheduleGroupSingle<T>(this T jobData, EntityQuery cg, JobHandle dependsOn = default(JobHandle))
            where T : struct, JobForEachExtensions.IBaseJobForEach
        {
            return jobData.ScheduleSingle(cg, dependsOn);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("RunGroup has been renamed to Run.")]
        public static JobHandle RunGroup<T>(this T jobData, EntityQuery cg, JobHandle dependsOn = default(JobHandle))
            where T : struct, JobForEachExtensions.IBaseJobForEach
        {
            return jobData.Run(cg, dependsOn);
        }
    }
#endif

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("ComponentGroup has been renamed to EntityQuery. (UnityUpgradable) -> EntityQuery", true)]
    public class ComponentGroup : IDisposable
    {
        public bool IsEmptyIgnoreFilter
        {
            get { throw new NotImplementedException(); }
        }

        public int CalculateLength()
        {
            throw new NotImplementedException();
        }

        public NativeArray<ArchetypeChunk> CreateArchetypeChunkArray(Allocator allocator, out JobHandle jobhandle)
        {
            throw new NotImplementedException();
        }

        public NativeArray<ArchetypeChunk> CreateArchetypeChunkArray(Allocator allocator)
        {
            throw new NotImplementedException();
        }


        public NativeArray<Entity> ToEntityArray(Allocator allocator, out JobHandle jobhandle)
        {
            throw new NotImplementedException();
        }

        public NativeArray<Entity> ToEntityArray(Allocator allocator)
        {
            throw new NotImplementedException();
        }

        public NativeArray<T> ToComponentDataArray<T>(Allocator allocator, out JobHandle jobhandle)
            where T : struct, IComponentData
        {
            throw new NotImplementedException();
        }

        public NativeArray<T> ToComponentDataArray<T>(Allocator allocator)
            where T : struct, IComponentData
        {
            throw new NotImplementedException();
        }

        public void CopyFromComponentDataArray<T>(NativeArray<T> componentDataArray)
            where T : struct, IComponentData
        {
            throw new NotImplementedException();
        }

        public void CopyFromComponentDataArray<T>(NativeArray<T> componentDataArray, out JobHandle jobhandle)
            where T : struct, IComponentData
        {
            throw new NotImplementedException();
        }

        public Entity GetSingletonEntity()
        {
            throw new NotImplementedException();
        }

        public T GetSingleton<T>()
            where T : struct, IComponentData
        {
            throw new NotImplementedException();
        }

        public void SetSingleton<T>(T value)
            where T : struct, IComponentData
        {
            throw new NotImplementedException();
        }

        public bool CompareComponents(ComponentType[] componentTypes)
        {
            throw new NotImplementedException();
        }

        public bool CompareComponents(NativeArray<ComponentType> componentTypes)
        {
            throw new NotImplementedException();
        }

        public bool CompareQuery(EntityArchetypeQuery[] queryDesc)
        {
            throw new NotImplementedException();
        }

        public void ResetFilter()
        {
            throw new NotImplementedException();
        }

        public void SetFilter<SharedComponent1>(SharedComponent1 sharedComponent1)
            where SharedComponent1 : struct, ISharedComponentData
        {
            throw new NotImplementedException();
        }

        public void SetFilter<SharedComponent1, SharedComponent2>(SharedComponent1 sharedComponent1,
            SharedComponent2 sharedComponent2)
            where SharedComponent1 : struct, ISharedComponentData
            where SharedComponent2 : struct, ISharedComponentData
        {
            throw new NotImplementedException();
        }

        public void SetFilterChanged(ComponentType componentType)
        {
            throw new NotImplementedException();
        }

        public void SetFilterChanged(ComponentType[] componentType)
        {
            throw new NotImplementedException();
        }

        public void CompleteDependency()
        {
            throw new NotImplementedException();
        }

        public JobHandle GetDependency()
        {
            throw new NotImplementedException();
        }

        public void AddDependency(JobHandle job)
        {
            throw new NotImplementedException();
        }

        public int GetCombinedComponentOrderVersion()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
