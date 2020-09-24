#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Object = UnityEngine.Object;

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
            var realIndex = GetTrueQualityLevel(curLevel);
            QualityLevelChange?.Invoke(curLevel, realIndex);
            lastQualityLevel = curLevel;
        }

        public static int GetTrueQualityLevel()
        {
            return GetTrueQualityLevel(QualitySettings.GetQualityLevel());
        }

        public static int GetTrueQualityLevel(int level)
        {
            return ConstantData.QualityLevels.IndexOf(QualitySettings.names[level]);
        }

        public static string RemoveWhitespace(string input)
        {
            return Regex.Replace(input, @"\s+", "");
        }

        public static void SafeDestroy(Object obj)
        {
            if (obj != null)
            {
#if UNITY_EDITOR
                EditorApplication.delayCall += () => Object.DestroyImmediate(obj);
                return;
#else
                Object.Destroy(obj);
                return;
#endif
            }
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