using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WaterSystem.Settings;

public class settingsTest : MonoBehaviour
{

    public TMP_Text test;
    
    void Start()
    {
        test.text = WaterProjectSettings.Instance.m_SomeString;
    }
}
