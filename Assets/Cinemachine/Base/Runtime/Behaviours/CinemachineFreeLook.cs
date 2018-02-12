using UnityEngine;
using Cinemachine.Utility;
using UnityEngine.Serialization;
using System;

namespace Cinemachine
{
    /// <summary>
    /// A Cinemachine Camera geared towards a 3rd person camera experience.
    /// The camera orbits around its subject with three separate camera rigs defining
    /// rings around the target. Each rig has its own radius, height offset, composer,
    /// and lens settings.
    /// Depending on the camera's position along the spline connecting these three rigs,
    /// these settings are interpolated to give the final camera position and state.
    /// </summary>
    [DocumentationSorting(11, DocumentationSortingAttribute.Level.UserRef)]
    [ExecuteInEditMode, DisallowMultipleComponent]
    [AddComponentMenu("Cinemachine/CinemachineFreeLook")]
    public class CinemachineFreeLook : CinemachineVirtualCameraBase
    {
        /// <summary>Object for the camera children to look at (the aim target)</summary>
        [Tooltip("Object for the camera children to look at (the aim target).")]
        [NoSaveDuringPlay]
        public Transform m_LookAt = null;

        /// <summary>Object for the camera children wants to move with (the body target)</summary>
        [Tooltip("Object for the camera children wants to move with (the body target).")]
        [NoSaveDuringPlay]
        public Transform m_Follow = null;

        /// <summary>If enabled, this lens setting will apply to all three child rigs, otherwise the child rig lens settings will be used</summary>
        [Tooltip("If enabled, this lens setting will apply to all three child rigs, otherwise the child rig lens settings will be used")]
        [FormerlySerializedAs("m_UseCommonLensSetting")]
        public bool m_CommonLens = true;

        /// <summary>Specifies the lens properties of this Virtual Camera.  
        /// This generally mirrors the Unity Camera's lens settings, and will be used to drive 
        /// the Unity camera when the vcam is active</summary>
        [FormerlySerializedAs("m_LensAttributes")]
        [Tooltip("Specifies the lens properties of this Virtual Camera.  This generally mirrors the Unity Camera's lens settings, and will be used to drive the Unity camera when the vcam is active")]
        [LensSettingsProperty]
        public LensSettings m_Lens = LensSettings.Default;

        /// <summary>The Vertical axis.  Value is 0..1.  Chooses how to blend the child rigs</summary>
        [Header("Axis Control")]
        [Tooltip("The Vertical axis.  Value is 0..1.  Chooses how to blend the child rigs")]
        public AxisState m_YAxis = new AxisState(2f, 0.2f, 0.1f, 0.5f, "Mouse Y", false);

        /// <summary>The Horizontal axis.  Value is 0..359.  This is passed on to the rigs' OrbitalTransposer component</summary>
        [Tooltip("The Horizontal axis.  Value is 0..359.  This is passed on to the rigs' OrbitalTransposer component")]
        public AxisState m_XAxis = new AxisState(300f, 0.1f, 0.1f, 0f, "Mouse X", true);

        /// <summary>The definition of Forward.  Camera will follow behind</summary>
        [Tooltip("The definition of Forward.  Camera will follow behind.")]
        public CinemachineOrbitalTransposer.Heading m_Heading 
            = new CinemachineOrbitalTransposer.Heading(
                CinemachineOrbitalTransposer.Heading.HeadingDefinition.TargetForward, 4, 0);

        /// <summary>Controls how automatic recentering of the X axis is accomplished</summary>
        [Tooltip("Controls how automatic recentering of the X axis is accomplished")]
        public CinemachineOrbitalTransposer.Recentering m_RecenterToTargetHeading
            = new CinemachineOrbitalTransposer.Recentering(false, 1, 2);

        /// <summary>The coordinate space to use when interpreting the offset from the target</summary>
        [Header("Orbits")]
        [Tooltip("The coordinate space to use when interpreting the offset from the target.  This is also used to set the camera's Up vector, which will be maintained when aiming the camera.")]
        public CinemachineOrbitalTransposer.BindingMode m_BindingMode 
            = CinemachineOrbitalTransposer.BindingMode.SimpleFollowWithWorldUp;

