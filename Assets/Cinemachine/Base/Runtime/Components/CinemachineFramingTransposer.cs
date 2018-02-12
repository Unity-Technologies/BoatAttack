using System;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.Serialization;

namespace Cinemachine
{
    /// <summary>
    /// This is a Cinemachine Component in the Body section of the component pipeline. 
    /// Its job is to position the camera in a fixed screen-space relationship to 
    /// the vcam's Follow target object, with offsets and damping.
    /// 
    /// The camera will be first moved along the camera Z axis until the Follow target
    /// is at the desired distance from the camera's X-Y plane.  The camera will then
    /// be moved in its XY plane until the Follow target is at the desired point on
    /// the camera's screen.
    /// 
    /// The FramingTansposer will only change the camera's position in space.  It will not 
    /// re-orient or otherwise aim the camera.
    /// 
    /// For this component to work properly, the vcam's LookAt target must be null.
    /// The Follow target will define what the camera is looking at.
    /// 
    /// If the Follow target is a CinemachineTargetGroup, then additional controls will 
    /// be available to dynamically adjust the camera’s view in order to frame the entire group.
    /// 
    /// Although this component was designed for orthographic cameras, it works equally  
    /// well with persective cameras and can be used in 3D environments.
    /// </summary>
    [DocumentationSorting(5.5f, DocumentationSortingAttribute.Level.UserRef)]
    [ExecuteInEditMode] // for OnGUI
    [AddComponentMenu("")] // Don't display in add component menu
    [RequireComponent(typeof(CinemachinePipeline))]
    [SaveDuringPlay]
    public class CinemachineFramingTransposer : CinemachineComponentBase
    {
        /// <summary>Used by the Inspector Editor to display on-screen guides.</summary>
        [NoSaveDuringPlay, HideInInspector]
        public Action OnGUICallback = null;

        /// <summary>This setting will instruct the composer to adjust its target offset based
        /// on the motion of the target.  The composer will look at a point where it estimates
        /// the target will be this many seconds into the future.  Note that this setting is sensitive
        /// to noisy animation, and can amplify the noise, resulting in undesirable camera jitter.
        /// If the camera jitters unacceptably when the target is in motion, turn down this setting, 
        /// or animate the target more smoothly.</summary>
        [Tooltip("This setting will instruct the composer to adjust its target offset based on the motion of the target.  The composer will look at a point where it estimates the target will be this many seconds into the future.  Note that this setting is sensitive to noisy animation, and can amplify the noise, resulting in undesirable camera jitter.  If the camera jitters unacceptably when the target is in motion, turn down this setting, or animate the target more smoothly.")]
        [Range(0f, 1f)]
        public float m_LookaheadTime = 0;

        /// <summary>Controls the smoothness of the lookahead algorithm.  Larger values smooth out 
        /// jittery predictions and also increase prediction lag</summary>
        [Tooltip("Controls the smoothness of the lookahead algorithm.  Larger values smooth out jittery predictions and also increase prediction lag")]
        [Range(3, 30)]
        public float m_LookaheadSmoothing = 10;

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

        /// <summary>Horizontal screen position for target. The camera will move to position the tracked object here</summary>
        [Space]
        [Range(0f, 1f)]
        [Tooltip("Horizontal screen position for target. The camera will move to position the tracked object here.")]
        public float m_ScreenX = 0.5f;

        /// <summary>Vertical screen position for target, The camera will move to to position the tracked object here</summary>
        [Range(0f, 1f)]
        [Tooltip("Vertical screen position for target, The camera will move to position the tracked object here.")]
        public float m_ScreenY = 0.5f;

        /// <summary>The distance along the camera axis that will be maintained from the Follow target</summary>
        [Tooltip("The distance along the camera axis that will be maintained from the Follow target")]
        public float m_CameraDistance = 10f;

        /// <summary>Camera will not move horizontally if the target is within this range of the position</summary>
        [Space]
        [Range(0f, 1f)]
        [Tooltip("Camera will not move horizontally if the target is within this range of the position.")]
        public float m_DeadZoneWidth = 0.1f;

