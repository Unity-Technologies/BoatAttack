using System;
using Unity.Assertions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine.Profiling;

namespace Unity.Entities
{

    /// <summary>
    /// The ComponentJobSafetyManager maintains a safety handle for each component type registered in the TypeManager.
    /// It also maintains JobHandles for each type with any jobs that read or write those component types.
    /// Safety and job handles are only maintained for components that can be modified by jobs:
    /// That means only dynamic buffer components and component data that are not tag components will have valid
    /// safety and job handles. For those components the safety handle represents ReadOnly or ReadWrite access to those
    /// components as well as their change versions.
    /// The Entity type is a special case: It can not be modified by jobs and its safety handle is used to represent the
    /// entire EntityManager state. Any job reading from any part of the EntityManager must contain either a safety handle
    /// for the Entity type OR a safety handle for any other component type.
    /// Job component systems that have no other type dependencies have their JobHandles registered on the Entity type
    /// to ensure that they are completed by CompleteAllJobsAndInvalidateArrays
    /// </summary>
    internal unsafe struct ComponentJobSafetyManager
    {
        private const int kMaxReadJobHandles = 17;
        private const int kMaxTypes = TypeManager.MaximumTypesCount;

        private JobHandle* m_JobDependencyCombineBuffer;
        private int m_JobDependencyCombineBufferCount;
        private ComponentSafetyHandle* m_ComponentSafetyHandles;

        private JobHandle m_ExclusiveTransactionDependency;

        private JobHandle* m_ReadJobFences;

        private const int EntityTypeIndex = 1;

        private ushort* m_TypeArrayIndices;
        private ushort m_TypeCount;
        private const ushort NullTypeIndex = 0xFFFF;

        ushort GetTypeArrayIndex(int typeIndex)
        {
            var withoutFlags = typeIndex & TypeManager.ClearFlagsMask;
            var arrayIndex = m_TypeArrayIndices[withoutFlags];
            if (arrayIndex != NullTypeIndex)
                return arrayIndex;

            arrayIndex = m_TypeCount++;
            m_TypeArrayIndices[withoutFlags] = arrayIndex;
            m_ComponentSafetyHandles[arrayIndex].TypeIndex = typeIndex;
            m_ComponentSafetyHandles[arrayIndex].NumReadFences = 0;
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            m_ComponentSafetyHandles[arrayIndex].SafetyHandle = AtomicSafetyHandle.Create();
            AtomicSafetyHandle.SetAllowSecondaryVersionWriting(m_ComponentSafetyHandles[arrayIndex].SafetyHandle, false);
            m_ComponentSafetyHandles[arrayIndex].BufferHandle = AtomicSafetyHandle.Create();
#endif
            m_ComponentSafetyHandles[arrayIndex].WriteFence = new JobHandle();

            return arrayIndex;
        }

        void ClearAllTypeArrayIndices()
        {
            for(int i=0;i<m_TypeCount;++i)
                m_TypeArrayIndices[m_ComponentSafetyHandles[i].TypeIndex & TypeManager.ClearFlagsMask] = NullTypeIndex;
            m_TypeCount = 0;
        }

        public void OnCreate()
        {
            m_TypeArrayIndices = (ushort*)UnsafeUtility.Malloc(sizeof(ushort) * kMaxTypes, 16, Allocator.Persistent);
            UnsafeUtilityEx.MemSet(m_TypeArrayIndices, 0xFF, sizeof(ushort)*kMaxTypes);

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            m_TempSafety = AtomicSafetyHandle.Create();
#endif
            m_ReadJobFences = (JobHandle*) UnsafeUtility.Malloc(sizeof(JobHandle) * kMaxReadJobHandles * kMaxTypes, 16,
                Allocator.Persistent);
            UnsafeUtility.MemClear(m_ReadJobFences, sizeof(JobHandle) * kMaxReadJobHandles * kMaxTypes);

            m_ComponentSafetyHandles =
                (ComponentSafetyHandle*) UnsafeUtility.Malloc(sizeof(ComponentSafetyHandle) * kMaxTypes, 16,
                    Allocator.Persistent);
            UnsafeUtility.MemClear(m_ComponentSafetyHandles, sizeof(ComponentSafetyHandle) * kMaxTypes);

            m_JobDependencyCombineBufferCount = 4 * 1024;
            m_JobDependencyCombineBuffer = (JobHandle*) UnsafeUtility.Malloc(
                sizeof(ComponentSafetyHandle) * m_JobDependencyCombineBufferCount, 16, Allocator.Persistent);

            m_TypeCount = 0;
            IsInTransaction = false;
            m_ExclusiveTransactionDependency = default(JobHandle);
        }

