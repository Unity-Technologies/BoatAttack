using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine.Assertions;

public static class LocalToWorldJob
{
    private static Dictionary<int, TransformLocalToWorld> _data = new Dictionary<int, TransformLocalToWorld>();

    [BurstCompile]
    struct LocalToWorldConvertJob : IJob
    {
        [WriteOnly] public NativeArray<float3> positionsWorld;
        [ReadOnly] public Matrix4x4 matrix;
        [ReadOnly] public NativeArray<float3> positionsLocal;

        // The code actually running on the job
        public void Execute()
        {
            for (var i = 0; i < positionsLocal.Length; i++)
            {
                float4 pos = float4.zero;
                pos.xyz = positionsLocal[i];
                pos.w = 1f;
                pos = matrix * pos;
                positionsWorld[i] = pos.xyz;
            }
        }
    }

    public static void SetupJob(int guid, Vector3[] positions, ref NativeArray<float3> output)
    {
        TransformLocalToWorld jobData = new TransformLocalToWorld();
        jobData.positionsWorld = new NativeArray<float3>(positions.Length, Allocator.Persistent);
        jobData.positionsLocal = new NativeArray<float3>(positions.Length, Allocator.Persistent);
        for (var i = 0; i < positions.Length; i++)
            jobData.positionsLocal[i] = positions[i];
        _data.Add(guid, jobData);
        output = jobData.positionsWorld;
    }

    public static void ScheduleJob(int guid, Matrix4x4 localToWorld)
    {
        if (_data[guid].processing)
            return;
        
        _data[guid].job = new LocalToWorldConvertJob()
        {
            positionsWorld = _data[guid].positionsWorld,
            positionsLocal = _data[guid].positionsLocal,
            matrix = localToWorld
        };
        
        _data[guid].handle = _data[guid].job.Schedule();
        _data[guid].processing = true;
        JobHandle.ScheduleBatchedJobs();
    }

    public static void CompleteJob(int guid)
    {
        _data[guid].handle.Complete();
        _data[guid].processing = false;
        //return _data[guid].job.positionsWorld;
    }

    public static void Cleanup(int guid)
    {
        if (_data.ContainsKey(guid))
        {
            _data[guid].handle.Complete();
            _data[guid].positionsWorld.Dispose();
            _data[guid].positionsLocal.Dispose();
            _data.Remove(guid);
        }
    }

    class TransformLocalToWorld
    {
        public NativeArray<float3> positionsLocal;
        public NativeArray<float3> positionsWorld;
        public JobHandle handle;
        public LocalToWorldConvertJob job;
        public bool processing;
    }
}