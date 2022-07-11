using UnityEngine;

namespace BoatAttack
{
    public class BoatFoamGenerator : MonoBehaviour
    {
        public Transform boatTransform;
        private ParticleSystem.MainModule _module;
        public ParticleSystem ps;
        public float waterLevel = 0;
        private Vector3 _offset;

        private void Start()
        {
            _module = ps.main;
            _offset = transform.localPosition;
        }

        // Update is called once per frame
        private void Update()
        {
            var pos = boatTransform.TransformPoint(_offset);
            pos.y = waterLevel;
            transform.position = pos;

            var fwd = boatTransform.forward;
            fwd.y = 0;
            var angle = Vector3.Angle(fwd.normalized, Vector3.forward);
            _module.startRotation = angle * Mathf.Deg2Rad;
        }
    }
}