        public bool IsInTransaction { get; private set; }

        public JobHandle ExclusiveTransactionDependency
        {
            get { return m_ExclusiveTransactionDependency; }
            set
            {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                if (!IsInTransaction)
                    throw new InvalidOperationException(
                        "EntityManager.TransactionDependency can only after EntityManager.BeginExclusiveEntityTransaction has been called.");

                if (!JobHandle.CheckFenceIsDependencyOrDidSyncFence(m_ExclusiveTransactionDependency, value))
                    throw new InvalidOperationException(
                        "EntityManager.TransactionDependency must depend on the Entity Transaction job.");
#endif
                m_ExclusiveTransactionDependency = value;
            }
        }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        public AtomicSafetyHandle ExclusiveTransactionSafety { get; private set; }
#endif

        //@TODO: Optimize as one function call to in batch bump version on every single handle...
        public void CompleteAllJobsAndInvalidateArrays()
        {
            if (m_TypeCount == 0)
                return;

            Profiler.BeginSample("CompleteAllJobsAndInvalidateArrays");
            for (int t = 0; t < m_TypeCount; ++t)
            {
                m_ComponentSafetyHandles[t].WriteFence.Complete();

                var readFencesCount = m_ComponentSafetyHandles[t].NumReadFences;
                var readFences = m_ReadJobFences + t * kMaxReadJobHandles;
                for (var r = 0; r != readFencesCount; r++)
                    readFences[r].Complete();
                m_ComponentSafetyHandles[t].NumReadFences = 0;
            }


#if ENABLE_UNITY_COLLECTIONS_CHECKS
            for (var i = 0; i != m_TypeCount; i++)
            {
                AtomicSafetyHandle.CheckDeallocateAndThrow(m_ComponentSafetyHandles[i].SafetyHandle);
                AtomicSafetyHandle.CheckDeallocateAndThrow(m_ComponentSafetyHandles[i].BufferHandle);
            }

            for (var i = 0; i != m_TypeCount; i++)
            {
                AtomicSafetyHandle.Release(m_ComponentSafetyHandles[i].SafetyHandle);
                AtomicSafetyHandle.Release(m_ComponentSafetyHandles[i].BufferHandle);
            }
#endif

            ClearAllTypeArrayIndices();
            Profiler.EndSample();
        }



        public void Dispose()
        {
            for (var i = 0; i < m_TypeCount; i++)
                m_ComponentSafetyHandles[i].WriteFence.Complete();

            for (var i = 0; i < m_TypeCount * kMaxReadJobHandles; i++)
                m_ReadJobFences[i].Complete();

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            for (var i = 0; i < m_TypeCount; i++)
            {
                var res0 = AtomicSafetyHandle.EnforceAllBufferJobsHaveCompletedAndRelease(m_ComponentSafetyHandles[i].SafetyHandle);
                var res1 = AtomicSafetyHandle.EnforceAllBufferJobsHaveCompletedAndRelease(m_ComponentSafetyHandles[i].BufferHandle);

                if (res0 == EnforceJobResult.DidSyncRunningJobs || res1 == EnforceJobResult.DidSyncRunningJobs)
                    Debug.LogError(
                        "Disposing EntityManager but a job is still running against the ComponentData. It appears the job has not been registered with JobComponentSystem.AddDependency.");
            }

            AtomicSafetyHandle.Release(m_TempSafety);
#endif

            UnsafeUtility.Free(m_JobDependencyCombineBuffer, Allocator.Persistent);

            UnsafeUtility.Free(m_TypeArrayIndices, Allocator.Persistent);
            UnsafeUtility.Free(m_ComponentSafetyHandles, Allocator.Persistent);
            m_ComponentSafetyHandles = null;

            UnsafeUtility.Free(m_ReadJobFences, Allocator.Persistent);
            m_ReadJobFences = null;
        }

