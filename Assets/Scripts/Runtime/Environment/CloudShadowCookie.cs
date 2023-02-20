using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace BoatAttack
{
    [ExecuteAlways]
    [RequireComponent(typeof(Light))]
    public class CloudShadowCookie : MonoBehaviour
    {
        private UniversalAdditionalLightData _lightData;

        private void OnEnable()
        {
            TryGetComponent(out _lightData);
        }

        // Update is called once per frame
        void Update()
        {
            if (_lightData == null) return;

            var offset = _lightData.lightCookieOffset;

            var dir = transform.InverseTransformDirection(GlobalWind.WindVector.x, 0f, GlobalWind.WindVector.y);

            offset += new Vector2(dir.x, dir.y) * Time.deltaTime;
            offset.x = Mathf.Repeat(offset.x, _lightData.lightCookieSize.x);
            offset.y = Mathf.Repeat(offset.y, _lightData.lightCookieSize.y);

            _lightData.lightCookieOffset = offset;
        }
    }
}
