using UnityEngine;

namespace Cinemachine
{
    /// <summary>
    /// An abstract representation of a virtual camera which lives within the Unity scene
    /// </summary>
    public interface ICinemachineCamera
    {
        /// <summary>
        /// Gets the name of this virtual camera. For use when deciding how to blend
        /// to or from this camera
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets a brief debug description of this virtual camera, for use when displayiong debug info
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the priority of this <c>ICinemachineCamera</c>. The virtual camera
        /// will be inserted into the global priority stack based on this value.
        /// </summary>
        int Priority { get; set; }

        /// <summary>
        /// The thing the camera wants to look at (aim).  May be null.
        /// </summary>
        Transform LookAt { get; set; }

        /// <summary>
        /// The thing the camera wants to follow (moving camera).  May be null.
        /// </summary>
        Transform Follow { get; set; }

        /// <summary>
        /// Camera state at the current time.
        /// </summary>
        CameraState State { get; }

        /// <summary>
        /// Gets the virtual camera game attached to this class.
        /// </summary>
        GameObject VirtualCameraGameObject { get; }

        /// <summary>For cameras that implement child cameras, return the live child,
        /// otherwise, just returns self.</summary>
        ICinemachineCamera LiveChildOrSelf { get; }

        /// <summary>
        /// For cameras that implement child cameras, returns the parent vcam, otherwise null.
        /// </summary>
        ICinemachineCamera ParentCamera { get; }

        /// <summary>Check whether the vcam is a live child of this camera.</summary>
        /// <param name="vcam">The Virtual Camera to check</param>
        /// <returns>True if the vcam is currently actively influencing the state of this vcam</returns>
        bool IsLiveChild(ICinemachineCamera vcam);

        /// <summary>
        /// Updates this Cinemachine Camera. For an active camera this should be
        /// called once and only once each frame.  To guarantee this, you should never
        /// call this method directly.  Always use
        /// CinemachineCore.UpdateVirtualCamera(ICinemachineCamera, float), which
        /// has protection against multiple calls per frame.
        /// </summary>
        /// <param name="worldUp">Default world Up, set by the CinemachineBrain</param>
        /// <param name="deltaTime">Delta time for time-based effects (ignore if less than 0)</param>
        void UpdateCameraState(Vector3 worldUp, float deltaTime);

        /// <summary>
        /// Notification that a new camera is being activated.  This is sent to the
        /// currently active camera.  Both may be active simultaneously for a while, if blending.
        /// </summary>
        /// <param name="fromCam">The camera being deactivated.  May be null.</param>
        /// <param name="worldUp">Default world Up, set by the CinemachineBrain</param>
        /// <param name="deltaTime">Delta time for time-based effects (ignore if less than 0)</param>
        void OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime);
    }
}
