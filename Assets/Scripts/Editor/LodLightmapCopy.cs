using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
class LodLightmapCopy : IProcessSceneWithReport
{
    public int callbackOrder => -1;

    public void OnProcessScene(Scene scene, BuildReport report)
    {
        Execute();
    }
    
    static LodLightmapCopy()
    {
        Lightmapping.bakeCompleted += Execute;
        EditorApplication.playModeStateChanged += LodLightmapEdit;
    }

    static void LodLightmapEdit(PlayModeStateChange state)
    {
        if(state == PlayModeStateChange.EnteredEditMode) Execute();
    }
    
    private static void Execute()
    {
        if(Debug.isDebugBuild)
            Debug.Log("Baking LOD Lightmap values");
        var lodGroups= Object.FindObjectsOfType<LODGroup>();
        foreach (var lodGroup in lodGroups)
        {
            //is lod0 lightmapped
            var lods = lodGroup.GetLODs();
            if (lods == null || lods.Length == 0) continue;

            var lod0 = lods[0].renderers;
            if (lod0 == null || lod0.Length == 0) continue;

            //if(lod0[0].lightmapIndex == -1) return;
            //copy settings to other lods
            for (var i = 1; i < lods.Length; i++)
            {
                if (lods[i].renderers == null) continue;

                // lod0와 현재 LOD의 renderer 개수 중 작은 값만큼만 복사
                int copyCount = Mathf.Min(lod0.Length, lods[i].renderers.Length);

                for (var j = 0; j < copyCount; j++)
                {
                    if (lod0[j] == null || lods[i].renderers[j] == null) continue;

                    lods[i].renderers[j].lightmapIndex = lod0[j].lightmapIndex;
                    lods[i].renderers[j].lightmapScaleOffset = lod0[j].lightmapScaleOffset;
                }
            }
        }
    }
}
