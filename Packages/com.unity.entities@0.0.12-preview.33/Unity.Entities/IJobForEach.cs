using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using Unity.Assertions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using ReadOnlyAttribute = Unity.Collections.ReadOnlyAttribute;

namespace Unity.Entities
{
    //@TODO: What about change or add?
    [AttributeUsage(AttributeTargets.Parameter)]
    public class ChangedFilterAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Struct)]
    public class RequireComponentTagAttribute : Attribute
    {
        public Type[] TagComponents;

        public RequireComponentTagAttribute(params Type[] tagComponents)
        {
            TagComponents = tagComponents;
        }
    }

    [AttributeUsage(AttributeTargets.Struct)]
    public class ExcludeComponentAttribute : Attribute
    {
        public Type[] ExcludeComponents;

        public ExcludeComponentAttribute(params Type[] subtractiveComponents)
        {
            ExcludeComponents = subtractiveComponents;
        }
    }

    public static partial class JobForEachExtensions
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public interface IBaseJobForEach
        {
        }

#if UNITY_DOTSPLAYER
        // Methods used so Tiny code will link / compile, but replaced by codegen.
        //
        // Code-Gen of Schedule()
        // ----------------------
        // Taking the specific example of Schedule(), the steps are:
        //
        // T4 operates on .tt files to generate IJobFerEach.gen.cs. This is
        // done by a developer when the code is written. (T4 is a tool for
        // generating code variations.)
        //
        // A game developer calls job.Schedule(this).Complete() method.
        //
        // After the compiler runs, code-gen runs, which operates on the IL code
        // output from tehe compiler. Code-gen replaces, in IL, the
        // call to Schedule() with the correct variant (Schedule_rD, for example.)
        //
        // Schedule_rD<TJob, T0> would be a job with one read-only Component.
        //
        // Schedule_rD is internal by default, so it can't be directly called from user code.
        // Code gen will also promote it to public.
        //
        // For ComponentData with the [DeallocateOnJobCompletion] Attribute, code-gen is
        // used create the Dispose() calls needed to clean up the resources.

        static internal void DoDeallocateOnJobCompletion(object jobData)
        {
            throw new NotImplementedException("This function should have been replaced by codegen");
        }

        public static JobHandle Schedule<T>(this T jobData, EntityQuery query, JobHandle dependsOn = default(JobHandle))
            where T : struct, IBaseJobForEach
        {
            throw new NotImplementedException("Schedule<T>(EntityQuery query) should have been replaced by code-gen.");
        }

        public static JobHandle Run<T>(this T jobData, EntityQuery query, JobHandle dependsOn = default(JobHandle))
            where T : struct, IBaseJobForEach
        {
            throw new NotImplementedException("Run<T>(EntityQuery query) should have been replaced by code-gen.");
        }

        public static JobHandle ScheduleSingle<T>(this T jobData, EntityQuery query, JobHandle dependsOn = default(JobHandle))
            where T : struct, IBaseJobForEach
        {
            throw new NotImplementedException("ScheduleSingle<T>(EntityQuery query) should have been replaced by code-gen.");
        }


        public unsafe static JobHandle Schedule<TJob>(this TJob job, ComponentSystemBase system, JobHandle dependsOn = default(JobHandle))
            where TJob : struct, IBaseJobForEach
        {
            throw new NotImplementedException("Schedule<TJob>(ComponentSystemBase system) should have been replaced by code-gen.");
        }

        public unsafe static JobHandle Run<TJob>(this TJob job, ComponentSystemBase system, JobHandle dependsOn = default(JobHandle))
            where TJob : struct, IBaseJobForEach
        {
            throw new NotImplementedException("Schedule<TJob>(ComponentSystemBase system) should have been replaced by code-gen.");
        }

        public unsafe static JobHandle ScheduleSingle<TJob>(this TJob job, ComponentSystemBase system, JobHandle dependsOn = default(JobHandle))
            where TJob : struct, IBaseJobForEach
        {
            throw new NotImplementedException("Schedule<TJob>(ComponentSystemBase system) should have been replaced by code-gen.");
        }

#endif


