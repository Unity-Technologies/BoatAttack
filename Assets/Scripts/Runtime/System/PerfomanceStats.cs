using System;
using System.Collections.Generic;
using BoatAttack;
using BoatAttack.Benchmark;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class PerfomanceStats : MonoBehaviour
{
	// Frame time stats
	private PerfBasic Stats;
	private TestInfo defaultInfo;
	private float frametime;
	private float runtime;

	// Demo stuff
	public PerfMode mode = PerfMode.DisplayOnly;
	private const int demoFrames = 1000;

	// TempData
	private float averageFrametime;
	private float averageVel;
	private FrameData minFrame = FrameData.DefaultMin;
	private FrameData maxFrame = FrameData.DefaultMax;

	// UI display
    private TextMeshProUGUI frametimeDisplay;
    private string debugInfo;
    
    private void Start()
    {
	    CreateTextGui();
		defaultInfo = new TestInfo("Test");
    }

    public void StartRun(string benchmarkName, int runLength)
    {
	    Stats = new PerfBasic(benchmarkName, Benchmark.UrpVersion, runLength);
	    CreateTextGui();
    }

    private void Update ()
    {
	    if (!frametimeDisplay) return;
	    
	    // Timing
	    frametime = Time.unscaledDeltaTime * 1000f;
	    runtime += Time.unscaledDeltaTime;

	    UpdateFrametime();

	    //Displaying
	    var totalMem = Profiler.GetTotalAllocatedMemoryLong();
	    var mem = ((float) totalMem / 1000000).ToString("#0.00");
	    var gpuMem = Profiler.GetAllocatedMemoryForGraphicsDriver();
	    var gpu = ((float) gpuMem / 1000000).ToString("#0.00");
	    DrawText(mem, gpu);

	    //Saving Data
	    if (mode == PerfMode.Benchmark && Stats != null)
	    {
		    if (Benchmark.CurrentRunIndex >= 0 && Benchmark.CurrentRunIndex < Stats.RunData.Length)
		    {
			    var runData = Stats.RunData?[Benchmark.CurrentRunIndex];
			    if (runData == null)
				    Stats.RunData[0] = new RunData(new float[Benchmark.Current.runLength]);

			    runData.rawSamples[Benchmark.CurrentRunFrame] = frametime; // add sample
		    }
	    }

	    // Auto mode
        if (mode == PerfMode.DisplayOnly)
        {
	        Benchmark.CurrentRunFrame++;
	        if (Benchmark.CurrentRunFrame >= demoFrames)
		        Benchmark.CurrentRunFrame = 0;
        }
    }

    private void DrawText(string memory, string gpuMemory)
	{
		frametimeDisplay.text = "";
		var info = mode == PerfMode.Benchmark ? Stats?.info ?? defaultInfo : defaultInfo;
		debugInfo = $"<b>Unity:</b>{info.UnityVersion}   " +
		            $"<b>URP:</b>{info.UrpVersion}   " +
		            $"<b>Build:</b>{info.BoatAttackVersion}   " +
		            $"<b>Scene:</b>{info.Scene}   " +
		            $"<b>Quality:</b>{info.Quality}\n" +
		            //////////////////////////////////////////////////
		            $"<b>DeviceInfo:</b>{info.Platform}   " +
		            $"{info.API}   " +
		            $"{info.Os}\n" +
		            //////////////////////////////////////////////////
		            $"<b>CPU:</b>{info.CPU}   " +
		            $"<b>GPU:</b>{info.GPU}   " +
		            $"<b>Resolution:</b>{info.Resolution}\n" +
		            //////////////////////////////////////////////////
		            $"<b>CurrentFrame:</b>{Benchmark.CurrentRunFrame}   " +
		            $"<b>Mem:</b>{memory}mb   " +
		            $"<b>GPUMem:</b>{gpuMemory}mb\n" +
		            //////////////////////////////////////////////////
		            $"<b>Frametimes Average:</b>{averageFrametime:#0.00}ms   " +
		            $"<b>Min(Fastest):</b>{minFrame.ms:#0.00}ms(@frame {minFrame.frameIndex})   " +
		            $"<b>Max(Slowest):</b>{maxFrame.ms:#0.00}ms(@frame {maxFrame.frameIndex})";
		frametimeDisplay.text = $"<size=50>{Application.productName} Benchmark - {info.BenchmarkName}</size>\n{debugInfo}";
	}

	public void EndRun()
	{
		var runNumber = Benchmark.CurrentRunIndex == -1 ? "Warmup" : (Benchmark.CurrentRunIndex + 1).ToString();
		Debug.Log($"<b>{Stats.info.BenchmarkName} " +
		          $"Run {runNumber}:" +
		          $"TotalRuntime:{runtime:#0.00}s</b>\n{debugInfo}");

		if (Benchmark.CurrentRunIndex >= 0 && !Benchmark.SimpleRun)
		{
			Stats.RunData[Benchmark.CurrentRunIndex].EndRun(runtime, minFrame, maxFrame);
		}

		minFrame = FrameData.DefaultMin;
		maxFrame = FrameData.DefaultMax;
		runtime = 0.0f;
	}

	public PerfBasic EndBench()
	{
		frametimeDisplay.text = "<size=50>Benchmark Ended</size>";
		return Stats != null ? Stats : null;
	}

	private void UpdateFrametime()
	{
		averageFrametime = Mathf.SmoothDamp(averageFrametime, frametime, ref averageVel, 5.0f);
		averageFrametime = Mathf.SmoothDamp(averageFrametime, frametime, ref averageVel, 5.0f);

        if (minFrame.ms > frametime)
        {
	        minFrame.Set(Benchmark.CurrentRunFrame, frametime);
        }

        if (maxFrame.ms < frametime)
        {
	        maxFrame.Set(Benchmark.CurrentRunFrame, frametime);
        }
	}

	private void CreateTextGui()
	{
		if (frametimeDisplay != null) return;
		var textGo = new GameObject("perfText", typeof(TextMeshProUGUI));
		textGo.transform.SetParent(AppSettings.ConsoleCanvas.transform, true);

		frametimeDisplay = textGo.GetComponent<TextMeshProUGUI>();
		frametimeDisplay.fontSize = 20.0f;
		frametimeDisplay.lineSpacing = 1.2f;
		frametimeDisplay.characterSpacing = 5.0f;
		frametimeDisplay.raycastTarget = false;

		var rectTransform = frametimeDisplay.rectTransform;
		rectTransform.anchorMin = rectTransform.sizeDelta = rectTransform.anchoredPosition = Vector2.zero;
		rectTransform.anchorMax = Vector2.one;
	}

	public enum PerfMode
	{
		Benchmark,
		DisplayOnly
	}
}
