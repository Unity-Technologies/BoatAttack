using System;
using UnityEngine;
using Cinemachine.Utility;
using UnityEngine.Serialization;

namespace Cinemachine
{
    /// <summary>
    /// This is a CinemachineComponent in the the Body section of the component pipeline. 
    /// Its job is to position the camera in a variable relationship to a the vcam's 
    /// Follow target object, with offsets and damping.
    /// 
    /// This component is typically used to implement a camera that follows its target.
    /// It can accept player input from an input device, which allows the player to 
    /// dynamically control the relationship between the camera and the target, 
    /// for example with a joystick.
    /// 
    /// The OrbitalTransposer introduces the concept of __Heading__, which is the direction
    /// in which the target is moving, and the OrbitalTransposer will attempt to position 
    /// the camera in relationship to the heading, which is by default directly behind the target.
    /// You can control the default relationship by adjusting the Heading Bias setting.
    /// 
    /// If you attach an input controller to the OrbitalTransposer, then the player can also
    /// control the way the camera positions itself in relation to the target heading.  This allows
    /// the camera to move to any spot on an orbit around the target.
    /// </summary>
    [DocumentationSorting(6, DocumentationSortingAttribute.Level.UserRef)]
    [AddComponentMenu("")] // Don't display in add component menu
    [RequireComponent(typeof(CinemachinePipeline))]
    [SaveDuringPlay]
    public class CinemachineOrbitalTransposer : CinemachineTransposer
    {
        /// <summary>
        /// How the "forward" direction is defined.  Orbital offset is in relation to the forward
        /// direction.
        /// </summary>
        [DocumentationSorting(6.2f, DocumentationSortingAttribute.Level.UserRef)]
        [Serializable]
        public struct Heading
        {
            /// <summary>
            /// Sets the algorithm for determining the target's heading for purposes
            /// of re-centering the camera
            /// </summary>
            [DocumentationSorting(6.21f, DocumentationSortingAttribute.Level.UserRef)]
            public enum HeadingDefinition
            {
                /// <summary>
                /// Target heading calculated from the difference between its position on
                /// the last update and current frame.
                /// </summary>
                PositionDelta,
                /// <summary>
                /// Target heading calculated from its <b>Rigidbody</b>'s velocity.
                /// If no <b>Rigidbody</b> exists, it will fall back
                /// to HeadingDerivationMode.PositionDelta
                /// </summary>
                Velocity,
                /// <summary>
                /// Target heading calculated from the Target <b>Transform</b>'s euler Y angle
                /// </summary>
                TargetForward,
                /// <summary>
                /// Default heading is a constant world space heading.
                /// </summary>
                WorldForward,
            }
            /// <summary>The method by which the 'default heading' is calculated if
            /// recentering to target heading is enabled</summary>
            [Tooltip("How 'forward' is defined.  The camera will be placed by default behind the target.  PositionDelta will consider 'forward' to be the direction in which the target is moving.")]
            public HeadingDefinition m_HeadingDefinition;

            /// <summary>Size of the velocity sampling window for target heading filter.
            /// Used only if deriving heading from target's movement</summary>
            [Range(0, 10)]
            [Tooltip("Size of the velocity sampling window for target heading filter.  This filters out irregularities in the target's movement.  Used only if deriving heading from target's movement (PositionDelta or Velocity)")]
            public int m_VelocityFilterStrength;

            /// <summary>Additional Y rotation applied to the target heading.
            /// When this value is 0, the camera will be placed behind the target</summary>
            [Range(-180f, 180f)]
            [Tooltip("Where the camera is placed when the X-axis value is zero.  This is a rotation in degrees around the Y axis.  When this value is 0, the camera will be placed behind the target.  Nonzero offsets will rotate the zero position around the target.")]
            public float m_HeadingBias;

            /// <summary>Constructor</summary>
            public Heading(HeadingDefinition def, int filterStrength, float bias)
            {
                m_HeadingDefinition = def;
                m_VelocityFilterStrength = filterStrength;
                m_HeadingBias = bias;
            }
        };

        /// <summary>The definition of Forward.  Camera will follow behind.</summary>
        [Space]
        [Tooltip("The definition of Forward.  Camera will follow behind.")]
        public Heading m_Heading = new Heading(Heading.HeadingDefinition.TargetForward, 4, 0);

