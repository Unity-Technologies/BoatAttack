using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script sets global rendering resolution based on the predefined settings inside scriptable object that is attached
// to the component with this script.
// This is needed for tests consistency. For example by the date of writing this new Android devices are added to the
// test rig, which have different resolution (2280x1080) compared to the old ones (1920x1080). This difference causes
// majority of tests fail.

public class GlobalResolutionSetter : MonoBehaviour
{
    public CustomResolutionSettings customResolutionSettings;

    // Used for per-scene asset-style resolution setting.
    void Awake()
    {
        foreach (var resolutionSettingsField in customResolutionSettings.fields)
        {
            if (SetResolution(resolutionSettingsField))
            {
                break;
            }
        }
    }

    public static bool SetResolution(CustomResolutionFields resolutionFields)
    {
        if (resolutionFields.Platform != Application.platform)
        {
            Debug.Log(
                $"Skipping setting rendering resolution, target platform: {resolutionFields.Platform}, current platform: {Application.platform}"
            );
            return false;
        }

        Debug.Log(
            $"Setting new rendering resolution: {resolutionFields.Width}x{resolutionFields.Height}"
        );
        Screen.SetResolution(
            resolutionFields.Width,
            resolutionFields.Height,
            resolutionFields.isFullScreen
        );
        return true;
    }

    public static bool SetResolution(
        RuntimePlatform platformFilter,
        int width = 1920,
        int height = 1080,
        bool fullscreen = true
    )
    {
        return SetResolution(
            new CustomResolutionFields
            {
                Platform = platformFilter,
                Width = width,
                Height = height,
                isFullScreen = fullscreen,
            }
        );
    }
}
