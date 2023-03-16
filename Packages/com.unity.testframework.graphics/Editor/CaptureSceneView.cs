#if UNITY_2022_2_OR_NEWER
using System;
using System.Collections;
using System.IO;
using UnityEditorInternal;
using UnityEngine;

namespace UnityEditor.TestTools.Graphics
{
    /// <summary>
    /// Capture the current scene view into a Texture2D for use in ImageAssert tests.
    /// </summary>
    public class CaptureSceneView
    {
        private static Texture2D CapturedTexture;

        /// <summary>
        /// Returns the result of the Scene View capture
        /// </summary>
        /// 
        public static Texture2D Result { get => CapturedTexture; }

        /// <summary>
        /// Captures a scene view from the perspective of the MainCamera in the hierarchy.
        /// </summary>
        /// <param name="sceneView"> An existing scene view that will be used instead of creating a new one. </param>
        /// <param name="sceneViewWidth"> The width (in pixels) for the captured scene view image. Defaults to 512. </param>
        /// <param name="sceneViewHeight"> The height (in pixels) for the captured scene view image. Defaults to 512. </param>
        /// <param name="delayBeforeCapture"> The delay between setting up the camera and capturing. Defaults to 100. </param>
        /// <returns> an IEnumerator to yield return to UnityTests </returns>
        public static IEnumerator CaptureFromMainCamera(SceneView sceneView = null, int sceneViewWidth = 512, int sceneViewHeight = 512, int delayBeforeCapture = 100)
        {
            yield return Capture(Camera.main.transform, sceneView, sceneViewWidth, sceneViewHeight, delayBeforeCapture);
        }

        /// <summary>
        /// Captures a scene view from the perspective of the chosen viewpoint transform.
        /// </summary>
        /// <param name="imageComparisonViewpoint"> The viewpoint camera to be used for capturing the image. </param>
        /// <param name="sceneView"> An existing scene view that will be used instead of creating a new one. </param>
        /// <param name="sceneViewWidth"> The size (in pixels) for the captured scene view image. Defaults to 512. </param>
        /// <param name="sceneViewHeight"> The height (in pixels) for the captured scene view image. Defaults to 512. </param>
        /// <param name="delayBeforeCapture"> The delay between setting up the camera and capturing. Defaults to 100. </param>
        /// <returns> an IEnumerator to yield return to UnityTests </returns>
        public static IEnumerator Capture(Transform imageComparisonViewpoint, SceneView sceneView = null, int sceneViewWidth = 512, int sceneViewHeight = 512, int delayBeforeCapture = 100)
        {
            GameObject.DestroyImmediate(CapturedTexture);
            // Create the Scene View or use the user-provided one
            if (sceneView == null) sceneView = EditorWindow.CreateWindow<SceneView>();

            sceneView.minSize = new Vector2(sceneViewWidth, sceneViewHeight);
            sceneView.maxSize = new Vector2(sceneViewWidth, sceneViewHeight);
            yield return null;

            // Move the scene view camera to the scene's MainCamera
            sceneView.AlignViewToObject(imageComparisonViewpoint);

            // Wait for the view to change
            while (!(sceneView.camera.transform.position == imageComparisonViewpoint.position) ||
                   !(sceneView.camera.transform.rotation.eulerAngles == imageComparisonViewpoint.rotation.eulerAngles))
                yield return null;

            // Wait for all shaders to finish compiling
            bool asyncAllowedPriorState = ShaderUtil.allowAsyncCompilation;
            ShaderUtil.allowAsyncCompilation = false;
            while (ShaderUtil.anythingCompiling)
                yield return null;

            for (int i = 0; i < delayBeforeCapture; i++) yield return null; // Just waiting for shaders not enough for SRPs

            TakeSceneViewSnapshot(sceneView, sceneViewWidth, sceneViewHeight);

            while (CapturedTexture == null)
                yield return null;

            ShaderUtil.allowAsyncCompilation = asyncAllowedPriorState;
            sceneView.Close();
        }

        private static void TakeSceneViewSnapshot(SceneView sceneView, int width, int height)
        {
            sceneView.Focus();

            // Prepare textures
            GameObject.DestroyImmediate(CapturedTexture);
            CapturedTexture = new Texture2D(width, height, TextureFormat.RGB24, false);
            RenderTexture backBufferCapture = RenderTexture.GetTemporary(width, height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);

            // Capture and set to the active RenderTexture
            InternalEditorUtility.CaptureSceneView(sceneView, backBufferCapture);
            RenderTexture.active = backBufferCapture;

            // Apply to our Tex2D
            CapturedTexture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            CapturedTexture.Apply();

            // Clean up
            RenderTexture.active = null;
            RenderTexture.ReleaseTemporary(backBufferCapture);
        }
    }
}
#endif