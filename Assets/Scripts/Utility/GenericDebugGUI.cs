using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaterSystem;

/*
[ExecuteAlways]
public class GenericDebugGUI : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.TextArea(new Rect(0, 0, Screen.width * 0.2f, Screen.height), GerstnerWaveRegistry());
    }

    private string GerstnerWaveRegistry()
    {
        var output = "Gerstner Wave Registry:\n";
        var data = GerstnerWavesJobs.Registry;

        foreach (var entry in data)
        {
            output += $" GUID:{entry.guid} - {entry.name}\n -Sample Point {entry.offsets.y - entry.offsets.x}\n -Offsets {entry.offsets}\n";
        }

        return output;
    }
}
*/
