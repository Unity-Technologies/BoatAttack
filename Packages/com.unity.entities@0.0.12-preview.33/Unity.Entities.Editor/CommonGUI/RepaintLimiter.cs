using UnityEditor;
using UnityEngine;

namespace Unity.Entities.Editor
{
    internal class RepaintLimiter
    {
        
        private float lastUpdate;
        private int lastFrame;
        public const float defaultUpdateFrequency = 0.2f;
        private readonly float playingRepaintFrequency;

        public RepaintLimiter(float frequency = defaultUpdateFrequency)
        {
            playingRepaintFrequency = frequency;
        }

        public bool SimulationAdvanced()
        {
            if (EditorApplication.isPlaying) 
            {
                var playUpdate = !EditorApplication.isPaused && Time.unscaledTime > lastUpdate + playingRepaintFrequency;
                var stepUpdate = EditorApplication.isPaused && Time.frameCount != lastFrame;
                return playUpdate || stepUpdate;
            }

            return false;
        }

        public void RecordRepaint()
        {
            lastUpdate = Time.unscaledTime;
            lastFrame = Time.frameCount;
        }
    }
}