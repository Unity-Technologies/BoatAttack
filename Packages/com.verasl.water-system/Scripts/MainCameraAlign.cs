using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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
            RenderPipelineManager.beginCameraRendering += UpdatePosition;
        }

        private void OnDisable()
        {
            RenderPipelineManager.beginCameraRendering -= UpdatePosition;
        }

        void UpdatePosition(ScriptableRenderContext src, Camera cam)
        {
            Vector3 newPos = cam.transform.TransformPoint(Vector3.forward * forwards);
            newPos.y = yOffset;
            newPos.x = quantizeValue * (int)(newPos.x / quantizeValue);
            newPos.z = quantizeValue * (int)(newPos.z / quantizeValue);
            transform.position = newPos;
        }
    }
}
