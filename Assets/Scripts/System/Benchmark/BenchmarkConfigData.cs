using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace BoatAttack.Benchmark
{
    [CreateAssetMenu(fileName = "BenchmarkSettings", menuName = "Boat Attack/System/Benchmark Settings")]
    public class BenchmarkConfigData : ScriptableObject
    {
        public bool saveData;
        public bool disableVSync = true;
        public bool stats = false;
        [NonReorderable]
        public List<BenchmarkData> benchmarkData = new List<BenchmarkData>();
    }

    [Serializable]
    public enum BenchmarkType
    {
        Scene,
        Shader
    }

    [Serializable]
    public enum BenchmarkCameraType
    {
        Static,
        FlyThrough
    }

    [Serializable]
    public enum FinishAction
    {
        Exit,
        ShowStats,
        MainMenu,
        Nothing
    }

    [Serializable]
    public class BenchmarkData
    {
        public string benchmarkName;
#if UNITY_EDITOR
        public SceneAsset sceneAsset;
#endif
        public string scene = "benchmark_island-flythrough";
        public BenchmarkType type;
        public int runs = 4;
        public int runLength = 1000;
        public bool warmup;
        public bool enabled = true;
    }
}