        /// <summary></summary>
        [Tooltip("Controls how taut is the line that connects the rigs' orbits, which determines final placement on the Y axis")]
        [Range(0f, 1f)]
        [FormerlySerializedAs("m_SplineTension")]
        public float m_SplineCurvature = 0.2f;

        /// <summary>Defines the height and radius of the Rig orbit</summary>
        [Serializable]
        public struct Orbit 
        { 
            /// <summary>Height relative to target</summary>
            public float m_Height; 
            /// <summary>Radius of orbit</summary>
            public float m_Radius; 
            /// <summary>Constructor with specific values</summary>
            public Orbit(float h, float r) { m_Height = h; m_Radius = r; }
        }

        /// <summary>The radius and height of the three orbiting rigs</summary>
        [Tooltip("The radius and height of the three orbiting rigs.")]
        public Orbit[] m_Orbits = new Orbit[3] 
        { 
            // These are the default orbits
            new Orbit(4.5f, 1.75f),
            new Orbit(2.5f, 3f),
            new Orbit(0.4f, 1.3f)
        };

        // Legacy support
        [SerializeField] [HideInInspector] [FormerlySerializedAs("m_HeadingBias")] 
        private float m_LegacyHeadingBias = float.MaxValue;
        bool mUseLegacyRigDefinitions = false;

        /// <summary>Enforce bounds for fields, when changed in inspector.</summary>
        protected override void OnValidate()
        {
            base.OnValidate();

            // Upgrade after a legacy deserialize
            if (m_LegacyHeadingBias != float.MaxValue)
            {
                m_Heading.m_HeadingBias = m_LegacyHeadingBias;
                m_LegacyHeadingBias = float.MaxValue;
                m_RecenterToTargetHeading.LegacyUpgrade(
                    ref m_Heading.m_HeadingDefinition, ref m_Heading.m_VelocityFilterStrength);
                mUseLegacyRigDefinitions = true;
            }
            m_YAxis.Validate();
            m_XAxis.Validate();
            m_RecenterToTargetHeading.Validate();
            m_Lens.Validate();

            InvalidateRigCache();
        }

        /// <summary>Get a child rig</summary>
        /// <param name="i">Rig index.  Can be 0, 1, or 2</param>
        /// <returns>The rig, or null if index is bad.</returns>
        public CinemachineVirtualCamera GetRig(int i) 
        { 
            UpdateRigCache();  
            return (i < 0 || i > 2) ? null : m_Rigs[i]; 
        }

        /// <summary>Names of the 3 child rigs</summary>
        public static string[] RigNames { get { return new string[] { "TopRig", "MiddleRig", "BottomRig" }; } }

        bool mIsDestroyed = false;

        /// <summary>Updates the child rig cache</summary>
        protected override void OnEnable()
        {
            mIsDestroyed = false;
            base.OnEnable();
            InvalidateRigCache();
        }

        /// <summary>Makes sure that the child rigs get destroyed in an undo-firndly manner.
        /// Invalidates the rig cache.</summary>
        protected override void OnDestroy()
        {
            // Make the rigs visible instead of destroying - this is to keep Undo happy
            if (m_Rigs != null)
                foreach (var rig in m_Rigs)
                    if (rig != null && rig.gameObject != null)
                        rig.gameObject.hideFlags
                            &= ~(HideFlags.HideInHierarchy | HideFlags.HideInInspector);

            mIsDestroyed = true;
            base.OnDestroy();
        }

        /// <summary>Invalidates the rig cache</summary>
        void OnTransformChildrenChanged()
        {
            InvalidateRigCache();
        }

        void Reset()
        {
            DestroyRigs();
        }

        /// <summary>The cacmera state, which will be a blend of the child rig states</summary>
        override public CameraState State { get { return m_State; } }

        /// <summary>Get the current LookAt target.  Returns parent's LookAt if parent
        /// is non-null and no specific LookAt defined for this camera</summary>
        override public Transform LookAt
        {
            get { return ResolveLookAt(m_LookAt); }
            set { m_LookAt = value; }
        }

        /// <summary>Get the current Follow target.  Returns parent's Follow if parent
        /// is non-null and no specific Follow defined for this camera</summary>
        override public Transform Follow
        {
            get { return ResolveFollow(m_Follow); }
            set { m_Follow = value; }
        }

