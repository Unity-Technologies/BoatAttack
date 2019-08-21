using System;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Entities
{
#if !UNITY_DOTSPLAYER
    [JobProducerType(typeof(JobChunkExtensions.JobChunk_Process<>))]
#endif
    public interface IJobChunk
    {
        // firstEntityIndex refers to the index of the first entity in the current chunk within the EntityQuery the job was scheduled with
        // For example, if the job operates on 3 chunks with 20 entities each, then the firstEntityIndices will be [0, 20, 40] respectively
        void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex);
    }

    public static class JobChunkExtensions
    {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
        [NativeContainer]
        internal struct EntitySafetyHandle
        {
            public AtomicSafetyHandle m_Safety;
        }
#endif

        internal struct JobChunkData<T> where T : struct
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
#pragma warning disable 414
            [ReadOnly] public EntitySafetyHandle safety;
#pragma warning restore
#endif
            public T Data;          

            [DeallocateOnJobCompletion]
            [NativeDisableContainerSafetyRestriction]
            public NativeArray<byte> PrefilterData;
        }
        
        public static unsafe JobHandle Schedule<T>(this T jobData, EntityQuery query, JobHandle dependsOn = default(JobHandle))
            where T : struct, IJobChunk
        {
            return ScheduleInternal(ref jobData, query, dependsOn, ScheduleMode.Batched);
        }

        public static void Run<T>(this T jobData, EntityQuery query)
            where T : struct, IJobChunk
        {
            ScheduleInternal(ref jobData, query, default(JobHandle), ScheduleMode.Run);
        }

#if !UNITY_DOTSPLAYER
        internal static unsafe JobHandle ScheduleInternal<T>(ref T jobData, EntityQuery query, JobHandle dependsOn, ScheduleMode mode)
            where T : struct, IJobChunk
        {
            ComponentChunkIterator iterator = query.GetComponentChunkIterator();
            
            var unfilteredChunkCount = query.CalculateNumberOfChunksWithoutFiltering();

            var prefilterHandle = ComponentChunkIterator.PreparePrefilteredChunkLists(unfilteredChunkCount,
                iterator.m_MatchingArchetypeList, iterator.m_Filter, dependsOn, mode, out var prefilterData,
                out var deferredCountData);

            JobChunkData<T> fullData = new JobChunkData<T>
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                // All IJobChunk jobs have a EntityManager safety handle to ensure that BeforeStructuralChange throws an error if
                // jobs without any other safety handles are still running (haven't been synced).
                safety = new EntitySafetyHandle{m_Safety = query.SafetyManager->GetEntityManagerSafetyHandle()},
#endif
                Data = jobData,
                PrefilterData = prefilterData,
            };

            var scheduleParams = new JobsUtility.JobScheduleParameters(
                UnsafeUtility.AddressOf(ref fullData),
                JobChunk_Process<T>.Initialize(),
                prefilterHandle,
                mode);           
      
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            try 
            {          
#endif
            if(mode == ScheduleMode.Batched)
                return JobsUtility.ScheduleParallelForDeferArraySize(ref scheduleParams, 1, deferredCountData, null);
            else
            {
                var count = unfilteredChunkCount;
                return JobsUtility.ScheduleParallelFor(ref scheduleParams, count, 1);
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

        internal struct JobChunk_Process<T>
            where T : struct, IJobChunk
        {
            public static IntPtr jobReflectionData;

            public static IntPtr Initialize()
            {
                if (jobReflectionData == IntPtr.Zero)
                    jobReflectionData = JobsUtility.CreateJobReflectionData(typeof(JobChunkData<T>),
                        typeof(T), JobType.ParallelFor, (ExecuteJobFunction)Execute);

                return jobReflectionData;
            }
            public delegate void ExecuteJobFunction(ref JobChunkData<T> data, System.IntPtr additionalPtr, System.IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);

            public unsafe static void Execute(ref JobChunkData<T> jobData, System.IntPtr additionalPtr, System.IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex)
            {
                ExecuteInternal(ref jobData, ref ranges, jobIndex);
            }

            internal unsafe static void ExecuteInternal(ref JobChunkData<T> jobData, ref JobRanges ranges, int jobIndex)
            {
                ComponentChunkIterator.UnpackPrefilterData(jobData.PrefilterData, out var filteredChunks, out var entityIndices, out var chunkCount);
                
                int chunkIndex, end;
                while (JobsUtility.GetWorkStealingRange(ref ranges, jobIndex, out chunkIndex, out end))
                {
                    var chunk = filteredChunks[chunkIndex];
                    var entityOffset = entityIndices[chunkIndex];
                    
                    jobData.Data.Execute(chunk, chunkIndex, entityOffset);
                }
            }
        }
#else
        internal static unsafe JobHandle ScheduleInternal<T>(ref T jobData, EntityQuery query, JobHandle dependsOn, ScheduleMode mode)
            where T : struct, IJobChunk
        {
            using (var chunks = query.CreateArchetypeChunkArray(Allocator.Temp))
            {
                int currentChunk = 0;
                int currentEntity = 0;
                foreach (var chunk in chunks)
                {
                    jobData.Execute(chunk, currentChunk, currentEntity);
                    currentChunk++;
                    currentEntity += chunk.Count;
                }
            }

            DoDeallocateOnJobCompletion(jobData);

            return new JobHandle();
        }

        static internal void DoDeallocateOnJobCompletion(object jobData)
        {
            throw new NotImplementedException("This function should have been replaced by codegen");
        }
#endif
    }
}
