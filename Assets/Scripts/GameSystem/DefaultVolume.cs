using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public static class DefaultVolume
{
    public static List<VolumeProfile> DefaultVolumes = new List<VolumeProfile>();

    public static void AddVolumes(List<VolumeProfile> volumes)
    {
        DefaultVolumes.AddRange(volumes);
        
    }
}

public class DefaultVolumeSwitcher : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void LoadVolumeManager()
    {
        if (FindObjectOfType<VolumeManager>() != null)
            return;

        var go = new GameObject { name = "[Volume Manager]" };
        var volMan = go.AddComponent<VolumeManager>();
        volMan.Volumes = DefaultVolume.DefaultVolumes;
        volMan.vol = go.AddComponent<Volume>();
        DontDestroyOnLoad(go);
    }
    
    public class VolumeManager : MonoBehaviour
    {
        public List<VolumeProfile> Volumes = new List<VolumeProfile>();
        public Volume vol;
        private void OnEnable()
        {
            vol.profile = Volumes[QualitySettings.GetQualityLevel()];
        }
    }
    
    [CreateAssetMenu(fileName = "VolumeHolder", menuName = "Volume Holder", order = 0)]
    public class VolumeHolder : ScriptableObject
    {
        public VolumeProfile[] volumes;
        [SerializeField]
        public Dictionary<int, int> VolumeQualityIndicies = new Dictionary<int, int>();
    }
}