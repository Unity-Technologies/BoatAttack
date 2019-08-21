using System;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Serialization;
using Unity.IO.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;


namespace Unity.Scenes
{
    unsafe class AsyncLoadSceneOperation
    {
        public enum LoadingStatus
        {
            Completed,
            NotStarted,
            WaitingForResourcesLoad,
            WaitingForEntitiesLoad
        }

        public override string ToString()
        {
            return $"AsyncLoadSceneJob({_ScenePath})";
        }

        unsafe struct FreeJob : IJob
        {
            [NativeDisableUnsafePtrRestriction]
            public void* ptr;
            public Allocator allocator;
            public void Execute()
            {
                UnsafeUtility.Free(ptr, allocator);
            }
        }

        public void Dispose()
        {
            if (_LoadingStatus == LoadingStatus.Completed)
            {
                new FreeJob {ptr = _FileContent, allocator = Allocator.Persistent}.Schedule();
            }
            else if (_LoadingStatus == LoadingStatus.WaitingForResourcesLoad)
            {
                new FreeJob {ptr = _FileContent, allocator = Allocator.Persistent}.Schedule(_ReadHandle.JobHandle);
            }
            else if(_LoadingStatus == LoadingStatus.WaitingForEntitiesLoad)
            {
                _EntityManager.ExclusiveEntityTransactionDependency.Complete();
                new FreeJob {ptr = _FileContent, allocator = Allocator.Persistent}.Schedule();
            }
        }

        struct AsyncLoadSceneJob : IJob
        {
            public GCHandle                     LoadingOperationHandle;
            public ExclusiveEntityTransaction   Transaction;
            public int                          SharedComponentCount;
            [NativeDisableUnsafePtrRestriction]
            public byte*                        FileContent;

            static readonly ProfilerMarker k_ProfileDeserializeWorld = new ProfilerMarker("AsyncLoadSceneJob.DeserializeWorld");
            static readonly ProfilerMarker k_ProfileReleaseSharedComponents = new ProfilerMarker("AsyncLoadSceneJob.ReleaseSharedComponents");

            public void Execute()
            {
                var loadingOperation = (AsyncLoadSceneOperation)LoadingOperationHandle.Target;
                LoadingOperationHandle.Free();

                try
                {
                    using (var reader = new MemoryBinaryReader(FileContent))
                    {
                        k_ProfileDeserializeWorld.Begin();
                        SerializeUtility.DeserializeWorld(Transaction, reader, SharedComponentCount);
                        k_ProfileDeserializeWorld.End();
                        k_ProfileReleaseSharedComponents.Begin();
                        SerializeUtilityHybrid.ReleaseSharedComponents(Transaction, SharedComponentCount);
                        k_ProfileReleaseSharedComponents.End();
                    }
                }
                catch (Exception exc)
                {
                    loadingOperation._LoadingFailure = $"{exc.Message}\n{exc.StackTrace}";
                }
            }
        }

        string                  _ScenePath;
        int                     _SceneSize;
        int                     _ExpectedSharedComponentCount;
        string                  _ResourcesPath;
        EntityManager           _EntityManager;

        ResourceRequest         _ResourceRequest;
        LoadingStatus           _LoadingStatus;
        string                  _LoadingFailure;

        byte*                    _FileContent;
        ReadHandle               _ReadHandle;

        private double _StartTime;

        public AsyncLoadSceneOperation(string scenePath, int sceneSize, int expectedSharedComponentCount, string resourcesPath, EntityManager entityManager)
        {
            _ScenePath = scenePath;
            _SceneSize = sceneSize;
            _ResourcesPath = resourcesPath;
            _EntityManager = entityManager;
            _LoadingStatus = LoadingStatus.NotStarted;
            _ExpectedSharedComponentCount = expectedSharedComponentCount;
        }

        public bool IsCompleted
        {
            get
            {
                return _LoadingStatus == LoadingStatus.Completed;
            }
        }

