using UnityEngine.Profiling;
using UnityEngine.Rendering;

namespace UnityEngine.Experimental.Rendering
{
    public class MiniProfiler : MonoBehaviour
    {
        private bool m_Enable = true;
        private const float kAverageStatDuration = 1.0f;            // stats refresh each second
        private int m_frameCount;
		private float m_AccDeltaTime;
        private string m_statsLabel;
        private GUIStyle m_style;

        private float[] m_frameTimes = new float[5000];
        private int m_totalFrames = 0;
        private float m_minFrameTime = 1000f;
        private float m_maxFrameTime = 0f;

        internal class RecorderEntry
        {
            public string name;
            public int callCount;
            public float accTime;
            public Profiling.Recorder recorder;
        };

		enum Markers
		{
			kRenderloop,
			kCulling,
            kShadows,
            kDraw,
            kPost,
		};
		
        RecorderEntry[] recordersList =
        {
			// Warning: Keep that list in the exact same order than SRPBMarkers enum
            new RecorderEntry() { name="UnityEngine.CoreModule.dll!UnityEngine.Rendering::RenderPipelineManager.DoRenderLoop_Internal()" },
            new RecorderEntry() { name="CullScriptable" },
            new RecorderEntry() { name="Shadows.ExecuteDrawShadows" },
            new RecorderEntry() { name="RenderLoop.ScheduleDraw" },
            new RecorderEntry() { name="Render PostProcessing Effects" },
        };

        void Awake()
        {
            for (int i = 0; i < recordersList.Length; i++)
            {
                var sampler = Sampler.Get(recordersList[i].name);
                if (sampler.isValid)
                    recordersList[i].recorder = sampler.GetRecorder();
            }

            m_style =new GUIStyle();
            m_style.fontSize = 30;
            m_style.normal.textColor = Color.white;

            ResetStats();

        }

        void RazCounters()
        {
            m_AccDeltaTime = 0.0f;
            m_frameCount = 0;
            for (int i = 0; i < recordersList.Length; i++)
            {
                recordersList[i].accTime = 0.0f;
                recordersList[i].callCount = 0;
            }
        }

        void    ResetStats()
        {
             m_statsLabel = "Gathering data...";
             RazCounters();
        }

        void Update()
        {
            if (m_Enable)
            {
                m_AccDeltaTime += Time.unscaledDeltaTime;
                m_frameCount++;

                m_frameTimes[(int) Mathf.Repeat(m_totalFrames, 5000)] = Time.unscaledDeltaTime;

                int frameFactor = Mathf.Clamp(m_totalFrames, 0, 5000);

                float m_averageFrameTime = 0f;
                
                for (int i = 0; i < frameFactor; i++)
                {
                    m_averageFrameTime += m_frameTimes[i];
                }

                if (m_frameCount > 10)
                {
                    m_minFrameTime = Time.unscaledDeltaTime < m_minFrameTime ? Time.unscaledDeltaTime : m_minFrameTime;
                    m_maxFrameTime = Time.unscaledDeltaTime > m_maxFrameTime ? Time.unscaledDeltaTime : m_maxFrameTime;
                }

                // get timing & update average accumulators
                for (int i = 0; i < recordersList.Length; i++)
                {
                    if (recordersList[i].recorder != null)
                    {
                        recordersList[i].accTime += recordersList[i].recorder.elapsedNanoseconds / 1000000.0f;      // acc time in ms
                        recordersList[i].callCount += recordersList[i].recorder.sampleBlockCount;
                    }
                }

				if (m_AccDeltaTime >= kAverageStatDuration)
				{

					float ooFrameCount = 1.0f / (float)m_frameCount;
					float avgLoop = recordersList[(int)Markers.kRenderloop].accTime * ooFrameCount;
					float avgCulling = recordersList[(int)Markers.kCulling].accTime * ooFrameCount;
					float avgShadow = recordersList[(int)Markers.kShadows].accTime * ooFrameCount;
					float avgDraw = recordersList[(int)Markers.kDraw].accTime * ooFrameCount;
					float avgPost = recordersList[(int)Markers.kPost].accTime * ooFrameCount;

					m_statsLabel = $"Rendering Loop Main Thread:{avgLoop:N}ms\n";
					m_statsLabel += $"    Culling:{avgCulling:N}ms\n";
					m_statsLabel += $"    Shadows:{avgShadow:N}ms\n";
					m_statsLabel += $"    Draws:{avgDraw:F2}ms\n";
					m_statsLabel += $"    PostProcessing:{avgPost:F2}ms\n";
					m_statsLabel += $"Total: {(m_AccDeltaTime * 1000.0f * ooFrameCount):F2}ms ({(int)(((float)m_frameCount) / m_AccDeltaTime)} FPS)\n";
                    
                    float frameMulti = 1f / frameFactor;
                    m_statsLabel += $"Average:{(m_averageFrameTime * 1000f * frameMulti):F2}ms\n";
                    m_statsLabel += $"Minimum:{m_minFrameTime * 1000f:F2}ms\n";
                    m_statsLabel += $"Maximum:{m_maxFrameTime * 1000f:F2}ms\n";
                    
					RazCounters();
				}
            }

            m_totalFrames++;
        }

        void OnGUI()
        {
            if (m_Enable)
            {
                bool SRPBatcher = UnityEngine.Rendering.Universal.UniversalRenderPipeline.asset.useSRPBatcher;

//                GUI.skin.label.fontSize = 15;
                GUI.color = new Color(1, 1, 1, 1);
                float w = 1000, h = 356;

                if ( SRPBatcher )
                    GUILayout.BeginArea(new Rect(32, 50, w, h), "(SRP batcher ON)", GUI.skin.window);
                else
                    GUILayout.BeginArea(new Rect(32, 50, w, h), "(SRP batcher OFF)", GUI.skin.window);

                GUILayout.Label(m_statsLabel, m_style);

                GUILayout.EndArea();
            }
        }
    }
}
