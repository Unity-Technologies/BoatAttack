using System;
using UnityEngine;

namespace Cinemachine
{
    /// <summary>
    /// Describes a blend between 2 Cinemachine Virtual Cameras, and holds the
    /// current state of the blend.
    /// </summary>
    public class CinemachineBlend
    {
        /// <summary>First camera in the blend</summary>
        public ICinemachineCamera CamA { get; set; }

        /// <summary>Second camera in the blend</summary>
        public ICinemachineCamera CamB { get; set; }

        /// <summary>The curve that describes the way the blend transitions over time
        /// from the first camera to the second.  X-axis is time in seconds over which
        /// the blend takes place and Y axis is blend weight (0..1)</summary>
        public AnimationCurve BlendCurve { get; set; }

        /// <summary>The current time relative to the start of the blend</summary>
        public float TimeInBlend { get; set; }

        /// <summary>The current weight of the blend.  This is an evaluation of the
        /// BlendCurve at the current time relative to the start of the blend.
        /// 0 means camA, 1 means camB.</summary>
        public float BlendWeight
        { 
            get { return BlendCurve != null ? BlendCurve.Evaluate(TimeInBlend) : 0; } 
        }

        /// <summary>Validity test for the blend.  True if both cameras are defined.</summary>
        public bool IsValid
        {
            get { return (CamA != null || CamB != null); }
        }

        /// <summary>Duration in seconds of the blend.
        /// This is given read from the BlendCurve.</summary>
        public float Duration { get; set; }

        /// <summary>True if the time relative to the start of the blend is greater
        /// than or equal to the blend duration</summary>
        public bool IsComplete { get { return TimeInBlend >= Duration; } }

        /// <summary>Text description of the blend, for debugging</summary>
        public string Description
        {
            get
            {
                string fromName = (CamA != null) ? "[" + CamA.Name + "]": "(none)";
                string toName = (CamB != null) ? "[" + CamB.Name + "]" : "(none)";
                int percent = (int)(BlendWeight * 100f);
                return string.Format("{0} {1}% from {2}", toName, percent, fromName);
            }
        }

        /// <summary>Does the blend use a specific Cinemachine Virtual Camera?</summary>
        /// <param name="cam">The camera to test</param>
        /// <returns>True if the camera is involved in the blend</returns>
        public bool Uses(ICinemachineCamera cam)
        {
            if (cam == CamA || cam == CamB)
                return true;
            BlendSourceVirtualCamera b = CamA as BlendSourceVirtualCamera;
            if (b != null && b.Blend.Uses(cam))
                return true;
            b = CamB as BlendSourceVirtualCamera;
            if (b != null && b.Blend.Uses(cam))
                return true;
            return false;
        }

        /// <summary>Construct a blend</summary>
        /// <param name="a">First camera</param>
        /// <param name="b">Second camera</param>
        /// <param name="curve">Blend curve</param>
        /// <param name="t">Current time in blend, relative to the start of the blend</param>
        public CinemachineBlend(
            ICinemachineCamera a, ICinemachineCamera b, AnimationCurve curve, float duration, float t)
        {
            if (a == null || b == null)
                throw new ArgumentException("Blend cameras cannot be null");
            CamA = a;
            CamB = b;
            BlendCurve = curve;
            TimeInBlend = t;
            Duration = duration;
        }

        /// <summary>Make sure the source cameras get updated.</summary>
        /// <param name="worldUp">Default world up.  Individual vcams may modify this</param>
        /// <param name="deltaTime">Time increment used for calculating time-based behaviours (e.g. damping)</param>
        public void UpdateCameraState(Vector3 worldUp, float deltaTime)
        {
            // Make sure both cameras have been updated (they are not necessarily
            // enabled, and only enabled cameras get updated automatically
            // every frame)
            CinemachineCore.Instance.UpdateVirtualCamera(CamA, worldUp, deltaTime);
            CinemachineCore.Instance.UpdateVirtualCamera(CamB, worldUp, deltaTime);
        }

