using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorSwatch : MonoBehaviour
{
    public static int activeIndexA;
    public static int activeIndexB;
    
    public Image colorSwatch;
    public Image outline;
    [ColorUsage(false)]public Color activeColor;
    [ColorUsage(false)]public Color inactiveColor;
    private bool _activated;
    private int index;
    private int group;
    private Color color;

    private void LateUpdate()
    {
        SetActive((group == 0 ? activeIndexA : activeIndexB) == index);
    }

    public void SetColorSwatch(Color inputColor, int index, int group)
    {
        colorSwatch.color = color = inputColor;
        this.index = index;
        this.group = group;
    }

    public static void SetActive(int index, int group = 0)
    {
        if (group == 0)
        {
            activeIndexA = index;
        }
        else
        {
            activeIndexB = index;
        }
    }

    public void SetActive(bool active)
    {
        _activated = active;
        outline.color = _activated ? activeColor : inactiveColor;
        if (!active) return;
        
        if (group == 0)
        {
            activeIndexA = index;
        }
        else
        {
            activeIndexB = index;
        }
    }
}
