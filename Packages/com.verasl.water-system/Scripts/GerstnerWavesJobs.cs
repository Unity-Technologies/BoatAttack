using UnityEngine;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Burst;
using Unity.Mathematics;
using WaterSystem.Data;

namespace WaterSystem
{
	/// <summary>
	/// C# Jobs system version of the Gerstner waves implimentation
	/// </summary>
    public static class GerstnerWavesJobs
    {
        //General variables
        public static bool init;
        public static bool firstFrame = true;
        public static bool processing = false;
        static int _waveCount;
        static NativeArray<Wave> waveData; // Wave data from the water system

        //Details for Buoyant Objects
        static NativeArray<float3> positions;
        static int positionCount = 0;
        static NativeArray<float3> wavePos;
        static NativeArray<float3> tempNullNormal;
        static JobHandle waterHeightHandle;
        static Dictionary<int, int2> registry = new Dictionary<int, int2>();

        //Details for Simple Buoyant Objects
        static NativeArray<float3> simplePositions;
        static int simplePositionCount = 0;
        static NativeArray<float3> waveSimplePos;
        static NativeArray<float3> waveSimpleNormal;
        static JobHandle waterSimpleHeightHandle;
        static Dictionary<int, int2> simpleRegistry = new Dictionary<int, int2>();


        public static void Init()
        {
            //Wave data
            _waveCount = Water.Instance._waves.Length;
            waveData = new NativeArray<Wave>(_waveCount, Allocator.Persistent);
            for (var i = 0; i < waveData.Length; i++)
            {
                waveData[i] = Water.Instance._waves[i];
            }

            positions = new NativeArray<float3>(4096, Allocator.Persistent);
            wavePos = new NativeArray<float3>(4096, Allocator.Persistent);
            simplePositions = new NativeArray<float3>(1024, Allocator.Persistent);
            waveSimplePos = new NativeArray<float3>(1024, Allocator.Persistent);
            waveSimpleNormal = new NativeArray<float3>(1024, Allocator.Persistent);
            tempNullNormal = new NativeArray<float3>(1, Allocator.Persistent);

            init = true;
        }

        public static void Cleanup()
        {
            Debug.LogWarning("Cleaning up GerstnerWaves");
            waterHeightHandle.Complete();
            waterSimpleHeightHandle.Complete();

            //Cleanup native arrays
            waveData.Dispose();
            tempNullNormal.Dispose();

            positions.Dispose();
            wavePos.Dispose();
            simplePositions.Dispose();
            waveSimplePos.Dispose();
            waveSimpleNormal.Dispose();
        }

        public static void UpdateSamplePoints(float3[] samplePoints, int guid, bool simple)
        {
            CompleteJobs();
            int2 offsets;
            if (simple)
            {
                if (simpleRegistry.TryGetValue(guid, out offsets))
                {
                    for (var i = offsets.x; i < offsets.y; i++) simplePositions[i] = samplePoints[i - offsets.x];
                }
                else
                {
                    if (simplePositionCount + samplePoints.Length < simplePositions.Length)
                    {
                        offsets = new int2(simplePositionCount, simplePositionCount + samplePoints.Length);
                        //Debug.Log("<color=yellow>Adding Object:" + guid + " to the simple registry at offset:" + offsets + "</color>");
                        simpleRegistry.Add(guid, offsets);
                        simplePositionCount += samplePoints.Length;
                    }
                }
            }
            else
            {
                if (registry.TryGetValue(guid, out offsets))
                {
                    for (var i = offsets.x; i < offsets.y; i++) positions[i] = samplePoints[i - offsets.x];
                }
                else
                {
                    if (positionCount + samplePoints.Length < positions.Length)
                    {
                        offsets = new int2(positionCount, positionCount + samplePoints.Length);
                        //Debug.Log("<color=yellow>Adding Object:" + guid + " to the registry at offset:" + offsets + "</color>");
                        registry.Add(guid, offsets);
                        positionCount += samplePoints.Length;
                    }
                }
            }
        }

        public static void GetSimpleData(int guid, ref float3[] outPos, ref float3[] outNorm)
        {
            var offsets = new int2(0, 0);
            if (simpleRegistry.TryGetValue(guid, out offsets))
            {
                waveSimplePos.Slice(offsets.x, offsets.y - offsets.x).CopyTo(outPos);
                waveSimpleNormal.Slice(offsets.x, offsets.y - offsets.x).CopyTo(outNorm);
            }
        }

        public static void GetData(int guid, ref float3[] outPos)
        {
            var offsets = new int2(0, 0);
            if (registry.TryGetValue(guid, out offsets))
            {
                wavePos.Slice(offsets.x, offsets.y - offsets.x).CopyTo(outPos);
            }
        }

