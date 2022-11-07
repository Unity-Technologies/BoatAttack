using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace BoatAttack.UI
{
    public class PlayerMapMarker : MonoBehaviour
    {
        public Image primary;
        public Image secondary;
        [SerializeField]private bool forMap = true;

        private BoatData _boatData;
        private Transform _boatTransform;
        //private RectTransform _rect;
        private float _scale;
        private int _playerCount;

        private void OnEnable()
        {
            //_rect = transform as RectTransform;
            if(forMap)
                RenderPipelineManager.beginFrameRendering += UpdatePosition;
        }

        private void OnDisable()
        {
            if(forMap)
                RenderPipelineManager.beginFrameRendering -= UpdatePosition;
        }

        public void Setup(BoatData boat, float scale = 0.0028f) // TODO magic number for mini map size
        {
            _boatData = boat;
            _boatTransform = boat.Boat.transform;
            _scale = scale;

            var p = _boatData.Livery.primaryColor;
            p.a = 1f;
            primary.color = p;
            var t = _boatData.Livery.trimColor;
            t.a = 1f;
            secondary.color = t;

            _playerCount = RaceManager.RaceData.boatCount;
        }

        private void UpdatePosition(ScriptableRenderContext context, Camera[] cameras)
        {
            if (_boatData == null || Camera.main == null) return; // if no boat or camera, the player marker cannot work

            var position = _boatTransform.position;
            ((RectTransform)transform).anchorMin = ((RectTransform)transform).anchorMax = 1f * 0.5f + ((float3)position).xz * _scale;
            _boatTransform.SetSiblingIndex(_playerCount - _boatData.Boat.Place + 1);
        }
    }
}
