using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "VolumeHolder", menuName = "Volume Holder", order = 0)]
public class VolumeHolder : ScriptableObject
{
    [SerializeField]
    public VolumeProfile[] _Volumes;
    [SerializeField]
    public List<int> qualityIndicies = new List<int>();
    [SerializeField]
    public List<int> qualityVolumeIndicies = new List<int>();

    public bool ContainsKey(int key)
    {
        return qualityIndicies.Contains(key);
    }

    public void Add(int key, int value)
    {
        qualityIndicies.Add(key);
        qualityVolumeIndicies.Add(value);
    }

    public void SetKey(int key, int value)
    {
        if (qualityIndicies.Contains(key))
        {
            qualityVolumeIndicies[qualityIndicies.IndexOf(key)] = value;
        }
        else
        {
            Add(key, value);
        }
    }

    public int GetValue(int key)
    {
        if (qualityIndicies.Contains(key))
        {
            return qualityVolumeIndicies[qualityIndicies.IndexOf(key)];
        }

        throw new Exception(message: $"{qualityIndicies} does not contain key {key}");
    }
}