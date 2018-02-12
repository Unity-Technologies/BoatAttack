using UnityEngine;
using Cinemachine.Utility;
using System.Collections.Generic;

namespace Cinemachine
{
    /// <summary>
    /// The output of the Cinemachine engine for a specific virtual camera.  The information
    /// in this struct can be blended, and provides what is needed to calculate an
    /// appropriate camera position, orientation, and lens setting.
    /// 
    /// Raw values are what the Cinemachine behaviours generate.  The correction channel
    /// holds perturbations to the raw values - e.g. noise or smoothing, or obstacle
    /// avoidance corrections.  Coirrections are not considered when making time-based
    /// calculations such as damping.
    /// 
    /// The Final position and orientation is the comination of the raw values and
    /// their corrections.
    /// </summary>
    public struct CameraState
    {
        /// <summary>
        /// Camera Lens Settings.
        /// </summary>
        public LensSettings Lens { get; set; }

        /// <summary>
        /// Which way is up.  World space unit vector.
        /// </summary>
        public Vector3 ReferenceUp { get; set; }

        /// <summary>
        /// The world space focus point of the camera.  What the camera wants to look at.
        /// There is a special constant define to represent "nothing".  Be careful to 
        /// check for that (or check the HasLookAt property).
        /// </summary>
        public Vector3 ReferenceLookAt { get; set; }

        /// <summary>
        /// Returns true if this state has a valid ReferenceLookAt value.
        /// </summary>
        public bool HasLookAt { get { return ReferenceLookAt == ReferenceLookAt; } } // will be false if NaN

        /// <summary>
        /// This constant represents "no point in space" or "no direction".
        /// </summary>
        public static Vector3 kNoPoint = new Vector3(float.NaN, float.NaN, float.NaN);

        /// <summary>
        /// Raw (un-corrected) world space position of this camera
        /// </summary>
        public Vector3 RawPosition { get; set; }

        /// <summary>
        /// Raw (un-corrected) world space orientation of this camera
        /// </summary>
        public Quaternion RawOrientation { get; set; }

        /// <summary>This is a way for the Body component to bypass aim damping,
        /// useful for when the body need to rotate its point of view, but does not
        /// want interference from the aim damping</summary>
        internal Vector3 PositionDampingBypass { get; set; }

        /// <summary>
        /// Subjective estimation of how "good" the shot is.
        /// Larger values mean better quality.  Default is 1.
        /// </summary>
        public float ShotQuality { get; set; }

        /// <summary>
        /// Position correction.  This will be added to the raw position.
        /// This value doesn't get fed back into the system when calculating the next frame.
        /// Can be noise, or smoothing, or both, or something else.
        /// </summary>
        public Vector3 PositionCorrection { get; set; }

        /// <summary>
        /// Orientation correction.  This will be added to the raw orientation.
        /// This value doesn't get fed back into the system when calculating the next frame.
        /// Can be noise, or smoothing, or both, or something else.
        /// </summary>
        public Quaternion OrientationCorrection { get; set; }

        /// <summary>
        /// Position with correction applied.
        /// </summary>
        public Vector3 CorrectedPosition { get { return RawPosition + PositionCorrection; } }

        /// <summary>
        /// Orientation with correction applied.
        /// </summary>
        public Quaternion CorrectedOrientation { get { return RawOrientation * OrientationCorrection; } }

        /// <summary>
        /// Position with correction applied.  This is what the final camera gets.
        /// </summary>
        public Vector3 FinalPosition { get { return RawPosition + PositionCorrection; } }

        /// <summary>
        /// Orientation with correction and dutch applied.  This is what the final camera gets.
        /// </summary>
        public Quaternion FinalOrientation
        {
            get
            {
                if (Mathf.Abs(Lens.Dutch) > UnityVectorExtensions.Epsilon)
                    return CorrectedOrientation * Quaternion.AngleAxis(Lens.Dutch, Vector3.forward);
                return CorrectedOrientation;
            }
        }

        /// <summary>
        /// State with default values
        /// </summary>
        public static CameraState Default
        {
            get
            {
                CameraState state = new CameraState();
                state.Lens = LensSettings.Default;
                state.ReferenceUp = Vector3.up;
                state.ReferenceLookAt = kNoPoint;
                state.RawPosition = Vector3.zero;
                state.RawOrientation = Quaternion.identity;
                state.ShotQuality = 1;
                state.PositionCorrection = Vector3.zero;
                state.OrientationCorrection = Quaternion.identity;
                state.PositionDampingBypass = Vector3.zero;
                return state;
            }
        }

