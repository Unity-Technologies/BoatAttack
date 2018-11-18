using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// Simple day/night system
    /// </summary>
    [ExecuteInEditMode]
    public class DayNightController : MonoBehaviour
    {
        [Range(0, 1)]
        public float _time = 0.5f; // the global 'time'
        [Header("Skybox Settings")]
        // Skybox
        public Material _skybox; // skybox reference
        public Gradient _skyboxColour; // skybox tint over time
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
        public Gradient _fogColour; // fog colour over time

        // vars
        private float _prevTime; // previous time

        void Start()
        {
            _prevTime = _time;
        }

        // Update is called once per frame
        void Update()
        {
            if (_time != _prevTime) // if time has changed
            {
                // do update
                if (_sun)
                {
                    // update sun
                    _sun.transform.forward = Vector3.down;
                    _sun.transform.rotation *= Quaternion.AngleAxis(_northHeading, Vector3.forward); // north facing
                    _sun.transform.rotation *= Quaternion.AngleAxis((_time * 180f) - 90f, Vector3.right); // time of day

                    _sun.color = _sunColour.Evaluate(_time);
                }
                if (_skybox)
                {
                    // update skybox
                    _skybox.SetFloat("_Rotation", 85 + ((_time - 0.5f) * 20f)); // rotate slightly for cheap moving cloud eefect
                    _skybox.SetColor("_Tint", _skyboxColour.Evaluate(_time));
                }
                RenderSettings.fogColor = _fogColour.Evaluate(_time); // update fog colour
                RenderSettings.ambientSkyColor = _ambientColour.Evaluate(_time); // update ambient light colour
            }
        }

        /// <summary>
        /// Sets the time of day
        /// </summary>
        /// <param name="time">Time in linear 0-1</param>
        public void SetTimeOfDay(float time)
        {
            _time = time;
        }
    }
}
