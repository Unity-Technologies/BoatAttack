using UnityEngine;

namespace BoatAttack
{
    /// <summary>
    /// This make lower LOD levels use the same Lightmaps/offsets as LOD0
    /// </summary>
    [RequireComponent(typeof(LODGroup)), ExecuteInEditMode]
    public class LodLightmaps : MonoBehaviour
    {
        private LODGroup _lodGrp; // the LOD group
        private Renderer[] _main; // LOD0 Meshes
        private Renderer[] _lod1; // LOD2 Meshes
        private Renderer[] _lod2; // LOD3 Meshes
        private Renderer[] _lod3; // LOD3 Meshes

        private void OnEnable()
        {
            CopyLightmapSettings();
        }

        /// <summary>
        /// Loops through and copies light map index and offset from LOD0 to LOD1+2
        /// </summary>
        void CopyLightmapSettings()
        {
            _lodGrp = GetComponent<LODGroup>();
            var lods = _lodGrp.GetLODs();
            _main = lods[0].renderers;

            for (var i = 1; i < lods.Length; i++)
            {
                switch (i)
                {
                    case 1:
                        _lod1 = lods[i].renderers;
                        break;
                    case 2:
                        _lod2 = lods[i].renderers;
                        break;
                    case 3:
                        _lod3 = lods[i].renderers;
                        break;
                }
            }

            var lmIndex = new int[_main.Length];
            var lmScaleOffset = new Vector4[_main.Length];

            for (var i = 0; i < _main.Length; i++)
            {
                lmIndex[i] = _main[i].lightmapIndex;
                lmScaleOffset[i] = _main[i].lightmapScaleOffset;
            }

            for (var i = 0; i < _main.Length; i++)
            {
#pragma warning disable
                _lod1[i].lightmapIndex = lmIndex[i];
                _lod1[i].lightmapScaleOffset = lmScaleOffset[i];
                if (!_lod2[i]) continue;
                _lod2[i].lightmapIndex = lmIndex[i];
                _lod2[i].lightmapScaleOffset = lmScaleOffset[i];
                if (!_lod3[i]) continue;
                _lod3[i].lightmapIndex = lmIndex[i];
                _lod3[i].lightmapScaleOffset = lmScaleOffset[i];
#pragma warning restore
            }
        }
    }
}
