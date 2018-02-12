using Cinemachine.Utility;
using UnityEngine;

namespace Cinemachine
{
    /// <summary>
    /// This component will expose a non-cinemachine camera to the cinemachine system,
    /// allowing it to participate in blends.
    /// Just add it as a component alongside an existing Unity Camera component.
    /// </summary>
    [DocumentationSorting(14, DocumentationSortingAttribute.Level.UserRef)]
    [RequireComponent(typeof(Camera)), DisallowMultipleComponent, ExecuteInEditMode]
    [AddComponentMenu("Cinemachine/CinemachineExternalCamera")]
    public class CinemachineExternalCamera : CinemachineVirtualCameraBase
    {
        /// <summary>The object that the camera is looking at.</summary>
        [Tooltip("The object that the camera is looking at.  Setting this will improve the quality of the blends to and from this camera")]
        [NoSaveDuringPlay]
        public Transform m_LookAt = null;

        private Camera m_Camera;
        private CameraState m_State = CameraState.Default;

        /// <summary>Get the CameraState, as we are able to construct one from the Unity Camera</summary>
        public override CameraState State { get { return m_State; } }

        /// <summary>The object that the camera is looking at</summary>
        override public Transform LookAt 
        {
            get { return m_LookAt; }
            set { m_LookAt = value; }
        }

        /// <summary>This vcam defines no targets</summary>
        override public Transform Follow { get; set; }

        /// <summary>Construct a CameraState object from the Unity Camera</summary>
        public override void UpdateCameraState(Vector3 worldUp, float deltaTime)
        {
            // Get the state from the camera
            if (m_Camera == null)
                m_Camera = GetComponent<Camera>();

            m_State = CameraState.Default;
            m_State.RawPosition = transform.position;
            m_State.RawOrientation = transform.rotation;
            m_State.ReferenceUp = m_State.RawOrientation * Vector3.up;
            if (m_Camera != null)
                m_State.Lens = LensSettings.FromCamera(m_Camera);

            if (m_LookAt != null)
            {
                m_State.ReferenceLookAt = m_LookAt.transform.position;
                Vector3 dir = m_State.ReferenceLookAt - State.RawPosition;
                if (!dir.AlmostZero())
                    m_State.ReferenceLookAt = m_State.RawPosition + Vector3.Project(
                        dir, State.RawOrientation * Vector3.forward);
            }
        }
    }
}
