using UnityEngine;
using System;
using Cinemachine.Utility;
using UnityEngine.Serialization;

namespace Cinemachine
{
    /// <summary>
    /// Axis state for defining to react to player input.  
    /// The settings here control the responsiveness of the axis to player input.
    /// </summary>
    [DocumentationSorting(6.4f, DocumentationSortingAttribute.Level.UserRef)]
    [Serializable]
    public struct AxisState
    {
        /// <summary>The current value of the axis</summary>
        [NoSaveDuringPlay]
        [Tooltip("The current value of the axis.")]
        public float Value;

        /// <summary>How fast the axis value can travel.  Increasing this number
        /// makes the behaviour more responsive to joystick input</summary>
        [Tooltip("The maximum speed of this axis in units/second")]
        public float m_MaxSpeed;

        /// <summary>The amount of time in seconds it takes to accelerate to
        /// MaxSpeed with the supplied Axis at its maximum value</summary>
        [Tooltip("The amount of time in seconds it takes to accelerate to MaxSpeed with the supplied Axis at its maximum value")]
        public float m_AccelTime;

        /// <summary>The amount of time in seconds it takes to decelerate
        /// the axis to zero if the supplied axis is in a neutral position</summary>
        [Tooltip("The amount of time in seconds it takes to decelerate the axis to zero if the supplied axis is in a neutral position")]
        public float m_DecelTime;

        /// <summary>The name of this axis as specified in Unity Input manager.
        /// Setting to an empty string will disable the automatic updating of this axis</summary>
        [FormerlySerializedAs("m_AxisName")]
        [Tooltip("The name of this axis as specified in Unity Input manager. Setting to an empty string will disable the automatic updating of this axis")]
        public string m_InputAxisName;

        /// <summary>The value of the input axis.  A value of 0 means no input
        /// You can drive this directly from a
        /// custom input system, or you can set the Axis Name and have the value
        /// driven by the internal Input Manager</summary>
        [NoSaveDuringPlay]
        [Tooltip("The value of the input axis.  A value of 0 means no input.  You can drive this directly from a custom input system, or you can set the Axis Name and have the value driven by the internal Input Manager")]
        public float m_InputAxisValue;

        /// <summary>If checked, then the raw value of the input axis will be inverted 
        /// before it is used.</summary>
        [NoSaveDuringPlay]
        [Tooltip("If checked, then the raw value of the input axis will be inverted before it is used")]
        public bool m_InvertAxis;

        private float mCurrentSpeed;
        private float mMinValue;
        private float mMaxValue;
        private bool mWrapAround;

        /// <summary>Constructor with specific values</summary>
        public AxisState(
            float maxSpeed, float accelTime, float decelTime, float val, string name, bool invert)
        {
            m_MaxSpeed = maxSpeed;
            m_AccelTime = accelTime;
            m_DecelTime = decelTime;
            Value = val;
            m_InputAxisName = name;
            m_InputAxisValue = 0;
            m_InvertAxis = invert;

            mCurrentSpeed = 0f;
            mMinValue = 0f;
            mMaxValue = 0f;
            mWrapAround = false;
        }

        /// <summary>Call from OnValidate: Make sure the fields are sensible</summary>
        public void Validate()
        {
            m_MaxSpeed = Mathf.Max(0, m_MaxSpeed);
            m_AccelTime = Mathf.Max(0, m_AccelTime);
            m_DecelTime = Mathf.Max(0, m_DecelTime);
        }

        /// <summary>
        /// Sets the constraints by which this axis will operate on
        /// </summary>
        /// <param name="minValue">The lowest value this axis can achieve</param>
        /// <param name="maxValue">The highest value this axis can achieve</param>
        /// <param name="wrapAround">If <b>true</b>, values commanded greater
        /// than mMaxValue or less than mMinValue will wrap around.
        /// If <b>false</b>, the value will be clamped within the range.</param>
        public void SetThresholds(float minValue, float maxValue, bool wrapAround)
        {
            mMinValue = minValue;
            mMaxValue = maxValue;
            mWrapAround = wrapAround;
        }

