using UnityEngine;

namespace Cinemachine
{
    /// <summary>
    /// This is a CinemachineComponent in the Aim section of the component pipeline.
    /// Its job is to aim the camera in response to the user's mouse or joystick input.
    /// 
    /// The composer does not change the camera's position.  It will only pan and tilt the 
    /// camera where it is, in order to get the desired framing.  To move the camera, you have
    /// to use the virtual camera's Body section.
    /// </summary>
    [DocumentationSorting(23, DocumentationSortingAttribute.Level.UserRef)]
    [AddComponentMenu("")] // Don't display in add component menu
    [RequireComponent(typeof(CinemachinePipeline))]
    [SaveDuringPlay]
    public class CinemachinePOV : CinemachineComponentBase
    {
        /// <summary>The Vertical axis.  Value is -90..90. Controls the vertical orientation</summary>
        [Tooltip("The Vertical axis.  Value is -90..90. Controls the vertical orientation")]
        public AxisState m_VerticalAxis = new AxisState(300f, 0.1f, 0.1f, 0f, "Mouse Y", true);

        /// <summary>The Horizontal axis.  Value is -180..180.  Controls the horizontal orientation</summary>
        [Tooltip("The Horizontal axis.  Value is -180..180.  Controls the horizontal orientation")]
        public AxisState m_HorizontalAxis = new AxisState(300f, 0.1f, 0.1f, 0f, "Mouse X", false);

        /// <summary>True if component is enabled and has a LookAt defined</summary>
        public override bool IsValid { get { return enabled; } }

        /// <summary>Get the Cinemachine Pipeline stage that this component implements.
        /// Always returns the Aim stage</summary>
        public override CinemachineCore.Stage Stage { get { return CinemachineCore.Stage.Aim; } }

        private void OnValidate()
        {
            m_HorizontalAxis.Validate();
            m_VerticalAxis.Validate();
        }

        private void OnEnable()
        {
            m_HorizontalAxis.SetThresholds(-180f, 180f, true);
            m_VerticalAxis.SetThresholds(-90, 90, false);
        }
        
        /// <summary>Applies the axis values and orients the camera accordingly</summary>
        /// <param name="curState">The current camera state</param>
        /// <param name="deltaTime">Used for calculating damping.  Not used.</param>
        public override void MutateCameraState(ref CameraState curState, float deltaTime)
        {
            if (!IsValid)
                return;

            //UnityEngine.Profiling.Profiler.BeginSample("CinemachinePOV.MutateCameraState");

            // Only read joystick when game is playing
            if (deltaTime >= 0 || CinemachineCore.Instance.IsLive(VirtualCamera))
            {
                m_HorizontalAxis.Update(deltaTime);
                m_VerticalAxis.Update(deltaTime);
            }
            Quaternion rot = Quaternion.Euler(m_VerticalAxis.Value, m_HorizontalAxis.Value, 0);
            rot = rot * Quaternion.FromToRotation(Vector3.up, curState.ReferenceUp);
            curState.OrientationCorrection = curState.OrientationCorrection * rot;

            //UnityEngine.Profiling.Profiler.EndSample();
        }
    }
}

