using UnityEngine;
using Cinemachine.Utility;
using System;

namespace Cinemachine
{
    /// <summary>Abstract base class for a world-space path,
    /// suitable for a camera dolly track.</summary>
    public abstract class CinemachinePathBase : MonoBehaviour
    {
        /// <summary>Path samples per waypoint</summary>
        [Tooltip("Path samples per waypoint.  This is used for calculating path distances.")]
        [Range(1, 100)]
        public int m_Resolution = 20;

        /// <summary>This class holds the settings that control how the path
        /// will appear in the editor scene view.  The path is not visible in the game view</summary>
        [DocumentationSorting(18.1f, DocumentationSortingAttribute.Level.UserRef)]
        [Serializable] public class Appearance
        {
            [Tooltip("The color of the path itself when it is active in the editor")]
            public Color pathColor = Color.green;
            [Tooltip("The color of the path itself when it is inactive in the editor")]
            public Color inactivePathColor = Color.gray;
            [Tooltip("The width of the railroad-tracks that are drawn to represent the path")]
            [Range(0f, 10f)]
            public float width = 0.2f;
        }
        /// <summary>The settings that control how the path
        /// will appear in the editor scene view.</summary>
        [Tooltip("The settings that control how the path will appear in the editor scene view.")]
        public Appearance m_Appearance = new Appearance();

        /// <summary>The minimum value for the path position</summary>
        public abstract float MinPos { get; }

        /// <summary>The maximum value for the path position</summary>
        public abstract float MaxPos { get; }

        /// <summary>True if the path ends are joined to form a continuous loop</summary>
        public abstract bool Looped { get; }

        /// <summary>Get a normalized path position, taking spins into account if looped</summary>
        /// <param name="pos">Position along the path</param>
        /// <returns>Normalized position, between MinPos and MaxPos</returns>
        public virtual float NormalizePos(float pos)
        {
            if (MaxPos == 0)
                return 0;
            if (Looped)
            {
                pos = pos % MaxPos;
                if (pos < 0)
                    pos += MaxPos;
                return pos;
            }
            return Mathf.Clamp(pos, 0, MaxPos);
        }

        /// <summary>Get a worldspace position of a point along the path</summary>
        /// <param name="pos">Postion along the path.  Need not be normalized.</param>
        /// <returns>World-space position of the point along at path at pos</returns>
        public abstract Vector3 EvaluatePosition(float pos);

        /// <summary>Get the tangent of the curve at a point along the path.</summary>
        /// <param name="pos">Postion along the path.  Need not be normalized.</param>
        /// <returns>World-space direction of the path tangent.
        /// Length of the vector represents the tangent strength</returns>
        public abstract Vector3 EvaluateTangent(float pos);

        /// <summary>Get the orientation the curve at a point along the path.</summary>
        /// <param name="pos">Postion along the path.  Need not be normalized.</param>
        /// <returns>World-space orientation of the path</returns>
        public abstract Quaternion EvaluateOrientation(float pos);

        /// <summary>Find the closest point on the path to a given worldspace target point.</summary>
        /// <remarks>Performance could be improved by checking the bounding polygon of each segment,
        /// and only entering the best segment(s)</remarks>
        /// <param name="p">Worldspace target that we want to approach</param>
        /// <param name="startSegment">In what segment of the path to start the search.
        /// A Segment is a section of path between 2 waypoints.</param>
        /// <param name="searchRadius">How many segments on either side of the startSegment
        /// to search.  -1 means no limit, i.e. search the entire path</param>
        /// <param name="stepsPerSegment">We search a segment by dividing it into this many
        /// straight pieces.  The higher the number, the more accurate the result, but performance
        /// is proportionally slower for higher numbers</param>
        /// <returns>The position along the path that is closest to the target point.  
        /// The value is in Path Units, not Distance units.</returns>
        public virtual float FindClosestPoint(
            Vector3 p, int startSegment, int searchRadius, int stepsPerSegment)
        {
            float start = MinPos;
            float end = MaxPos;
            if (searchRadius >= 0)
            {
                int r = Mathf.FloorToInt(Mathf.Min(searchRadius, (end - start) / 2f));
                start = startSegment - r;
                end = startSegment + r + 1;
                if (!Looped)
                {
                    start = Mathf.Max(start, MinPos);
                    end = Mathf.Max(end, MaxPos);
                }
            }
            stepsPerSegment = Mathf.RoundToInt(Mathf.Clamp(stepsPerSegment, 1f, 100f));
            float stepSize = 1f / stepsPerSegment;
            float bestPos = startSegment;
            float bestDistance = float.MaxValue;
            int iterations = (stepsPerSegment == 1) ? 1 : 3;
            for (int i = 0; i < iterations; ++i)
            {
                Vector3 v0 = EvaluatePosition(start);
                for (float f = start + stepSize; f <= end; f += stepSize)
                {
                    Vector3 v = EvaluatePosition(f);
                    float t = p.ClosestPointOnSegment(v0, v);
                    float d = Vector3.SqrMagnitude(p - Vector3.Lerp(v0, v, t));
                    if (d < bestDistance)
                    {
                        bestDistance = d;
                        bestPos = f - (1 - t) * stepSize;
                    }
                    v0 = v;
                }
                start = bestPos - stepSize;
                end = bestPos + stepSize;
                stepSize /= stepsPerSegment;
            }
            return bestPos;
        }

