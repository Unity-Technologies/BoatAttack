using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BoatAttack
{
    public class Benchmark : MonoBehaviour
    {



    }

    [Serializable]
    public class PerfBasic
    {
        public TestInfo info;
        public float RunTime;
        public int Frames;
        public float AvgMs;
        public float MinMs = Single.PositiveInfinity;
        public float MinMSFrame;
        public float MaxMs = Single.NegativeInfinity;
        public float MaxMSFrame;
        public float[] RawSamples;

        public PerfBasic(int frames)
        {
            Frames = frames;
            info = new TestInfo();
        }
    }

    [Serializable]
    public class TestInfo
    {
        public string Scene;
        public string UnityVersion;
        public string UrpVersion;
        public string BoatAttackVersion;
        public string Platform;
        public string API;
        public string CPU;
        public string GPU;
        public string Os;
        public string Quality;
        public string Resolution;

        public TestInfo()
        {
            Scene = SceneManager.GetActiveScene().name.Replace(" ", "");
            UnityVersion = Application.unityVersion;
            UrpVersion = "N/A";
            BoatAttackVersion = Application.version;
            Platform = Application.platform.ToString().Replace(" ", "");
            API = SystemInfo.graphicsDeviceType.ToString().Replace(" ", "");
            CPU = SystemInfo.processorType.Replace(" ", "");
            GPU = SystemInfo.graphicsDeviceName.Replace(" ", "");
            Os = SystemInfo.operatingSystem.Replace(" ", "");
            Quality = QualitySettings.names[QualitySettings.GetQualityLevel()].Replace(" ", "");
            Resolution = $"{Display.main.renderingWidth}x{Display.main.renderingHeight}";
        }
    }
}
