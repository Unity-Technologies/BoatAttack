using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "VolumeHolder", menuName = "Volume Holder", order = 0)]
public class VolumeHolder : ScriptableObject
{
    [SerializeField]
    public AssetReference[] _Volumes;
    [FormerlySerializedAs("qualityIndicies")] [SerializeField]
    public List<int> qualityIndices = new List<int>();
    [FormerlySerializedAs("qualityVolumeIndicies")] [SerializeField]
    public List<int> qualityVolumeIndices = new List<int>();

    public bool ContainsKey(int key)
    {
        return qualityIndices.Contains(key);
    }

    public void Add(int key, int value)
    {
        qualityIndices.Add(key);
        qualityVolumeIndices.Add(value);
    }

    public void SetKey(int key, int value)
    {
        if (qualityIndices.Contains(key))
        {
            qualityVolumeIndices[qualityIndices.IndexOf(key)] = value;
        }
        else
        {
            Add(key, value);
        }
    }

    public int GetValue(int key)
    {
        if (qualityIndices.Contains(key))
        {
            return qualityVolumeIndices[qualityIndices.IndexOf(key)];
        }

        throw new Exception(message: $"{qualityIndices} does not contain key {key}");
    }
}