        /// <summary>Returns the rig with the greatest weight</summary>
        public override ICinemachineCamera LiveChildOrSelf 
        { 
            get 
            { 
                // Do not update the rig cache here or there will be infinite loop at creation time 
                if (m_Rigs == null || m_Rigs.Length != 3)
                    return this;
                if (m_YAxis.Value < 0.33f)
                    return m_Rigs[2];
                if (m_YAxis.Value > 0.66f)
                    return m_Rigs[0];
                return m_Rigs[1];
            }
        }

        /// <summary>Check whether the vcam a live child of this camera.  
        /// Returns true if the child is currently contributing actively to the camera state.</summary>
        /// <param name="vcam">The Virtual Camera to check</param>
        /// <returns>True if the vcam is currently actively influencing the state of this vcam</returns>
        public override bool IsLiveChild(ICinemachineCamera vcam) 
        {
            // Do not update the rig cache here or there will be infinite loop at creation time 
            if (m_Rigs == null || m_Rigs.Length != 3)
                return false;

            if (m_YAxis.Value < 0.33f)
                return vcam == (ICinemachineCamera)m_Rigs[2];
            if (m_YAxis.Value > 0.66f)
                return vcam == (ICinemachineCamera)m_Rigs[0];
            return vcam == (ICinemachineCamera)m_Rigs[1]; 
        }

        /// <summary>Remove a Pipeline stage hook callback.
        /// Make sure it is removed from all the children.</summary>
        /// <param name="d">The delegate to remove.</param>
        public override void RemovePostPipelineStageHook(OnPostPipelineStageDelegate d)
        {
            base.RemovePostPipelineStageHook(d);
            UpdateRigCache();
            if (m_Rigs != null)
                foreach (var vcam in m_Rigs)
                    if (vcam != null)
                        vcam.RemovePostPipelineStageHook(d);
        }

        /// <summary>Called by CinemachineCore at designated update time
        /// so the vcam can position itself and track its targets.  All 3 child rigs are updated,
        /// and a blend calculated, depending on the value of the Y axis.</summary>
        /// <param name="worldUp">Default world Up, set by the CinemachineBrain</param>
        /// <param name="deltaTime">Delta time for time-based effects (ignore if less than 0)</param>
        override public void UpdateCameraState(Vector3 worldUp, float deltaTime)
        {
            //UnityEngine.Profiling.Profiler.BeginSample("CinemachineFreeLook.UpdateCameraState");
            if (!PreviousStateIsValid)
                deltaTime = -1;

            UpdateRigCache();

            // Reset the base camera state, in case the game object got moved in the editor
            if (deltaTime < 0)
                m_State = PullStateFromVirtualCamera(worldUp); // Not in gameplay

            // Update the current state by invoking the component pipeline
            m_State = CalculateNewState(worldUp, deltaTime);

            // Push the raw position back to the game object's transform, so it
            // moves along with the camera.  Leave the orientation alone, because it
            // screws up camera dragging when there is a LookAt behaviour.
            if (Follow != null)
            {
                Vector3 delta = State.RawPosition - transform.position;
                transform.position = State.RawPosition;
                m_Rigs[0].transform.position -= delta;
                m_Rigs[1].transform.position -= delta;
                m_Rigs[2].transform.position -= delta;
            }

            PreviousStateIsValid = true;

            // Set up for next frame
            bool activeCam = (deltaTime >= 0) || CinemachineCore.Instance.IsLive(this);
            if (activeCam)
                m_YAxis.Update(deltaTime);

            PushSettingsToRigs();
                 
            //UnityEngine.Profiling.Profiler.EndSample();
        }

        /// <summary>If we are transitioning from another FreeLook, grab the axis values from it.</summary>
        /// <param name="fromCam">The camera being deactivated.  May be null.</param>
        /// <param name="worldUp">Default world Up, set by the CinemachineBrain</param>
        /// <param name="deltaTime">Delta time for time-based effects (ignore if less than or equal to 0)</param>
        public override void OnTransitionFromCamera(
            ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime) 
        {
            base.OnTransitionFromCamera(fromCam, worldUp, deltaTime);
            if ((fromCam != null) && (fromCam is CinemachineFreeLook))
            {
                CinemachineFreeLook freeLookFrom = fromCam as CinemachineFreeLook;
                if (freeLookFrom.Follow == Follow)
                {
                    m_XAxis.Value = freeLookFrom.m_XAxis.Value;
                    m_YAxis.Value = freeLookFrom.m_YAxis.Value;
                    UpdateCameraState(worldUp, deltaTime);
                }
            }
        }

