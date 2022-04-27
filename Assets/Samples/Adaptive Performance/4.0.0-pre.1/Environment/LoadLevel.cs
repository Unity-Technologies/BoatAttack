using UnityEngine;
using System;


[Serializable]
public class LoadLevel
{
    public enum loadlevels
    {
        No,
        Mid,
        High
    }
    public loadlevels Name;
    public float Duration;
    public bool isActive;
    public LoadLevel(loadlevels name, float duration, bool active = false)
    {
        Name = name;
        Duration = duration;
        isActive = active;
    }
}
