using UnityEngine;
using System;

namespace Cinemachine
{
    /// <summary>
    /// Describes the FOV and clip planes for a camera.  This generally mirrors the Unity Camera's 
    /// lens settings, and will be used to drive the Unity camera when the vcam is active.
    /// </summary>
    [Serializable]
    [DocumentationSorting(2, DocumentationSortingAttribute.Level.UserRef)]
    public struct LensSettings
    {
        /// <summary>Default Lens Settings</summary>
        public static LensSettings Default = new LensSettings(40f, 10, 0.1f, 5000f, 0, false, 1);

        /// <summary>
        /// This is the camera view in vertical degrees. For cinematic people, a 50mm lens
        /// on a super-35mm sensor would equal a 19.6 degree FOV
        /// </summary>
        [Range(1f, 179f)]
        [Tooltip("This is the camera view in vertical degrees. For cinematic people, a 50mm lens on a super-35mm sensor would equal a 19.6 degree FOV")]
        public float FieldOfView;

        /// <summary>
        /// When using an orthographic camera, this defines the height, in world 
        /// co-ordinates, of the camera view.
        /// </summary>
        [Tooltip("When using an orthographic camera, this defines the half-height, in world coordinates, of the camera view.")]
        public float OrthographicSize;

        /// <summary>
        /// The near clip plane for this LensSettings
        /// </summary>
        [Tooltip("This defines the near region in the renderable range of the camera frustum. Raising this value will stop the game from drawing things near the camera, which can sometimes come in handy.  Larger values will also increase your shadow resolution.")]
        public float NearClipPlane;

        /// <summary>
        /// The far clip plane for this LensSettings
        /// </summary>
        [Tooltip("This defines the far region of the renderable range of the camera frustum. Typically you want to set this value as low as possible without cutting off desired distant objects")]
        public float FarClipPlane;

        /// <summary>
        /// The dutch (tilt) to be applied to the camera. In degrees
        /// </summary>
        [Range(-180f, 180f)]
        [Tooltip("Camera Z roll, or tilt, in degrees.")]
        public float Dutch;

        /// <summary>
        /// This is set every frame by the virtual camera, based on the value found in the 
        /// currently associated Unity camera
        /// </summary>
        internal bool Orthographic { get; set; }

        /// <summary>
        /// This is set every frame by the virtual camera, based on the value 
        /// found in the currently associated Unity camera
        /// </summary>
        internal float Aspect { get; set; }

        /// <summary>
        /// Creates a new LensSettings, copying the values from the 
        /// supplied Camera
        /// </summary>
        /// <param name="fromCamera">The Camera from which the FoV, near 
        /// and far clip planes will be copied.</param>
	    public static LensSettings FromCamera(Camera fromCamera)
        {
            LensSettings lens = Default;
            if (fromCamera != null)
            {
                lens.FieldOfView = fromCamera.fieldOfView;
                lens.OrthographicSize = fromCamera.orthographicSize;
                lens.NearClipPlane = fromCamera.nearClipPlane;
                lens.FarClipPlane = fromCamera.farClipPlane;
                lens.Orthographic = fromCamera.orthographic;
                lens.Aspect = fromCamera.aspect;
            }
            return lens;
        }

        /// <summary>
        /// Explicit constructor for this LensSettings
        /// </summary>
        /// <param name="fov">The Vertical field of view</param>
        /// <param name="orthographicSize">If orthographic, this is the half-height of the screen</param>
        /// <param name="nearClip">The near clip plane</param>
        /// <param name="farClip">The far clip plane</param>
        /// <param name="dutch">Camera roll, in degrees.  This is applied at the end 
        /// <param name="ortho">Whether the lens is orthographic</param>
        /// <param name="aspect">The aspect ratio of the lens  Width/height</param>
        /// after shot composition.</param>
        public LensSettings(
            float fov, float orthographicSize,
            float nearClip, float farClip, float dutch,
            bool ortho, float aspect) : this()
        {
            FieldOfView = fov;
            OrthographicSize = orthographicSize;
            NearClipPlane = nearClip;
            FarClipPlane = farClip;
            Dutch = dutch;
            Orthographic = ortho;
            Aspect = aspect;
        }

        /// <summary>
        /// Linearly blends the fields of two LensSettings and returns the result
        /// </summary>
        /// <param name="lensA">The LensSettings to blend from</param>
        /// <param name="lensB">The LensSettings to blend to</param>
        /// <param name="t">The interpolation value. Internally clamped to the range [0,1]</param>
        /// <returns>Interpolated settings</returns>
        public static LensSettings Lerp(LensSettings lensA, LensSettings lensB, float t)
        {
            t = Mathf.Clamp01(t);
            LensSettings blendedLens = new LensSettings();
            blendedLens.FarClipPlane = Mathf.Lerp(lensA.FarClipPlane, lensB.FarClipPlane, t);
            blendedLens.NearClipPlane = Mathf.Lerp(lensA.NearClipPlane, lensB.NearClipPlane, t);
            blendedLens.FieldOfView = Mathf.Lerp(lensA.FieldOfView, lensB.FieldOfView, t);
            blendedLens.OrthographicSize = Mathf.Lerp(lensA.OrthographicSize, lensB.OrthographicSize, t);
            blendedLens.Dutch = Mathf.Lerp(lensA.Dutch, lensB.Dutch, t);
            blendedLens.Aspect = Mathf.Lerp(lensA.Aspect, lensB.Aspect, t);
            blendedLens.Orthographic = lensA.Orthographic && lensB.Orthographic;
            return blendedLens;
        }

        /// <summary>Make sure lens settings are sane.  Call this from OnValidate().</summary>
        public void Validate()
        {
            NearClipPlane = Mathf.Max(NearClipPlane, 0.01f);
            FarClipPlane = Mathf.Max(FarClipPlane, NearClipPlane + 0.01f);
        }
    }
}
