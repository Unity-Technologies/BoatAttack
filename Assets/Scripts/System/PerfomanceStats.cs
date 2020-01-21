using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class PerfomanceStats : MonoBehaviour {

    // Frame time stats
    private List<float> samples = new List<float>();
    private int totalSamples = 250;


    // UI display
    public Text frametimeDisplay;
    
	void Update () {
        frametimeDisplay.text = "";
        // sample frametime
        samples.Insert(0, Time.deltaTime); // add sample at the start
		if(samples.Count >= totalSamples - 1)
		{
            samples.RemoveAt(totalSamples);
        }
        UpdateFrametime();

        long totalMem = Profiler.GetTotalAllocatedMemoryLong();
        frametimeDisplay.text += string.Format("Total Memory:{0}Mbs\n", ((float)totalMem / 1000000).ToString("##.00"));
        long gpuMem = Profiler.GetAllocatedMemoryForGraphicsDriver();
        frametimeDisplay.text += string.Format("GPU Memory:{0}Mbs\n", ((float)gpuMem / 1000000).ToString("##.00"));

        //frametimeDisplay.text += string.Format("RenderPipe:{0}ms", "d");
    }

	void UpdateFrametime()
	{
        float avgFrametime = 0f;
        float sampleDivision = 1f / samples.Count;
        for(var i = 0; i < samples.Count; i++)
		{
            avgFrametime += samples[i] * sampleDivision;
        }

        frametimeDisplay.text += string.Format("Total time:{0}ms fps:{1}\n", (avgFrametime * 1000).ToString("00.00"), (1f / avgFrametime).ToString("###.00"));
    }
}