        public void CompleteDependenciesNoChecks(int* readerTypes, int readerTypesCount, int* writerTypes, int writerTypesCount)
        {
            for (var i = 0; i != writerTypesCount; i++)
                CompleteReadAndWriteDependencyNoChecks(writerTypes[i]);

            for (var i = 0; i != readerTypesCount; i++)
                CompleteWriteDependencyNoChecks(readerTypes[i]);
        }

        internal void PreDisposeCheck()
        {
            for (var i = 0; i < m_TypeCount; i++)
                m_ComponentSafetyHandles[i].WriteFence.Complete();

            for (var i = 0; i < m_TypeCount * kMaxReadJobHandles; i++)
                m_ReadJobFences[i].Complete();

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            for (var i = 0; i < m_TypeCount; i++)
            {
                var res0 = AtomicSafetyHandle.EnforceAllBufferJobsHaveCompleted(m_ComponentSafetyHandles[i].SafetyHandle);
                var res1 = AtomicSafetyHandle.EnforceAllBufferJobsHaveCompleted(m_ComponentSafetyHandles[i].BufferHandle);
                if (res0 == EnforceJobResult.DidSyncRunningJobs || res1 == EnforceJobResult.DidSyncRunningJobs)
                    Debug.LogError(
                        "Disposing EntityManager but a job is still running against the ComponentData. It appears the job has not been registered with JobComponentSystem.AddDependency.");
            }
#endif
        }

        public bool HasReaderOrWriterDependency(int type, JobHandle dependency)
        {

            var typeArrayIndex = m_TypeArrayIndices[type & TypeManager.ClearFlagsMask];
            if (typeArrayIndex == NullTypeIndex)
                return false;

            var writer = m_ComponentSafetyHandles[typeArrayIndex].WriteFence;
            if (JobHandle.CheckFenceIsDependencyOrDidSyncFence(dependency, writer))
                return true;

            var count = m_ComponentSafetyHandles[typeArrayIndex].NumReadFences;
            for (var r = 0; r < count; r++)
            {
                var reader = m_ReadJobFences[typeArrayIndex * kMaxReadJobHandles + r];
                if (JobHandle.CheckFenceIsDependencyOrDidSyncFence(dependency, reader))
                    return true;
            }

            return false;
        }

        public JobHandle GetDependency(int* readerTypes, int readerTypesCount, int* writerTypes, int writerTypesCount)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (readerTypesCount * kMaxReadJobHandles + writerTypesCount > m_JobDependencyCombineBufferCount)
                throw new ArgumentException("Too many readers & writers in GetDependency");
#endif

            var count = 0;
            for (var i = 0; i != readerTypesCount; i++)
            {
                var typeArrayIndex = m_TypeArrayIndices[readerTypes[i] & TypeManager.ClearFlagsMask];
                if(typeArrayIndex != NullTypeIndex)
                    m_JobDependencyCombineBuffer[count++] = m_ComponentSafetyHandles[typeArrayIndex].WriteFence;
            }


            for (var i = 0; i != writerTypesCount; i++)
            {
                var typeArrayIndex = m_TypeArrayIndices[writerTypes[i] & TypeManager.ClearFlagsMask];
                if (typeArrayIndex == NullTypeIndex)
                    continue;

                m_JobDependencyCombineBuffer[count++] = m_ComponentSafetyHandles[typeArrayIndex].WriteFence;

                var numReadFences = m_ComponentSafetyHandles[typeArrayIndex].NumReadFences;
                for (var j = 0; j != numReadFences; j++)
                    m_JobDependencyCombineBuffer[count++] = m_ReadJobFences[typeArrayIndex * kMaxReadJobHandles + j];
            }

            return JobHandleUnsafeUtility.CombineDependencies(m_JobDependencyCombineBuffer,
                count);
        }

