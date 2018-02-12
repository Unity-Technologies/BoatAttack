using Cinemachine.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine
{
    /// <summary>
    /// This is a virtual camera "manager" that owns and manages a collection
    /// of child Virtual Cameras.  These child vcams are mapped to individual states in
    /// an animation state machine, allowing you to associate specific vcams to specific 
    /// animation states.  When that state is active in the state machine, then the 
    /// associated camera will be activated.
    /// 
    /// You can define custom blends and transitions between child cameras.
    /// 
    /// In order to use this behaviour, you must have an animated target (i.e. an object
    /// animated with a state machine) to drive the behaviour.
    /// </summary>
    [DocumentationSorting(13, DocumentationSortingAttribute.Level.UserRef)]
    [ExecuteInEditMode, DisallowMultipleComponent]
    [AddComponentMenu("Cinemachine/CinemachineStateDrivenCamera")]
    public class CinemachineStateDrivenCamera : CinemachineVirtualCameraBase
    {
        /// <summary>Default object for the camera children to look at (the aim target), if not specified in a child rig.  May be empty</summary>
        [Tooltip("Default object for the camera children to look at (the aim target), if not specified in a child camera.  May be empty if all of the children define targets of their own.")]
        [NoSaveDuringPlay]
        public Transform m_LookAt = null;

        /// <summary>Default object for the camera children wants to move with (the body target), if not specified in a child rig.  May be empty</summary>
        [Tooltip("Default object for the camera children wants to move with (the body target), if not specified in a child camera.  May be empty if all of the children define targets of their own.")]
        [NoSaveDuringPlay]
        public Transform m_Follow = null;

        /// <summary>The state machine whose state changes will drive this camera's choice of active child</summary>
        [Space]
        [Tooltip("The state machine whose state changes will drive this camera's choice of active child")]
        public Animator m_AnimatedTarget;

        /// <summary>Which layer in the target FSM to observe</summary>
        [Tooltip("Which layer in the target state machine to observe")]
        public int m_LayerIndex;

        /// <summary>When enabled, the current camera and blend will be indicated in the game window, for debugging</summary>
        [Tooltip("When enabled, the current child camera and blend will be indicated in the game window, for debugging")]
        public bool m_ShowDebugText = false;

        /// <summary>Force all child cameras to be enabled.  This is useful if animating them in Timeline, but consumes extra resources.</summary>
        [Tooltip("Force all child cameras to be enabled.  This is useful if animating them in Timeline, but consumes extra resources")]
        public bool m_EnableAllChildCameras;

        /// <summary>Internal API for the editor.  Do not use this field</summary>
        [SerializeField][HideInInspector][NoSaveDuringPlay]
        public CinemachineVirtualCameraBase[] m_ChildCameras = null;

        /// <summary>This represents a single instrunction to the StateDrivenCamera.  It associates
        /// an state from the state machine with a child Virtual Camera, and also holds
        /// activation tuning parameters.</summary>
        [Serializable]
        public struct Instruction
        {
            /// <summary>The full hash of the animation state</summary>
            [Tooltip("The full hash of the animation state")]
            public int m_FullHash;
            /// <summary>The virtual camera to activate whrn the animation state becomes active</summary>
            [Tooltip("The virtual camera to activate whrn the animation state becomes active")]
            public CinemachineVirtualCameraBase m_VirtualCamera;
            /// <summary>How long to wait (in seconds) before activating the virtual camera. 
            /// This filters out very short state durations</summary>
            [Tooltip("How long to wait (in seconds) before activating the virtual camera. This filters out very short state durations")]
            public float m_ActivateAfter;
            /// <summary>The minimum length of time (in seconds) to keep a virtual camera active</summary>
            [Tooltip("The minimum length of time (in seconds) to keep a virtual camera active")]
            public float m_MinDuration;
        };

        /// <summary>The set of instructions associating virtual cameras with states.  
        /// These instructions are used to choose the live child at any given moment</summary>
        [Tooltip("The set of instructions associating virtual cameras with states.  These instructions are used to choose the live child at any given moment")]
        public Instruction[] m_Instructions;

        /// <summary>
        /// The blend which is used if you don't explicitly define a blend between two Virtual Camera children.
        /// </summary>
        [CinemachineBlendDefinitionProperty]
        [Tooltip("The blend which is used if you don't explicitly define a blend between two Virtual Camera children")]
        public CinemachineBlendDefinition m_DefaultBlend
            = new CinemachineBlendDefinition(CinemachineBlendDefinition.Style.EaseInOut, 0.5f);

        /// <summary>
        /// This is the asset which contains custom settings for specific child blends.
        /// </summary>
        [Tooltip("This is the asset which contains custom settings for specific child blends")]
        public CinemachineBlenderSettings m_CustomBlends = null;

        /// <summary>Internal API for the Inspector editor.  This implements nested states.</summary>
        [Serializable]
        [DocumentationSorting(13.2f, DocumentationSortingAttribute.Level.Undoc)]
        public struct ParentHash
        {
            /// <summary>Internal API for the Inspector editor</summary>
            public int m_Hash;
            /// <summary>Internal API for the Inspector editor</summary>
            public int m_ParentHash;
            /// <summary>Internal API for the Inspector editor</summary>
            public ParentHash(int h, int p) { m_Hash = h; m_ParentHash = p; }
        }
        /// <summary>Internal API for the Inspector editor</summary>
        [HideInInspector][SerializeField] public ParentHash[] m_ParentHash = null;

        /// <summary>Gets a brief debug description of this virtual camera, for use when displayiong debug info</summary>
        public override string Description 
        { 
            get 
            { 
                // Show the active camera and blend
                ICinemachineCamera vcam = LiveChild;
                if (mActiveBlend == null) 
                    return (vcam != null) ? "[" + vcam.Name + "]" : "(none)";
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

        /// <summary>Called by CinemachineCore at designated update time
        /// so the vcam can position itself and track its targets.  This implementation
        /// updates all the children, chooses the best one, and implements any required blending.</summary>
        /// <param name="worldUp">Default world Up, set by the CinemachineBrain</param>
        /// <param name="deltaTime">Delta time for time-based effects (ignore if less than or equal to 0)</param>
        public override void UpdateCameraState(Vector3 worldUp, float deltaTime)
        {
            //UnityEngine.Profiling.Profiler.BeginSample("CinemachineStateDrivenCamera.UpdateCameraState");
            if (!PreviousStateIsValid)
                deltaTime = -1;

            UpdateListOfChildren();
            CinemachineVirtualCameraBase best = ChooseCurrentCamera(deltaTime);
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

            ICinemachineCamera previousCam = LiveChild;
            LiveChild = best;

            // Are we transitioning cameras?
            if (previousCam != null && LiveChild != null && previousCam != LiveChild)
            {
                // Create a blend (will be null if a cut)
                float duration = 0;
                AnimationCurve curve = LookupBlendCurve(previousCam, LiveChild, out duration);
                mActiveBlend = CreateBlend(
                        previousCam, LiveChild,
                        curve, duration, mActiveBlend, deltaTime);

                // Notify incoming camera of transition
                LiveChild.OnTransitionFromCamera(previousCam, worldUp, deltaTime);

                // Generate Camera Activation event if live
                CinemachineCore.Instance.GenerateCameraActivationEvent(LiveChild);

                // If cutting, generate a camera cut event if live
                if (mActiveBlend == null)
                    CinemachineCore.Instance.GenerateCameraCutEvent(LiveChild);
            }

            // Advance the current blend (if any)
            if (mActiveBlend != null)
            {
                mActiveBlend.TimeInBlend += (deltaTime >= 0)
                    ? deltaTime : mActiveBlend.Duration;
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

        /// <summary>API for the inspector editor.  Animation module does not have hashes
        /// for state parents, so we have to invent them in order to implement nested state
        /// handling</summary>
        public static string CreateFakeHashName(int parentHash, string stateName)
            { return parentHash.ToString() + "_" + stateName; }

        float mActivationTime = 0;
        Instruction mActiveInstruction;
        float mPendingActivationTime = 0;
        Instruction mPendingInstruction;
        private CinemachineBlend mActiveBlend = null;

        void InvalidateListOfChildren() { m_ChildCameras = null; LiveChild = null; }

        void UpdateListOfChildren()
        {
            if (m_ChildCameras != null && mInstructionDictionary != null && mStateParentLookup != null)
                return;
            List<CinemachineVirtualCameraBase> list = new List<CinemachineVirtualCameraBase>();
            CinemachineVirtualCameraBase[] kids = GetComponentsInChildren<CinemachineVirtualCameraBase>(true);
            foreach (CinemachineVirtualCameraBase k in kids)
                if (k.transform.parent == transform)
                    list.Add(k);
            m_ChildCameras = list.ToArray();
            ValidateInstructions();
        }

        private Dictionary<int, int> mInstructionDictionary;
        private Dictionary<int, int> mStateParentLookup;
        /// <summary>Internal API for the inspector editor.</summary>
        public void ValidateInstructions()
        {
            if (m_Instructions == null)
                m_Instructions = new Instruction[0];
            mInstructionDictionary = new Dictionary<int, int>();
            for (int i = 0; i < m_Instructions.Length; ++i)
            {
                if (m_Instructions[i].m_VirtualCamera != null
                    && m_Instructions[i].m_VirtualCamera.transform.parent != transform)
                {
                    m_Instructions[i].m_VirtualCamera = null;
                }
                mInstructionDictionary[m_Instructions[i].m_FullHash] = i;
            }

            // Create the parent lookup
            mStateParentLookup = new Dictionary<int, int>();
            if (m_ParentHash != null)
                foreach (var i in m_ParentHash)
                    mStateParentLookup[i.m_Hash] = i.m_ParentHash;

            // Zap the cached current instructions
            mActivationTime = mPendingActivationTime = 0;
            mActiveBlend = null;
        }

        List<AnimatorClipInfo>  m_clipInfoList = new List<AnimatorClipInfo>();
        private CinemachineVirtualCameraBase ChooseCurrentCamera(float deltaTime)
        {
            //UnityEngine.Profiling.Profiler.BeginSample("CinemachineStateDrivenCamera.ChooseCurrentCamera");
            if (m_ChildCameras == null || m_ChildCameras.Length == 0)
            {
                mActivationTime = 0;
                //UnityEngine.Profiling.Profiler.EndSample();
                return null;
            }
            CinemachineVirtualCameraBase defaultCam = m_ChildCameras[0];
            if (m_AnimatedTarget == null || !m_AnimatedTarget.gameObject.activeSelf 
                || m_AnimatedTarget.runtimeAnimatorController == null
                || m_LayerIndex < 0 || m_LayerIndex >= m_AnimatedTarget.layerCount)
            {
                mActivationTime = 0;
                //UnityEngine.Profiling.Profiler.EndSample();
                return defaultCam;
            }

            // Get the current state
            int hash;
            if (m_AnimatedTarget.IsInTransition(m_LayerIndex))
            {
                // Force "current" state to be the state we're transitionaing to
                AnimatorStateInfo info = m_AnimatedTarget.GetNextAnimatorStateInfo(m_LayerIndex);
                hash = info.fullPathHash;
                if (m_AnimatedTarget.GetNextAnimatorClipInfoCount(m_LayerIndex) > 1)
                {
                    m_AnimatedTarget.GetNextAnimatorClipInfo(m_LayerIndex, m_clipInfoList);
                    hash = GetClipHash(info.fullPathHash, m_clipInfoList);
                }
            }
            else 
            {
                AnimatorStateInfo info = m_AnimatedTarget.GetCurrentAnimatorStateInfo(m_LayerIndex);
                hash = info.fullPathHash;
                if (m_AnimatedTarget.GetCurrentAnimatorClipInfoCount(m_LayerIndex) > 1)
                {
                    m_AnimatedTarget.GetCurrentAnimatorClipInfo(m_LayerIndex, m_clipInfoList);
                    hash = GetClipHash(info.fullPathHash, m_clipInfoList);
                }
            }

            // If we don't have an instruction for this state, find a suitable default
            while (hash != 0 && !mInstructionDictionary.ContainsKey(hash))
                hash = mStateParentLookup.ContainsKey(hash) ? mStateParentLookup[hash] : 0;

            float now = Time.time;
            if (mActivationTime != 0)
            {
                // Is it active now?
                if (mActiveInstruction.m_FullHash == hash)
                {
                    // Yes, cancel any pending
                    mPendingActivationTime = 0;
                    //UnityEngine.Profiling.Profiler.EndSample();
                    return mActiveInstruction.m_VirtualCamera;
                }

                // Is it pending?
                if (deltaTime >= 0)
                {
                    if (mPendingActivationTime != 0 && mPendingInstruction.m_FullHash == hash)
                    {
                        // Has it been pending long enough, and are we allowed to switch away
                        // from the active action?
                        if ((now - mPendingActivationTime) > mPendingInstruction.m_ActivateAfter
                            && ((now - mActivationTime) > mActiveInstruction.m_MinDuration
                                || mPendingInstruction.m_VirtualCamera.Priority
                                > mActiveInstruction.m_VirtualCamera.Priority))
                        {
                            // Yes, activate it now
                            mActiveInstruction = mPendingInstruction;
                            mActivationTime = now;
                            mPendingActivationTime = 0;
                        }
                        //UnityEngine.Profiling.Profiler.EndSample();
                        return mActiveInstruction.m_VirtualCamera;
                    }
                }
            }
            // Neither active nor pending.
            mPendingActivationTime = 0; // cancel the pending, if any

            if (!mInstructionDictionary.ContainsKey(hash))
            {
                // No defaults set, we just ignore this state
                if (mActivationTime != 0)
                    return mActiveInstruction.m_VirtualCamera;
                //UnityEngine.Profiling.Profiler.EndSample();
                return defaultCam;
            }

            // Can we activate it now?
            Instruction newInstr = m_Instructions[mInstructionDictionary[hash]];
            if (newInstr.m_VirtualCamera == null)
                newInstr.m_VirtualCamera = defaultCam;
            if (deltaTime >= 0 && mActivationTime > 0)
            {
                if (newInstr.m_ActivateAfter > 0
                    || ((now - mActivationTime) < mActiveInstruction.m_MinDuration
                        && newInstr.m_VirtualCamera.Priority
                        <= mActiveInstruction.m_VirtualCamera.Priority))
                {
                    // Too early - make it pending
                    mPendingInstruction = newInstr;
                    mPendingActivationTime = now;
                    if (mActivationTime != 0)
                        return mActiveInstruction.m_VirtualCamera;
                    //UnityEngine.Profiling.Profiler.EndSample();
                    return defaultCam;
                }
            }
            // Activate now
            mActiveInstruction = newInstr;
            mActivationTime = now;
            //UnityEngine.Profiling.Profiler.EndSample();
            return mActiveInstruction.m_VirtualCamera;
        }

        int GetClipHash(int hash, List<AnimatorClipInfo> clips)
        {
            // Is there an animation clip substate?
            if (clips.Count > 1)
            {
                // Find the strongest-weighted one
                int bestClip = -1;
                for (int i = 0; i < clips.Count; ++i)
                    if (bestClip < 0 || clips[i].weight > clips[bestClip].weight)
                        bestClip = i;

                // Use its hash
                if (bestClip >= 0 && clips[bestClip].weight > 0)
                    hash = Animator.StringToHash(CreateFakeHashName(hash, clips[bestClip].clip.name));
            }
            return hash;
        }
            
        private AnimationCurve LookupBlendCurve(
            ICinemachineCamera fromKey, ICinemachineCamera toKey, out float duration)
        {
            // Get the blend curve that's most appropriate for these cameras
            AnimationCurve blendCurve = m_DefaultBlend.BlendCurve;
            if (m_CustomBlends != null)
            {
                string fromCameraName = (fromKey != null) ? fromKey.Name : string.Empty;
                string toCameraName = (toKey != null) ? toKey.Name : string.Empty;
                blendCurve = m_CustomBlends.GetBlendCurveForVirtualCameras(
                        fromCameraName, toCameraName, blendCurve);
            }
            var keys = blendCurve.keys;
            duration = (keys == null || keys.Length == 0) ? 0 : keys[keys.Length-1].time;
            return blendCurve;
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