        CameraState m_State = CameraState.Default;          // Current state this frame

        /// Serialized in order to support copy/paste
        [SerializeField][HideInInspector][NoSaveDuringPlay] private CinemachineVirtualCamera[] m_Rigs 
            = new CinemachineVirtualCamera[3];

        void InvalidateRigCache() { mOrbitals = null; }
        CinemachineOrbitalTransposer[] mOrbitals = null;
        CinemachineBlend mBlendA;
        CinemachineBlend mBlendB;

        /// <summary>
        /// Override component pipeline creation.
        /// This needs to be done by the editor to support Undo.
        /// The override must do exactly the same thing as the CreatePipeline method in this class.
        /// </summary>
        public static CreateRigDelegate CreateRigOverride;

        /// <summary>
        /// Override component pipeline creation.
        /// This needs to be done by the editor to support Undo.
        /// The override must do exactly the same thing as the CreatePipeline method in this class.
        /// </summary>
        public delegate CinemachineVirtualCamera CreateRigDelegate(
            CinemachineFreeLook vcam, string name, CinemachineVirtualCamera copyFrom);

        /// <summary>
        /// Override component pipeline destruction.
        /// This needs to be done by the editor to support Undo.
        /// </summary>
        public static DestroyRigDelegate DestroyRigOverride;

        /// <summary>
        /// Override component pipeline destruction.
        /// This needs to be done by the editor to support Undo.
        /// </summary>
        public delegate void DestroyRigDelegate(GameObject rig);

        private void DestroyRigs()
        {
            CinemachineVirtualCamera[] oldRigs = new CinemachineVirtualCamera[RigNames.Length];
            for (int i = 0; i < RigNames.Length; ++i)
            {
                foreach (Transform child in transform)
                    if (child.gameObject.name == RigNames[i])
                        oldRigs[i] = child.GetComponent<CinemachineVirtualCamera>();
            }
            for (int i = 0; i < oldRigs.Length; ++i)
            {
                if (oldRigs[i] != null)
                {
                    if (DestroyRigOverride != null)
                        DestroyRigOverride(oldRigs[i].gameObject);
                    else
                        Destroy(oldRigs[i].gameObject);
                }
            }
            m_Rigs = null;
            mOrbitals = null;
        }

        private CinemachineVirtualCamera[] CreateRigs(CinemachineVirtualCamera[] copyFrom)
        {
            // Invalidate the cache
            mOrbitals = null;
            float[] softCenterDefaultsV = new float[] { 0.5f, 0.55f, 0.6f };
            CinemachineVirtualCamera[] newRigs = new CinemachineVirtualCamera[3];
            for (int i = 0; i < RigNames.Length; ++i)
            {
                CinemachineVirtualCamera src = null;
                if (copyFrom != null && copyFrom.Length > i)
                    src = copyFrom[i];

                if (CreateRigOverride != null)
                    newRigs[i] = CreateRigOverride(this, RigNames[i], src);
                else
                {
                    // Create a new rig with default components
                    GameObject go = new GameObject(RigNames[i]);
                    go.transform.parent = transform;
                    newRigs[i] = go.AddComponent<CinemachineVirtualCamera>();
                    if (src != null)
                        ReflectionHelpers.CopyFields(src, newRigs[i]);
                    else
                    {
                        go = newRigs[i].GetComponentOwner().gameObject;
                        go.AddComponent<CinemachineOrbitalTransposer>();
                        go.AddComponent<CinemachineComposer>();
                    }
                }

                // Set up the defaults
                newRigs[i].InvalidateComponentPipeline();
                CinemachineOrbitalTransposer orbital = newRigs[i].GetCinemachineComponent<CinemachineOrbitalTransposer>();
                if (orbital == null)
                    orbital = newRigs[i].AddCinemachineComponent<CinemachineOrbitalTransposer>(); // should not happen
                if (src == null)
                {
                    // Only set defaults if not copying
                    orbital.m_YawDamping = 0;
                    CinemachineComposer composer = newRigs[i].GetCinemachineComponent<CinemachineComposer>();
                    if (composer != null)
                    {
                        composer.m_HorizontalDamping = composer.m_VerticalDamping = 0;
                        composer.m_ScreenX = 0.5f;
                        composer.m_ScreenY = softCenterDefaultsV[i];
                        composer.m_DeadZoneWidth = composer.m_DeadZoneHeight = 0.1f;
                        composer.m_SoftZoneWidth = composer.m_SoftZoneHeight = 0.8f;
                        composer.m_BiasX = composer.m_BiasY = 0;
                    }
                }
            }
            return newRigs;
        }

