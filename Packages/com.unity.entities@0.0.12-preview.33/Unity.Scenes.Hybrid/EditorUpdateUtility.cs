using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

[assembly: InternalsVisibleTo("Unity.Scenes.Editor")]

namespace Unity.Scenes
{
    static class EditorUpdateUtility
    {
#if UNITY_EDITOR
        public static void EditModeQueuePlayerLoopUpdate()
        {
            if (!Application.isPlaying)
            {
                EditorApplication.QueuePlayerLoopUpdate();
                EditorApplication.update += EditorUpdate;
            }
        }
        static void EditorUpdate()
        {
            EditorApplication.update -= EditorUpdate;
            EditorApplication.QueuePlayerLoopUpdate();
        }
#else    
        public static void EditModeQueuePlayerLoopUpdate() { }
#endif
    }
}