        // Height jobs for the next frame
        public static void UpdateHeights()
        {
            if (!processing)
            {
                processing = true;

                // Buoyant Object Job
                var waterHeight = new GerstnerWavesJobs.HeightJob()
                {
                    waveData = waveData,
                    position = positions,
                    offsetLength = new int2(0, positions.Length),
                    time = Time.time,
                    outPosition = wavePos,
                    outNormal = tempNullNormal,
                    normal = 0
                };
                // dependant on job4
                waterHeightHandle = waterHeight.Schedule(positionCount, 32);

                // Simple Buoyant Object Job
                var waterSimpleHeight = new GerstnerWavesJobs.HeightJob()
                {
                    waveData = waveData,
                    position = simplePositions,
                    offsetLength = new int2(0, simplePositions.Length),
                    time = Time.time,
                    outPosition = waveSimplePos,
                    outNormal = waveSimpleNormal,
                    normal = 1
                };
                // dependant on job4
                waterSimpleHeightHandle = waterSimpleHeight.Schedule(simplePositionCount, 32);

                JobHandle.ScheduleBatchedJobs();

                firstFrame = false;
            }
        }

        public static void CompleteJobs()
        {
            if (!firstFrame && processing)
            {
                waterHeightHandle.Complete();
                waterSimpleHeightHandle.Complete();
                processing = false;
            }
        }

        // Gerstner Height C# Job
        [BurstCompile]
        public struct HeightJob : IJobParallelFor
        {
            [ReadOnly]
            public NativeArray<Wave> waveData; // wave data stroed in vec4's like the shader version but packed into one
            [ReadOnly]
            public NativeArray<float3> position;

            [WriteOnly]
            public NativeArray<float3> outPosition;
            [WriteOnly]
            public NativeArray<float3> outNormal;

            [ReadOnly]
            public float time;
            [ReadOnly]
            public int2 offsetLength;
            [ReadOnly]
            public int normal;

            // The code actually running on the job
            public void Execute(int i)
            {
                if (i >= offsetLength.x && i < offsetLength.y - offsetLength.x)
                {
                    var waveCountMulti = 1f / waveData.Length;
                    float3 wavePos = new float3(0f, 0f, 0f);
                    float3 waveNorm = new float3(0f, 0f, 0f);

                    for (var wave = 0; wave < waveData.Length; wave++) // for each wave
                    {
                        // Wave data vars
                        float2 pos = position[i].xz;

                        var amplitude = waveData[wave].amplitude;
                        var direction = waveData[wave].direction;
                        var wavelength = waveData[wave].wavelength;
                        float2 omniPos = waveData[wave].origin;
                        ////////////////////////////////wave value calculations//////////////////////////
                        float w = 6.28318f / wavelength; // 2pi over wavelength(hardcoded)
                        float wSpeed = math.sqrt(9.8f * w); // frequency of the wave based off wavelength
                        float peak = 0.8f; // peak value, 1 is the sharpest peaks
                        float qi = peak / (amplitude * w * waveData.Length);

                        float2 windDir = new float2(0f, 0f);
                        float dir = 0;

                        direction = math.radians(direction); // convert the incoming degrees to radians
                        float2 windDirInput = new float2(math.sin(direction), math.cos(direction)) * (1 - waveData[wave].onmiDir); // calculate wind direction - TODO - currently radians
                        float2 windOmniInput = (pos - omniPos) * waveData[wave].onmiDir;

                        windDir += windDirInput;
                        windDir += windOmniInput;
                        windDir = math.normalize(windDir);
                        dir = math.dot(windDir, pos - (omniPos * waveData[wave].onmiDir)); // calculate a gradient along the wind direction

                        ////////////////////////////position output calculations/////////////////////////
                        float calc = dir * w + -time * wSpeed; // the wave calculation
                        float cosCalc = math.cos(calc); // cosine version(used for horizontal undulation)
                        float sinCalc = math.sin(calc); // sin version(used for vertical undulation)

                        // calculate the offsets for the current point
                        wavePos.x += qi * amplitude * windDir.x * cosCalc;
                        wavePos.z += qi * amplitude * windDir.y * cosCalc;
                        wavePos.y += ((sinCalc * amplitude)) * waveCountMulti; // the height is divided by the number of waves 

                        if (normal == 1)
                        {
                            ////////////////////////////normal output calculations/////////////////////////
                            float wa = w * amplitude;
                            // normal vector
                            float3 norm = new float3(-(windDir.xy * wa * cosCalc),
                                            1 - (qi * wa * sinCalc));
                            waveNorm += (norm * waveCountMulti) * amplitude;
                        }
                    }
                    outPosition[i] = wavePos;
                    if (normal == 1) outNormal[i] = math.normalize(waveNorm.xzy);
                }
            }
        }
    }
}
