using Cinemachine.Utility;
using UnityEngine;

namespace Cinemachine
{
    /// <summary>
    /// This is a CinemachineComponent in the Body section of the component pipeline. 
    /// Its job is to position the camera in a fixed relationship to the vcam's Follow 
    /// target object, with offsets and damping.
    /// 
    /// The Tansposer will only change the camera's position in space.  It will not 
    /// re-orient or otherwise aim the camera.  To to that, you need to instruct 
    /// the vcam in the Aim section of its pipeline.
    /// </summary>
    [DocumentationSorting(5, DocumentationSortingAttribute.Level.UserRef)]
    [AddComponentMenu("")] // Don't display in add component menu
    [RequireComponent(typeof(CinemachinePipeline))]
    [SaveDuringPlay]
    public class CinemachineTransposer : CinemachineComponentBase
    {
        /// <summary>
        /// The coordinate space to use when interpreting the offset from the target
        /// </summary>
        [DocumentationSorting(5.01f, DocumentationSortingAttribute.Level.UserRef)]
        public enum BindingMode
        {
            /// <summary>
            /// Camera will be bound to the Follow target using a frame of reference consisting
            /// of the target's local frame at the moment when the virtual camera was enabled,
            /// or when the target was assigned.
            /// </summary>
            LockToTargetOnAssign = 0,
            /// <summary>
            /// Camera will be bound to the Follow target using a frame of reference consisting
            /// of the target's local frame, with the tilt and roll zeroed out.
            /// </summary>
            LockToTargetWithWorldUp = 1,
            /// <summary>
            /// Camera will be bound to the Follow target using a frame of reference consisting
            /// of the target's local frame, with the roll zeroed out.
            /// </summary>
            LockToTargetNoRoll = 2,
            /// <summary>
            /// Camera will be bound to the Follow target using the target's local frame.
            /// </summary>
            LockToTarget = 3,
            /// <summary>Camera will be bound to the Follow target using a world space offset.</summary>
            WorldSpace = 4,
            /// <summary>Offsets will be calculated relative to the target, using Camera-local axes</summary>
            SimpleFollowWithWorldUp = 5
        }
        /// <summary>The coordinate space to use when interpreting the offset from the target</summary>
        [Tooltip("The coordinate space to use when interpreting the offset from the target.  This is also used to set the camera's Up vector, which will be maintained when aiming the camera.")]
        public BindingMode m_BindingMode = BindingMode.LockToTargetWithWorldUp;

        /// <summary>The distance which the transposer will attempt to maintain from the transposer subject</summary>
        [Tooltip("The distance vector that the transposer will attempt to maintain from the Follow target")]
        public Vector3 m_FollowOffset = Vector3.back * 10f;

