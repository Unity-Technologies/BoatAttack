#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace BoatAttack
{
    public static class Utility
    {
        public static event Action<int, int> QualityLevelChange;
        private static int lastQualityLevel = -1;
        
        public static void CheckQualityLevel()
        {
            var curLevel = QualitySettings.GetQualityLevel();
            if (lastQualityLevel == curLevel) return;
            
            if(UniversalRenderPipeline.asset.debugLevel != PipelineDebugLevel.Disabled)
                Debug.Log($"Quality level changed:{lastQualityLevel} to {curLevel}");
            QualityLevelChange?.Invoke(lastQualityLevel, curLevel);
            lastQualityLevel = curLevel;
        }

        public static string RemoveWhitespace(string input)
        {
            return Regex.Replace(input, @"\s+", "");
        }
    }
    
#if UNITY_EDITOR
    [InitializeOnLoad]
    internal class UtilityScheduler
    {
        static UtilityScheduler()
        {
            // setup the things
            if(UniversalRenderPipeline.asset.debugLevel != PipelineDebugLevel.Disabled)
                Debug.Log("Setting up some utilities");
            EditorApplication.update += Utility.CheckQualityLevel;
        }
    }
#endif
}