        private void UpdateRigCache()
        {
            //UnityEngine.Profiling.Profiler.BeginSample("CinemachineFreeLook.UpdateRigCache");
            if (mIsDestroyed)
            {
                //UnityEngine.Profiling.Profiler.EndSample();
                return;
            }

            // Special condition: Did we just get copy/pasted?
            if (m_Rigs != null && m_Rigs.Length == 3 && m_Rigs[0] != null && m_Rigs[0].transform.parent != transform)
            {
                DestroyRigs();
                m_Rigs = CreateRigs(m_Rigs);
            }

            // Early out if we're up to date
            if (mOrbitals != null && mOrbitals.Length == 3)
            {
                //UnityEngine.Profiling.Profiler.EndSample();
                return;
            }

            // Locate existing rigs, and recreate them if any are missing
            if (LocateExistingRigs(RigNames, false) != 3)
            {
                DestroyRigs();
                m_Rigs = CreateRigs(null);
                LocateExistingRigs(RigNames, true);
            }

            foreach (var rig in m_Rigs)
            {
                // Configure the UI
                rig.m_ExcludedPropertiesInInspector = m_CommonLens 
                    ? new string[] { "m_Script", "Header", "Extensions", "m_Priority", "m_Follow", "m_Lens" }
                    : new string[] { "m_Script", "Header", "Extensions", "m_Priority", "m_Follow" };
                rig.m_LockStageInInspector = new CinemachineCore.Stage[] { CinemachineCore.Stage.Body };
            }

            // Create the blend objects
            mBlendA = new CinemachineBlend(m_Rigs[1], m_Rigs[0], AnimationCurve.Linear(0, 0, 1, 1), 1, 0);
            mBlendB = new CinemachineBlend(m_Rigs[2], m_Rigs[1], AnimationCurve.Linear(0, 0, 1, 1), 1, 0);

            // Horizontal rotation clamped to [0,360] (with wraparound)
            m_XAxis.SetThresholds(0f, 360f, true);

            // Vertical rotation cleamped to [0,1] as it is a t-value for the
            // catmull-rom spline going through the 3 points on the rig
            m_YAxis.SetThresholds(0f, 1f, false);
            //UnityEngine.Profiling.Profiler.EndSample();
        }

        private int LocateExistingRigs(string[] rigNames, bool forceOrbital)
        {
            mOrbitals = new CinemachineOrbitalTransposer[rigNames.Length];
            m_Rigs = new CinemachineVirtualCamera[rigNames.Length];
            int rigsFound = 0;
            foreach (Transform child in transform)
            {
                CinemachineVirtualCamera vcam = child.GetComponent<CinemachineVirtualCamera>();
                if (vcam != null)
                {
                    GameObject go = child.gameObject;
                    for (int i = 0; i < rigNames.Length; ++i)
                    {
                        if (mOrbitals[i] == null && go.name == rigNames[i])
                        {
                            // Must have an orbital transposer or it's no good
                            mOrbitals[i] = vcam.GetCinemachineComponent<CinemachineOrbitalTransposer>();
                            if (mOrbitals[i] == null && forceOrbital)
                                mOrbitals[i] = vcam.AddCinemachineComponent<CinemachineOrbitalTransposer>();
                            if (mOrbitals[i] != null)
                            {
                                mOrbitals[i].m_HeadingIsSlave = true;
                                if (i == 0)
                                    mOrbitals[i].HeadingUpdater 
                                        = (CinemachineOrbitalTransposer orbital, float deltaTime, Vector3 up) 
                                            => { return orbital.UpdateHeading(deltaTime, up, ref m_XAxis); };
                                m_Rigs[i] = vcam;
                                ++rigsFound;
                            }
                        }
                    }
                }
            }
            return rigsFound;
        }