        /// <summary>Controls how automatic orbit recentering occurs</summary>
        [DocumentationSorting(6.5f, DocumentationSortingAttribute.Level.UserRef)]
        [Serializable]
        public struct Recentering
        {
            /// <summary>If checked, will enable automatic recentering of the
            /// camera based on the heading calculation mode. If FALSE, recenting is disabled.</summary>
            [Tooltip("If checked, will enable automatic recentering of the camera based on the heading definition. If unchecked, recenting is disabled.")]
            public bool m_enabled;

            /// <summary>If no input has been detected, the camera will wait
            /// this long in seconds before moving its heading to the default heading.</summary>
            [Tooltip("If no input has been detected, the camera will wait this long in seconds before moving its heading to the zero position.")]
            public float m_RecenterWaitTime;

            /// <summary>Maximum angular speed of recentering.  Will accelerate into and decelerate out of this</summary>
            [Tooltip("Maximum angular speed of recentering.  Will accelerate into and decelerate out of this.")]
            public float m_RecenteringTime;

            /// <summary>Constructor with specific field values</summary>
            public Recentering(bool enabled, float recenterWaitTime,  float recenteringSpeed)
            {
                m_enabled = enabled;
                m_RecenterWaitTime = recenterWaitTime;
                m_RecenteringTime = recenteringSpeed;
                m_LegacyHeadingDefinition = m_LegacyVelocityFilterStrength = -1;
            }

            /// <summary>Call this from OnValidate()</summary>
            public void Validate()
            {
                m_RecenterWaitTime = Mathf.Max(0, m_RecenterWaitTime);
                m_RecenteringTime = Mathf.Max(0, m_RecenteringTime);
            }

            // Legacy support
            [SerializeField] [HideInInspector] [FormerlySerializedAs("m_HeadingDefinition")] private int m_LegacyHeadingDefinition;
            [SerializeField] [HideInInspector] [FormerlySerializedAs("m_VelocityFilterStrength")] private int m_LegacyVelocityFilterStrength;
            internal bool LegacyUpgrade(ref Heading.HeadingDefinition heading, ref int velocityFilter)
            {
                if (m_LegacyHeadingDefinition != -1 && m_LegacyVelocityFilterStrength != -1)
                {
                    heading = (Heading.HeadingDefinition)m_LegacyHeadingDefinition;
                    velocityFilter = m_LegacyVelocityFilterStrength;
                    m_LegacyHeadingDefinition = m_LegacyVelocityFilterStrength = -1;
                    return true;
                }
                return false;
            }
        };

        /// <summary>Parameters that control Automating Heading Recentering</summary>
        [Tooltip("Automatic heading recentering.  The settings here defines how the camera will reposition itself in the absence of player input.")]
        public Recentering m_RecenterToTargetHeading = new Recentering(true, 1, 2);

        /// <summary>Axis representing the current heading.  Value is in degrees
        /// and represents a rotation about the up vector</summary>
        [Tooltip("Heading Control.  The settings here control the behaviour of the camera in response to the player's input.")]
        public AxisState m_XAxis = new AxisState(300f, 2f, 1f, 0f, "Mouse X", true);

        // Legacy support
        [SerializeField] [HideInInspector] [FormerlySerializedAs("m_Radius")] private float m_LegacyRadius = float.MaxValue;
        [SerializeField] [HideInInspector] [FormerlySerializedAs("m_HeightOffset")] private float m_LegacyHeightOffset = float.MaxValue;
        [SerializeField] [HideInInspector] [FormerlySerializedAs("m_HeadingBias")] private float m_LegacyHeadingBias = float.MaxValue;
        protected override void OnValidate()
        {
            // Upgrade after a legacy deserialize
            if (m_LegacyRadius != float.MaxValue 
                && m_LegacyHeightOffset != float.MaxValue
                && m_LegacyHeadingBias != float.MaxValue)
            {
                m_FollowOffset = new Vector3(0, m_LegacyHeightOffset, -m_LegacyRadius);
                m_LegacyHeightOffset = m_LegacyRadius = float.MaxValue;

                m_Heading.m_HeadingBias = m_LegacyHeadingBias;
                m_XAxis.m_MaxSpeed /= 10;
                m_XAxis.m_AccelTime /= 10;
                m_XAxis.m_DecelTime /= 10;
                m_LegacyHeadingBias = float.MaxValue;
                m_RecenterToTargetHeading.LegacyUpgrade(
                    ref m_Heading.m_HeadingDefinition, ref m_Heading.m_VelocityFilterStrength);
            }
            m_XAxis.Validate();
            m_RecenterToTargetHeading.Validate();

            base.OnValidate();
        }