        /// <summary>Camera will not move vertically if the target is within this range of the position</summary>
        [Range(0f, 1f)]
        [Tooltip("Camera will not move vertically if the target is within this range of the position.")]
        public float m_DeadZoneHeight = 0.1f;

        /// <summary>The camera will not move along its z-axis if the Follow target is within this distance of the specified camera distance</summary>
        [Tooltip("The camera will not move along its z-axis if the Follow target is within this distance of the specified camera distance")]
        [FormerlySerializedAs("m_DistanceDeadZoneSize")]
        public float m_DeadZoneDepth = 0;

        [Space]
        /// <summary>If checked, then then soft zone will be unlimited in size</summary>
        [Tooltip("If checked, then then soft zone will be unlimited in size.")]
        public bool m_UnlimitedSoftZone = false;

        /// <summary>When target is within this region, camera will gradually move to re-align
        /// towards the desired position, depending onm the damping speed</summary>
        [Range(0f, 2f)]
        [Tooltip("When target is within this region, camera will gradually move horizontally to re-align towards the desired position, depending on the damping speed.")]
        public float m_SoftZoneWidth = 0.8f;

        /// <summary>When target is within this region, camera will gradually move to re-align
        /// towards the desired position, depending onm the damping speed</summary>
        [Range(0f, 2f)]
        [Tooltip("When target is within this region, camera will gradually move vertically to re-align towards the desired position, depending on the damping speed.")]
        public float m_SoftZoneHeight = 0.8f;

        /// <summary>A non-zero bias will move the targt position away from the center of the soft zone</summary>
        [Range(-0.5f, 0.5f)]
        [Tooltip("A non-zero bias will move the target position horizontally away from the center of the soft zone.")]
        public float m_BiasX = 0f;

        /// <summary>A non-zero bias will move the targt position away from the center of the soft zone</summary>
        [Range(-0.5f, 0.5f)]
        [Tooltip("A non-zero bias will move the target position vertically away from the center of the soft zone.")]
        public float m_BiasY = 0f;

        /// <summary>What screen dimensions to consider when framing</summary>
        [DocumentationSorting(4.01f, DocumentationSortingAttribute.Level.UserRef)]
        public enum FramingMode
        {
            /// <summary>Consider only the horizontal dimension.  Vertical framing is ignored.</summary>
            Horizontal,
            /// <summary>Consider only the vertical dimension.  Horizontal framing is ignored.</summary>
            Vertical,
            /// <summary>The larger of the horizontal and vertical dimensions will dominate, to get the best fit.</summary>
            HorizontalAndVertical,
            /// <summary>Don't do any framing adjustment</summary>
            None
        };

        /// <summary>What screen dimensions to consider when framing</summary>
        [Space]
        [Tooltip("What screen dimensions to consider when framing.  Can be Horizontal, Vertical, or both")]
        [FormerlySerializedAs("m_FramingMode")]
        public FramingMode m_GroupFramingMode = FramingMode.HorizontalAndVertical;

        /// <summary>How to adjust the camera to get the desired framing</summary>
        public enum AdjustmentMode
        {
            /// <summary>Do not move the camera, only adjust the FOV.</summary>
            ZoomOnly,
            /// <summary>Just move the camera, don't change the FOV.</summary>
            DollyOnly,
            /// <summary>Move the camera as much as permitted by the ranges, then
            /// adjust the FOV if necessary to make the shot.</summary>
            DollyThenZoom
        };

        /// <summary>How to adjust the camera to get the desired framing</summary>
        [Tooltip("How to adjust the camera to get the desired framing.  You can zoom, dolly in/out, or do both.")]
        public AdjustmentMode m_AdjustmentMode = AdjustmentMode.DollyThenZoom;

