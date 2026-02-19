using UnityEngine;

namespace BoatAttack
{
    public class BoatFoamGenerator : MonoBehaviour
    {
        public Transform boatTransform;
        public ParticleSystem ps;
        public float waterLevel = 0;
        private Vector3 _offset;

        private void Start()
        {
            _offset = transform.localPosition;
        }

        // Update is called once per frame
        private void Update()
        {
            // null 체크 추가
            if (boatTransform == null || ps == null)
                return;

            var pos = boatTransform.TransformPoint(_offset);
            pos.y = waterLevel;
            transform.position = pos;

            var fwd = boatTransform.forward;
            fwd.y = 0;
            var angle = Vector3.Angle(fwd.normalized, Vector3.forward);

            // ParticleSystem.MainModule은 매번 가져와야 안전함
            var mainModule = ps.main;
            mainModule.startRotation = angle * Mathf.Deg2Rad;
        }
    }
}
