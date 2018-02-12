using UnityEngine;
using System;
using Cinemachine.Utility;
using UnityEngine.Serialization;

namespace Cinemachine
{
    /// <summary>
    /// A Cinemachine Virtual Camera Body component that constrains camera motion
    /// to a CinemachinePath.  The camera can move along the path.
    /// 
    /// This behaviour can operate in two modes: manual positioning, and Auto-Dolly positioning.  
    /// In Manual mode, the camera's position is specified by animating the Path Position field.  
    /// In Auto-Dolly mode, the Path Position field is animated automatically every frame by finding
    /// the position on the path that's closest to the virtual camera's Follow target.
    /// </summary>
    [DocumentationSorting(7, DocumentationSortingAttribute.Level.UserRef)]
    [AddComponentMenu("")] // Don't display in add component menu
    [RequireComponent(typeof(CinemachinePipeline))]
    [SaveDuringPlay]
    public class CinemachineTrackedDolly : CinemachineComponentBase
    {
        /// <summary>The path to which the camera will be constrained.  This must be non-null.</summary>
        [Tooltip("The path to which the camera will be constrained.  This must be non-null.")]
        public CinemachinePathBase m_Path;

        /// <summary>The position along the path at which the camera will be placed.
        /// This can be animated directly, or set automatically by the Auto-Dolly feature
        /// to get as close as possible to the Follow target.</summary>
        [Tooltip("The position along the path at which the camera will be placed.  This can be animated directly, or set automatically by the Auto-Dolly feature to get as close as possible to the Follow target.  The value is interpreted according to the Position Units setting.")]
        public float m_PathPosition;

        /// <summary>How to interpret the Path Position</summary>
        [Tooltip("How to interpret Path Position.  If set to Path Units, values are as follows: 0 represents the first waypoint on the path, 1 is the second, and so on.  Values in-between are points on the path in between the waypoints.  If set to Distance, then Path Position represents distance along the path.")]
        public CinemachinePathBase.PositionUnits m_PositionUnits = CinemachinePathBase.PositionUnits.PathUnits;

        /// <summary>Where to put the camera realtive to the path postion.  X is perpendicular to the path, Y is up, and Z is parallel to the path.</summary>
        [Tooltip("Where to put the camera relative to the path position.  X is perpendicular to the path, Y is up, and Z is parallel to the path.  This allows the camera to be offset from the path itself (as if on a tripod, for example).")]
        public Vector3 m_PathOffset = Vector3.zero;