        void PushSettingsToRigs()
        {
            //UnityEngine.Profiling.Profiler.BeginSample("CinemachineFreeLook.PushSettingsToRigs");
            UpdateRigCache();
            for (int i = 0; i < m_Rigs.Length; ++i)
            {
                //UnityEngine.Profiling.Profiler.BeginSample("CinemachineFreeLook.PushSettingsToRigs.m_Rigs[i] == null");
                if (m_Rigs[i] == null)
                {
                    //UnityEngine.Profiling.Profiler.EndSample();
                    continue;
                }
                //UnityEngine.Profiling.Profiler.EndSample();

                //UnityEngine.Profiling.Profiler.BeginSample("CinemachineFreeLook.PushSettingsToRigs.m_CommonLens");
                if (m_CommonLens)
                    m_Rigs[i].m_Lens = m_Lens;
                //UnityEngine.Profiling.Profiler.EndSample();

                // If we just deserialized from a legacy version, 
                // pull the orbits and targets from the rigs
                //UnityEngine.Profiling.Profiler.BeginSample("CinemachineFreeLook.PushSettingsToRigs.mUseLegacyRigDefinitions");
                if (mUseLegacyRigDefinitions)
                {
                    mUseLegacyRigDefinitions = false;
                    m_Orbits[i].m_Height = mOrbitals[i].m_FollowOffset.y;
                    m_Orbits[i].m_Radius = -mOrbitals[i].m_FollowOffset.z;
                    if (m_Rigs[i].Follow != null)
                        Follow = m_Rigs[i].Follow;
                }
                m_Rigs[i].Follow = null;
                //UnityEngine.Profiling.Profiler.EndSample();

                // Hide the rigs from prying eyes
                //UnityEngine.Profiling.Profiler.BeginSample("CinemachineFreeLook.PushSettingsToRigs.Hide the rigs");
                if (CinemachineCore.sShowHiddenObjects)
                    m_Rigs[i].gameObject.hideFlags
                        &= ~(HideFlags.HideInHierarchy | HideFlags.HideInInspector);
                else
                    m_Rigs[i].gameObject.hideFlags
                        |= (HideFlags.HideInHierarchy | HideFlags.HideInInspector);
                //UnityEngine.Profiling.Profiler.EndSample();

                //UnityEngine.Profiling.Profiler.BeginSample("CinemachineFreeLook.PushSettingsToRigs.Push");
                mOrbitals[i].m_FollowOffset = GetLocalPositionForCameraFromInput(m_YAxis.Value);
                mOrbitals[i].m_BindingMode = m_BindingMode;
                mOrbitals[i].m_Heading = m_Heading;
                mOrbitals[i].m_XAxis = m_XAxis;
                mOrbitals[i].m_RecenterToTargetHeading = m_RecenterToTargetHeading;
                if (i > 0)
                    mOrbitals[i].m_RecenterToTargetHeading.m_enabled = false;

                // Hack to get SimpleFollow with heterogeneous dampings to work
                if (m_BindingMode == CinemachineTransposer.BindingMode.SimpleFollowWithWorldUp)
                    m_Rigs[i].SetStateRawPosition(State.RawPosition);

                //UnityEngine.Profiling.Profiler.EndSample();
            }
            //UnityEngine.Profiling.Profiler.EndSample();
        }

        private CameraState CalculateNewState(Vector3 worldUp, float deltaTime)
        {
            //UnityEngine.Profiling.Profiler.BeginSample("CinemachineFreeLook.CalculateNewState");
            CameraState state = PullStateFromVirtualCamera(worldUp);

            // Blend from the appropriate rigs
            float t = m_YAxis.Value;
            if (t > 0.5f)
            {
                if (mBlendA != null)
                {
                    mBlendA.TimeInBlend = (t - 0.5f) * 2f;
                    mBlendA.UpdateCameraState(worldUp, deltaTime);
                    state = mBlendA.State;
                }
            }
            else
            {
                if (mBlendB != null)
                {
                    mBlendB.TimeInBlend = t * 2f;
                    mBlendB.UpdateCameraState(worldUp, deltaTime);
                    state = mBlendB.State;
                }
            }
            //UnityEngine.Profiling.Profiler.EndSample();
            return state;
        }

