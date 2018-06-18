using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LightweightPipeline;

[ExecuteInEditMode]
public class DayNightController : MonoBehaviour {

	[Range(0, 1)]
    public float _time = 0.5f;
	[Header("Skybox Settings")]
    // Skybox
    public Material _skybox;
    public Gradient _skyboxColour;
    // Sunlight
    [Header("Sun Settings")]
    public Light _sun;
    public Gradient _sunColour;
    [Range(0, 360)]
    public float _northHeading = 136;

    //Ambient light
    [Header("Ambient Lighting")]
    public Gradient _ambientColour;

    // Fog
    [Header("Fog Settings")]
    public Gradient _fogColour;

    // vars
    private float _prevTime;

    void Start () {
        _prevTime = _time;
    }
	
	// Update is called once per frame
	void Update () {
		if(_time != _prevTime)
		{
			// do update
			if(_sun)
			{
                // update sun
                _sun.transform.forward = Vector3.down;
                _sun.transform.rotation *= Quaternion.AngleAxis(_northHeading, Vector3.forward); // north facing
                _sun.transform.rotation *= Quaternion.AngleAxis((_time * 180f) - 90f, Vector3.right); // time of day

                _sun.color = _sunColour.Evaluate(_time);
            }
			if(_skybox)
			{
                // update skybox
                _skybox.SetFloat("_Rotation", 85 + ((_time - 0.5f) * 20f));
                _skybox.SetColor("_Tint", _skyboxColour.Evaluate(_time));
            }
            RenderSettings.fogColor = _fogColour.Evaluate(_time);
            RenderSettings.ambientSkyColor = _ambientColour.Evaluate(_time);
        }
	}

    public void SetTimeOfDay(float time)
    {
        _time = time;
    }

	private void UpdatePipeline(Camera cam)
	{
		// blah
	}

	private void OnEnable() {
        LightweightPipeline.beginCameraRendering += UpdatePipeline;
    }

    private void OnDisable()
    {
        LightweightPipeline.beginCameraRendering -= UpdatePipeline;
    }
}
