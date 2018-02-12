using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

        [SerializeField]
        private RenderTexture _depthTex;
        [SerializeField]
        private Camera _depthCam;
        [SerializeField]
        private RenderTexture _fxTexture;
        private Camera _fxCam;
        public float _waterMaxDepth = 40f;
        [SerializeField]
        private Texture2D _colorRamp;
        public Gradient _absorptionRampRaw;
        public Gradient _scatterRampRaw;
        [SerializeField]
        public List<Wave> _waves = new List<Wave>();
        [SerializeField]
        private Wave[] _backupWaves;
        [SerializeField]
        bool _customWaves = false;
        [SerializeField]
        public int randomSeed = 3234;
        [SerializeField]
        public BasicWaves _basicWaveSettings = new BasicWaves(1f, 45f, 4);
        private float _maxWaveHeight;
        [SerializeField]
        DebugMode _debugMode;

        void Start()
        {
            Init();
        }

        void OnDestroy()
        {
            if (_depthCam)
            {
                _depthCam.targetTexture = null;
                DestroyImmediate(_depthCam.gameObject);
            }
            if(_depthTex)
                DestroyImmediate(_depthTex);
            if(_fxCam)
            {
                _fxCam.targetTexture = null;
                DestroyImmediate(_fxCam.gameObject);
            }
            if(_fxTexture)
                DestroyImmediate(_fxTexture);
        }

        public void Init()
        {
            SetWaves();
            GenerateVertexColors();
            GenerateColorRamp();
            CaptureDepthMap();
            CreateFXCam();
        }

        void CreateFXCam()
        {
            if(!_fxCam)
            {
                GameObject go = new GameObject("FXCam");
                go.hideFlags = HideFlags.HideAndDontSave;
                _fxCam = go.AddComponent<Camera>();
                _fxCam.cullingMask = (1 << LayerMask.NameToLayer("WaterFX"));
                _fxCam.clearFlags = CameraClearFlags.Color;
                _fxCam.backgroundColor = Color.black;
                _fxCam.transform.SetPositionAndRotation(Camera.main.transform.position, Camera.main.transform.rotation);
                _fxCam.depthTextureMode = DepthTextureMode.None;
                _fxCam.depth = -20;
            }

            if(!_fxTexture)
            {
                _fxTexture = new RenderTexture(Camera.main.pixelWidth, Camera.main.pixelHeight, 0, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear);
                _fxTexture.name = "_WaterFX_Texture";
                _fxCam.targetTexture = _fxTexture;
                Debug.LogError(_fxTexture);
            }
            Shader.SetGlobalTexture("_WaterFXMap", _fxTexture);
        }

        void Update()
        {
            if(_fxCam)
            {
                _fxCam.transform.SetPositionAndRotation(Camera.main.transform.position, Camera.main.transform.rotation);
                _fxCam.fieldOfView = Camera.main.fieldOfView;
                if(_fxCam.activeTexture == null)
                    _fxCam.targetTexture =_fxTexture;
            }
        }

        public void FragWaveNormals(bool toggle)
        {
            Material mat = GetComponent<Renderer>().sharedMaterial;
            if (toggle)
                mat.EnableKeyword("GERSTNER_WAVES");
            else
                mat.DisableKeyword("GERSTNER_WAVES");
        }

        [ContextMenu("UpdateShader")]
        void SetWaves()
        {
            //if (_customWaves)
                //_backupWaves = _waves.ToArray();

            Vector4[] waveData = new Vector4[10];
            Vector4[] waveData2 = new Vector4[10];
            for (int i = 0; i < _waves.Count; i++)
            {
                waveData[i] = new Vector4(_waves[i].amplitude, _waves[i].direction, _waves[i].wavelength, 1);//1 is for omni testing only TODO
                waveData2[i] = new Vector4(_waves[i].origin.x, _waves[i].origin.y, 0, 0);
            }

            foreach (Wave w in _waves)
            {
                _maxWaveHeight += w.amplitude;
            }
            _maxWaveHeight /= (float)_waves.Count;

            Shader.SetGlobalFloat("_MaxWaveHeight", _maxWaveHeight);
            Shader.SetGlobalFloat("_MaxDepth", _waterMaxDepth);

            //GPU side
            Shader.SetGlobalInt("_WaveCount", _waves.Count);
            Shader.SetGlobalVectorArray("_WaveData", waveData);
            Shader.SetGlobalVectorArray("_WaveData2", waveData2);
            //CPU side
            GerstnerWaves.GerstnerWaves._WaveCount = _waves.Count;
            GerstnerWaves.GerstnerWaves._WaveData = waveData;
            GerstnerWaves.GerstnerWaves._WaveData2 = waveData2;
            CaptureDepthMap();
            GenerateVertexColors();
        }

        public void ToggleBasicWaves(bool custom)
        {
            if(!custom)
            {
                //create basic waves based off basic wave settings
                Random.State backupSeed = Random.state;
                Random.InitState(randomSeed);
                float a = _basicWaveSettings.amplitude;
                float d = _basicWaveSettings.direction;
                float l = _basicWaveSettings.wavelength;
                _waves.Clear();

                float r = 1f / _basicWaveSettings.numWaves;

                for (int i = 0; i <= _basicWaveSettings.numWaves; i++)
                {
                    float p = Mathf.Lerp(0.5f, 1.5f, (float)i * r);
                    float amp = a * p * Random.Range(0.8f, 1.2f);
                    float dir = d + Random.Range(-45f, 45f);
                    float len = l * p * Random.Range(0.8f, 1.2f);
                    Vector2 origin = new Vector2(Random.value * 2 - 1, Random.value * 2 - 1);
                    _waves.Add(new Wave(amp, dir, len, origin * 500f, true));//large wave
                    Random.InitState(randomSeed + i + 1);
                }

                Random.state = backupSeed;
            }
            else
            {
                //restore custom waves
                _waves.Clear();
                _waves.AddRange(_backupWaves);
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

            _colorRamp = new Texture2D(128, 2, TextureFormat.ARGB32, false, false);
            _colorRamp.wrapMode = TextureWrapMode.Clamp;

            Color[] cols = new Color[256];
            for (int i = 0; i < 128; i++)
            {
                cols[i] = _absorptionRampRaw.Evaluate((float)i / 128f);
            }
            for (int i = 0; i < 128; i++)
            {
                cols[i + 128] = _scatterRampRaw.Evaluate((float)i / 128f);
            }
            _colorRamp.SetPixels(cols);
            _colorRamp.Apply();
            Shader.SetGlobalTexture("_AbsorptionScatteringRamp", _colorRamp);
        }

        GerstnerWaves.WaveStruct tempWave = new GerstnerWaves.WaveStruct();

        public float GetWaterHeight(Vector3 pos)
        {
            float waveHeight = 0;
            tempWave = GerstnerWaves.GerstnerWaves.SampleWaves(pos, 1f);
            waveHeight = (tempWave.position.y + transform.position.y) - pos.y;

            return waveHeight;
        }

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
            _depthCam.transform.position = transform.position + Vector3.up * 4f;//center the camera on this water plane
            _depthCam.transform.up = Vector3.forward;//face teh camera down
            _depthCam.enabled = true;
            _depthCam.orthographic = true;
            _depthCam.orthographicSize = 500;//hardcoded - TODO
            _depthCam.depthTextureMode = DepthTextureMode.Depth;
            _depthCam.nearClipPlane =0.1f;
            _depthCam.farClipPlane = _waterMaxDepth;
            _depthCam.allowHDR = false;
            //_depthCam.allowMSAA = false;
            _depthCam.cullingMask = (1 << 10);
            //Generate RT
            if (!_depthTex)
                _depthTex = new RenderTexture(1024, 1024, 24, RenderTextureFormat.Depth);
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
            _depthCam.enabled = false;
            _depthCam.targetTexture = null;
        }

        [System.Serializable]
        public class Wave
        {
            public float amplitude = 0.1f;//height of the wave in units
            public float direction = 0f;//direction the wave travels in degrees from Z+
            public float wavelength = 2f;//distance between crest>crest
            public Vector2 origin = Vector2.zero;
            public bool onmiDir;
            public Wave(float amp, float dir, float length, Vector2 org, bool omni)
            {
                amplitude = amp;
                direction = dir;
                wavelength = length;
                origin = org;
                onmiDir = omni;
            }
        }

        [System.Serializable]
        public class BasicWaves
        {
            public int numWaves = 6;
            public float amplitude;
            public float direction;
            public float wavelength;

            public BasicWaves(float amp, float dir, float len)
            {
                numWaves = 6;
                amplitude = amp;
                direction = dir;
                wavelength = len;
            }
        }

        [System.Serializable]
        public enum DebugMode { none, stationary, screen };
    }
}
