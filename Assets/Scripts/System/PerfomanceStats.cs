using System.Collections.Generic;
using BoatAttack;
//using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class PerfomanceStats : MonoBehaviour
{
	private int _runNumber = 1;
	public int runCount = 4;

	public int runLength = 2000;

	// Frame time stats
	private List<PerfBasic> _stats = new List<PerfBasic>();
	public PerfBasic Stats => _stats[_runNumber - 1];
    private List<float> samples = new List<float>();
    private int totalSamples = 250;
    private int curFrame = 0;

    // UI display
    public Text frametimeDisplay;
    private string debugInfo;

    private void OnEnable()
    {
	    _stats.Add(new PerfBasic(runLength));
    }

    private void Update () {
        frametimeDisplay.text = "";
        // sample frametime
        samples.Insert(0, Time.deltaTime); // add sample at the start
		if(samples.Count >= totalSamples)
		{
            samples.RemoveAt(totalSamples - 1);
        }
        UpdateFrametime();

        var totalMem = Profiler.GetTotalAllocatedMemoryLong();
        var gpuMem = Profiler.GetAllocatedMemoryForGraphicsDriver();
        
        DrawText(((float)totalMem / 1000000).ToString("#0.00"), ((float)gpuMem / 1000000).ToString("#0.00"));
        
        
        curFrame++;
        Stats.RunTime += Time.unscaledDeltaTime;

        if (curFrame > runLength)
	        ResetRun();
    }

    private void DrawText(string memory, string gpuMemory)
	{
		var i = Stats.info;
		debugInfo = $"Unity:<b>{i.UnityVersion}</b>   " +
		            $"URP:<b>{i.UrpVersion}</b>   " +
		            $"Build:<b>{i.BoatAttackVersion}</b>   " +
		            $"Scene:<b>{i.Scene}</b>   " +
		            $"Quality:<b>{i.Quality}</b>\n" + //////////////////////////////////////////////////
		            $"DeviceInfo:<b>{i.Platform}</b>   " +
		            $"<b>{i.API}</b>   " +
		            $"<b>{i.Os.Replace(" ", "")}</b>\n" + ////////////////////////////
		            $"CPU:<b>{i.CPU}</b>   " +
		            $"GPU:<b>{i.GPU}</b>   " +
		            $"Resolution:<b>{i.Resolution}</b>\n" + ////////////////////////////////////////////
		            $"CurrentFrame:<b>{curFrame}</b>   " +
		            $"Mem:<b>{memory}mb</b>   " +
		            $"GPUMem:<b>{gpuMemory}mb</b>\n" + /////////////////////////////////////////////////
		            $"AvgFrametime:<b>{Stats.AvgMs:#0.00}ms</b>   " +
		            $"MinFrametime:<b>{Stats.MinMs*1000:#0.00}ms</b>(frame <b>{Stats.MinMSFrame}</b>)   " +
		            $"MaxFrametime:<b>{Stats.MaxMs*1000:#0.00}ms</b>(frame <b>{Stats.MaxMSFrame}</b>)";
		frametimeDisplay.text = $"<b><size=50>Boat Attack Benchmark</size></b>\n{debugInfo}";
	}

	private void ResetRun()
	{
		Debug.Log($"<b>Run {_runNumber}: TotalRuntime:{Stats.RunTime:#0.00}s</b>\n{debugInfo}");
		Stats.RawSamples = samples.ToArray();
		samples.Clear();
		
		curFrame = 0;
		_stats.Add(new PerfBasic(runLength));
		if (_runNumber < runCount)
		{
			_runNumber++;
		}
		else
		{
			Benchmark.EndBenchmark();
		}
	}

	private void UpdateFrametime()
	{
		Stats.AvgMs = 0f;
        var sampleDivision = 1f / samples.Count;
        
        foreach (var t in samples)
        {
	        Stats.AvgMs += t * sampleDivision;
        }
        
        if (Stats.MinMs > samples[0])
        {
	        Stats.MinMs = samples[0];
	        Stats.MinMSFrame = curFrame;
        }

        if (curFrame > 20 && Stats.MaxMs < samples[0])
        {
	        Stats.MaxMs = samples[0];
	        Stats.MaxMSFrame = curFrame;
        }

        Stats.AvgMs *= 1000;
    }
}
