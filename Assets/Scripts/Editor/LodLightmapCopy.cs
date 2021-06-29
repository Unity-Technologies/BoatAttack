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
            var lod0 = lods[0].renderers;
            //if(lod0[0].lightmapIndex == -1) return;
            //copy settings to other lods
            for (var i = 1; i < lods.Length; i++)
            {
                for (var j = 0; j < lod0.Length; j++)
                {
                    lods[i].renderers[j].lightmapIndex = lod0[j].lightmapIndex;
                    lods[i].renderers[j].lightmapScaleOffset = lod0[j].lightmapScaleOffset;
                }
            }
        }
    }
}
