using UnityEngine;
using UnityEngine.InputSystem;

namespace BoatAttack
{
    /// <summary>
    /// Simple day/night system
    /// </summary>
    [ExecuteInEditMode]
    public class DayNightController : MonoBehaviour
    {
        private static DayNightController instance;
        [Range(0, 1)]
        public float _time = 0.5f; // the global 'time'

        private float[] presets = new float[] { 0.27f, 0.35f, 0.45f, 0.55f, 0.65f, 0.73f };
        private int currentPreset = 0;
        private const string presetKey = "BoatAttack.DayNight.TimePreset";

        public bool _autoIcrement;
        public float _speed = 1f;

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
            instance = this;
            currentPreset = PlayerPrefs.GetInt(presetKey);
            SetTimeOfDay(presets[currentPreset], true);
            _prevTime = _time;
        }

        // Update is called once per frame
        void Update()
        {
            if (_autoIcrement && Application.isPlaying)
            {
                var t = Mathf.PingPong(Time.time * _speed, 1);
                _time = t * 0.5f + 0.25f;
            }

            if (_time != _prevTime) // if time has changed
            {
                SetTimeOfDay(_time);
            }
        }

        /// <summary>
        /// Sets the time of day
        /// </summary>
        /// <param name="time">Time in linear 0-1</param>
        public void SetTimeOfDay(float time, bool reflectionUpdate = false)
        {
            Debug.Log($"Setting time of day to:{time}, updating reflectionprobes:{reflectionUpdate.ToString()}");
            _time = time;
            _prevTime = time;

            if (instance.reflections.Length > 0 && reflectionUpdate)
            {
                foreach (var probe in instance.reflections)
                {
                    probe.RenderProbe();
                }
            }

            GlobalTime = _time;
            // do update
            if (_sun)
            {
                // update sun
                _sun.transform.forward = Vector3.down;
                _sun.transform.rotation *= Quaternion.AngleAxis(_northHeading, Vector3.forward); // north facing
                _sun.transform.rotation *= Quaternion.AngleAxis(_tilt, Vector3.up);
                _sun.transform.rotation *= Quaternion.AngleAxis((_time * 360f) - 180f, Vector3.right); // time of day

                _sun.color = _sunColour.Evaluate(Mathf.Clamp01(_time * 2f - 0.5f));
            }
            if (_skybox)
            {
                // update skybox
                _skybox.SetFloat("_Rotation", 85 + ((_time - 0.5f) * 20f)); // rotate slightly for cheap moving cloud eefect
                _skybox.SetColor("_Tint", _skyboxColour.Evaluate(_time));
            }

            if (clouds)
            {
                clouds.eulerAngles = new Vector3(0f, _time * 45f + cloudOffset, 0f);
            }

            Shader.SetGlobalFloat("_NightFade", Mathf.Clamp01(Mathf.Abs(_time * 2f - 1f) * 3f - 1f));
            RenderSettings.fogColor = _fogColour.Evaluate(_time); // update fog colour
            RenderSettings.ambientSkyColor = _ambientColour.Evaluate(_time); // update ambient light colour
        }

        public static void SelectPreset(float input)
        {
            instance.currentPreset += Mathf.RoundToInt(input);

            instance.currentPreset = (int)Mathf.Repeat(instance.currentPreset, instance.presets.Length);

            PlayerPrefs.SetInt(presetKey, instance.currentPreset);

            instance.SetTimeOfDay(instance.presets[instance.currentPreset], true);
        }
    }
}