        /// <summary>Opaque structure represent extra blendable stuff and its weight.
        /// The base system ignores this data - it is intended for extension modules</summary>
        public struct CustomBlendable 
        { 
            /// <summary>The custom stuff that the extention module will consider</summary>
            public Object m_Custom; 
            /// <summary>The weight of the custom stuff.  Must be 0...1</summary>
            public float m_Weight; 

            /// <summary>Constructor with specific values</summary>
            /// <param name="custom">The custom stuff that the extention module will consider</param>
            /// <param name="weight">The weight of the custom stuff.  Must be 0...1</param>
            public CustomBlendable(Object custom, float weight) 
                { m_Custom = custom; m_Weight = weight; }
        };

        // This is to avoid excessive GC allocs
        CustomBlendable mCustom0;
        CustomBlendable mCustom1;
        CustomBlendable mCustom2;
        CustomBlendable mCustom3;
        List<CustomBlendable> m_CustomOverflow;

        /// <summary>The number of custom blendables that will be applied to the camera.  
        /// The base system manages but otherwise ignores this data - it is intended for 
        /// extension modules</summary>
        public int NumCustomBlendables { get; private set; }

        /// <summary>Get a custom blendable that will be applied to the camera.  
        /// The base system manages but otherwise ignores this data - it is intended for 
        /// extension modules</summary>
        /// <param name="index">Which one to get.  Must be in range [0...NumCustomBlendables)</param>
        /// <returns>The custom blendable at the specified index.</returns>
        public CustomBlendable GetCustomBlendable(int index)
        {
            switch (index)
            {
                case 0: return mCustom0;
                case 1: return mCustom1;
                case 2: return mCustom2;
                case 3: return mCustom3;
                default: 
                {
                    index -= 4;
                    if (m_CustomOverflow != null && index < m_CustomOverflow.Count)
                        return m_CustomOverflow[index];
                    return new CustomBlendable(null, 0);
                }
            }
        }

        int FindCustomBlendable(Object custom)
        {
            if (mCustom0.m_Custom == custom)
                return 0;
            if (mCustom1.m_Custom == custom)
                return 1;
            if (mCustom2.m_Custom == custom)
                return 2;
            if (mCustom3.m_Custom == custom)
                return 3;
            if (m_CustomOverflow != null)
            {
                for (int i = 0; i < m_CustomOverflow.Count; ++i)
                    if (m_CustomOverflow[i].m_Custom == custom)
                        return i + 4;
            }
            return -1;
        }

        /// <summary>Add a custom blendable to the pot for eventual application to the camera.
        /// The base system manages but otherwise ignores this data - it is intended for 
        /// extension modules</summary>
        /// <param name="b">The custom blendable to add.  If b.m_Custom is the same as an 
        /// already-added custom blendable, then they will be merged and the weights combined.</param>
        public void AddCustomBlendable(CustomBlendable b)
        {
            // Attempt to merge common blendables to avoid growth
            int index = FindCustomBlendable(b.m_Custom);
            if (index >= 0)
                b.m_Weight += GetCustomBlendable(index).m_Weight;
            else
            {
                index = NumCustomBlendables;
                NumCustomBlendables = index + 1;
            }
            switch (index)
            {
                case 0: mCustom0 = b; break;
                case 1: mCustom1 = b; break;
                case 2: mCustom2 = b; break;
                case 3: mCustom3 = b; break;
                default: 
                {
                    if (m_CustomOverflow == null)
                        m_CustomOverflow = new List<CustomBlendable>();
                    m_CustomOverflow.Add(b);
                    break;
                }
            }
         }

