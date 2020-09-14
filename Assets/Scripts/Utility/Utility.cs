#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using UnityEngine;

namespace BoatAttack
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public class Utility
    {
        public static event Action<int, int> QualityLevelChange;
        private static int lastQualityLevel = -1;
        
#if UNITY_EDITOR
        static Utility()
        {
            // setup the things
            Debug.Log("Setting up some utilities");
            EditorApplication.update += CheckQualityLevel;
        }
#endif

        public static void CheckQualityLevel()
        {
            var curLevel = QualitySettings.GetQualityLevel();
            if (lastQualityLevel == curLevel) return;
            
            Debug.Log($"Quality level changed:{lastQualityLevel} to {curLevel}");
            QualityLevelChange?.Invoke(lastQualityLevel, curLevel);
            lastQualityLevel = curLevel;
        }
    }
}