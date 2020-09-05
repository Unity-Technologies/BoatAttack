using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AdaptivePerformance;

public class ScalerVisualisation : MonoBehaviour
{
    public Text Name;
    public Text Value;
    public Text Status;
    public Slider Level;
    public Toggle Override;
    public Toggle EnabledToggle;
    public AdaptivePerformanceScaler Scaler;

    public void SetOverride()
    {
        if (Scaler == null)
            return;

        Scaler.OverrideLevel = Override.isOn ? Scaler.CurrentLevel : -1;
        Level.interactable = Override.isOn;
    }

    public void SetEnabled()
    {
        if (Scaler == null)
            return;

        Scaler.Enabled = EnabledToggle.isOn;
    }

    public void SetLevel(float value)
    {
        if (Scaler == null)
            return;
        var level = (int)(value * Scaler.MaxLevel);
        if (Scaler.OverrideLevel != -1)
            Scaler.OverrideLevel = level;
        Level.value = (float)level / Scaler.MaxLevel;
        Value.text = $"{Level.value}";
    }

    private void Start()
    {
        if (Scaler == null)
            return;

        Name.text = Scaler.Name;
        Override.isOn = Scaler.OverrideLevel != -1;
        EnabledToggle.isOn = Scaler.Enabled;
        Level.value = (float)Scaler.CurrentLevel / Scaler.MaxLevel;
    }

    private void Update()
    {
        if (Scaler == null)
            return;

        Level.interactable = Scaler.OverrideLevel != -1;
        if (Scaler.OverrideLevel == -1)
            Level.value = (float)Scaler.CurrentLevel / Scaler.MaxLevel;

        if (Scaler.Enabled)
            Status.text = $"<color=lime>Enabled</color>";
        else
            Status.text = $"<color=red>Disabled</color>";
    }
}
