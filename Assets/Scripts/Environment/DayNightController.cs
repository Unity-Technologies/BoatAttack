using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// Simple day/night system
    /// </summary>
    [ExecuteInEditMode]
    public class DayNightController : MonoBehaviour
    {
        private static DayNightController _instance;
        [Range(0, 1)]
        public float time = 0.5f; // the global 'time'

        private readonly float[] _presets = { 0.27f, 0.35f, 0.45f, 0.55f, 0.65f, 0.73f };
        private int _currentPreset;
        private const string PresetKey = "BoatAttack.DayNight.TimePreset";

        public bool autoIcrement;
        public float speed = 1f;

        public static float GlobalTime;
        [Header("Skybox Settings")]
        // Skybox
        public Material _skybox; // skybox reference
        public Gradient _skyboxColour; // skybox tint over time
        public Transform clouds;
        [Range(-180, 180)]
        public float cloudOffset = 0f;
        public ReflectionProbe[] reflections;
        // Sunlight
        [Header("Sun Settings")]
        public Light _sun; // sun light
        public Gradient _sunColour; // sun light colour over time
        [Range(0, 360)]
        public float _northHeading = 136; // north

        [Range(0, 90)] public float _tilt = 60f;

        
        //Ambient light
        [Header("Ambient Lighting")]
        public Gradient _ambientColour; // ambient light colour (not used in LWRP correctly) over time

        // Fog
        [Header("Fog Settings")][GradientUsage(true)]
        public Gradient _fogColour; // fog colour over time

        // vars
        private float _prevTime; // previous time

        void Awake()
        {
            _instance = this;
            _currentPreset = 2;
            SetTimeOfDay(_presets[_currentPreset], true);
            _prevTime = time;
        }

        // Update is called once per frame
        void Update()
        {
            if (autoIcrement)
            {
                var t = Mathf.PingPong(Time.time * speed, 1);
                time = t * 0.5f + 0.25f;
            }

            if (time != _prevTime) // if time has changed
            {
                SetTimeOfDay(time);
            }
        }

        /// <summary>
        /// Sets the time of day
        /// </summary>
        /// <param name="time">Time in linear 0-1</param>
        public void SetTimeOfDay(float time, bool reflectionUpdate = false)
        {
            //Debug.Log($"Setting time of day to:{time}, updating reflectionprobes:{reflectionUpdate.ToString()}");
            this.time = time;
            _prevTime = time;

            if (reflectionUpdate && _instance.reflections?.Length > 0)
            {
                foreach (var probe in _instance.reflections)
                {
                    probe.RenderProbe();
                }
            }

            GlobalTime = this.time;
            // do update
            if (_sun)
            {
                // update sun
                _sun.transform.forward = Vector3.down;
                _sun.transform.rotation *= Quaternion.AngleAxis(_northHeading, Vector3.forward); // north facing
                _sun.transform.rotation *= Quaternion.AngleAxis(_tilt, Vector3.up);
                _sun.transform.rotation *= Quaternion.AngleAxis((this.time * 360f) - 180f, Vector3.right); // time of day

                _sun.color = _sunColour.Evaluate(TimeToGradient(this.time));
            }
            if (_skybox)
            {
                // update skybox
                _skybox.SetFloat("_Rotation", 85 + ((this.time - 0.5f) * 20f)); // rotate slightly for cheap moving cloud eefect
                _skybox.SetColor("_Tint", _skyboxColour.Evaluate(TimeToGradient(this.time)));
            }

            if (clouds)
            {
                clouds.eulerAngles = new Vector3(0f, this.time * 22.5f + cloudOffset, 0f);
            }

            Shader.SetGlobalFloat("_NightFade", Mathf.Clamp01(Mathf.Abs(this.time * 2f - 1f) * 3f - 1f));
            RenderSettings.fogColor = _fogColour.Evaluate(TimeToGradient(this.time)); // update fog colour
            RenderSettings.ambientSkyColor = _ambientColour.Evaluate(TimeToGradient(this.time)); // update ambient light colour
        }

        float TimeToGradient(float time)
        {
            return Mathf.Abs(time * 2f - 1f);
        }

        public static void SelectPreset(float input)
        {
            _instance._currentPreset += Mathf.RoundToInt(input);

            _instance._currentPreset = (int)Mathf.Repeat(_instance._currentPreset, _instance._presets.Length);

            PlayerPrefs.SetInt(PresetKey, _instance._currentPreset);

            _instance.SetTimeOfDay(_instance._presets[_instance._currentPreset], true);
        }
    }
}
