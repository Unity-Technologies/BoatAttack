using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace BoatAttack.UI
{
    public class PlayerMapMarker : MonoBehaviour
    {
        public Image primary;
        public Image secondary;

        private RectTransform _rect;
        private BoatData _boatData;
        private Boat _boat;
        private Transform _boatTransform;
        private float _scale;
        private int _playerCount;

        private void OnEnable()
        {
            RenderPipelineManager.beginFrameRendering += UpdatePosition;
        }

        private void OnDisable()
        {
            RenderPipelineManager.beginFrameRendering -= UpdatePosition;
        }

        public void Setup(BoatData boat, float scale = 0.0028f) // TODO magic number for mini map size
        {
            _boatData = boat;
            _boat = boat.Boat;
            _boatTransform = boat.Boat.transform;
            _rect = transform as RectTransform;
            _scale = scale;

            var p = _boatData.livery.primaryColor;
            p.a = 1f;
            primary.color = p;
            var t = _boatData.livery.trimColor;
            t.a = 1f;
            secondary.color = t;

            _playerCount = RaceManager.RaceData.boatCount;
        }

        private void UpdatePosition(ScriptableRenderContext context, Camera[] cameras)
        {
            if (_boatData == null || Camera.main == null) return; // if no boat or camera, the player marker cannot work

            var position = _boatTransform.position;
            _rect.anchorMin = _rect.anchorMax = Vector2.one * 0.5f + new Vector2(position.x, position.z) * _scale;
            _rect.SetSiblingIndex(_playerCount - _boat.Place + 1);
        }
    }
}
