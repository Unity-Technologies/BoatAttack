using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LODGroup))]
public class LODLightmaps : MonoBehaviour {

    LODGroup _lodGrp;
    Renderer[] _main;
    Renderer[] _LOD1;
    Renderer[] _LOD2;

    void Awake ()
	{
        CopyLightmapSettings();
    }

	void CopyLightmapSettings()
	{
        _lodGrp = GetComponent<LODGroup>();
        LOD[] lods = _lodGrp.GetLODs();
        _main = lods[0].renderers;
        _LOD1 = lods[1].renderers;
        _LOD2 = lods[2].renderers;

        int[] lmIndex = new int[_main.Length];
        Vector4[] lmScaleOffset = new Vector4[_main.Length];

        for (var i = 0; i < _main.Length; i++)
        {
            lmIndex[i] = _main[i].lightmapIndex;
            lmScaleOffset[i] = _main[i].lightmapScaleOffset;
        }

        for (var i = 0; i < _main.Length; i++)
        {
            _LOD1[i].lightmapIndex = lmIndex[i];
            _LOD1[i].lightmapScaleOffset = lmScaleOffset[i];
            _LOD2[i].lightmapIndex = lmIndex[i];
            _LOD2[i].lightmapScaleOffset = lmScaleOffset[i];
        }
	}
}