        /// <summary>How aggressively the camera tries to maintain the offset perpendicular to the path.
        /// Small numbers are more responsive, rapidly translating the camera to keep the target's
        /// x-axis offset.  Larger numbers give a more heavy slowly responding camera.
        /// Using different settings per axis can yield a wide range of camera behaviors</summary>
        [Range(0f, 20f)]
        [Tooltip("How aggressively the camera tries to maintain its position in a direction perpendicular to the path.  Small numbers are more responsive, rapidly translating the camera to keep the target's x-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
        public float m_XDamping = 0f;

        /// <summary>How aggressively the camera tries to maintain the offset in the path-local up direction.
        /// Small numbers are more responsive, rapidly translating the camera to keep the target's
        /// y-axis offset.  Larger numbers give a more heavy slowly responding camera.
        /// Using different settings per axis can yield a wide range of camera behaviors</summary>
        [Range(0f, 20f)]
        [Tooltip("How aggressively the camera tries to maintain its position in the path-local up direction.  Small numbers are more responsive, rapidly translating the camera to keep the target's y-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
        public float m_YDamping = 0f;

        /// <summary>How aggressively the camera tries to maintain the offset parallel to the path.
        /// Small numbers are more responsive, rapidly translating the camera to keep the
        /// target's z-axis offset.  Larger numbers give a more heavy slowly responding camera.
        /// Using different settings per axis can yield a wide range of camera behaviors</summary>
        [Range(0f, 20f)]
        [Tooltip("How aggressively the camera tries to maintain its position in a direction parallel to the path.  Small numbers are more responsive, rapidly translating the camera to keep the target's z-axis offset.  Larger numbers give a more heavy slowly responding camera. Using different settings per axis can yield a wide range of camera behaviors.")]
        public float m_ZDamping = 1f;

        /// <summary>Different ways to set the camera's up vector</summary>
        [DocumentationSorting(7.1f, DocumentationSortingAttribute.Level.UserRef)]
        public enum CameraUpMode
        {
            /// <summary>Leave the camera's up vector alone.  It will be set according to the Brain's WorldUp.</summary>
            Default,
            /// <summary>Take the up vector from the path's up vector at the current point</summary>
            Path,
            /// <summary>Take the up vector from the path's up vector at the current point, but with the roll zeroed out</summary>
            PathNoRoll,
            /// <summary>Take the up vector from the Follow target's up vector</summary>
            FollowTarget,
            /// <summary>Take the up vector from the Follow target's up vector, but with the roll zeroed out</summary>
            FollowTargetNoRoll,
        };

        /// <summary>How to set the virtual camera's Up vector.  This will affect the screen composition.</summary>
        [Tooltip("How to set the virtual camera's Up vector.  This will affect the screen composition, because the camera Aim behaviours will always try to respect the Up direction.")]
        public CameraUpMode m_CameraUp = CameraUpMode.Default;

        /// <summary>"How aggressively the camera tries to track the target rotation's X angle.  
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

        /// <summary>Controls how automatic dollying occurs</summary>
        [DocumentationSorting(7.2f, DocumentationSortingAttribute.Level.UserRef)]
        [Serializable]
        public struct AutoDolly
        {
            /// <summary>If checked, will enable automatic dolly, which chooses a path position
            /// that is as close as possible to the Follow target.</summary>
            [Tooltip("If checked, will enable automatic dolly, which chooses a path position that is as close as possible to the Follow target.  Note: this can have significant performance impact")]
            public bool m_Enabled;

            /// <summary>Offset, in current position units, from the closest point on the path to the follow target.</summary>
            [Tooltip("Offset, in current position units, from the closest point on the path to the follow target")]
            public float m_PositionOffset;

            /// <summary>Search up to how many waypoints on either side of the current position.  Use 0 for Entire path</summary>
            [Tooltip("Search up to how many waypoints on either side of the current position.  Use 0 for Entire path.")]
            public int m_SearchRadius;

            /// <summary>We search between waypoints by dividing the segment into this many straight pieces.
            /// The higher the number, the more accurate the result, but performance is
            /// proportionally slower for higher numbers</summary>
            [FormerlySerializedAs("m_StepsPerSegment")]
            [Tooltip("We search between waypoints by dividing the segment into this many straight pieces.  The higher the number, the more accurate the result, but performance is proportionally slower for higher numbers")]
            public int m_SearchResolution;

            /// <summary>Constructor with specific field values</summary>
            public AutoDolly(bool enabled, float positionOffset, int searchRadius, int stepsPerSegment)
            {
                m_Enabled = enabled;
                m_PositionOffset = positionOffset;
                m_SearchRadius = searchRadius;
                m_SearchResolution = stepsPerSegment;
            }
        };

        /// <summary>Controls how automatic dollying occurs</summary>
        [Tooltip("Controls how automatic dollying occurs.  A Follow target is necessary to use this feature.")]
        public AutoDolly m_AutoDolly = new AutoDolly(false, 0, 2, 5);

        /// <summary>True if component is enabled and has a path</summary>
        public override bool IsValid { get { return enabled && m_Path != null; } }

        /// <summary>Get the Cinemachine Pipeline stage that this component implements.
        /// Always returns the Body stage</summary>
        public override CinemachineCore.Stage Stage { get { return CinemachineCore.Stage.Body; } }

        /// <summary>Positions the virtual camera according to the transposer rules.</summary>
        /// <param name="curState">The current camera state</param>
        /// <param name="deltaTime">Used for damping.  If less that 0, no damping is done.</param>
        public override void MutateCameraState(ref CameraState curState, float deltaTime)
        {
            // Init previous frame state info
            if (deltaTime < 0)
            {
                m_PreviousPathPosition = m_PathPosition;
                m_PreviousCameraPosition = curState.RawPosition;
            }

            if (!IsValid)
                return;

            //UnityEngine.Profiling.Profiler.BeginSample("CinemachineTrackedDolly.MutateCameraState");
            // Get the new ideal path base position
            if (m_AutoDolly.m_Enabled && FollowTarget != null)
            {
                float prevPos = m_PreviousPathPosition;
                if (m_PositionUnits == CinemachinePathBase.PositionUnits.Distance)
                    prevPos = m_Path.GetPathPositionFromDistance(prevPos);
                // This works in path units
                m_PathPosition = m_Path.FindClosestPoint(
                    FollowTarget.transform.position,
                    Mathf.FloorToInt(prevPos),
                    (deltaTime < 0 || m_AutoDolly.m_SearchRadius <= 0) 
                        ? -1 : m_AutoDolly.m_SearchRadius,
                    m_AutoDolly.m_SearchResolution);
                if (m_PositionUnits == CinemachinePathBase.PositionUnits.Distance)
                    m_PathPosition = m_Path.GetPathDistanceFromPosition(m_PathPosition);

                // Apply the path position offset
                m_PathPosition += m_AutoDolly.m_PositionOffset;
            }
            float newPathPosition = m_PathPosition;

            if (deltaTime >= 0)
            {
                // Normalize previous position to find the shortest path
                float maxUnit = m_Path.MaxUnit(m_PositionUnits);
                if (maxUnit > 0)
                {
                    float prev = m_Path.NormalizeUnit(m_PreviousPathPosition, m_PositionUnits);
                    float next = m_Path.NormalizeUnit(newPathPosition, m_PositionUnits);
                    if (m_Path.Looped && Mathf.Abs(next - prev) > maxUnit / 2)
                    {
                        if (next > prev)
                            prev += maxUnit;
                        else
                            prev -= maxUnit;
                    }
                    m_PreviousPathPosition = prev;
                    newPathPosition = next;
                }

                // Apply damping along the path direction
                float offset = m_PreviousPathPosition - newPathPosition;
                offset = Damper.Damp(offset, m_ZDamping, deltaTime);
                newPathPosition = m_PreviousPathPosition - offset;
            }
            m_PreviousPathPosition = newPathPosition;
            Quaternion newPathOrientation = m_Path.EvaluateOrientationAtUnit(newPathPosition, m_PositionUnits);

            // Apply the offset to get the new camera position
            Vector3 newCameraPos = m_Path.EvaluatePositionAtUnit(newPathPosition, m_PositionUnits);
            Vector3 offsetX = newPathOrientation * Vector3.right;
            Vector3 offsetY = newPathOrientation * Vector3.up;
            Vector3 offsetZ = newPathOrientation * Vector3.forward;
            newCameraPos += m_PathOffset.x * offsetX;
            newCameraPos += m_PathOffset.y * offsetY;
            newCameraPos += m_PathOffset.z * offsetZ;

            // Apply damping to the remaining directions
            if (deltaTime >= 0)
            {
                Vector3 currentCameraPos = m_PreviousCameraPosition;
                Vector3 delta = (currentCameraPos - newCameraPos);
                Vector3 delta1 = Vector3.Dot(delta, offsetY) * offsetY;
                Vector3 delta0 = delta - delta1;
                delta0 = Damper.Damp(delta0, m_XDamping, deltaTime);
                delta1 = Damper.Damp(delta1, m_YDamping, deltaTime);
                newCameraPos = currentCameraPos - (delta0 + delta1);
            }
            curState.RawPosition = m_PreviousCameraPosition = newCameraPos;

            // Set the orientation and up
            Quaternion newOrientation 
                = GetTargetOrientationAtPathPoint(newPathOrientation, curState.ReferenceUp);
            if (deltaTime < 0)
                m_PreviousOrientation = newOrientation;
            else 
            {
                if (deltaTime >= 0)
                {
                    Vector3 relative = (Quaternion.Inverse(m_PreviousOrientation) 
                        * newOrientation).eulerAngles;
                    for (int i = 0; i < 3; ++i)
                        if (relative[i] > 180)
                            relative[i] -= 360;
                    relative = Damper.Damp(relative, AngularDamping, deltaTime);
                    newOrientation = m_PreviousOrientation * Quaternion.Euler(relative);
                }
                m_PreviousOrientation = newOrientation;
            }

            curState.RawOrientation = newOrientation;
            curState.ReferenceUp = curState.RawOrientation * Vector3.up;
            //UnityEngine.Profiling.Profiler.EndSample();
        }

        /// <summary>API for the editor, to process a position drag from the user.
        /// This implementation adds the delta to the follow offset.</summary>
        /// <param name="delta">The amount dragged this frame</param>
        public override void OnPositionDragged(Vector3 delta)
        {
            Quaternion targetOrientation = m_Path.EvaluateOrientationAtUnit(m_PathPosition, m_PositionUnits);
            Vector3 localOffset = Quaternion.Inverse(targetOrientation) * delta;
            m_PathOffset += localOffset;
        }
        
        private Quaternion GetTargetOrientationAtPathPoint(Quaternion pathOrientation, Vector3 up)
        {
            switch (m_CameraUp)
            {
                default:
                case CameraUpMode.Default: break;
                case CameraUpMode.Path: return pathOrientation;
                case CameraUpMode.PathNoRoll: 
                    return Quaternion.LookRotation(pathOrientation * Vector3.forward, up);
                case CameraUpMode.FollowTarget:
                    if (FollowTarget != null)
                        return FollowTarget.rotation;
                    break;
                case CameraUpMode.FollowTargetNoRoll:
                    if (FollowTarget != null)
                        return Quaternion.LookRotation(FollowTarget.rotation * Vector3.forward, up);
                    break;
            }
            return Quaternion.LookRotation(transform.rotation * Vector3.forward, up);
        }

        private Vector3 AngularDamping
        {
            get 
            { 
                switch (m_CameraUp)
                {
                    case CameraUpMode.PathNoRoll:
                    case CameraUpMode.FollowTargetNoRoll:
                        return new Vector3(m_PitchDamping, m_YawDamping, 0); 
                    case CameraUpMode.Default:
                        return Vector3.zero;
                    default:
                        return new Vector3(m_PitchDamping, m_YawDamping, m_RollDamping); 
                }
            } 
        }
        
        private float m_PreviousPathPosition = 0;
        Quaternion m_PreviousOrientation = Quaternion.identity;
        private Vector3 m_PreviousCameraPosition = Vector3.zero;
    }
}
