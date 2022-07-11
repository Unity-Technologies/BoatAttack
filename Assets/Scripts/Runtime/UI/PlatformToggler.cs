using System;
using UnityEngine;

public class PlatformToggler : MonoBehaviour
{
    public bool disableByDefault;
    public PlatformState[] states;

    private void OnEnable()
    {
        var currentPlatform = Application.platform;
        PlatformState state = null;

        foreach (var s in states)
        {
            if (s.platform == currentPlatform)
            {
                state = s;
            }
        }

        if (state != null)
        {
            gameObject.SetActive(state.enabled);
        }
        else
        {
            gameObject.SetActive(!disableByDefault);
        }
    }

    [Serializable]
    public class PlatformState
    {
        public RuntimePlatform platform;
        public bool enabled;
    }
}
