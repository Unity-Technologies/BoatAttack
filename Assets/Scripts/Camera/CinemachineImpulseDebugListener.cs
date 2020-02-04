
using UnityEngine;
namespace Cinemachine
{
    /// <summary>
    /// An extension for Cinemachine Virtual Camera which listens for CinemachineImpulse
    /// signals on the specified channels, and outputs debug information to console when received
    /// </summary>
    [SaveDuringPlay]
    [AddComponentMenu("")] // Hide in menu
#if UNITY_2018_3_OR_NEWER
    [ExecuteAlways]
#else
[ExecuteInEditMode]
#endif
    public class CinemachineImpulseDebugListener : CinemachineExtension
    {
        /// <summary>
        /// Impulse events on channels not included in the mask will be ignored.
        /// </summary>
        [Tooltip("Impulse events on channels not included in the mask will be ignored.")]
        [CinemachineImpulseChannelProperty]
        public int m_ChannelMask = 1;

        /// <summary>
        /// Enable this to perform distance calculation in 2D (ignore Z).
        /// </summary>
        [Tooltip("Enable this to perform distance calculation in 2D (ignore Z)")]
        public bool m_Use2DDistance = false;

        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                Vector3 impulsePos = Vector3.zero;
                Quaternion impulseRot = Quaternion.identity;
                if (CinemachineImpulseManager.Instance.GetImpulseAt(
                    state.FinalPosition, m_Use2DDistance, m_ChannelMask, out impulsePos, out impulseRot))
                {
                    Debug.Log("CinemachineImpulseDebugListener on: "+gameObject.name+" got impulse"+Quaternion.Angle(impulseRot,Quaternion.identity).ToString("F5")+" "+impulsePos.magnitude.ToString("F5"));
                }
            }
        }
    }
}