        public JobHandle AddDependency(int* readerTypes, int readerTypesCount, int* writerTypes, int writerTypesCount,
            JobHandle dependency)
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            JobHandle* combinedDependencies = null;
            var combinedDependenciesCount = 0;
#endif
            if (readerTypesCount == 0 && writerTypesCount == 0)
            {
                ushort entityTypeArrayIndex = GetTypeArrayIndex(EntityTypeIndex);
                // if no dependency types are provided add read dependency to the Entity type
                // to ensure these jobs are still synced by CompleteAllJobsAndInvalidateArrays
                m_ReadJobFences[entityTypeArrayIndex * kMaxReadJobHandles +
                    m_ComponentSafetyHandles[entityTypeArrayIndex].NumReadFences] = dependency;
                m_ComponentSafetyHandles[entityTypeArrayIndex].NumReadFences++;

                if (m_ComponentSafetyHandles[entityTypeArrayIndex].NumReadFences == kMaxReadJobHandles)
                {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                    return CombineReadDependencies(entityTypeArrayIndex);
#else
                    CombineReadDependencies(entityTypeArrayIndex);
#endif
                }
                return dependency;
            }

            for (var i = 0; i != writerTypesCount; i++)
            {
                m_ComponentSafetyHandles[GetTypeArrayIndex(writerTypes[i])].WriteFence = dependency;
            }


            for (var i = 0; i != readerTypesCount; i++)
            {
                var reader = GetTypeArrayIndex(readerTypes[i]);
                m_ReadJobFences[reader * kMaxReadJobHandles + m_ComponentSafetyHandles[reader].NumReadFences] =
                    dependency;
                m_ComponentSafetyHandles[reader].NumReadFences++;

                if (m_ComponentSafetyHandles[reader].NumReadFences == kMaxReadJobHandles)
                {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
                    var combined = CombineReadDependencies(reader);
                    if (combinedDependencies == null)
                    {
                        JobHandle* temp = stackalloc JobHandle[readerTypesCount];
                        combinedDependencies = temp;
                    }

                    combinedDependencies[combinedDependenciesCount++] = combined;
#else
                    CombineReadDependencies(reader);
#endif
                }
            }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (combinedDependencies != null)
                return JobHandleUnsafeUtility.CombineDependencies(combinedDependencies, combinedDependenciesCount);
            return dependency;
#else
            return dependency;
#endif
        }

        ushort CompleteWriteDependencyNoChecks(int type)
        {
            if (TypeManager.IsZeroSized(type))
                return NullTypeIndex;

            var withoutFlags = type & TypeManager.ClearFlagsMask;
            var arrayIndex = m_TypeArrayIndices[withoutFlags];
            if (arrayIndex != NullTypeIndex)
            {
                m_ComponentSafetyHandles[arrayIndex].WriteFence.Complete();
            }
            return arrayIndex;
        }

        ushort CompleteReadAndWriteDependencyNoChecks(int type)
        {
            if (TypeManager.IsZeroSized(type))
                return NullTypeIndex;

            var withoutFlags = type & TypeManager.ClearFlagsMask;
            var arrayIndex = m_TypeArrayIndices[withoutFlags];
            if (arrayIndex != NullTypeIndex)
            {
                for (var i = 0; i < m_ComponentSafetyHandles[arrayIndex].NumReadFences; ++i)
                    m_ReadJobFences[arrayIndex * kMaxReadJobHandles + i].Complete();
                m_ComponentSafetyHandles[arrayIndex].NumReadFences = 0;

                m_ComponentSafetyHandles[arrayIndex].WriteFence.Complete();
            }
            return arrayIndex;
        }

        public void CompleteWriteDependency(int type)
        {
            var arrayIndex = CompleteWriteDependencyNoChecks(type);

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (arrayIndex == NullTypeIndex)
                return;
            AtomicSafetyHandle.CheckReadAndThrow(m_ComponentSafetyHandles[arrayIndex].SafetyHandle);
            AtomicSafetyHandle.CheckReadAndThrow(m_ComponentSafetyHandles[arrayIndex].BufferHandle);
#endif
        }

        public void CompleteReadAndWriteDependency(int type)
        {
            var arrayIndex = CompleteReadAndWriteDependencyNoChecks(type);
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            if (arrayIndex == NullTypeIndex)
                return;
            AtomicSafetyHandle.CheckWriteAndThrow(m_ComponentSafetyHandles[arrayIndex].SafetyHandle);
            AtomicSafetyHandle.CheckWriteAndThrow(m_ComponentSafetyHandles[arrayIndex].BufferHandle);
#endif
        }