        public string ErrorStatus
        {
            get
            {
                if (_LoadingStatus == LoadingStatus.Completed)
                    return _LoadingFailure;
                else
                    return null;
            }
        }

        public void Update()
        {
            //@TODO: Try to overlap Resources load and entities scene load

            // Begin Async resource load
            if (_LoadingStatus == LoadingStatus.NotStarted)
            {
                if (_SceneSize == 0) return;
                try
                {
                    _StartTime = Time.realtimeSinceStartup;
                    if (_ExpectedSharedComponentCount != 0)
                    {
                        _ResourceRequest = Resources.LoadAsync<GameObject>(_ResourcesPath);
                        _LoadingStatus = LoadingStatus.WaitingForResourcesLoad;
                    }
                    else
                    {
                        _LoadingStatus = LoadingStatus.WaitingForEntitiesLoad;
                    }
                    _FileContent = (byte*)UnsafeUtility.Malloc(_SceneSize, 16, Allocator.Persistent);

                    ReadCommand cmd;
                    cmd.Buffer = _FileContent;
                    cmd.Offset = 0;
                    cmd.Size = _SceneSize;
                    _ReadHandle = AsyncReadManager.Read(_ScenePath, &cmd, 1);
                }
                catch (Exception e)
                {
                    _LoadingFailure = e.Message;
                    _LoadingStatus = LoadingStatus.Completed;
                }
            }

            // Once async resource load is done, we can async read the entity scene data
            if (_LoadingStatus == LoadingStatus.WaitingForResourcesLoad)
            {
                if (!_ResourceRequest.isDone)
                    return;

                if (!_ResourceRequest.asset)
                {
                    _LoadingFailure = $"Failed to load Shared component resource '{_ResourcesPath}'";
                    _LoadingStatus = LoadingStatus.Completed;
                    return;
                }

                try
                {
                    _LoadingStatus = LoadingStatus.WaitingForEntitiesLoad;
                    ScheduleSceneRead(_ResourceRequest.asset as GameObject);
                }
                catch (Exception e)
                {
                    _LoadingFailure = e.Message;
                    _LoadingStatus = LoadingStatus.Completed;
                }
            }

            // Complete Loading status
            if (_LoadingStatus == LoadingStatus.WaitingForEntitiesLoad)
            {
                if (_EntityManager.ExclusiveEntityTransactionDependency.IsCompleted)
                {
                    _EntityManager.ExclusiveEntityTransactionDependency.Complete();

                    _LoadingStatus = LoadingStatus.Completed;
                    var currentTime = Time.realtimeSinceStartup;
                    var totalTime = currentTime - _StartTime;
                    System.Console.WriteLine($"Streamed scene with {totalTime*1000,3:f0}ms latency from {_ScenePath}");
                }
            }

        }

        void ScheduleSceneRead(GameObject sharedComponents)
        {
            var transaction = _EntityManager.BeginExclusiveEntityTransaction();
            int sharedComponentCount = SerializeUtilityHybrid.DeserializeSharedComponents(_EntityManager, sharedComponents, _ScenePath);
            if (_ExpectedSharedComponentCount != sharedComponentCount)
            {
                _LoadingFailure = $"Expected shared component count ({_ExpectedSharedComponentCount}) didn't match actual shared component count ({sharedComponentCount}) '{_ResourcesPath}'";
                _LoadingStatus = LoadingStatus.Completed;
                return;
            }

            var loadJob = new AsyncLoadSceneJob
            {
                Transaction = transaction,
                LoadingOperationHandle = GCHandle.Alloc(this),
                SharedComponentCount = sharedComponentCount,
                FileContent = _FileContent
            };

            _EntityManager.ExclusiveEntityTransactionDependency = loadJob.Schedule(JobHandle.CombineDependencies(_EntityManager.ExclusiveEntityTransactionDependency, _ReadHandle.JobHandle));
        }
    }
    
}
