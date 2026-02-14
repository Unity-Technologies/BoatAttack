using UnityEngine;
using WaterSystem;

public class EnvironmentController : MonoBehaviour
{
    [Header("=== Wave Settings ===")]
    [Range(0f, 5f)] public float waveStrength = 1.0f;
    [Range(0.1f, 3f)] public float waveSpeed = 1.0f;
    [Range(0f, 360f)] public float waveDirection = 0f;

    [Header("=== Wind Settings ===")]
    [Range(0f, 30f)] public float windStrength = 5.0f;
    [Range(0f, 360f)] public float windDirection = 0f;
    [Range(0f, 1f)] public float windTurbulence = 0.3f;

    [Header("=== Random Weather ===")]
    public bool randomizeOnStart = false;
    public bool dynamicWeather = false;
    [Range(10f, 300f)] public float weatherChangeInterval = 60f;

    [Header("=== Presets ===")]
    public WeatherPreset currentPreset = WeatherPreset.Calm;

    public enum WeatherPreset { Calm, Light, Moderate, Rough, Storm }

    private Water waterInstance;
    private float nextWeatherChangeTime;
    private Vector3 currentWindVector;

    void Start()
    {
        waterInstance = FindObjectOfType<Water>();

        if (randomizeOnStart)
            RandomizeWeather();
        else
            ApplyPreset(currentPreset);

        ApplySettings();
        nextWeatherChangeTime = Time.time + weatherChangeInterval;
    }

    void Update()
    {
        if (dynamicWeather && Time.time >= nextWeatherChangeTime)
        {
            SmoothWeatherChange();
            nextWeatherChangeTime = Time.time + weatherChangeInterval;
        }

        if (Application.isEditor)
            ApplySettings();
    }

    public void ApplySettings()
    {
        ApplyWaveSettings();
        ApplyWindSettings();
    }

    void ApplyWaveSettings()
    {
        if (waterInstance == null) return;
        waterInstance.transform.position = new Vector3(0, 0, 0);
    }

    void ApplyWindSettings()
    {
        float radians = windDirection * Mathf.Deg2Rad;
        currentWindVector = new Vector3(Mathf.Sin(radians), 0f, Mathf.Cos(radians)) * windStrength;

        if (windTurbulence > 0)
        {
            currentWindVector += new Vector3(
                Random.Range(-windTurbulence, windTurbulence), 0f,
                Random.Range(-windTurbulence, windTurbulence)) * windStrength;
        }
    }

    public void ApplyPreset(WeatherPreset preset)
    {
        currentPreset = preset;
        switch (preset)
        {
            case WeatherPreset.Calm:
                waveStrength = 0.3f; waveSpeed = 0.5f; windStrength = 2f; windTurbulence = 0.1f;
                break;
            case WeatherPreset.Light:
                waveStrength = 0.8f; waveSpeed = 0.8f; windStrength = 5f; windTurbulence = 0.2f;
                break;
            case WeatherPreset.Moderate:
                waveStrength = 1.5f; waveSpeed = 1.0f; windStrength = 10f; windTurbulence = 0.3f;
                break;
            case WeatherPreset.Rough:
                waveStrength = 2.5f; waveSpeed = 1.5f; windStrength = 15f; windTurbulence = 0.5f;
                break;
            case WeatherPreset.Storm:
                waveStrength = 4.0f; waveSpeed = 2.0f; windStrength = 25f; windTurbulence = 0.8f;
                break;
        }
        ApplySettings();
    }

    public void RandomizeWeather()
    {
        waveStrength = Random.Range(0.5f, 3.0f);
        waveSpeed = Random.Range(0.5f, 2.0f);
        waveDirection = Random.Range(0f, 360f);
        windStrength = Random.Range(3f, 20f);
        windDirection = Random.Range(0f, 360f);
        windTurbulence = Random.Range(0.1f, 0.6f);
        ApplySettings();
    }

    void SmoothWeatherChange()
    {
        waveStrength = Mathf.Clamp(waveStrength + Random.Range(-0.2f, 0.2f), 0.3f, 4.0f);
        waveSpeed = Mathf.Clamp(waveSpeed + Random.Range(-0.1f, 0.1f), 0.3f, 2.5f);
        windStrength = Mathf.Clamp(windStrength + Random.Range(-3f, 3f), 1f, 25f);
        windDirection = (windDirection + Random.Range(-30f, 30f)) % 360f;
        ApplySettings();
    }

    public Vector3 GetWindVector() { return currentWindVector; }

    public float GetWaveHeightAt(Vector3 position)
    {
        if (waterInstance == null) return 0f;
        float waveOffset = (position.x + position.z) * 0.1f + Time.time * waveSpeed;
        return Mathf.Sin(waveOffset) * waveStrength * 0.5f;
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.cyan;
        Vector3 arrowStart = transform.position + Vector3.up * 5f;
        Gizmos.DrawLine(arrowStart, arrowStart + currentWindVector.normalized * 10f);

        Gizmos.color = Color.blue;
        float waveRad = waveDirection * Mathf.Deg2Rad;
        Vector3 waveDir = new Vector3(Mathf.Sin(waveRad), 0, Mathf.Cos(waveRad));
        Gizmos.DrawLine(arrowStart, arrowStart + waveDir * 8f);
    }
}