        /// <summary>How much of the screen to fill with the bounding box of the targets.</summary>
        [Tooltip("The bounding box of the targets should occupy this amount of the screen space.  1 means fill the whole screen.  0.5 means fill half the screen, etc.")]
        public float m_GroupFramingSize = 0.8f;

        /// <summary>How much closer to the target can the camera go?</summary>
        [Tooltip("The maximum distance toward the target that this behaviour is allowed to move the camera.")]
        public float m_MaxDollyIn = 5000f;

        /// <summary>How much farther from the target can the camera go?</summary>
        [Tooltip("The maximum distance away the target that this behaviour is allowed to move the camera.")]
        public float m_MaxDollyOut = 5000f;

        /// <summary>Set this to limit how close to the target the camera can get</summary>
        [Tooltip("Set this to limit how close to the target the camera can get.")]
        public float m_MinimumDistance = 1;

        /// <summary>Set this to limit how far from the taregt the camera can get</summary>
        [Tooltip("Set this to limit how far from the target the camera can get.")]
        public float m_MaximumDistance = 5000f;

        /// <summary>If adjusting FOV, will not set the FOV lower than this</summary>
        [Range(1, 179)]
        [Tooltip("If adjusting FOV, will not set the FOV lower than this.")]
        public float m_MinimumFOV = 3;

        /// <summary>If adjusting FOV, will not set the FOV higher than this</summary>
        [Range(1, 179)]
        [Tooltip("If adjusting FOV, will not set the FOV higher than this.")]
        public float m_MaximumFOV = 60;

        /// <summary>If adjusting Orthographic Size, will not set it lower than this</summary>
        [Tooltip("If adjusting Orthographic Size, will not set it lower than this.")]
        public float m_MinimumOrthoSize = 1;

        /// <summary>If adjusting Orthographic Size, will not set it higher than this</summary>
        [Tooltip("If adjusting Orthographic Size, will not set it higher than this.")]
        public float m_MaximumOrthoSize = 100;

        /// <summary>Internal API for the inspector editor</summary>
        public Rect SoftGuideRect
        {
            get
            {
                return new Rect(
                    m_ScreenX - m_DeadZoneWidth / 2, m_ScreenY - m_DeadZoneHeight / 2,
                    m_DeadZoneWidth, m_DeadZoneHeight);
            }
            set
            {
                m_DeadZoneWidth = Mathf.Clamp01(value.width);
                m_DeadZoneHeight = Mathf.Clamp01(value.height);
                m_ScreenX = Mathf.Clamp01(value.x + m_DeadZoneWidth / 2);
                m_ScreenY = Mathf.Clamp01(value.y + m_DeadZoneHeight / 2);
                m_SoftZoneWidth = Mathf.Max(m_SoftZoneWidth, m_DeadZoneWidth);
                m_SoftZoneHeight = Mathf.Max(m_SoftZoneHeight, m_DeadZoneHeight);
            }
        }

        /// <summary>Internal API for the inspector editor</summary>
        public Rect HardGuideRect
        {
            get
            {
                Rect r = new Rect(
                        m_ScreenX - m_SoftZoneWidth / 2, m_ScreenY - m_SoftZoneHeight / 2,
                        m_SoftZoneWidth, m_SoftZoneHeight);
                r.position += new Vector2(
                        m_BiasX * (m_SoftZoneWidth - m_DeadZoneWidth),
                        m_BiasY * (m_SoftZoneHeight - m_DeadZoneHeight));
                return r;
            }
            set
            {
                m_SoftZoneWidth = Mathf.Clamp(value.width, 0, 2f);
                m_SoftZoneHeight = Mathf.Clamp(value.height, 0, 2f);
                m_DeadZoneWidth = Mathf.Min(m_DeadZoneWidth, m_SoftZoneWidth);
                m_DeadZoneHeight = Mathf.Min(m_DeadZoneHeight, m_SoftZoneHeight);

                Vector2 center = value.center;
                Vector2 bias = center - new Vector2(m_ScreenX, m_ScreenY);
                float biasWidth = Mathf.Max(0, m_SoftZoneWidth - m_DeadZoneWidth);
                float biasHeight = Mathf.Max(0, m_SoftZoneHeight - m_DeadZoneHeight);
                m_BiasX = biasWidth < Epsilon ? 0 : Mathf.Clamp(bias.x / biasWidth, -0.5f, 0.5f);
                m_BiasY = biasHeight < Epsilon ? 0 : Mathf.Clamp(bias.y / biasHeight, -0.5f, 0.5f);
            }
        }