        /// <summary>How to interpret the Path Position</summary>
        public enum PositionUnits
        {
            /// <summary>Use PathPosition units, where 0 is first waypoint, 1 is second waypoint, etc</summary>
            PathUnits,
            /// <summary>Use Distance Along Path.  Path will be sampled according to its Resolution
            /// setting, and a distance lookup table will be cached internally</summary>
            Distance
        }

        /// <summary>Get the minimum value, for the given unity type</summary>
        /// <param name="units">The uniot type</param>
        /// <returns>The minimum allowable value for this path</returns>
        public float MinUnit(PositionUnits units)
        { 
            return units == PositionUnits.Distance ? 0 : MinPos; 
        }

        /// <summary>Get the maximum value, for the given unity type</summary>
        /// <param name="units">The uniot type</param>
        /// <returns>The maximum allowable value for this path</returns>
        public float MaxUnit(PositionUnits units)
        { 
            return units == PositionUnits.Distance ? PathLength : MaxPos; 
        }

        /// <summary>Normalize the unit, so that it lies between MinUmit and MaxUnit</summary>
        /// <param name="pos">The value to be normalized</param>
        /// <param name="units">The unit type</param>
        /// <returns>The normalized value of pos, between MinUnit and MaxUnit</returns>
        public virtual float NormalizeUnit(float pos, PositionUnits units)
        {
            if (units == PositionUnits.Distance)
                return NormalizePathDistance(pos);
            return NormalizePos(pos);
        }

        /// <summary>Get a worldspace position of a point along the path</summary>
        /// <param name="pos">Postion along the path.  Need not be normalized.</param>
        /// <param name="units">The unit to use when interpreting the value of pos.</param>
        /// <returns>World-space position of the point along at path at pos</returns>
        public Vector3 EvaluatePositionAtUnit(float pos, PositionUnits units)
        {
            if (units == PositionUnits.Distance)
                pos = GetPathPositionFromDistance(pos);
            return EvaluatePosition(pos);
        }

        /// <summary>Get the tangent of the curve at a point along the path.</summary>
        /// <param name="pos">Postion along the path.  Need not be normalized.</param>
        /// <param name="units">The unit to use when interpreting the value of pos.</param>
        /// <returns>World-space direction of the path tangent.
        /// Length of the vector represents the tangent strength</returns>
        public Vector3 EvaluateTangentAtUnit(float pos, PositionUnits units)
        {
            if (units == PositionUnits.Distance)
                pos = GetPathPositionFromDistance(pos);
            return EvaluateTangent(pos);
        }

        /// <summary>Get the orientation the curve at a point along the path.</summary>
        /// <param name="pos">Postion along the path.  Need not be normalized.</param>
        /// <param name="units">The unit to use when interpreting the value of pos.</param>
        /// <returns>World-space orientation of the path</returns>
        public Quaternion EvaluateOrientationAtUnit(float pos, PositionUnits units)
        {
            if (units == PositionUnits.Distance)
                pos = GetPathPositionFromDistance(pos);
            return EvaluateOrientation(pos);
        }

        /// <summary>When calculating the distance cache, sample the path this many 
        /// times between points</summary>
        public abstract int DistanceCacheSampleStepsPerSegment { get; }

        /// <summary>Call this if the path changes in such a way as to affect distances
        /// or other cached path elements</summary>
        public virtual void InvalidateDistanceCache() 
        { 
            m_DistanceToPos = null; 
            m_PosToDistance = null; 
            m_CachedSampleSteps = 0;
            m_PathLength = 0; 
        }

        /// <summary>See whether the distance cache is valid.  If it's not valid,
        /// then any call to GetPathLength() or GetPathPositionFromDistance() will
        /// trigger a potentially costly regeneration of the path distance cache</summary>
        /// <param name="stepsPerSegment">The number of steps to take between path points</param>
        /// <returns>Whether the cache is valid for this sampling rate</returns>
        public bool DistanceCacheIsValid()
        {
            return (MaxPos == MinPos)
                || (m_DistanceToPos != null && m_PosToDistance != null
                    && m_CachedSampleSteps == DistanceCacheSampleStepsPerSegment 
                    && m_CachedSampleSteps > 0);
        }

