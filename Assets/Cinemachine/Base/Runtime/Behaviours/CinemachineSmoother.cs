#if false // GML We disable smoother because people are too tempted to use it.  It won't give good results.
using UnityEngine;
using Cinemachine.Utility;

namespace Cinemachine
{
    /// <summary>
    /// An add-on module for Cinemachine Virtual Camera which post-processes
    /// the final position and  orientation of the virtual camera, as a kind of low-pass filter.
    /// </summary>
    [DocumentationSorting(17, DocumentationSortingAttribute.Level.UserRef)]
    [ExecuteInEditMode]
    [AddComponentMenu("")] // Hide in menu
    [SaveDuringPlay]
    public class CinemachineSmoother : CinemachineExtension
    {
        /// <summary>
        /// The strength of the smoothing for position.  This is applied after the vcam cas calculated its state.
        /// </summary>
        [Range(0f, 10f)]
        [Tooltip("The strength of the smoothing for position.  Higher numbers smooth more but reduce performance and introduce lag.")]
        public float m_PositionSmoothing = 1;

        /// <summary>
        /// The strength of the smoothing for the LookAt target.  This is applied after the vcam cas calculated its state.
        /// </summary>
        [Range(0f, 10f)]
        [Tooltip("The strength of the smoothing for the LookAt target.  Higher numbers smooth more but reduce performance and introduce lag.")]
        public float m_LookAtSmoothing = 1;

        /// <summary>
        /// The strength of the smoothing for rotation.  This is applied after the vcam cas calculated its state.
        /// </summary>
        [Range(0f, 10f)]
        [Tooltip("The strength of the smoothing for rotation.  Higher numbers smooth more but reduce performance and introduce lag.")]
        public float m_RotationSmoothing = 1;

        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (stage == CinemachineCore.Stage.Body)
            {
                VcamExtraState extra = GetExtraState<VcamExtraState>(vcam);
                if (m_PositionSmoothing > 0)
                {
                    if (deltaTime < 0)
                        extra.mSmoothingFilter = null; // reset the filter
                    state.PositionCorrection
                        += ApplySmoothing(vcam, state.CorrectedPosition, extra) - state.CorrectedPosition;
                }
                if (m_LookAtSmoothing > 0 && state.HasLookAt)
                {
                    if (deltaTime < 0)
                        extra.mSmoothingFilterLookAt = null; // reset the filter
                    state.ReferenceLookAt = ApplySmoothingLookAt(vcam, state.ReferenceLookAt, extra);
                }
            }
            if (stage == CinemachineCore.Stage.Aim)
            {
                if (m_RotationSmoothing > 0)
                {
                    VcamExtraState extra = GetExtraState<VcamExtraState>(vcam);
                    if (deltaTime < 0)
                        extra.mSmoothingFilterRotation = null; // reset the filter
                    Quaternion q = Quaternion.Inverse(state.CorrectedOrientation)
                        * ApplySmoothing(vcam, state.CorrectedOrientation, state.ReferenceUp, extra);
                    state.OrientationCorrection = state.OrientationCorrection * q;
                }
            }
        }
 
        class VcamExtraState
        {
            public GaussianWindow1D_Vector3 mSmoothingFilter;
            public GaussianWindow1D_Vector3 mSmoothingFilterLookAt;
            public GaussianWindow1D_CameraRotation mSmoothingFilterRotation;
        };

        private Vector3 ApplySmoothing(CinemachineVirtualCameraBase vcam, Vector3 pos, VcamExtraState extra)
        {
            if (extra.mSmoothingFilter == null || extra.mSmoothingFilter.Sigma != m_PositionSmoothing)
                extra.mSmoothingFilter = new GaussianWindow1D_Vector3(m_PositionSmoothing);
            return extra.mSmoothingFilter.Filter(pos);
        }

        private Vector3 ApplySmoothingLookAt(CinemachineVirtualCameraBase vcam, Vector3 pos, VcamExtraState extra)
        {
            if (extra.mSmoothingFilterLookAt == null || extra.mSmoothingFilterLookAt.Sigma != m_LookAtSmoothing)
                extra.mSmoothingFilterLookAt = new GaussianWindow1D_Vector3(m_LookAtSmoothing);
            return extra.mSmoothingFilterLookAt.Filter(pos);
        }

        private Quaternion ApplySmoothing(CinemachineVirtualCameraBase vcam, Quaternion rot, Vector3 up, VcamExtraState extra)
        {
            if (extra.mSmoothingFilterRotation == null || extra.mSmoothingFilterRotation.Sigma != m_RotationSmoothing)
                extra.mSmoothingFilterRotation = new GaussianWindow1D_CameraRotation(m_RotationSmoothing);
            Vector3 camRot = Quaternion.identity.GetCameraRotationToTarget(rot * Vector3.forward, up);
            return Quaternion.identity.ApplyCameraRotation(extra.mSmoothingFilterRotation.Filter(camRot), up);
        }
    }
}
#endif
