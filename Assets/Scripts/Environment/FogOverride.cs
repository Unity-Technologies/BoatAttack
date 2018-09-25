using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class FogOverride : MonoBehaviour
{
    [ColorUsage(false, true)]
    public Color m_FogColor = Color.white;
    // Update is called once per frame
    void LateUpdate()
    {
        RenderSettings.fogColor = m_FogColor;
    }
}