        /// <summary>How aggressively the camera tries to maintain the offset in the X-axis.
        /// Small numbers are more responsive, rapidly translating the camera to keep the target's
        /// x-axis offset.  Larger numbers give a more heavy slowly responding camera.
        /// Using different settings per axis can yield a wide range of camera behaviors</summary>
        [Range(0f, 20f)]
        [Tooltip("How aggressively the camera tries to maintain the offset in the X-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's x-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
        public float m_XDamping = 1f;

        /// <summary>How aggressively the camera tries to maintain the offset in the Y-axis.
        /// Small numbers are more responsive, rapidly translating the camera to keep the target's
        /// y-axis offset.  Larger numbers give a more heavy slowly responding camera.
        /// Using different settings per axis can yield a wide range of camera behaviors</summary>
        [Range(0f, 20f)]
        [Tooltip("How aggressively the camera tries to maintain the offset in the Y-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's y-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
        public float m_YDamping = 1f;

        /// <summary>How aggressively the camera tries to maintain the offset in the Z-axis.
        /// Small numbers are more responsive, rapidly translating the camera to keep the
        /// target's z-axis offset.  Larger numbers give a more heavy slowly responding camera.
        /// Using different settings per axis can yield a wide range of camera behaviors</summary>
        [Range(0f, 20f)]
        [Tooltip("How aggressively the camera tries to maintain the offset in the Z-axis.  Small numbers are more responsive, rapidly translating the camera to keep the target's z-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
        public float m_ZDamping = 1f;

        /// <summary>How aggressively the camera tries to track the target rotation's X angle.  
        /// Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.</summary>
        [Range(0f, 20f)]
        [Tooltip("How aggressively the camera tries to track the target rotation's X angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
        public float m_PitchDamping = 0;

        /// <summary>How aggressively the camera tries to track the target rotation's Y angle.  
        /// Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.</summary>
        [Range(0f, 20f)]
        [Tooltip("How aggressively the camera tries to track the target rotation's Y angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
        public float m_YawDamping = 0;

        /// <summary>How aggressively the camera tries to track the target rotation's Z angle.  
        /// Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.</summary>
        [Range(0f, 20f)]
        [Tooltip("How aggressively the camera tries to track the target rotation's Z angle.  Small numbers are more responsive.  Larger numbers give a more heavy slowly responding camera.")]
        public float m_RollDamping = 0f;

        protected virtual void OnValidate()
        {
            m_FollowOffset = EffectiveOffset;
        }
        
        /// <summary>Get the target offset, with sanitization</summary>
        protected Vector3 EffectiveOffset 
        { 
            get 
            { 
                Vector3 offset = m_FollowOffset; 
                if (m_BindingMode == BindingMode.SimpleFollowWithWorldUp)
                {
                    offset.x = 0;
                    offset.z = -Mathf.Abs(offset.z);
                }
                return offset;
            } 
        }
        
        /// <summary>True if component is enabled and has a valid Follow target</summary>
        public override bool IsValid { get { return enabled && FollowTarget != null; } }

        /// <summary>Get the Cinemachine Pipeline stage that this component implements.
        /// Always returns the Body stage</summary>
        public override CinemachineCore.Stage Stage { get { return CinemachineCore.Stage.Body; } }

        /// <summary>Positions the virtual camera according to the transposer rules.</summary>
        /// <param name="curState">The current camera state</param>
        /// <param name="deltaTime">Used for damping.  If less than 0, no damping is done.</param>
        public override void MutateCameraState(ref CameraState curState, float deltaTime)
        {
            //UnityEngine.Profiling.Profiler.BeginSample("CinemachineTransposer.MutateCameraState");
            InitPrevFrameStateInfo(ref curState, deltaTime);
            if (IsValid)
            {
                Vector3 pos;
                Quaternion orient;
                Vector3 offset = EffectiveOffset;
                TrackTarget(deltaTime, curState.ReferenceUp, offset, out pos, out orient);
                curState.RawPosition = pos + orient * offset;
                curState.ReferenceUp = orient * Vector3.up;
            }
            //UnityEngine.Profiling.Profiler.EndSample();
        }

        /// <summary>API for the editor, to process a position drag from the user.
        /// This implementation adds the delta to the follow offset.</summary>
        /// <param name="delta">The amount dragged this frame</param>
        public override void OnPositionDragged(Vector3 delta)
        {
            Quaternion targetOrientation = GetReferenceOrientation(VcamState.ReferenceUp);
            Vector3 localOffset = Quaternion.Inverse(targetOrientation) * delta;
            m_FollowOffset += localOffset;
            m_FollowOffset = EffectiveOffset;
        }

        /// <summary>Initializes the state for previous frame if appropriate.</summary>
        protected void InitPrevFrameStateInfo(
            ref CameraState curState, float deltaTime)
        {
            if (m_previousTarget != FollowTarget || deltaTime < 0)
            {
                m_previousTarget = FollowTarget;
                m_targetOrientationOnAssign 
                    = (m_previousTarget == null) ? Quaternion.identity : FollowTarget.rotation;
            }
            if (deltaTime < 0)
            {
                m_PreviousTargetPosition = curState.RawPosition;
                m_PreviousReferenceOrientation = GetReferenceOrientation(curState.ReferenceUp);
            }
        }

        /// <summary>Positions the virtual camera according to the transposer rules.</summary>
        /// <param name="deltaTime">Used for damping.  If less than 0, no damping is done.</param>
        /// <param name="up">Current camera up</param>
        /// <param name="desiredCameraOffset">Where we want to put the camera relative to the follow target</param>
        /// <param name="outTargetPosition">Resulting camera position</param>
        /// <param name="outTargetOrient">Damped target orientation</param>
        protected void TrackTarget(
            float deltaTime, Vector3 up, Vector3 desiredCameraOffset,
            out Vector3 outTargetPosition, out Quaternion outTargetOrient)
        {
            Quaternion targetOrientation = GetReferenceOrientation(up);
            Quaternion dampedOrientation = targetOrientation;
            if (deltaTime >= 0)
            {
                Vector3 relative = (Quaternion.Inverse(m_PreviousReferenceOrientation) 
                    * targetOrientation).eulerAngles;
                for (int i = 0; i < 3; ++i)
                    if (relative[i] > 180)
                        relative[i] -= 360;
                relative = Damper.Damp(relative, AngularDamping, deltaTime);
                dampedOrientation = m_PreviousReferenceOrientation * Quaternion.Euler(relative);
            }
            m_PreviousReferenceOrientation = dampedOrientation;

            Vector3 targetPosition = FollowTarget.position;
            Vector3 currentPosition = m_PreviousTargetPosition;
            Vector3 worldOffset = targetPosition - currentPosition;

            // Adjust for damping, which is done in camera-offset-local coords
            if (deltaTime >= 0)
            {
                Quaternion dampingSpace;
                if (desiredCameraOffset.AlmostZero())
                    dampingSpace = VcamState.RawOrientation;
                else
                    dampingSpace = Quaternion.LookRotation(dampedOrientation * desiredCameraOffset.normalized, up);
                Vector3 localOffset = Quaternion.Inverse(dampingSpace) * worldOffset;
                localOffset = Damper.Damp(localOffset, Damping, deltaTime);
                worldOffset = dampingSpace * localOffset;
            }
            outTargetPosition = m_PreviousTargetPosition = currentPosition + worldOffset;
            outTargetOrient = dampedOrientation;
        }

        /// <summary>
        /// Damping speeds for each of the 3 axes of the offset from target
        /// </summary>
        protected Vector3 Damping
        {
            get 
            { 
                switch (m_BindingMode)
                {
                    case BindingMode.SimpleFollowWithWorldUp:
                        return new Vector3(0, m_YDamping, m_ZDamping); 
                    default:
                        return new Vector3(m_XDamping, m_YDamping, m_ZDamping); 
                }
            } 
        }

        /// <summary>
        /// Damping speeds for each of the 3 axes of the target's rotation
        /// </summary>
        protected Vector3 AngularDamping
        {
            get 
            { 
                switch (m_BindingMode)
                {
                    case BindingMode.LockToTargetNoRoll:
                        return new Vector3(m_PitchDamping, m_YawDamping, 0); 
                    case BindingMode.LockToTargetWithWorldUp:
                        return new Vector3(0, m_YawDamping, 0); 
                    case BindingMode.LockToTargetOnAssign:
                    case BindingMode.WorldSpace:
                    case BindingMode.SimpleFollowWithWorldUp:
                        return Vector3.zero;
                    default:
                        return new Vector3(m_PitchDamping, m_YawDamping, m_RollDamping); 
                }
            } 
        }

        /// <summary>Internal API for the Inspector Editor, so it can draw a marker at the target</summary>
        public Vector3 GeTargetCameraPosition(Vector3 worldUp)
        {
            if (!IsValid)
                return Vector3.zero;
            return FollowTarget.position + GetReferenceOrientation(worldUp) * EffectiveOffset;
        }

        /// <summary>State information for damping</summary>
        Vector3 m_PreviousTargetPosition = Vector3.zero;
        Quaternion m_PreviousReferenceOrientation = Quaternion.identity;
        Quaternion m_targetOrientationOnAssign = Quaternion.identity;
        Transform m_previousTarget = null;

        /// <summary>Internal API for the Inspector Editor, so it can draw a marker at the target</summary>
        public Quaternion GetReferenceOrientation(Vector3 worldUp)
        {
            if (FollowTarget != null)
            {
                Quaternion targetOrientation = FollowTarget.rotation;
                switch (m_BindingMode)
                {
                    case BindingMode.LockToTargetOnAssign:
                        return m_targetOrientationOnAssign;
                    case BindingMode.LockToTargetWithWorldUp:
                        return Uppify(targetOrientation, worldUp);
                    case BindingMode.LockToTargetNoRoll:
                        return Quaternion.LookRotation(targetOrientation * Vector3.forward, worldUp);
                    case BindingMode.LockToTarget:
                        return targetOrientation;
                    case BindingMode.SimpleFollowWithWorldUp:
                    {
                        Vector3 dir = FollowTarget.position - VcamState.RawPosition;
                        if (dir.AlmostZero())
                            break;
                        return Uppify(Quaternion.LookRotation(dir, worldUp), worldUp);
                    }
                    default:
                        break;
                }
            }
            return Quaternion.identity; 
        }

        static Quaternion Uppify(Quaternion q, Vector3 up)
        {
            Quaternion r = Quaternion.FromToRotation(q * Vector3.up, up);
            return r * q;
        }
    }
}