        /// <summary>Intelligently blend the contents of two states.</summary>
        /// <param name="stateA">The first state, corresponding to t=0</param>
        /// <param name="stateB">The second state, corresponding to t=1</param>
        /// <param name="t">How much to interpolate.  Internally clamped to 0..1</param>
        /// <returns>Linearly interpolated CameraState</returns>
        public static CameraState Lerp(CameraState stateA, CameraState stateB, float t)
        {
            t = Mathf.Clamp01(t);
            float adjustedT = t;

            CameraState state = new CameraState();
            state.Lens = LensSettings.Lerp(stateA.Lens, stateB.Lens, t);
            state.ReferenceUp = Vector3.Slerp(stateA.ReferenceUp, stateB.ReferenceUp, t);
            state.RawPosition = Vector3.Lerp(stateA.RawPosition, stateB.RawPosition, t);

            state.ShotQuality = Mathf.Lerp(stateA.ShotQuality, stateB.ShotQuality, t);
            state.PositionCorrection = Vector3.Lerp(
                    stateA.PositionCorrection, stateB.PositionCorrection, t);
            // GML todo: is this right?  Can it introduce a roll?
            state.OrientationCorrection = Quaternion.Slerp(
                    stateA.OrientationCorrection, stateB.OrientationCorrection, t);

            Vector3 dirTarget = Vector3.zero;
            if (!stateA.HasLookAt || !stateB.HasLookAt)
                state.ReferenceLookAt = kNoPoint;   // can't interpolate if undefined
            else
            {
                // Re-interpolate FOV to preserve target composition, if possible
                float fovA = stateA.Lens.FieldOfView;
                float fovB = stateB.Lens.FieldOfView;
                if (!state.Lens.Orthographic && !Mathf.Approximately(fovA, fovB))
                {
                    LensSettings lens = state.Lens;
                    lens.FieldOfView = state.InterpolateFOV(
                            fovA, fovB,
                            Mathf.Max((stateA.ReferenceLookAt - stateA.CorrectedPosition).magnitude, stateA.Lens.NearClipPlane),
                            Mathf.Max((stateB.ReferenceLookAt - stateB.CorrectedPosition).magnitude, stateB.Lens.NearClipPlane), t);
                    state.Lens = lens;

                    // Make sure we preserve the screen composition through FOV changes
                    adjustedT = Mathf.Abs((lens.FieldOfView - fovA) / (fovB - fovA));
                }

                // Linear interpolation of lookAt target point
                state.ReferenceLookAt = Vector3.Lerp(
                        stateA.ReferenceLookAt, stateB.ReferenceLookAt, adjustedT);
                
                // If orientations are different, use LookAt to blend them
                float angle = Quaternion.Angle(stateA.RawOrientation, stateB.RawOrientation);
                if (angle > UnityVectorExtensions.Epsilon)
                    dirTarget = state.ReferenceLookAt - state.CorrectedPosition;
            }

            // Clever orientation interpolation
            if (dirTarget.AlmostZero())
            {
                // Don't know what we're looking at - can only slerp
                state.RawOrientation = UnityQuaternionExtensions.SlerpWithReferenceUp(
                        stateA.RawOrientation, stateB.RawOrientation, t, state.ReferenceUp);
            }
            else
            {
                // Rotate while preserving our lookAt target
                dirTarget = dirTarget.normalized;
                if ((dirTarget - state.ReferenceUp).AlmostZero()
                    || (dirTarget + state.ReferenceUp).AlmostZero())
                {
                    // Looking up or down at the pole
                    state.RawOrientation = UnityQuaternionExtensions.SlerpWithReferenceUp(
                            stateA.RawOrientation, stateB.RawOrientation, t, state.ReferenceUp);
                }
                else
                {
                    // Put the target in the center
                    state.RawOrientation = Quaternion.LookRotation(dirTarget, state.ReferenceUp);

                    // Blend the desired offsets from center
                    Vector2 deltaA = -stateA.RawOrientation.GetCameraRotationToTarget(
                            stateA.ReferenceLookAt - stateA.CorrectedPosition, stateA.ReferenceUp);
                    Vector2 deltaB = -stateB.RawOrientation.GetCameraRotationToTarget(
                            stateB.ReferenceLookAt - stateB.CorrectedPosition, stateB.ReferenceUp);
                    state.RawOrientation = state.RawOrientation.ApplyCameraRotation(
                            Vector2.Lerp(deltaA, deltaB, adjustedT), state.ReferenceUp);
                }
            }

            // Accumulate the custom blendables and apply the weights
            for (int i = 0; i < stateA.NumCustomBlendables; ++i)
            {
                CustomBlendable b = stateA.GetCustomBlendable(i);
                b.m_Weight *= (1-t);
                if (b.m_Weight > UnityVectorExtensions.Epsilon)
                    state.AddCustomBlendable(b);
            }
            for (int i = 0; i < stateB.NumCustomBlendables; ++i)
            {
                CustomBlendable b = stateB.GetCustomBlendable(i);
                b.m_Weight *= t;
                if (b.m_Weight > UnityVectorExtensions.Epsilon)
                    state.AddCustomBlendable(b);
            }
            return state;
        }

        float InterpolateFOV(float fovA, float fovB, float dA, float dB, float t)
        {
            // We interpolate shot height
            float hA = dA * 2f * Mathf.Tan(fovA * Mathf.Deg2Rad / 2f);
            float hB = dB * 2f * Mathf.Tan(fovB * Mathf.Deg2Rad / 2f);
            float h = Mathf.Lerp(hA, hB, t);
            float fov = 179f;
            float d = Mathf.Lerp(dA, dB, t);
            if (d > UnityVectorExtensions.Epsilon)
                fov = 2f * Mathf.Atan(h / (2 * d)) * Mathf.Rad2Deg;
            return Mathf.Clamp(fov, Mathf.Min(fovA, fovB), Mathf.Max(fovA, fovB));
        }
    }
}
