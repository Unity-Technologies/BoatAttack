using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LightweightPipeline;

namespace WaterSystem
{
    /// <summary>
    /// Camera script to align the water mesh with the camera in a quantized manner
    /// </summary>
    [ExecuteInEditMode]
    public class MainCameraAlign : MonoBehaviour
    {

        public float quantizeValue = 6.25f;
        public float forwards = 10f;
        public float yOffset = -1f;

        private void OnEnable()
        {
            LightweightRenderPipeline.beginCameraRendering += UpdatePosition;
        }

        private void OnDisable()
        {
            LightweightRenderPipeline.beginCameraRendering -= UpdatePosition;
        }

        void UpdatePosition(Camera cam)
        {
            Vector3 newPos = cam.transform.TransformPoint(Vector3.forward * forwards);
            newPos.y = yOffset;
            newPos.x = quantizeValue * (int)(newPos.x / quantizeValue);
            newPos.z = quantizeValue * (int)(newPos.z / quantizeValue);
            transform.position = newPos;
        }
    }
}