        private CameraState PullStateFromVirtualCamera(Vector3 worldUp)
        {
            CameraState state = CameraState.Default;
            state.RawPosition = transform.position;
            state.RawOrientation = transform.rotation;
            state.ReferenceUp = worldUp;

            CinemachineBrain brain = CinemachineCore.Instance.FindPotentialTargetBrain(this);
            m_Lens.Aspect = brain != null ? brain.OutputCamera.aspect : 1;
            m_Lens.Orthographic = brain != null ? brain.OutputCamera.orthographic : false;
            state.Lens = m_Lens;

            return state;
        }

        /// <summary>
        /// Returns the local position of the camera along the spline used to connect the
        /// three camera rigs. Does not take into account the current heading of the
        /// camera (or its target)
        /// </summary>
        /// <param name="t">The t-value for the camera on its spline. Internally clamped to
        /// the value [0,1]</param>
        /// <returns>The local offset (back + up) of the camera WRT its target based on the
        /// supplied t-value</returns>
        public Vector3 GetLocalPositionForCameraFromInput(float t)
        {
            //UnityEngine.Profiling.Profiler.BeginSample("CinemachineFreeLook.GetLocalPositionForCameraFromInput");
            if (mOrbitals == null)
            {
                //UnityEngine.Profiling.Profiler.EndSample();
                return Vector3.zero;
            }
            UpdateCachedSpline();
            int n = 1;
            if (t > 0.5f)
            {
                t -= 0.5f;
                n = 2;
            }
            //UnityEngine.Profiling.Profiler.EndSample();
            return SplineHelpers.Bezier3(
                t * 2f, m_CachedKnots[n], m_CachedCtrl1[n], m_CachedCtrl2[n], m_CachedKnots[n+1]);
        }
                
        Orbit[] m_CachedOrbits;
        float m_CachedTension;
        Vector4[] m_CachedKnots;
        Vector4[] m_CachedCtrl1;
        Vector4[] m_CachedCtrl2;
        void UpdateCachedSpline()
        {
            //UnityEngine.Profiling.Profiler.BeginSample("CinemachineFreeLook.UpdateCachedSpline");
            bool cacheIsValid = (m_CachedOrbits != null && m_CachedTension == m_SplineCurvature);
            for (int i = 0; i < 3 && cacheIsValid; ++i)
                cacheIsValid = (m_CachedOrbits[i].m_Height == m_Orbits[i].m_Height 
                    && m_CachedOrbits[i].m_Radius == m_Orbits[i].m_Radius);
            if (!cacheIsValid)
            {
                float t = m_SplineCurvature;
                m_CachedKnots = new Vector4[5];
                m_CachedCtrl1 = new Vector4[5];
                m_CachedCtrl2 = new Vector4[5];
                m_CachedKnots[1] = new Vector4(0, m_Orbits[2].m_Height, -m_Orbits[2].m_Radius, 0);
                m_CachedKnots[2] = new Vector4(0, m_Orbits[1].m_Height, -m_Orbits[1].m_Radius, 0);
                m_CachedKnots[3] = new Vector4(0, m_Orbits[0].m_Height, -m_Orbits[0].m_Radius, 0);
                m_CachedKnots[0] = Vector4.Lerp(m_CachedKnots[1], Vector4.zero, t);
                m_CachedKnots[4] = Vector4.Lerp(m_CachedKnots[3], Vector4.zero, t);
                SplineHelpers.ComputeSmoothControlPoints(
                    ref m_CachedKnots, ref m_CachedCtrl1, ref m_CachedCtrl2);
                m_CachedOrbits = new Orbit[3];
                for (int i = 0; i < 3; ++i)
                    m_CachedOrbits[i] = m_Orbits[i];
                m_CachedTension = m_SplineCurvature;
            }
            //UnityEngine.Profiling.Profiler.EndSample();
        }
    }
}