        /// <summary>
        /// Drive the x-axis setting programmatically.
        /// Automatic heading updating will be disabled.
        /// </summary>
        [HideInInspector, NoSaveDuringPlay]
        public bool m_HeadingIsSlave = false;

        /// <summary>
        /// Delegate that allows the the m_XAxis object to be replaced with another one.
        /// </summary>
        internal delegate float UpdateHeadingDelegate(
            CinemachineOrbitalTransposer orbital, float deltaTime, Vector3 up);

        /// <summary>
        /// Delegate that allows the the XAxis object to be replaced with another one.
        /// To use it, just call orbital.UpdateHeading() with a reference to a 
        /// private AxisState object, and that AxisState object will be updated and
        /// used to calculate the heading.
        /// </summary>
        internal UpdateHeadingDelegate HeadingUpdater 
            = (CinemachineOrbitalTransposer orbital, float deltaTime, Vector3 up) 
                => { return orbital.UpdateHeading(deltaTime, up, ref orbital.m_XAxis); };

        /// <summary>
        /// Update the X axis and calculate the heading.  This can be called by a delegate
        /// with a custom axis.
        /// <param name="deltaTime">Used for damping.  If less than 0, no damping is done.</param>
        /// <param name="up">World Up, set by the CinemachineBrain</param>
        /// <param name="axis"></param>
        /// <returns>Axis value</returns>
        /// </summary>
        public float UpdateHeading(float deltaTime, Vector3 up, ref AxisState axis)
        {
            // Only read joystick when game is playing
            if (deltaTime >= 0 || CinemachineCore.Instance.IsLive(VirtualCamera))
            {
                bool xAxisInput = false;
                xAxisInput |= axis.Update(deltaTime);
                if (xAxisInput)
                {
                    mLastHeadingAxisInputTime = Time.time;
                    mHeadingRecenteringVelocity = 0;
                }
            }
            float targetHeading = GetTargetHeading(axis.Value, GetReferenceOrientation(up), deltaTime);
            if (deltaTime < 0)
            {
                mHeadingRecenteringVelocity = 0;
                if (m_RecenterToTargetHeading.m_enabled)
                    axis.Value = targetHeading;
            }
            else
            {
                // Recentering
                if (m_BindingMode != BindingMode.SimpleFollowWithWorldUp
                    && m_RecenterToTargetHeading.m_enabled
                    && (Time.time > (mLastHeadingAxisInputTime + m_RecenterToTargetHeading.m_RecenterWaitTime)))
                {
                    // Scale value determined heuristically, to account for accel/decel
                    float recenterTime = m_RecenterToTargetHeading.m_RecenteringTime / 3f;
                    if (recenterTime <= deltaTime)
                        axis.Value = targetHeading;
                    else
                    {
                        float headingError = Mathf.DeltaAngle(axis.Value, targetHeading);
                        float absHeadingError = Mathf.Abs(headingError);
                        if (absHeadingError < UnityVectorExtensions.Epsilon)
                        {
                            axis.Value = targetHeading;
                            mHeadingRecenteringVelocity = 0;
                        }
                        else 
                        {
                            float scale = deltaTime / recenterTime;
                            float desiredVelocity = Mathf.Sign(headingError)
                                * Mathf.Min(absHeadingError, absHeadingError * scale);
                            // Accelerate to the desired velocity
                            float accel = desiredVelocity - mHeadingRecenteringVelocity;
                            if ((desiredVelocity < 0 && accel < 0) || (desiredVelocity > 0 && accel > 0))
                                desiredVelocity = mHeadingRecenteringVelocity + desiredVelocity * scale;
                            axis.Value += desiredVelocity;
                            mHeadingRecenteringVelocity = desiredVelocity;
                        }
                    }
                }
            }
            float finalHeading = axis.Value;
            if (m_BindingMode == BindingMode.SimpleFollowWithWorldUp)
                axis.Value = 0;
            return finalHeading;
        }

        private void OnEnable()
        {
            m_XAxis.SetThresholds(0f, 360f, true);
            PreviousTarget = null;
            mLastTargetPosition = Vector3.zero;
        }