        /// <summary>Compute the blended CameraState for the current time in the blend.</summary>
        public CameraState State { get { return CameraState.Lerp(CamA.State, CamB.State, BlendWeight); } }
    }

    /// <summary>Definition of a Camera blend.  This struct holds the information
    /// necessary to generate a suitable AnimationCurve for a Cinemachine Blend.</summary>
    [Serializable]
    [DocumentationSorting(10.2f, DocumentationSortingAttribute.Level.UserRef)]
    public struct CinemachineBlendDefinition
    {
        /// <summary>Supported predefined shapes for the blend curve.</summary>
        [DocumentationSorting(10.21f, DocumentationSortingAttribute.Level.UserRef)]
        public enum Style
        {
            /// <summary>Zero-length blend</summary>
            Cut,
            /// <summary>S-shaped curve, giving a gentle and smooth transition</summary>
            EaseInOut,
            /// <summary>Linear out of the outgoing shot, and easy into the incoming</summary>
            EaseIn,
            /// <summary>Easy out of the outgoing shot, and linear into the incoming</summary>
            EaseOut,
            /// <summary>Easy out of the outgoing, and hard into the incoming</summary>
            HardIn,
            /// <summary>Hard out of the outgoing, and easy into the incoming</summary>
            HardOut,
            /// <summary>Linear blend.  Mechanical-looking.</summary>
            Linear
        };

        /// <summary>The shape of the blend curve.</summary>
        [Tooltip("Shape of the blend curve")]
        public Style m_Style;

        /// <summary>The duration (in seconds) of the blend</summary>
        [Tooltip("Duration of the blend, in seconds")]
        public float m_Time;

        /// <summary>Constructor</summary>
        /// <param name="style">The shape of the blend curve.</param>
        /// <param name="time">The duration (in seconds) of the blend</param>
        public CinemachineBlendDefinition(Style style, float time)
        {
            m_Style = style;
            m_Time = time;
        }

        /// <summary>
        /// An AnimationCurve specifying the interpolation duration and value
        /// for this camera blend. The time of the last key frame is assumed to the be the
        /// duration of the blend. Y-axis values must be in range [0,1] (internally clamped
        /// within Blender) and time must be in range of [0, +infinity)
        /// </summary>
        public AnimationCurve BlendCurve
        {
            get
            {
                float time = Mathf.Max(0, m_Time);
                switch (m_Style)
                {
                    default:
                    case Style.Cut: return new AnimationCurve();
                    case Style.EaseInOut: return AnimationCurve.EaseInOut(0f, 0f, time, 1f);
                    case Style.EaseIn:
                    {
                        AnimationCurve curve = AnimationCurve.Linear(0f, 0f, time, 1f);
                        Keyframe[] keys = curve.keys;
                        keys[1].inTangent = 0;
                        curve.keys = keys;
                        return curve;
                    }
                    case Style.EaseOut:
                    {
                        AnimationCurve curve = AnimationCurve.Linear(0f, 0f, time, 1f);
                        Keyframe[] keys = curve.keys;
                        keys[0].outTangent = 0;
                        curve.keys = keys;
                        return curve;
                    }
                    case Style.HardIn:
                    {
                        AnimationCurve curve = AnimationCurve.Linear(0f, 0f, time, 1f);
                        Keyframe[] keys = curve.keys;
                        keys[0].outTangent = 0;
                        keys[1].inTangent = 1.5708f; // pi/2 = up
                        curve.keys = keys;
                        return curve;
                    }
                    case Style.HardOut:
                    {
                        AnimationCurve curve = AnimationCurve.Linear(0f, 0f, time, 1f);
                        Keyframe[] keys = curve.keys;
                        keys[0].outTangent = 1.5708f; // pi/2 = up
                        keys[1].inTangent = 0;
                        curve.keys = keys;
                        return curve;
                    }
                    case Style.Linear: return AnimationCurve.Linear(0f, 0f, time, 1f);
                }
            }
        }
    }
}
