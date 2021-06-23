using UnityEngine;
using System;

namespace BoatAttack
{
    /// <summary>
    /// Simple day/night system
    /// </summary>
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

        // Skybox
        [Header("Skybox Settings")]
        public Material _skybox; // skybox reference
        public Gradient _skyboxColour; // skybox tint over time
        public ReflectionProbe[] reflections;

        // Sunlight
        [Header("Sun Settings")]
        public Light _sun; // sun light
        public Gradient _sunColour; // sun light colour over time
        [Range(0, 360)]
        public float _northHeading = 136; // north

        //Ambient light
        [Header("Ambient Lighting")]
        public Gradient _ambientColour; // ambient light colour (not used in LWRP correctly) over time

        // Fog
        [Header("Fog Settings")]
        [GradientUsage(true)]
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

        private void OnValidate()
        {
            UpdateSun();
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

        void UpdateSun()
        {
            var rotation = CalculateSunPosition(NormalizedDateTime(time), 56.0, 9.0);
            _sun.transform.rotation = rotation;
            _sun.transform.Rotate(new Vector3(0f, _northHeading, 0f), Space.World);
            _sun.color = _sunColour.Evaluate(Mathf.Clamp01(Vector3.Dot(_sun.transform.forward, Vector3.down)));
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
                _sun.color = _sunColour.Evaluate(TimeToGradient(this.time));
            }
            if (_skybox)
            {
                // update skybox
                _skybox.SetFloat("_Rotation", 85 + ((this.time - 0.5f) * 20f)); // rotate slightly for cheap moving cloud eefect
                _skybox.SetColor("_Tint", _skyboxColour.Evaluate(TimeToGradient(this.time)));
            }

            Shader.SetGlobalFloat("_NightFade", Mathf.Clamp01(Mathf.Abs(this.time * 2f - 1f) * 3f - 1f));
            RenderSettings.fogColor = _fogColour.Evaluate(TimeToGradient(this.time)); // update fog colour
            RenderSettings.ambientSkyColor = _ambientColour.Evaluate(TimeToGradient(this.time)); // update ambient light colour
        }

        public static Quaternion CalculateSunPosition(DateTime dateTime, double latitude, double longitude)
        {
            // Convert to UTC
            dateTime = dateTime.ToUniversalTime();

            // Number of days from J2000.0.
            double julianDate = 367 * dateTime.Year -
                (int)((7.0 / 4.0) * (dateTime.Year +
                (int)((dateTime.Month + 9.0) / 12.0))) +
                (int)((275.0 * dateTime.Month) / 9.0) +
                dateTime.Day - 730531.5;

            double julianCenturies = julianDate / 36525.0;

            // Sidereal Time
            double siderealTimeHours = 6.6974 + 2400.0513 * julianCenturies;

            double siderealTimeUT = siderealTimeHours +
                (366.2422 / 365.2422) * (double)dateTime.TimeOfDay.TotalHours;

            double siderealTime = siderealTimeUT * 15 + longitude;

            // Refine to number of days (fractional) to specific time.
            julianDate += (double)dateTime.TimeOfDay.TotalHours / 24.0;
            julianCenturies = julianDate / 36525.0;

            // Solar Coordinates
            double meanLongitude = CorrectAngle(Mathf.Deg2Rad *
                (280.466 + 36000.77 * julianCenturies));

            double meanAnomaly = CorrectAngle(Mathf.Deg2Rad *
                (357.529 + 35999.05 * julianCenturies));

            double equationOfCenter = Mathf.Deg2Rad * ((1.915 - 0.005 * julianCenturies) *
                Math.Sin(meanAnomaly) + 0.02 * Math.Sin(2 * meanAnomaly));

            double elipticalLongitude =
                CorrectAngle(meanLongitude + equationOfCenter);

            double obliquity = (23.439 - 0.013 * julianCenturies) * Mathf.Deg2Rad;

            // Right Ascension
            double rightAscension = Math.Atan2(
                Math.Cos(obliquity) * Math.Sin(elipticalLongitude),
                Math.Cos(elipticalLongitude));

            double declination = Math.Asin(
                Math.Sin(rightAscension) * Math.Sin(obliquity));

            // Horizontal Coordinates
            double hourAngle = CorrectAngle(siderealTime * Mathf.Deg2Rad) - rightAscension;

            if (hourAngle > Math.PI)
            {
                hourAngle -= 2 * Math.PI;
            }

            double altitude = Math.Asin(Math.Sin(latitude * Mathf.Deg2Rad) *
                Math.Sin(declination) + Math.Cos(latitude * Mathf.Deg2Rad) *
                Math.Cos(declination) * Math.Cos(hourAngle));

            // Nominator and denominator for calculating Azimuth
            // angle. Needed to test which quadrant the angle is in.
            double aziNom = -Math.Sin(hourAngle);
            double aziDenom =
                Math.Tan(declination) * Math.Cos(latitude * Mathf.Deg2Rad) -
                Math.Sin(latitude * Mathf.Deg2Rad) * Math.Cos(hourAngle);

            double azimuth = Math.Atan(aziNom / aziDenom);

            if (aziDenom < 0) // In 2nd or 3rd quadrant
            {
                azimuth += Math.PI;
            }
            else if (aziNom < 0) // In 4th quadrant
            {
                azimuth += 2 * Math.PI;
            }

            Quaternion rot = Quaternion.Euler(0f, ((float)azimuth * Mathf.Rad2Deg), 0f);

            rot *= Quaternion.AngleAxis((float)(altitude * Mathf.Rad2Deg), Vector3.right);

            return rot;
        }

        private static double CorrectAngle(double angleInRadians)
        {
            if (angleInRadians < 0)
            {
                return 2 * Math.PI - (Math.Abs(angleInRadians) % (2 * Math.PI));
            }
            else if (angleInRadians > 2 * Math.PI)
            {
                return angleInRadians % (2 * Math.PI);
            }
            else
            {
                return angleInRadians;
            }
        }

        static DateTime NormalizedDateTime(float t)
        {
            var hour = (int)Mathf.Repeat(t * 24, 24); // 0-24
            var minute = (int)Mathf.Repeat(t * 24 * 60, 60); //0-60
            return new DateTime(2021, 03, 23, hour, minute, 0);
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
