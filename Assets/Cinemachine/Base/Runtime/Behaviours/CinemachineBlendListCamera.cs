using Cinemachine.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine
{
    /// <summary>
    /// This is a virtual camera "manager" that owns and manages a collection
    /// of child Virtual Cameras.  When the camera goes live, these child vcams 
    /// are enabled, one after another, holding each camera for a designated time.  
    /// Blends between cameras are specified.
    /// The last camera is held indefinitely.
    /// </summary>
    [DocumentationSorting(13, DocumentationSortingAttribute.Level.UserRef)]
    [ExecuteInEditMode, DisallowMultipleComponent]
    [AddComponentMenu("Cinemachine/CinemachineBlendListCamera")]
    public class CinemachineBlendListCamera : CinemachineVirtualCameraBase
    {
        /// <summary>Default object for the camera children to look at (the aim target), if not specified in a child rig.  May be empty</summary>
        [Tooltip("Default object for the camera children to look at (the aim target), if not specified in a child camera.  May be empty if all of the children define targets of their own.")]
        [NoSaveDuringPlay]
        public Transform m_LookAt = null;

        /// <summary>Default object for the camera children wants to move with (the body target), if not specified in a child rig.  May be empty</summary>
        [Tooltip("Default object for the camera children wants to move with (the body target), if not specified in a child camera.  May be empty if all of the children define targets of their own.")]
        [NoSaveDuringPlay]
        public Transform m_Follow = null;

        /// <summary>When enabled, the current camera and blend will be indicated in the game window, for debugging</summary>
        [Tooltip("When enabled, the current child camera and blend will be indicated in the game window, for debugging")]
        public bool m_ShowDebugText = false;

        /// <summary>Force all child cameras to be enabled.  This is useful if animating them in Timeline, but consumes extra resources.</summary>
        [Tooltip("Force all child cameras to be enabled.  This is useful if animating them in Timeline, but consumes extra resources")]
        public bool m_EnableAllChildCameras;

        /// <summary>Internal API for the editor.  Do not use this field</summary>
        [SerializeField][HideInInspector][NoSaveDuringPlay]
        public CinemachineVirtualCameraBase[] m_ChildCameras = null;

        /// <summary>This represents a single entry in the instrunction list of the BlendListCamera.</summary>
        [Serializable]
        public struct Instruction
        {
            /// <summary>The virtual camera to activate when this instruction becomes active</summary>
            [Tooltip("The virtual camera to activate when this instruction becomes active")]
            public CinemachineVirtualCameraBase m_VirtualCamera;
            /// <summary>How long to wait (in seconds) before activating the next virtual camera in the list (if any)</summary>
            [Tooltip("How long to wait (in seconds) before activating the next virtual camera in the list (if any)")]
            public float m_Hold;
            /// <summary>How to blend to the next virtual camera in the list (if any)</summary>
            [CinemachineBlendDefinitionProperty]
            [Tooltip("How to blend to the next virtual camera in the list (if any)")]
            public CinemachineBlendDefinition m_Blend;
        };

        /// <summary>The set of instructions associating virtual cameras with states.  
        /// The set of instructions for enabling child cameras</summary>
        [Tooltip("The set of instructions for enabling child cameras.")]
        public Instruction[] m_Instructions;

        /// <summary>Gets a brief debug description of this virtual camera, for use when displayiong debug info</summary>
        public override string Description 
        { 
            get 
            { 
                // Show the active camera and blend
                ICinemachineCamera vcam = LiveChild;
                if (mActiveBlend == null) 
                    return (vcam != null) ? "[" + vcam.Name + "]": "(none)";
                return mActiveBlend.Description;
            }
        }

        /// <summary>Get the current "best" child virtual camera, that would be chosen
        /// if the State Driven Camera were active.</summary>
        public ICinemachineCamera LiveChild { set; get; }

        /// <summary>Return the live child.</summary>
        public override ICinemachineCamera LiveChildOrSelf { get { return LiveChild; } }

        /// <summary>Check whether the vcam a live child of this camera.</summary>
        /// <param name="vcam">The Virtual Camera to check</param>
        /// <returns>True if the vcam is currently actively influencing the state of this vcam</returns>
        public override bool IsLiveChild(ICinemachineCamera vcam) 
        { 
            return vcam == LiveChild 
                || (mActiveBlend != null && (vcam == mActiveBlend.CamA || vcam == mActiveBlend.CamB));
        }

        /// <summary>The State of the current live child</summary>
        public override CameraState State { get { return m_State; } }

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

        /// <summary>Remove a Pipeline stage hook callback.
        /// Make sure it is removed from all the children.</summary>
        /// <param name="d">The delegate to remove.</param>
        public override void RemovePostPipelineStageHook(OnPostPipelineStageDelegate d)
        {
            base.RemovePostPipelineStageHook(d);
            UpdateListOfChildren();
            foreach (var vcam in m_ChildCameras)
                vcam.RemovePostPipelineStageHook(d);
        }

        /// <summary>Notification that this virtual camera is going live.
        /// <param name="fromCam">The camera being deactivated.  May be null.</param>
        /// <param name="worldUp">Default world Up, set by the CinemachineBrain</param>
        /// <param name="deltaTime">Delta time for time-based effects (ignore if less than or equal to 0)</param>
        public override void OnTransitionFromCamera(
            ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime) 
        {
            base.OnTransitionFromCamera(fromCam, worldUp, deltaTime);
            mActivationTime = Time.time;
            mCurrentInstruction = -1;
            LiveChild = null;
            mActiveBlend = null;
            UpdateCameraState(worldUp, deltaTime);
        }

        /// <summary>Called by CinemachineCore at designated update time
        /// so the vcam can position itself and track its targets.  This implementation
        /// updates all the children, chooses the best one, and implements any required blending.</summary>
        /// <param name="worldUp">Default world Up, set by the CinemachineBrain</param>
        /// <param name="deltaTime">Delta time for time-based effects (ignore if less than or equal to 0)</param>
        public override void UpdateCameraState(Vector3 worldUp, float deltaTime)
        {
            //UnityEngine.Profiling.Profiler.BeginSample("CinemachineBlendListCamera.UpdateCameraState");
            if (!PreviousStateIsValid)
                deltaTime = -1;

            UpdateListOfChildren();

            AdvanceCurrentInstruction();
            CinemachineVirtualCameraBase best = null;
            if (mCurrentInstruction >= 0 && mCurrentInstruction < m_Instructions.Length)
                best = m_Instructions[mCurrentInstruction].m_VirtualCamera;

            if (m_ChildCameras != null)
            {
                for (int i = 0; i < m_ChildCameras.Length; ++i)
                {
                    CinemachineVirtualCameraBase vcam  = m_ChildCameras[i];
                    if (vcam != null)
                    {
                        bool enableChild = m_EnableAllChildCameras || vcam == best;
                        if (enableChild != vcam.VirtualCameraGameObject.activeInHierarchy)
                        {
                            vcam.gameObject.SetActive(enableChild);
                            if (enableChild)
                                CinemachineCore.Instance.UpdateVirtualCamera(vcam, worldUp, deltaTime);
                        }
                    }
                }
            }

            if (best != null)
            {
                ICinemachineCamera previousCam = LiveChild;
                LiveChild = best;

                // Are we transitioning cameras?
                if (previousCam != null && LiveChild != null && previousCam != LiveChild && mCurrentInstruction > 0)
                {
                    // Create a blend (will be null if a cut)
                    mActiveBlend = CreateBlend(
                            previousCam, LiveChild,
                            m_Instructions[mCurrentInstruction].m_Blend.BlendCurve, 
                            m_Instructions[mCurrentInstruction].m_Blend.m_Time, mActiveBlend, deltaTime);

                    // Notify incoming camera of transition
                    LiveChild.OnTransitionFromCamera(previousCam, worldUp, deltaTime);

                    // Generate Camera Activation event if live
                    CinemachineCore.Instance.GenerateCameraActivationEvent(LiveChild);

                    // If cutting, generate a camera cut event if live
                    if (mActiveBlend == null)
                        CinemachineCore.Instance.GenerateCameraCutEvent(LiveChild);
                }
            }

            // Advance the current blend (if any)
            if (mActiveBlend != null)
            {
                mActiveBlend.TimeInBlend += (deltaTime >= 0) ? deltaTime : mActiveBlend.Duration;
                if (mActiveBlend.IsComplete)
                    mActiveBlend = null;
            }

            if (mActiveBlend != null)
            {
                mActiveBlend.UpdateCameraState(worldUp, deltaTime);
                m_State = mActiveBlend.State;
            }
            else if (LiveChild != null)
                m_State =  LiveChild.State;

            PreviousStateIsValid = true;
            //UnityEngine.Profiling.Profiler.EndSample();
        }

        /// <summary>Makes sure the internal child cache is up to date</summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            InvalidateListOfChildren();
            mActiveBlend = null;
        }

        /// <summary>Makes sure the internal child cache is up to date</summary>
        public void OnTransformChildrenChanged()
        {
            InvalidateListOfChildren();
        }

#if UNITY_EDITOR
        /// <summary>Displays the current active camera on the game screen, if requested</summary>
        protected override void OnGUI()
        {
            base.OnGUI();
            if (!m_ShowDebugText)
                CinemachineGameWindowDebug.ReleaseScreenPos(this);
            else
            {
                string text = Name + ": " + Description;
                Rect r = CinemachineGameWindowDebug.GetScreenPos(this, text, GUI.skin.box);
                GUI.Label(r, text, GUI.skin.box);
            }
        }
#endif
        CameraState m_State = CameraState.Default;

        /// <summary>The list of child cameras.  These are just the immediate children in the hierarchy.</summary>
        public CinemachineVirtualCameraBase[] ChildCameras { get { UpdateListOfChildren(); return m_ChildCameras; }}

        /// <summary>Is there a blend in progress?</summary>
        public bool IsBlending { get { return mActiveBlend != null; } }

        /// <summary>The time at which the current instruction went live</summary>
        float mActivationTime = -1;
        int mCurrentInstruction = 0;
        private CinemachineBlend mActiveBlend = null;

        void InvalidateListOfChildren() { m_ChildCameras = null; LiveChild = null; }

        void UpdateListOfChildren()
        {
            if (m_ChildCameras != null)
                return;
            List<CinemachineVirtualCameraBase> list = new List<CinemachineVirtualCameraBase>();
            CinemachineVirtualCameraBase[] kids = GetComponentsInChildren<CinemachineVirtualCameraBase>(true);
            foreach (CinemachineVirtualCameraBase k in kids)
                if (k.transform.parent == transform)
                    list.Add(k);
            m_ChildCameras = list.ToArray();
            ValidateInstructions();
        }

        /// <summary>Internal API for the inspector editor.</summary>
        /// // GML todo: make this private, part of UpdateListOfChildren()
        public void ValidateInstructions()
        {
            if (m_Instructions == null)
                m_Instructions = new Instruction[0];
            for (int i = 0; i < m_Instructions.Length; ++i)
            {
                if (m_Instructions[i].m_VirtualCamera != null
                    && m_Instructions[i].m_VirtualCamera.transform.parent != transform)
                {
                    m_Instructions[i].m_VirtualCamera = null;
                }
            }
            mActiveBlend = null;
        }

        private void AdvanceCurrentInstruction()
        {
            //UnityEngine.Profiling.Profiler.BeginSample("CinemachineBlendListCamera.AdvanceCurrentInstruction");
            if (m_ChildCameras == null || m_ChildCameras.Length == 0 
                || mActivationTime < 0 || m_Instructions.Length == 0)
            {
                mActivationTime = -1;
                mCurrentInstruction = -1;
                mActiveBlend = null;
            }
            else if (mCurrentInstruction >= m_Instructions.Length - 1)
            {
                mCurrentInstruction = m_Instructions.Length - 1;
            }
            else 
            {
                float now = Time.time;
                if (mCurrentInstruction < 0)
                {
                    mActivationTime = now;
                    mCurrentInstruction = 0;
                }
                else if (now - mActivationTime > Mathf.Max(0, m_Instructions[mCurrentInstruction].m_Hold))
                {
                    mActivationTime = now;
                    ++mCurrentInstruction;
                }
            }
            //UnityEngine.Profiling.Profiler.EndSample();
        }

        private CinemachineBlend CreateBlend(
            ICinemachineCamera camA, ICinemachineCamera camB, 
            AnimationCurve blendCurve, float duration,
            CinemachineBlend activeBlend, float deltaTime)
        {
            if (blendCurve == null || duration <= 0 || (camA == null && camB == null))
                return null;

            if (camA == null || activeBlend != null)
            {
                // Blend from the current camera position
                CameraState state = (activeBlend != null) ? activeBlend.State : State;
                camA = new StaticPointVirtualCamera(state, (activeBlend != null) ? "Mid-blend" : "(none)");
            }
            return new CinemachineBlend(camA, camB, blendCurve,duration,  0);
        }
    }
}
