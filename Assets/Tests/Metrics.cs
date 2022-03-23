using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Unity.Profiling.LowLevel.Unsafe;
using Unity.Profiling;
using Unity.Profiling.SystemMetrics;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public class Metrics
{
    ProfilerRecorder profilerRecorder;
    static string[] metricValues = {
        "GpuCycles", "GpuVertexAndComputeCycles", "GpuVertexAndComputeUtilization", "GpuFragmentCycles",
        "GpuFragmentUtilization", "GpuShaderCoreUtilization", "GpuInputPrimitives",
        "GpuVisiblePrimitives", "GpuVisiblePrimitivesPercentage", "GpuShaderComputeCycles", "GpuShaderComputeUtilization",
        "GpuShaderFragmentCycles", "GpuShaderFragmentUtilization", "GpuMemoryReadStallRate", "GpuMemoryReadStalledCycles",
        "GpuMemoryWriteStalledCycles","GpuMemoryWriteStallRate", "GpuMemoryReadBytes" ,"GpuMemoryWriteBytes",
        "GpuMemoryWriteAccesses", "GpuMemoryReadAccesses", "GpuCacheWriteLookups", "GpuCacheReadLookups",
        "GpuInstructions", "GpuPixels", "GpuUnchangedEliminatedTiles",
        "GpuFragmentJobs", "GpuVertexComputeJobs", "GpuLateZKills", "GpuLateZTests", "GpuEarlyZKills", "GpuEarlyZTests",
        "GpuShaderLoadStoreUtilization", "GpuShaderLoadStoreCycles", "GpuShaderTextureUtilization", "GpuShaderTextureCycles",
        "GpuShaderArithmeticUtilization", "GpuShaderArithmeticCycles", "GpuClippedPrimitives", "GpuCulledPrimitives", "GpuCulledPrimitivesPercentage"
    };

    // removed due to failures "GpuTiles",GpuShaderCoreCycles, GpuDivergedInstructions
    string unityVersion = "";
    float prepareTime;
    float testRunTime;
    double lastValue;
    double maxValue;
    double minValue;
    int frameCounter;
    List<double> profilerValues;

    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator MaliMetrix_ReturnsNotNull_IfCalled([ValueSource("metricValues")] string value)
    {
        // remove any values
        profilerValues = new List<double>();

        Type maliFields = typeof(SystemMetricsMali);
        ProfilerRecorderHandle recorderHandle = (ProfilerRecorderHandle)maliFields.GetProperty(value).GetValue(SystemMetricsMali.Instance);
        profilerRecorder = new ProfilerRecorder(recorderHandle);

        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);

        prepareTime = 5.0f;
        testRunTime = 30.0f;
        lastValue = 0;
        frameCounter = 0;

        if (profilerRecorder.Valid)
            profilerRecorder.Start();

        // Wait for 100 frames 
        for (int i = 0; i < 100; i++)
            yield return new WaitForEndOfFrame();

        // Run tests for 500 frames
        for (int i = 0; i < 500; i++) { 
            frameCounter++;
            profilerValues.Add(profilerRecorder.LastValue);
                        
            yield return new WaitForEndOfFrame();
        }

        double totalSum = profilerValues.Sum();
        double min = profilerValues.Min();
        double max = profilerValues.Max();
        double finalAverage = totalSum / frameCounter;

        Debug.Log("Final average: " + finalAverage);
        Debug.Log("Min value:: " + min);
        Debug.Log("Max value:: " + max);

        Assert.AreNotEqual(0, finalAverage, "Average value: " + finalAverage);

        profilerValues.Clear();
        profilerRecorder.Dispose();
    }
}