        /// <summary>Get the length of the path in distance units.  
        /// If the distance cache is not valid, then calling this will 
        /// trigger a potentially costly regeneration of the path distance cache</summary>
        /// <returns>The length of the path in distance units, when sampled at this rate</returns>
        public float PathLength
        { 
            get 
            {
                if (DistanceCacheSampleStepsPerSegment < 1)
                    return 0;
                if (!DistanceCacheIsValid())
                    ResamplePath(DistanceCacheSampleStepsPerSegment);
                return m_PathLength;
            }
        }

        /// <summary>Normalize a distance along the path based on the path length.  
        /// If the distance cache is not valid, then calling this will 
        /// trigger a potentially costly regeneration of the path distance cache</summary>
        /// <param name="distance">The distance to normalize</param>
        /// <returns>The normalized distance, ranging from 0 to path length</returns>
        public float NormalizePathDistance(float distance)
        {
            float length = PathLength;
            if (length < Vector3.kEpsilon)
                return 0;
            if (Looped)
            {
                distance = distance % length;
                if (distance < 0)
                    distance += length;
            }
            return Mathf.Clamp(distance, 0, length);
        }

        /// <summary>Get the path position (in path units) corresponding to this distance along the path.  
        /// If the distance cache is not valid, then calling this will 
        /// trigger a potentially costly regeneration of the path distance cache</summary>
        /// <returns>The length of the path in distance units, when sampled at this rate</returns>
        public float GetPathPositionFromDistance(float distance)
        {
            if (DistanceCacheSampleStepsPerSegment < 1 || PathLength < UnityVectorExtensions.Epsilon)
                return MinPos;
            distance = NormalizePathDistance(distance);
            float d = distance / m_cachedDistanceStepSize;
            int i = Mathf.FloorToInt(d);
            if (i >= m_DistanceToPos.Length-1)
                return MaxPos;
            float t = d - (float)i;
            return MinPos + Mathf.Lerp(m_DistanceToPos[i], m_DistanceToPos[i+1], t);
        }

        /// <summary>Get the path position (in path units) corresponding to this distance along the path.  
        /// If the distance cache is not valid, then calling this will 
        /// trigger a potentially costly regeneration of the path distance cache</summary>
        /// <returns>The length of the path in distance units, when sampled at this rate</returns>
        public float GetPathDistanceFromPosition(float pos)
        {
            if (DistanceCacheSampleStepsPerSegment < 1 || PathLength < UnityVectorExtensions.Epsilon)
                return 0;
            pos = NormalizePos(pos);
            float d = pos / m_cachedPosStepSize;
            int i = Mathf.FloorToInt(d);
            if (i >= m_PosToDistance.Length-1)
                return m_PathLength;
            float t = d - (float)i;
            return Mathf.Lerp(m_PosToDistance[i], m_PosToDistance[i+1], t);
        }

        private float[] m_DistanceToPos;
        private float[] m_PosToDistance;
        private int m_CachedSampleSteps;
        private float m_PathLength;
        private float m_cachedPosStepSize;
        private float m_cachedDistanceStepSize;

        private void ResamplePath(int stepsPerSegment)
        {
            InvalidateDistanceCache();

            float minPos = MinPos;
            float maxPos = MaxPos;
            float stepSize = 1f / Mathf.Max(1, stepsPerSegment);

            // Sample the positions
            int numKeys = Mathf.RoundToInt((maxPos - minPos) / stepSize) + 1;
            m_PosToDistance = new float[numKeys];
            m_CachedSampleSteps = stepsPerSegment;
            m_cachedPosStepSize = stepSize;

            Vector3 p0 = EvaluatePosition(0);
            m_PosToDistance[0] = 0;
            float pos = minPos;
            for (int i = 1; i < numKeys; ++i)
            {
                pos += stepSize;
                Vector3 p = EvaluatePosition(pos);
                float d = Vector3.Distance(p0, p);
                m_PathLength += d;
                p0 = p;
                m_PosToDistance[i] = m_PathLength;
            }

            // Resample the distances
            m_DistanceToPos = new float[numKeys];
            m_DistanceToPos[0] = 0;
            if (numKeys > 1)
            {
                stepSize = m_PathLength / (numKeys - 1);
                m_cachedDistanceStepSize = stepSize;
                float distance = 0;
                int posIndex = 1;
                for (int i = 1; i < numKeys; ++i)
                {
                    distance += stepSize;
                    float d = m_PosToDistance[posIndex];
                    while (d < distance && posIndex < numKeys-1)
                         d = m_PosToDistance[++posIndex];
                    float d0 =  m_PosToDistance[posIndex-1];
                    float delta = d - d0;
                    float t = (distance - d0) / delta;
                    m_DistanceToPos[i] = m_cachedPosStepSize * (t + posIndex - 1);
                }
            }
        }
    }
}
