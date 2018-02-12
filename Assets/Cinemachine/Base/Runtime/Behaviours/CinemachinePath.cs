using UnityEngine;
using System;
using Cinemachine.Utility;

namespace Cinemachine
{
    /// <summary>Defines a world-space path, consisting of an array of waypoints,
    /// each of which has position, tangent, and roll settings.  Bezier interpolation
    /// is performed between the waypoints, to get a smooth and continuous path.</summary>
    [DocumentationSorting(18, DocumentationSortingAttribute.Level.UserRef)]
    [AddComponentMenu("Cinemachine/CinemachinePath")]
    [SaveDuringPlay]
    public class CinemachinePath : CinemachinePathBase
    {
        /// <summary>A waypoint along the path</summary>
        [DocumentationSorting(18.2f, DocumentationSortingAttribute.Level.UserRef)]
        [Serializable] public struct Waypoint
        {
            /// <summary>Position in path-local space</summary>
            [Tooltip("Position in path-local space")]
            public Vector3 position;

            /// <summary>Offset from the position, which defines the tangent of the curve at the waypoint.  
            /// The length of the tangent encodes the strength of the bezier handle.  
            /// The same handle is used symmetrically on both sides of the waypoint, to ensure smoothness.</summary>
            [Tooltip("Offset from the position, which defines the tangent of the curve at the waypoint.  The length of the tangent encodes the strength of the bezier handle.  The same handle is used symmetrically on both sides of the waypoint, to ensure smoothness.")]
            public Vector3 tangent;

            /// <summary>Defines the roll of the path at this waypoint.  
            /// The other orientation axes are inferred from the tangent and world up.</summary>
            [Tooltip("Defines the roll of the path at this waypoint.  The other orientation axes are inferred from the tangent and world up.")]
            public float roll;
        }

        /// <summary>If checked, then the path ends are joined to form a continuous loop</summary>
        [Tooltip("If checked, then the path ends are joined to form a continuous loop.")]
        public bool m_Looped;

        /// <summary>The waypoints that define the path.
        /// They will be interpolated using a bezier curve</summary>
        [Tooltip("The waypoints that define the path.  They will be interpolated using a bezier curve.")]
        public Waypoint[] m_Waypoints = new Waypoint[0];

        /// <summary>The minimum value for the path position</summary>
        public override float MinPos { get { return 0; } }

        /// <summary>The maximum value for the path position</summary>
        public override float MaxPos
        {
            get
            {
                int count = m_Waypoints.Length - 1;
                if (count < 1)
                    return 0;
                return m_Looped ? count + 1 : count;
            }
        }
        /// <summary>True if the path ends are joined to form a continuous loop</summary>
        public override bool Looped { get { return m_Looped; } }

        /// <summary>When calculating the distance cache, sample the path this many 
        /// times between points</summary>
        public override int DistanceCacheSampleStepsPerSegment { get { return m_Resolution; } }

        /// <summary>Returns normalized position</summary>
        float GetBoundingIndices(float pos, out int indexA, out int indexB)
        {
            pos = NormalizePos(pos);
            int rounded = Mathf.RoundToInt(pos);
            if (Mathf.Abs(pos - rounded) < UnityVectorExtensions.Epsilon)
                indexA = indexB = (rounded == m_Waypoints.Length) ? 0 : rounded;
            else
            {
                indexA = Mathf.FloorToInt(pos);
                if (indexA >= m_Waypoints.Length)
                {
                    pos -= MaxPos;
                    indexA = 0;
                }
                indexB = Mathf.CeilToInt(pos);
                if (indexB >= m_Waypoints.Length)
                    indexB = 0;
            }
            return pos;
        }

        /// <summary>Get a worldspace position of a point along the path</summary>
        /// <param name="pos">Postion along the path.  Need not be normalized.</param>
        /// <returns>World-space position of the point along at path at pos</returns>
        public override Vector3 EvaluatePosition(float pos)
        {
            Vector3 result = new Vector3();
            if (m_Waypoints.Length == 0)
                result = transform.position;
            else
            {
                int indexA, indexB;
                pos = GetBoundingIndices(pos, out indexA, out indexB);
                if (indexA == indexB)
                    result = m_Waypoints[indexA].position;
                else
                {
                    // interpolate
                    Waypoint wpA = m_Waypoints[indexA];
                    Waypoint wpB = m_Waypoints[indexB];
                    result = SplineHelpers.Bezier3(pos - indexA,
                        m_Waypoints[indexA].position, wpA.position + wpA.tangent,
                        wpB.position - wpB.tangent, wpB.position);
                }
            }
            return transform.TransformPoint(result);
        }

        /// <summary>Get the tangent of the curve at a point along the path.</summary>
        /// <param name="pos">Postion along the path.  Need not be normalized.</param>
        /// <returns>World-space direction of the path tangent.
        /// Length of the vector represents the tangent strength</returns>
        public override Vector3 EvaluateTangent(float pos)
        {
            Vector3 result = new Vector3();
            if (m_Waypoints.Length == 0)
                result = transform.rotation * Vector3.forward;
            else
            {
                int indexA, indexB;
                pos = GetBoundingIndices(pos, out indexA, out indexB);
                if (indexA == indexB)
                    result = m_Waypoints[indexA].tangent;
                else
                {
                    Waypoint wpA = m_Waypoints[indexA];
                    Waypoint wpB = m_Waypoints[indexB];
                    result = SplineHelpers.BezierTangent3(pos - indexA,
                        m_Waypoints[indexA].position, wpA.position + wpA.tangent,
                        wpB.position - wpB.tangent, wpB.position);
                }
            }
            return transform.TransformDirection(result);
        }

        /// <summary>Get the orientation the curve at a point along the path.</summary>
        /// <param name="pos">Postion along the path.  Need not be normalized.</param>
        /// <returns>World-space orientation of the path, as defined by tangent, up, and roll.</returns>
        public override Quaternion EvaluateOrientation(float pos)
        {
            Quaternion result = transform.rotation;
            if (m_Waypoints.Length > 0)
            {
                float roll = 0;
                int indexA, indexB;
                pos = GetBoundingIndices(pos, out indexA, out indexB);
                if (indexA == indexB)
                    roll = m_Waypoints[indexA].roll;
                else
                {
                    float rollA = m_Waypoints[indexA].roll;
                    float rollB = m_Waypoints[indexB].roll;
                    if (indexB == 0)
                    {
                        // Special handling at the wraparound - cancel the spins
                        rollA = rollA % 360;
                        rollB = rollB % 360;
                    }
                    roll = Mathf.Lerp(rollA, rollB, pos - indexA);
                }

                Vector3 fwd = EvaluateTangent(pos);
                if (!fwd.AlmostZero())
                {
                    Vector3 up = transform.rotation * Vector3.up;
                    Quaternion q = Quaternion.LookRotation(fwd, up);
                    result = q * Quaternion.AngleAxis(roll, Vector3.forward);
                }
            }
            return result;
        }

        private void OnValidate() { InvalidateDistanceCache(); }
    }
}
