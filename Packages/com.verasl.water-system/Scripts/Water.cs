using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.LightweightPipeline;
using WaterSystem.Data;

namespace WaterSystem
{
    [ExecuteInEditMode]
    public class Water : MonoBehaviour
    {
        // Singleton
        private static Water _Instance = null;
        public static Water Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = (Water)FindObjectOfType(typeof(Water));
                return _Instance;
            }
        }

        private bool useComputeBuffer;
        public bool computeOverride;

        private RenderTexture _depthTex;
        private Camera _depthCam;
        [SerializeField]
        private Texture2D _rampTexture;
        [SerializeField]
        public Wave[] _waves;
        [SerializeField]
        private ComputeBuffer _waveBuffer;
        private float _maxWaveHeight;

        [SerializeField]
        public WaterSettingsData settingsData;
        [SerializeField]
        public WaterSurfaceData surfaceData;
        [SerializeField]
        private WaterResources resources;
        private float waterTime = 0;

        void OnEnable()
        {
            if (!computeOverride)
                useComputeBuffer = SystemInfo.supportsComputeShaders &&
                                   Application.platform != RuntimePlatform.WebGLPlayer;
            else
                useComputeBuffer = false;
            Init();
            LightweightPipeline.beginCameraRendering += BeginCameraRendering;

            if(resources == null)
            {
                resources = Resources.Load("WaterResources") as WaterResources;
            }
        }

        private void OnDisable() {
            Cleanup();
        }

        void Cleanup()
        {
            if(Application.isPlaying)
                GerstnerWavesJobs.Cleanup();
            LightweightPipeline.beginCameraRendering -= BeginCameraRendering;
            if (_depthCam)
            {
                _depthCam.targetTexture = null;
                SafeDestroy(_depthCam.gameObject);
            }
            if (_depthTex)
            {
                SafeDestroy(_depthTex);
            }
            if(_waveBuffer != null)
                _waveBuffer.Dispose();
        }

        private void BeginCameraRendering(Camera cam)
        {
            Vector3 fwd = cam.transform.forward;
            fwd.y = 0;
            float roll = cam.transform.localEulerAngles.z;
            Shader.SetGlobalFloat("_CameraRoll", roll);
            Shader.SetGlobalMatrix("_InvViewProjection", (GL.GetGPUProjectionMatrix(cam.projectionMatrix, false) * cam.worldToCameraMatrix).inverse);
        }

        private void SafeDestroy(Object o)
        {
            if(Application.isPlaying)
                Destroy(o);
            else
                DestroyImmediate(o);
        }

        public void Init()
        {
            SetWaves();
            GenerateColorRamp();
            CaptureDepthMap();
        }

        void Update()
        {
            if(Application.isPlaying)
            {
                waterTime = Time.time;
                Shader.SetGlobalFloat("_GlobalTime", waterTime);
            }
        }

        private void FixedUpdate() {
            if(Application.isPlaying)
                GerstnerWavesJobs.UpdateHeights();
        }

        public void FragWaveNormals(bool toggle)
        {
            Material mat = GetComponent<Renderer>().sharedMaterial;
            if (toggle)
                mat.EnableKeyword("GERSTNER_WAVES");
            else
                mat.DisableKeyword("GERSTNER_WAVES");
        }

        void SetWaves()
        {
            SetupWaves(surfaceData._customWaves);

            // set default resources
            Shader.SetGlobalTexture("_FoamMap", resources.defaultFoamMap);
            Shader.SetGlobalTexture("_SurfaceMap", resources.defaultSurfaceMap);

            _maxWaveHeight = 0f;
            foreach (Wave w in _waves)
            {
                _maxWaveHeight += w.amplitude;
            }
            _maxWaveHeight /= (float)_waves.Length;

            Shader.SetGlobalFloat("_MaxWaveHeight", _maxWaveHeight);
            Shader.SetGlobalFloat("_MaxDepth", surfaceData._waterMaxVisibility);

            switch(settingsData.refType)
            {
                case ReflectionType.Cubemap:
                Shader.EnableKeyword("_REFLECTION_CUBEMAP");
                Shader.DisableKeyword("_REFLECTION_PROBES");
                Shader.DisableKeyword("_REFLECTION_PLANARREFLECTION");
                Shader.SetGlobalTexture("_CubemapTexture", settingsData.cubemapRefType);
                break;
                case ReflectionType.ReflectionProbe:
                Shader.DisableKeyword("_REFLECTION_CUBEMAP");
                Shader.EnableKeyword("_REFLECTION_PROBES");
                Shader.DisableKeyword("_REFLECTION_PLANARREFLECTION");
                break;
                case ReflectionType.PlanarReflection:
                Shader.DisableKeyword("_REFLECTION_CUBEMAP");
                Shader.DisableKeyword("_REFLECTION_PROBES");
                Shader.EnableKeyword("_REFLECTION_PLANARREFLECTION");
                break;
            }

            Shader.SetGlobalInt("_WaveCount", _waves.Length);

            //GPU side
            if (useComputeBuffer)
            {
                Shader.EnableKeyword("USE_STRUCTURED_BUFFER");
                if (_waveBuffer == null)
                    _waveBuffer = new ComputeBuffer(10, (sizeof(float) * 6));
                _waveBuffer.SetData(_waves);
                Shader.SetGlobalBuffer("_WaveDataBuffer", _waveBuffer);
            }
            else
            {
                Shader.DisableKeyword("USE_STRUCTURED_BUFFER");
                Shader.SetGlobalVectorArray("waveData", GetWaveData());
            }
            //CPU side
            if(GerstnerWavesJobs.init == false && Application.isPlaying)
                GerstnerWavesJobs.Init();
        }

        public Vector4[] GetWaveData()
        {
            Vector4[] waveData = new Vector4[20];
            for (int i = 0; i < _waves.Length; i++)
            {
                waveData[i] = new Vector4(_waves[i].amplitude, _waves[i].direction, _waves[i].wavelength, _waves[i].onmiDir);
                waveData[i+10] = new Vector4(_waves[i].origin.x, _waves[i].origin.y, 0, 0);
            }
            return waveData;
        }

        public void SetupWaves(bool custom)
        {
            if(!custom)
            {
                //create basic waves based off basic wave settings
                Random.State backupSeed = Random.state;
                Random.InitState(surfaceData.randomSeed);
                BasicWaves basicWaves = surfaceData._basicWaveSettings;
                float a = basicWaves.amplitude;
                float d = basicWaves.direction;
                float l = basicWaves.wavelength;
                int numWave = basicWaves.numWaves;
                _waves = new Wave[numWave];

                float r = 1f / numWave;

                for (int i = 0; i < numWave; i++)
                {
                    float p = Mathf.Lerp(0.5f, 1.5f, (float)i * r);
                    float amp = a * p * Random.Range(0.8f, 1.2f);
                    float dir = d + Random.Range(-45f, 45f);
                    float len = l * p * Random.Range(0.6f, 1.4f);
                    _waves[i] = new Wave(amp, dir, len, Vector2.zero, false);
                    Random.InitState(surfaceData.randomSeed + i + 1);
                }
                Random.state = backupSeed;
            }
            else
            {
                _waves = surfaceData._waves.ToArray();
            }
        }

        void GenerateVertexColors()
        {
            Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
            Vector3[] vertices = mesh.vertices;

            // create new colors array where the colors will be created.
            Color[] colors = new Color[vertices.Length];
            RaycastHit hit;

            for (int i = 0; i < vertices.Length; i++)
            {
                colors[i] = Color.black;
                //seafloor Depth
                if (Physics.Raycast(vertices[i], -Vector3.up, out hit))
                    colors[i].r = hit.distance;
            }

            // assign the array of colors to the Mesh.
            mesh.colors = colors;
        }

        public void GenerateColorRamp()
        {

            _rampTexture = new Texture2D(128, 4, TextureFormat.ARGB32, false, false);
            _rampTexture.wrapMode = TextureWrapMode.Clamp;

            Texture2D _defaultFoamRamp = resources.defaultFoamRamp;

            Color[] cols = new Color[512];
            for (int i = 0; i < 128; i++)
            {
                cols[i] = surfaceData._absorptionRamp.Evaluate((float)i / 128f);
            }
            for (int i = 0; i < 128; i++)
            {
                cols[i + 128] = surfaceData._scatterRamp.Evaluate((float)i / 128f);
            }
            for (int i = 0; i < 128; i++)
            {
                switch(surfaceData._foamSettings.foamType)
                {
                    case 0:
                    {
                        // default
                        cols[i + 256] = _defaultFoamRamp.GetPixelBilinear((float)i / 128f , 0.5f);
                    }break;
                    case 1:
                    {
                        // simple
                        cols[i + 256] = _defaultFoamRamp.GetPixelBilinear(surfaceData._foamSettings.basicFoam.Evaluate((float)i / 128f) , 0.5f);
                    }break;
                    case 2:
                    {
                        // custom
                        cols[i + 256] = Color.black;
                    }break;
                }
            }
            _rampTexture.SetPixels(cols);
            _rampTexture.Apply();
            Shader.SetGlobalTexture("_AbsorptionScatteringRamp", _rampTexture);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////Shoreline Depth Texture/////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [ContextMenu("Capture Depth")]
        public void CaptureDepthMap()
        {
            //Generate the camera
            if(_depthCam == null)
            {
                GameObject go = new GameObject("depthCamera");//create the cameraObject
                go.hideFlags = HideFlags.HideAndDontSave;
                _depthCam = go.AddComponent<Camera>();
            }
            _depthCam.transform.position = Vector3.up * 4f;//center the camera on this water plane
            _depthCam.transform.up = Vector3.forward;//face teh camera down
            _depthCam.enabled = true;
            _depthCam.orthographic = true;
            _depthCam.orthographicSize = 250;//hardcoded = 1k area - TODO
            _depthCam.depthTextureMode = DepthTextureMode.Depth;
            _depthCam.nearClipPlane =0.1f;
            _depthCam.farClipPlane = surfaceData._waterMaxVisibility;
            _depthCam.allowHDR = false;
            //_depthCam.allowMSAA = false;
            _depthCam.cullingMask = (1 << 10);
            //Generate RT
            if (!_depthTex)
                _depthTex = new RenderTexture(1024, 1024, 24, RenderTextureFormat.Depth, RenderTextureReadWrite.Linear);
            _depthTex.name = "WaterDepthMap";
            //do depth capture
            _depthCam.targetTexture = _depthTex;
            _depthCam.Render();
            Shader.SetGlobalTexture("_WaterDepthMap", _depthTex);
            // set depthbufferParams for depth cam(since it doesnt exist and only temporary)
            float n = _depthCam.nearClipPlane;
            float f = _depthCam.farClipPlane;
            Vector4 zParams = new Vector4(n, f, f / (f-n), f * n / (n-f));
            //Vector4 zParams = new Vector4(1-f/n, f/n, (1-f/n)/f, (f/n)/f);//2015
            Shader.SetGlobalVector("_depthCamZParams", zParams);
            
            #if UNITY_EDITOR
/*            Texture2D tex2D = new Texture2D(1024, 1024, TextureFormat.Alpha8, false);
            Graphics.CopyTexture(_depthTex, tex2D);
            byte[] image = tex2D.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/WaterDepth.png", image);*/
            #endif
            
            _depthCam.enabled = false;
            _depthCam.targetTexture = null;
        }

        private void OnDrawGizmos() {
            if(!Application.isPlaying)
            {
                #if UNITY_EDITOR
                waterTime = (float)UnityEditor.EditorApplication.timeSinceStartup;
                #endif
                Shader.SetGlobalFloat("_GlobalTime", waterTime);
            }
        }

        [System.Serializable]
        public enum DebugMode { none, stationary, screen };
    }
}
