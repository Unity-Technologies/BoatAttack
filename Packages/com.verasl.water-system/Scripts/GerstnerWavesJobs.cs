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
        static NativeArray<float3> waveNormal;
        static JobHandle waterHeightHandle;
        static Dictionary<int, int2> registry = new Dictionary<int, int2>();

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
            waveNormal = new NativeArray<float3>(4096, Allocator.Persistent);

            init = true;
        }

        public static void Cleanup()
        {
            Debug.LogWarning("Cleaning up GerstnerWaves");
            waterHeightHandle.Complete();

            //Cleanup native arrays
            waveData.Dispose();

            positions.Dispose();
            wavePos.Dispose();
            waveNormal.Dispose();
        }

        public static void UpdateSamplePoints(float3[] samplePoints, int guid)
        {
            CompleteJobs();
            int2 offsets;

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

        public static void GetData(int guid, ref float3[] outPos, ref float3[] outNorm)
        {
            var offsets = new int2(0, 0);
            if (registry.TryGetValue(guid, out offsets))
            {
                wavePos.Slice(offsets.x, offsets.y - offsets.x).CopyTo(outPos);
                if(outNorm != null)
                    waveNormal.Slice(offsets.x, offsets.y - offsets.x).CopyTo(outNorm);
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
                    outNormal = waveNormal
                };
                
                waterHeightHandle = waterHeight.Schedule(positionCount, 32);
                
                JobHandle.ScheduleBatchedJobs();

                firstFrame = false;
            }
        }

        public static void CompleteJobs()
        {
            if (!firstFrame && processing)
            {
                waterHeightHandle.Complete();
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
                        var pos = position[i].xz;

                        var amplitude = waveData[wave].amplitude;
                        var direction = waveData[wave].direction;
                        var wavelength = waveData[wave].wavelength;
                        var omniPos = waveData[wave].origin;
                        ////////////////////////////////wave value calculations//////////////////////////
                        var w = 6.28318f / wavelength; // 2pi over wavelength(hardcoded)
                        var wSpeed = math.sqrt(9.8f * w); // frequency of the wave based off wavelength
                        var peak = 0.8f; // peak value, 1 is the sharpest peaks
                        var qi = peak / (amplitude * w * waveData.Length);

                        var windDir = new float2(0f, 0f);
                        var dir = 0f;

                        direction = math.radians(direction); // convert the incoming degrees to radians
                        var windDirInput = new float2(math.sin(direction), math.cos(direction)) * (1 - waveData[wave].onmiDir); // calculate wind direction - TODO - currently radians
                        var windOmniInput = (pos - omniPos) * waveData[wave].onmiDir;

                        windDir += windDirInput;
                        windDir += windOmniInput;
                        windDir = math.normalize(windDir);
                        dir = math.dot(windDir, pos - (omniPos * waveData[wave].onmiDir)); // calculate a gradient along the wind direction

                        ////////////////////////////position output calculations/////////////////////////
                        var calc = dir * w + -time * wSpeed; // the wave calculation
                        var cosCalc = math.cos(calc); // cosine version(used for horizontal undulation)
                        var sinCalc = math.sin(calc); // sin version(used for vertical undulation)

                        // calculate the offsets for the current point
                        wavePos.x += qi * amplitude * windDir.x * cosCalc;
                        wavePos.z += qi * amplitude * windDir.y * cosCalc;
                        wavePos.y += ((sinCalc * amplitude)) * waveCountMulti; // the height is divided by the number of waves 

                        ////////////////////////////normal output calculations/////////////////////////
                        float wa = w * amplitude;
                        // normal vector
                        float3 norm = new float3(-(windDir.xy * wa * cosCalc),
                                        1 - (qi * wa * sinCalc));
                        waveNorm += (norm * waveCountMulti) * amplitude;
                    }
                    outPosition[i] = wavePos;
                    outNormal[i] = math.normalize(waveNorm.xzy);
                }
            }
        }
    }
}