        private void OnValidate()
        {
            m_CameraDistance = Mathf.Max(m_CameraDistance, kMinimumCameraDistance);
            m_DeadZoneDepth = Mathf.Max(m_DeadZoneDepth, 0);

            m_GroupFramingSize = Mathf.Max(Epsilon, m_GroupFramingSize);
            m_MaxDollyIn = Mathf.Max(0, m_MaxDollyIn);
            m_MaxDollyOut = Mathf.Max(0, m_MaxDollyOut);
            m_MinimumDistance = Mathf.Max(0, m_MinimumDistance);
            m_MaximumDistance = Mathf.Max(m_MinimumDistance, m_MaximumDistance);
            m_MinimumFOV = Mathf.Max(1, m_MinimumFOV);
            m_MaximumFOV = Mathf.Clamp(m_MaximumFOV, m_MinimumFOV, 179);
            m_MinimumOrthoSize = Mathf.Max(0.01f, m_MinimumOrthoSize);
            m_MaximumOrthoSize = Mathf.Max(m_MinimumOrthoSize, m_MaximumOrthoSize);
        }

#if UNITY_EDITOR
        private void OnGUI() { if (OnGUICallback != null) OnGUICallback(); }
#endif

        /// <summary>True if component is enabled and has a valid Follow target</summary>
        public override bool IsValid { get { return enabled && FollowTarget != null && LookAtTarget == null; } }

        /// <summary>Get the Cinemachine Pipeline stage that this component implements.
        /// Always returns the Body stage</summary>
        public override CinemachineCore.Stage Stage { get { return CinemachineCore.Stage.Body; } }

        const float kMinimumCameraDistance = 0.01f;

        /// <summary>State information for damping</summary>
        Vector3 m_PreviousCameraPosition = Vector3.zero;
        PositionPredictor m_Predictor = new PositionPredictor();

        /// <summary>Internal API for inspector</summary>
        public Vector3 TrackedPoint { get; private set; }

