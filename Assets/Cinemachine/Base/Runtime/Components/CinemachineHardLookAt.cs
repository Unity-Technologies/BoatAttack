using UnityEngine;

namespace Cinemachine
{
    /// <summary>
    /// This is a CinemachineComponent in the Aim section of the component pipeline.
    /// Its job is to aim the camera hard at the LookAt target.
    /// </summary>
    [DocumentationSorting(23, DocumentationSortingAttribute.Level.UserRef)]
    [AddComponentMenu("")] // Don't display in add component menu
    [RequireComponent(typeof(CinemachinePipeline))]
    [SaveDuringPlay]
    public class CinemachineHardLookAt : CinemachineComponentBase
    {
        /// <summary>True if component is enabled and has a LookAt defined</summary>
        public override bool IsValid { get { return enabled && LookAtTarget != null; } }

        /// <summary>Get the Cinemachine Pipeline stage that this component implements.
        /// Always returns the Aim stage</summary>
        public override CinemachineCore.Stage Stage { get { return CinemachineCore.Stage.Aim; } }

        /// <summary>Applies the composer rules and orients the camera accordingly</summary>
        /// <param name="curState">The current camera state</param>
        /// <param name="deltaTime">Used for calculating damping.  If less than
        /// zero, then target will snap to the center of the dead zone.</param>
        public override void MutateCameraState(ref CameraState curState, float deltaTime)
        {
            if (IsValid && curState.HasLookAt)
            {
                Vector3 dir = (curState.ReferenceLookAt - curState.CorrectedPosition);
                if (dir.magnitude > Epsilon)
                {
                    if (Vector3.Cross(dir.normalized, curState.ReferenceUp).magnitude < Epsilon)
                        curState.RawOrientation = Quaternion.FromToRotation(Vector3.forward, dir);
                    else
                        curState.RawOrientation = Quaternion.LookRotation(dir, curState.ReferenceUp);
                }
            }
        }
    }
}