#if !UNITY_DOTSPLAYER
        static ComponentType[] GetComponentTypes(Type jobType)
        {
            var interfaceType = GetIJobForEachInterface(jobType);
            if (interfaceType != null)
            {
                int temp;
                ComponentType[] temp2;
                return GetComponentTypes(jobType, interfaceType, out temp, out temp2);
            }

            return null;
        }

        static ComponentType[] GetComponentTypes(Type jobType, Type interfaceType, out int processCount,
            out ComponentType[] changedFilter)
        {
            var genericArgs = interfaceType.GetGenericArguments();

            var executeMethodParameters = jobType.GetMethod("Execute").GetParameters();

            var componentTypes = new List<ComponentType>();
            var changedFilterTypes = new List<ComponentType>();


            // void Execute(Entity entity, int index, ref T0 data0, ref T1 data1, ref T2 data2);
            // First two parameters are optional, depending on the interface name used.
            var methodParameterOffset = genericArgs.Length != executeMethodParameters.Length ? 2 : 0;

            for (var i = 0; i < genericArgs.Length; i++)
            {
                var isReadonly = executeMethodParameters[i + methodParameterOffset].GetCustomAttribute(typeof(ReadOnlyAttribute)) != null;

                var type = new ComponentType(genericArgs[i],
                    isReadonly ? ComponentType.AccessMode.ReadOnly : ComponentType.AccessMode.ReadWrite);
                componentTypes.Add(type);

                var isChangedFilter = executeMethodParameters[i + methodParameterOffset].GetCustomAttribute(typeof(ChangedFilterAttribute)) != null;
                if (isChangedFilter)
                    changedFilterTypes.Add(type);
            }

            var subtractive = jobType.GetCustomAttribute<ExcludeComponentAttribute>();
            if (subtractive != null)
                foreach (var type in subtractive.ExcludeComponents)
                    componentTypes.Add(ComponentType.Exclude(type));

            var requiredTags = jobType.GetCustomAttribute<RequireComponentTagAttribute>();
            if (requiredTags != null)
                foreach (var type in requiredTags.TagComponents)
                    componentTypes.Add(ComponentType.ReadOnly(type));

            processCount = genericArgs.Length;
            changedFilter = changedFilterTypes.ToArray();
            return componentTypes.ToArray();
        }

        static int CalculateEntityCount(ComponentSystemBase system, Type jobType)
        {
            var query = GetEntityQueryForIJobForEach(system, jobType);

            int entityCount = query.CalculateLength();

            return entityCount;
        }

        static IntPtr GetJobReflection(Type jobType, Type wrapperJobType, Type interfaceType,
            bool isIJobParallelFor)
        {
            Assert.AreNotEqual(null, wrapperJobType);
            Assert.AreNotEqual(null, interfaceType);

            var genericArgs = interfaceType.GetGenericArguments();

            var jobTypeAndGenericArgs = new List<Type>();
            jobTypeAndGenericArgs.Add(jobType);
            jobTypeAndGenericArgs.AddRange(genericArgs);
            var resolvedWrapperJobType = wrapperJobType.MakeGenericType(jobTypeAndGenericArgs.ToArray());

            object[] parameters = {isIJobParallelFor ? JobType.ParallelFor : JobType.Single};
            var reflectionDataRes = resolvedWrapperJobType.GetMethod("Initialize").Invoke(null, parameters);
            return (IntPtr) reflectionDataRes;
        }

        static Type GetIJobForEachInterface(Type jobType)
        {
            foreach (var iType in jobType.GetInterfaces())
                if (iType.Assembly == typeof(IBaseJobForEach).Assembly &&
                    iType.Name.StartsWith("IJobForEach"))
                    return iType;

            return null;
        }

        static void PrepareEntityQuery(ComponentSystemBase system, Type jobType)
        {
            var iType = GetIJobForEachInterface(jobType);

            ComponentType[] filterChanged;
            int processTypesCount;
            var types = GetComponentTypes(jobType, iType, out processTypesCount, out filterChanged);
            system.GetEntityQueryInternal(types);
        }

        static unsafe void Initialize(ComponentSystemBase system, EntityQuery entityQuery, Type jobType, Type wrapperJobType,
            bool isParallelFor, ref JobForEachCache cache, out ProcessIterationData iterator)
        {
        // Get the job reflection data and cache it if we don't already have it cached.
            if (isParallelFor && cache.JobReflectionDataParallelFor == IntPtr.Zero ||
                !isParallelFor && cache.JobReflectionData == IntPtr.Zero)
            {
                var iType = GetIJobForEachInterface(jobType);
                if (cache.Types == null)
                    cache.Types = GetComponentTypes(jobType, iType, out cache.ProcessTypesCount,
                        out cache.FilterChanged);

                var res = GetJobReflection(jobType, wrapperJobType, iType, isParallelFor);

                if (isParallelFor)
                    cache.JobReflectionDataParallelFor = res;
                else
                    cache.JobReflectionData = res;
            }

            // Update cached EntityQuery and ComponentSystem data.
            if (system != null)
            {
                if (cache.ComponentSystem != system)
                {
                    cache.EntityQuery = system.GetEntityQueryInternal(cache.Types);

                    // If the cached filter has changed, update the newly cached EntityQuery with those changes.
                    if (cache.FilterChanged.Length != 0)
                        cache.EntityQuery.SetFilterChanged(cache.FilterChanged);

                    // Otherwise, just reset our newly cached EntityQuery's filter.
                    else
                        cache.EntityQuery.ResetFilter();

                    cache.ComponentSystem = system;
                }
            }
            else if (entityQuery != null)
            {
                if (cache.EntityQuery != entityQuery)
                {
                    // Cache the new EntityQuery and cache that our system is null.
                    cache.EntityQuery = entityQuery;
                    cache.ComponentSystem = null;
                }
            }

            var query = cache.EntityQuery;

            iterator.IsReadOnly0 = iterator.IsReadOnly1 = iterator.IsReadOnly2 = iterator.IsReadOnly3 = iterator.IsReadOnly4 = iterator.IsReadOnly5= 0;
            fixed (int* isReadOnly = &iterator.IsReadOnly0)
            {
                for (var i = 0; i != cache.ProcessTypesCount; i++)
                    isReadOnly[i] = cache.Types[i].AccessModeType == ComponentType.AccessMode.ReadOnly ? 1 : 0;
            }

            iterator.TypeIndex0 = iterator.TypeIndex1 = iterator.TypeIndex2 = iterator.TypeIndex3 = iterator.TypeIndex4 = iterator.TypeIndex5 = -1;
            fixed (int* typeIndices = &iterator.TypeIndex0)
            {
                for (var i = 0; i != cache.ProcessTypesCount; i++)
                    typeIndices[i] = cache.Types[i].TypeIndex;
            }

            iterator.m_IsParallelFor = isParallelFor;
            iterator.m_Length = query.CalculateNumberOfChunksWithoutFiltering();

            iterator.GlobalSystemVersion = query.GetComponentChunkIterator().m_GlobalSystemVersion;

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            iterator.m_MaxIndex = iterator.m_Length - 1;
            iterator.m_MinIndex = 0;

            iterator.m_Safety0 = iterator.m_Safety1 = iterator.m_Safety2 = iterator.m_Safety3 = iterator.m_Safety4 =
 iterator.m_Safety5 = default(AtomicSafetyHandle);

            iterator.m_SafetyReadOnlyCount = 0;
            fixed (AtomicSafetyHandle* safety = &iterator.m_Safety0)
            {
                for (var i = 0; i != cache.ProcessTypesCount; i++)
                    if (cache.Types[i].AccessModeType == ComponentType.AccessMode.ReadOnly)
                    {
                        safety[iterator.m_SafetyReadOnlyCount] =
                            query.GetSafetyHandle(query.GetIndexInEntityQuery(cache.Types[i].TypeIndex));
                        iterator.m_SafetyReadOnlyCount++;
                    }
            }

            iterator.m_SafetyReadWriteCount = 0;
            fixed (AtomicSafetyHandle* safety = &iterator.m_Safety0)
            {
                for (var i = 0; i != cache.ProcessTypesCount; i++)
                    if (cache.Types[i].AccessModeType == ComponentType.AccessMode.ReadWrite)
                    {
                        safety[iterator.m_SafetyReadOnlyCount + iterator.m_SafetyReadWriteCount] =
                            query.GetSafetyHandle(query.GetIndexInEntityQuery(cache.Types[i].TypeIndex));
                        iterator.m_SafetyReadWriteCount++;
                    }
            }

            iterator.m_BufferSafety0 = iterator.m_BufferSafety1 = iterator.m_BufferSafety2 = iterator.m_BufferSafety3 = iterator.m_BufferSafety4 =
                iterator.m_BufferSafety5 = default(AtomicSafetyHandle);

            fixed (AtomicSafetyHandle* safety = &iterator.m_BufferSafety0)
            {
                for (var i = 0; i != cache.ProcessTypesCount; i++)
                    if(cache.Types[i].IsBuffer)
                        safety[i] = query.GetBufferSafetyHandle(query.GetIndexInEntityQuery(cache.Types[i].TypeIndex));
            }

            Assert.AreEqual(cache.ProcessTypesCount, iterator.m_SafetyReadWriteCount + iterator.m_SafetyReadOnlyCount);
#endif
        }

        internal struct JobForEachCache
        {
            public IntPtr JobReflectionData;
            public IntPtr JobReflectionDataParallelFor;
            public ComponentType[] Types;
            public ComponentType[] FilterChanged;

            public int ProcessTypesCount;

            public EntityQuery EntityQuery;
            public ComponentSystemBase ComponentSystem;
        }

        [NativeContainer]
        [NativeContainerSupportsMinMaxWriteRestriction]
        [StructLayout(LayoutKind.Sequential)]
        internal struct ProcessIterationData
        {
            public uint GlobalSystemVersion;

            public int TypeIndex0;
            public int TypeIndex1;
            public int TypeIndex2;
            public int TypeIndex3;
            public int TypeIndex4;
            public int TypeIndex5;

            public int IsReadOnly0;
            public int IsReadOnly1;
            public int IsReadOnly2;
            public int IsReadOnly3;
            public int IsReadOnly4;
            public int IsReadOnly5;

            public bool m_IsParallelFor;

            public int m_Length;

#if ENABLE_UNITY_COLLECTIONS_CHECKS

            public int m_MinIndex;
            public int m_MaxIndex;

#pragma warning disable 414
            public int m_SafetyReadOnlyCount;
            public int m_SafetyReadWriteCount;
            public AtomicSafetyHandle m_Safety0;
            public AtomicSafetyHandle m_Safety1;
            public AtomicSafetyHandle m_Safety2;
            public AtomicSafetyHandle m_Safety3;
            public AtomicSafetyHandle m_Safety4;
            public AtomicSafetyHandle m_Safety5;

            public AtomicSafetyHandle m_BufferSafety0;
            public AtomicSafetyHandle m_BufferSafety1;
            public AtomicSafetyHandle m_BufferSafety2;
            public AtomicSafetyHandle m_BufferSafety3;
            public AtomicSafetyHandle m_BufferSafety4;
            public AtomicSafetyHandle m_BufferSafety5;
#pragma warning restore
#endif
        }

        public static EntityQuery GetEntityQueryForIJobForEach(this ComponentSystemBase system,
            Type jobType)
        {
            var types = GetComponentTypes(jobType);
            if (types != null)
                return system.GetEntityQueryInternal(types);
            else
                return null;
        }

        //NOTE: It would be much better if C# could resolve the branch with generic resolving,
        //      but apparently the interface constraint is not enough..

        public static void PrepareEntityQuery<T>(this T jobData, ComponentSystemBase system)
            where T : struct, IBaseJobForEach
        {
            PrepareEntityQuery(system, typeof(T));
        }

        public static int CalculateEntityCount<T>(this T jobData, ComponentSystemBase system)
            where T : struct, IBaseJobForEach
        {
            return CalculateEntityCount(system, typeof(T));
        }

        static unsafe JobHandle Schedule(void* fullData, NativeArray<byte> prefilterData, int unfilteredLength, int innerloopBatchCount,
            bool isParallelFor, bool isFiltered, ref JobForEachCache cache, void* deferredCountData, JobHandle dependsOn, ScheduleMode mode)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            try
            {
#endif
            if (isParallelFor)
            {
                var scheduleParams = new JobsUtility.JobScheduleParameters(fullData, cache.JobReflectionDataParallelFor, dependsOn, mode);
                if(isFiltered)
                    return JobsUtility.ScheduleParallelForDeferArraySize(ref scheduleParams, innerloopBatchCount, deferredCountData, null);
                else
                    return JobsUtility.ScheduleParallelFor(ref scheduleParams, unfilteredLength, innerloopBatchCount);
            }
            else
            {
                var scheduleParams = new JobsUtility.JobScheduleParameters(fullData, cache.JobReflectionData, dependsOn, mode);
                return JobsUtility.Schedule(ref scheduleParams);
            }
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            }
            catch (InvalidOperationException e)
            {
                prefilterData.Dispose();
                throw e;
            }
#endif
        }
#endif
    }
}