        /// <summary>Positions the virtual camera according to the transposer rules.</summary>
        /// <param name="curState">The current camera state</param>
        /// <param name="deltaTime">Used for damping.  If less than 0, no damping is done.</param>
        public override void MutateCameraState(ref CameraState curState, float deltaTime)
        {
            if (deltaTime < 0)
            {
                m_Predictor.Reset();
                m_PreviousCameraPosition = curState.RawPosition 
                    + (curState.RawOrientation * Vector3.back) * m_CameraDistance;
            }
            if (!IsValid)
                return;

            //UnityEngine.Profiling.Profiler.BeginSample("CinemachineFramingTransposer.MutateCameraState");
            Vector3 camPosWorld = m_PreviousCameraPosition;
            curState.ReferenceLookAt = FollowTarget.position;
            m_Predictor.Smoothing = m_LookaheadSmoothing;
            m_Predictor.AddPosition(curState.ReferenceLookAt);
            TrackedPoint = (m_LookaheadTime > 0) 
                ? m_Predictor.PredictPosition(m_LookaheadTime) : curState.ReferenceLookAt;

            // Work in camera-local space
            Quaternion localToWorld = curState.RawOrientation;
            Quaternion worldToLocal = Quaternion.Inverse(localToWorld);
            Vector3 cameraPos = worldToLocal * camPosWorld;
            Vector3 targetPos = (worldToLocal * TrackedPoint) - cameraPos;

            // Move along camera z
            Vector3 cameraOffset = Vector3.zero;
            float cameraMin = Mathf.Max(kMinimumCameraDistance, m_CameraDistance - m_DeadZoneDepth/2);
            float cameraMax = Mathf.Max(cameraMin, m_CameraDistance + m_DeadZoneDepth/2);
            if (targetPos.z < cameraMin)
                cameraOffset.z = targetPos.z - cameraMin;
            if (targetPos.z > cameraMax)
                cameraOffset.z = targetPos.z - cameraMax;

            // Adjust for group framing
            CinemachineTargetGroup group = TargetGroup;
            if (group != null && m_GroupFramingMode != FramingMode.None)
                cameraOffset.z += AdjustCameraDepthAndLensForGroupFraming(
                    group, targetPos.z - cameraOffset.z, ref curState, deltaTime);

            // Move along the XY plane
            targetPos.z -= cameraOffset.z;
            float screenSize = curState.Lens.Orthographic 
                ? curState.Lens.OrthographicSize 
                : Mathf.Tan(0.5f * curState.Lens.FieldOfView * Mathf.Deg2Rad) * targetPos.z;
            Rect softGuideOrtho = ScreenToOrtho(SoftGuideRect, screenSize, curState.Lens.Aspect);
            if (deltaTime < 0)
            {
                // No damping or hard bounds, just snap to central bounds, skipping the soft zone
                Rect rect = new Rect(softGuideOrtho.center, Vector2.zero); // Force to center
                cameraOffset += OrthoOffsetToScreenBounds(targetPos, rect);
            }
            else
            {
                // Move it through the soft zone
                cameraOffset += OrthoOffsetToScreenBounds(targetPos, softGuideOrtho);

                // Find where it intersects the hard zone
                Vector3 hard = Vector3.zero;
                if (!m_UnlimitedSoftZone)
                {
                    Rect hardGuideOrtho = ScreenToOrtho(HardGuideRect, screenSize, curState.Lens.Aspect);
                    hard = OrthoOffsetToScreenBounds(targetPos, hardGuideOrtho);
                    float t = Mathf.Max(hard.x / (cameraOffset.x + Epsilon), hard.y / (cameraOffset.y + Epsilon));
                    hard = cameraOffset * t;
                }
                // Apply damping, but only to the portion of the move that's inside the hard zone
                cameraOffset = hard + Damper.Damp(
                    cameraOffset - hard, new Vector3(m_XDamping, m_YDamping, m_ZDamping), deltaTime);
            }
            curState.RawPosition = m_PreviousCameraPosition = localToWorld * (cameraPos + cameraOffset);
            //UnityEngine.Profiling.Profiler.EndSample();
        }

        // Convert from screen coords to normalized orthographic distance coords
        private Rect ScreenToOrtho(Rect rScreen, float orthoSize, float aspect)
        {
            Rect r = new Rect();
            r.yMax = 2 * orthoSize * ((1f-rScreen.yMin) - 0.5f);
            r.yMin = 2 * orthoSize * ((1f-rScreen.yMax) - 0.5f);
            r.xMin = 2 * orthoSize * aspect * (rScreen.xMin - 0.5f);
            r.xMax = 2 * orthoSize * aspect * (rScreen.xMax - 0.5f);
            return r;
        }

        private Vector3 OrthoOffsetToScreenBounds(Vector3 targetPos2D, Rect screenRect)
        {
            // Bring it to the edge of screenRect, if outside.  Leave it alone if inside.
            Vector3 delta = Vector3.zero;
            if (targetPos2D.x < screenRect.xMin)
                delta.x += targetPos2D.x - screenRect.xMin;
            if (targetPos2D.x > screenRect.xMax)
                delta.x += targetPos2D.x - screenRect.xMax;
            if (targetPos2D.y < screenRect.yMin)
                delta.y += targetPos2D.y - screenRect.yMin;
            if (targetPos2D.y > screenRect.yMax)
                delta.y += targetPos2D.y - screenRect.yMax;
            return delta;
        }

        float m_prevTargetHeight; // State for frame damping

