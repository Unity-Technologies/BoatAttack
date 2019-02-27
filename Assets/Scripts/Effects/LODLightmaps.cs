using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// This make lower LOD levels use the same Lightmaps/offsets as LOD0
    /// </summary>
    [RequireComponent(typeof(LODGroup))]
    [ExecuteInEditMode]
    public class LODLightmaps : MonoBehaviour
    {
        LODGroup _lodGrp; // the LOD group
        Renderer[] _main; // LOD0 Meshes
        Renderer[] _LOD1; // LOD2 Meshes
        Renderer[] _LOD2; // LOD3 Meshes
        Renderer[] _LOD3; // LOD3 Meshes

        void OnEnable()
        {
            CopyLightmapSettings();
        }

        /// <summary>
        /// Loops through and copys lightmap index and offset from LOD0 to LOD1+2
        /// </summary>
        void CopyLightmapSettings()
        {
            _lodGrp = GetComponent<LODGroup>();
            LOD[] lods = _lodGrp.GetLODs();
            _main = lods[0].renderers;

            for (var i = 1; i < lods.Length; i++)
            {
                switch (i)
                {
                    case 1:
                        _LOD1 = lods[i].renderers;
                        break;
                    case 2:
                        _LOD2 = lods[i].renderers;
                        break;
                    case 3:
                        _LOD3 = lods[i].renderers;
                        break;
                }
            }

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
                if (_LOD3[i])
                {
                    _LOD3[i].lightmapIndex = lmIndex[i];
                    _LOD3[i].lightmapScaleOffset = lmScaleOffset[i];
                }
            }
        }
    }
}