        private float mLastHeadingAxisInputTime = 0f;
        private float mHeadingRecenteringVelocity = 0f;
        private Vector3 mLastTargetPosition = Vector3.zero;
        private HeadingTracker mHeadingTracker;
        private Rigidbody mTargetRigidBody = null;
        private Transform PreviousTarget { get; set; }
        private Quaternion mHeadingPrevFrame = Quaternion.identity;
        private Vector3 mOffsetPrevFrame = Vector3.zero;

        /// <summary>Positions the virtual camera according to the transposer rules.</summary>
        /// <param name="curState">The current camera state</param>
        /// <param name="deltaTime">Used for damping.  If less than 0, no damping is done.</param>
        public override void MutateCameraState(ref CameraState curState, float deltaTime)
        {
            //UnityEngine.Profiling.Profiler.BeginSample("CinemachineOrbitalTransposer.MutateCameraState");
            InitPrevFrameStateInfo(ref curState, deltaTime);

            // Update the heading
            if (FollowTarget != PreviousTarget)
            {
                PreviousTarget = FollowTarget;
                mTargetRigidBody = (PreviousTarget == null) ? null : PreviousTarget.GetComponent<Rigidbody>();
                mLastTargetPosition = (PreviousTarget == null) ? Vector3.zero : PreviousTarget.position;
                mHeadingTracker = null;
            }
            float heading = HeadingUpdater(this, deltaTime, curState.ReferenceUp);

            if (IsValid)
            {
                mLastTargetPosition = FollowTarget.position;

                // Calculate the heading
                if (m_BindingMode != BindingMode.SimpleFollowWithWorldUp)
                    heading += m_Heading.m_HeadingBias;
                Quaternion headingRot = Quaternion.AngleAxis(heading, curState.ReferenceUp);

                // Track the target, with damping
                Vector3 offset = EffectiveOffset;
                Vector3 pos;
                Quaternion orient;
                TrackTarget(deltaTime, curState.ReferenceUp, headingRot * offset, out pos, out orient);

                // Place the camera
                curState.ReferenceUp = orient * Vector3.up;
                if (deltaTime >= 0)
                {
                    Vector3 bypass = (headingRot * offset) - mHeadingPrevFrame * mOffsetPrevFrame;
                    bypass = orient * bypass;
                    curState.PositionDampingBypass = bypass;
                }
                orient = orient * headingRot;
                curState.RawPosition = pos + orient * offset;

                mHeadingPrevFrame = (m_BindingMode == BindingMode.SimpleFollowWithWorldUp) ? Quaternion.identity : headingRot;
                mOffsetPrevFrame = offset;
            }
            //UnityEngine.Profiling.Profiler.EndSample();
        }

        /// <summary>API for the editor, to process a position drag from the user.
        /// This implementation adds the delta to the follow offset, after zeroing out local x.</summary>
        /// <param name="delta">The amount dragged this frame</param>
        public override void OnPositionDragged(Vector3 delta)
        {
            Quaternion targetOrientation = GetReferenceOrientation(VcamState.ReferenceUp);
            Vector3 localOffset = Quaternion.Inverse(targetOrientation) * delta;
            localOffset.x = 0;
            m_FollowOffset += localOffset;
            m_FollowOffset = EffectiveOffset;
        }
        
        static string GetFullName(GameObject current)
        {
            if (current == null)
                return "";
            if (current.transform.parent == null)
                return "/" + current.name;
            return GetFullName(current.transform.parent.gameObject) + "/" + current.name;
        }