        const float Epsilon = UnityVectorExtensions.Epsilon;

        /// <summary>
        /// Updates the state of this axis based on the axis defined
        /// by AxisState.m_AxisName
        /// </summary>
        /// <param name="deltaTime">Delta time in seconds</param>
        /// <returns>Returns <b>true</b> if this axis' input was non-zero this Update,
        /// <b>flase</b> otherwise</returns>
        public bool Update(float deltaTime)
        {
            if (!string.IsNullOrEmpty(m_InputAxisName))
            {
                try
                {
                    m_InputAxisValue = CinemachineCore.GetInputAxis(m_InputAxisName);
                }
                catch (ArgumentException e)
                {
                    Debug.LogError(e.ToString());
                }
            }

            float input = m_InputAxisValue;
            if (m_InvertAxis)
                input *= -1f;

            if (m_MaxSpeed > Epsilon)
            {
                float targetSpeed = input * m_MaxSpeed;
                if (Mathf.Abs(targetSpeed) < Epsilon
                    || (Mathf.Sign(mCurrentSpeed) == Mathf.Sign(targetSpeed)
                        && Mathf.Abs(targetSpeed) <  Mathf.Abs(mCurrentSpeed)))
                {
                    // Need to decelerate
                    float a = Mathf.Abs(targetSpeed - mCurrentSpeed) / Mathf.Max(Epsilon, m_DecelTime);
                    float delta = Mathf.Min(a * deltaTime, Mathf.Abs(mCurrentSpeed));
                    mCurrentSpeed -= Mathf.Sign(mCurrentSpeed) * delta;
                }
                else 
                {
                    // Accelerate to the target speed
                    float a = Mathf.Abs(targetSpeed - mCurrentSpeed) / Mathf.Max(Epsilon, m_AccelTime);
                    mCurrentSpeed += Mathf.Sign(targetSpeed) * a * deltaTime;
                    if (Mathf.Sign(mCurrentSpeed) == Mathf.Sign(targetSpeed) 
                        && Mathf.Abs(mCurrentSpeed) > Mathf.Abs(targetSpeed))
                    {
                        mCurrentSpeed = targetSpeed;
                    }
                }
            }

            // Clamp our max speeds so we don't go crazy
            float maxSpeed = GetMaxSpeed();
            mCurrentSpeed = Mathf.Clamp(mCurrentSpeed, -maxSpeed, maxSpeed);

            Value += mCurrentSpeed * deltaTime;
            bool isOutOfRange = (Value > mMaxValue) || (Value < mMinValue);
            if (isOutOfRange)
            {
                if (mWrapAround)
                {
                    if (Value > mMaxValue)
                        Value = mMinValue + (Value - mMaxValue);
                    else
                        Value = mMaxValue + (Value - mMinValue);
                }
                else
                {
                    Value = Mathf.Clamp(Value, mMinValue, mMaxValue);
                    mCurrentSpeed = 0f;
                }
            }
            return Mathf.Abs(input) > Epsilon;
        }

        // MaxSpeed may be limited as we approach the range ends, in order
        // to prevent a hard bump
        private float GetMaxSpeed()
        {
            float range = mMaxValue - mMinValue;
            if (!mWrapAround && range > 0)
            {
                float threshold = range / 10f;
                if (mCurrentSpeed > 0 && (mMaxValue - Value) < threshold)
                {
                    float t = (mMaxValue - Value) / threshold;
                    return Mathf.Lerp(0, m_MaxSpeed, t);
                }
                else if (mCurrentSpeed < 0 && (Value - mMinValue) < threshold)
                {
                    float t = (Value - mMinValue) / threshold;
                    return Mathf.Lerp(0, m_MaxSpeed, t);
                }
            }
            return m_MaxSpeed;
        }
    }
}