#if ENABLE_UNITY_COLLECTIONS_CHECKS

        public AtomicSafetyHandle GetEntityManagerSafetyHandle()
        {
            var handle = m_ComponentSafetyHandles[GetTypeArrayIndex(EntityTypeIndex)].SafetyHandle;
            AtomicSafetyHandle.UseSecondaryVersion(ref handle);
            return handle;
        }

        public AtomicSafetyHandle GetSafetyHandle(int type, bool isReadOnly)
        {
            if (TypeManager.IsZeroSized(type))
            {
                return GetEntityManagerSafetyHandle();
            }

            var arrayIndex = GetTypeArrayIndex(type);

            var handle = m_ComponentSafetyHandles[arrayIndex].SafetyHandle;
            if (isReadOnly)
                AtomicSafetyHandle.UseSecondaryVersion(ref handle);

            return handle;
        }

        public AtomicSafetyHandle GetBufferSafetyHandle(int type)
        {
            Assert.IsTrue(TypeManager.IsBuffer(type));
            var arrayIndex = GetTypeArrayIndex(type);
            return m_ComponentSafetyHandles[arrayIndex].BufferHandle;
        }
#endif

        private JobHandle CombineReadDependencies(ushort typeArrayIndex)
        {
            var combined = JobHandleUnsafeUtility.CombineDependencies(
                m_ReadJobFences + typeArrayIndex * kMaxReadJobHandles, m_ComponentSafetyHandles[typeArrayIndex].NumReadFences);

            m_ReadJobFences[typeArrayIndex * kMaxReadJobHandles] = combined;
            m_ComponentSafetyHandles[typeArrayIndex].NumReadFences = 1;

            return combined;
        }

        public void BeginExclusiveTransaction()
        {
            if (IsInTransaction)
                return;

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            for (var i = 0; i != m_TypeCount; i++)
            {
                AtomicSafetyHandle.CheckDeallocateAndThrow(m_ComponentSafetyHandles[i].SafetyHandle);
                AtomicSafetyHandle.CheckDeallocateAndThrow(m_ComponentSafetyHandles[i].BufferHandle);
            }

            for (var i = 0; i != m_TypeCount; i++)
            {
                AtomicSafetyHandle.Release(m_ComponentSafetyHandles[i].SafetyHandle);
                AtomicSafetyHandle.Release(m_ComponentSafetyHandles[i].BufferHandle);
            }
#endif

            IsInTransaction = true;
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            ExclusiveTransactionSafety = AtomicSafetyHandle.Create();
#endif
            m_ExclusiveTransactionDependency = GetAllDependencies();
            ClearAllTypeArrayIndices();
        }

        public void EndExclusiveTransaction()
        {
            if (!IsInTransaction)
                return;

            m_ExclusiveTransactionDependency.Complete();

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            var res = AtomicSafetyHandle.EnforceAllBufferJobsHaveCompletedAndRelease(ExclusiveTransactionSafety);
            if (res != EnforceJobResult.AllJobsAlreadySynced)
                //@TODO: Better message
                Debug.LogError("ExclusiveEntityTransaction job has not been registered");
#endif
            IsInTransaction = false;
        }

        private JobHandle GetAllDependencies()
        {
            var jobHandles =
                new NativeArray<JobHandle>(m_TypeCount * (kMaxReadJobHandles + 1), Allocator.Temp);

            var count = 0;
            for (var i = 0; i != m_TypeCount; i++)
            {
                jobHandles[count++] = m_ComponentSafetyHandles[i].WriteFence;

                var numReadFences = m_ComponentSafetyHandles[i].NumReadFences;
                for (var j = 0; j != numReadFences; j++)
                    jobHandles[count++] = m_ReadJobFences[i * kMaxReadJobHandles + j];
            }

            var combined = JobHandle.CombineDependencies(jobHandles);
            jobHandles.Dispose();

            return combined;
        }

        private struct ComponentSafetyHandle
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            public AtomicSafetyHandle SafetyHandle;
            public AtomicSafetyHandle BufferHandle;
#endif
            public JobHandle WriteFence;
            public int NumReadFences;
            public int TypeIndex;
        }

#if ENABLE_UNITY_COLLECTIONS_CHECKS
        private AtomicSafetyHandle m_TempSafety;
#endif
    }
}