        // Make sure this is calld only once per frame
        private float GetTargetHeading(
            float currentHeading, Quaternion targetOrientation, float deltaTime)
        {
            if (m_BindingMode == BindingMode.SimpleFollowWithWorldUp)
                return 0;
            if (FollowTarget == null)
                return currentHeading;

            if (m_Heading.m_HeadingDefinition == Heading.HeadingDefinition.Velocity
                && mTargetRigidBody == null)
            {
                Debug.Log(string.Format(
                        "Attempted to use HeadingDerivationMode.Velocity to calculate heading for {0}. No RigidBody was present on '{1}'. Defaulting to position delta",
                        GetFullName(VirtualCamera.VirtualCameraGameObject), FollowTarget));
                m_Heading.m_HeadingDefinition = Heading.HeadingDefinition.PositionDelta;
            }

            Vector3 velocity = Vector3.zero;
            switch (m_Heading.m_HeadingDefinition)
            {
                case Heading.HeadingDefinition.PositionDelta:
                    velocity = FollowTarget.position - mLastTargetPosition;
                    break;
                case Heading.HeadingDefinition.Velocity:
                    velocity = mTargetRigidBody.velocity;
                    break;
                case Heading.HeadingDefinition.TargetForward:
                    velocity = FollowTarget.forward;
                    break;
                default:
                case Heading.HeadingDefinition.WorldForward:
                    return 0;
            }

            // Process the velocity and derive the heading from it.
            int filterSize = m_Heading.m_VelocityFilterStrength * 5;
            if (mHeadingTracker == null || mHeadingTracker.FilterSize != filterSize)
                mHeadingTracker = new HeadingTracker(filterSize);
            mHeadingTracker.DecayHistory();
            Vector3 up = targetOrientation * Vector3.up;
            velocity = velocity.ProjectOntoPlane(up);
            if (!velocity.AlmostZero())
                mHeadingTracker.Add(velocity);

            velocity = mHeadingTracker.GetReliableHeading();
            if (!velocity.AlmostZero())
                return UnityVectorExtensions.SignedAngle(targetOrientation * Vector3.forward, velocity, up);

            // If no reliable heading, then stay where we are.
            return currentHeading;
        }

        class HeadingTracker
        {
            struct Item
            {
                public Vector3 velocity;
                public float weight;
                public float time;
            };
            Item[] mHistory;
            int mTop;
            int mBottom;
            int mCount;

            Vector3 mHeadingSum;
            float mWeightSum = 0;
            float mWeightTime = 0;

            Vector3 mLastGoodHeading = Vector3.zero;

            public HeadingTracker(int filterSize)
            {
                mHistory = new Item[filterSize];
                float historyHalfLife = filterSize / 5f; // somewhat arbitrarily
                mDecayExponent = -Mathf.Log(2f) / historyHalfLife;
                ClearHistory();
            }

            public int FilterSize { get { return mHistory.Length; } }

            void ClearHistory()
            {
                mTop = mBottom = mCount = 0;
                mWeightSum = 0;
                mHeadingSum = Vector3.zero;
            }

            static float mDecayExponent;
            static float Decay(float time) { return Mathf.Exp(time * mDecayExponent); }

            public void Add(Vector3 velocity)
            {
                if (FilterSize == 0)
                {
                    mLastGoodHeading = velocity;
                    return;
                }
                float weight = velocity.magnitude;
                if (weight > UnityVectorExtensions.Epsilon)
                {
                    Item item = new Item();
                    item.velocity = velocity;
                    item.weight = weight;
                    item.time = Time.time;
                    if (mCount == FilterSize)
                        PopBottom();
                    ++mCount;
                    mHistory[mTop] = item;
                    if (++mTop == FilterSize)
                        mTop = 0;

                    mWeightSum *= Decay(item.time - mWeightTime);
                    mWeightTime = item.time;
                    mWeightSum += weight;
                    mHeadingSum += item.velocity;
                }
            }

            void PopBottom()
            {
                if (mCount > 0)
                {
                    float time = Time.time;
                    Item item = mHistory[mBottom];
                    if (++mBottom == FilterSize)
                        mBottom = 0;
                    --mCount;

                    float decay = Decay(time - item.time);
                    mWeightSum -= item.weight * decay;
                    mHeadingSum -= item.velocity * decay;
                    if (mWeightSum <= UnityVectorExtensions.Epsilon || mCount == 0)
                        ClearHistory();
                }
            }

            public void DecayHistory()
            {
                float time = Time.time;
                float decay = Decay(time - mWeightTime);
                mWeightSum *= decay;
                mWeightTime = time;
                if (mWeightSum < UnityVectorExtensions.Epsilon)
                    ClearHistory();
                else
                    mHeadingSum = mHeadingSum * decay;
            }

            public Vector3 GetReliableHeading()
            {
                // Update Last Good Heading
                if (mWeightSum > UnityVectorExtensions.Epsilon
                    && (mCount == mHistory.Length || mLastGoodHeading.AlmostZero()))
                {
                    Vector3  h = mHeadingSum / mWeightSum;
                    if (!h.AlmostZero())
                        mLastGoodHeading = h.normalized;
                }
                return mLastGoodHeading;
            }
        }
    }
}