        /// <summary>For editor visulaization of the calculated bounding box of the group</summary>
        public Bounds m_LastBounds { get; private set; }

        /// <summary>For editor visualization of the calculated bounding box of the group</summary>
        public Matrix4x4 m_lastBoundsMatrix { get; private set; }

        /// <summary>Get Follow target as CinemachineTargetGroup, or null if target is not a group</summary>
        public CinemachineTargetGroup TargetGroup 
        { 
            get
            {
                Transform follow = FollowTarget;
                if (follow != null)
                    return follow.GetComponent<CinemachineTargetGroup>();
                return null;
            }
        }

        float AdjustCameraDepthAndLensForGroupFraming(
            CinemachineTargetGroup group, float targetZ, 
            ref CameraState curState, float deltaTime)
        {
            float cameraOffset = 0;

            // Get the bounding box from that POV in view space, and find its height
            Bounds bounds = group.BoundingBox;
            Vector3 fwd = curState.RawOrientation * Vector3.forward;
            m_lastBoundsMatrix = Matrix4x4.TRS(
                    bounds.center - (fwd * bounds.extents.magnitude),
                    curState.RawOrientation, Vector3.one);
            m_LastBounds = group.GetViewSpaceBoundingBox(m_lastBoundsMatrix);
            float targetHeight = GetTargetHeight(m_LastBounds);

            // Apply damping
            if (deltaTime >= 0)
            {
                float delta = targetHeight - m_prevTargetHeight;
                delta = Damper.Damp(delta, m_ZDamping, deltaTime);
                targetHeight = m_prevTargetHeight + delta;
            }
            m_prevTargetHeight = targetHeight;

            // Move the camera
            if (!curState.Lens.Orthographic && m_AdjustmentMode != AdjustmentMode.ZoomOnly)
            {
                // What distance would be needed to get the target height, at the current FOV
                float desiredDistance 
                    = targetHeight / (2f * Mathf.Tan(curState.Lens.FieldOfView * Mathf.Deg2Rad / 2f));

                // target the near surface of the bounding box
                desiredDistance += m_LastBounds.extents.z;

                // Clamp to respect min/max distance settings
                desiredDistance = Mathf.Clamp(
                        desiredDistance, targetZ - m_MaxDollyIn, targetZ + m_MaxDollyOut);
                desiredDistance = Mathf.Clamp(desiredDistance, m_MinimumDistance, m_MaximumDistance);

                // Apply
                cameraOffset += desiredDistance - targetZ;
            }

            // Apply zoom
            if (curState.Lens.Orthographic || m_AdjustmentMode != AdjustmentMode.DollyOnly)
            {
                float nearBoundsDistance = (targetZ + cameraOffset) - m_LastBounds.extents.z;
                float currentFOV = 179;
                if (nearBoundsDistance > Epsilon)
                    currentFOV = 2f * Mathf.Atan(targetHeight / (2 * nearBoundsDistance)) * Mathf.Rad2Deg;

                LensSettings lens = curState.Lens;
                lens.FieldOfView = Mathf.Clamp(currentFOV, m_MinimumFOV, m_MaximumFOV);
                lens.OrthographicSize = Mathf.Clamp(targetHeight / 2, m_MinimumOrthoSize, m_MaximumOrthoSize);
                curState.Lens = lens;
            }
            return -cameraOffset;
        }

        float GetTargetHeight(Bounds b)
        {
            float framingSize = Mathf.Max(Epsilon, m_GroupFramingSize);
            switch (m_GroupFramingMode)
            {
                case FramingMode.Horizontal:
                    return b.size.x / (framingSize * VcamState.Lens.Aspect);
                case FramingMode.Vertical:
                    return b.size.y / framingSize;
                default:
                case FramingMode.HorizontalAndVertical:
                    return Mathf.Max(
                        b.size.x / (framingSize * VcamState.Lens.Aspect), 
                        b.size.y / framingSize);
            }
        }
    }
}
