using UnityEngine;
using System;
using Cinemachine.Utility;

namespace Cinemachine
{
    /// <summary>Defines a group of target objects, each with a radius and a weight.
    /// The weight is used when calculating the average position of the target group.
    /// Higher-weighted members of the group will count more.
    /// The bounding box is calculated by taking the member positions, weight, 
    /// and radii into account.
    /// </summary>
    [DocumentationSorting(19, DocumentationSortingAttribute.Level.UserRef)]
    [AddComponentMenu("Cinemachine/CinemachineTargetGroup")]
    [SaveDuringPlay]
    [ExecuteInEditMode]
    public class CinemachineTargetGroup : MonoBehaviour
    {
        /// <summary>Holds the information that represents a member of the group</summary>
        [DocumentationSorting(19.1f, DocumentationSortingAttribute.Level.UserRef)]
        [Serializable] public struct Target
        {
            /// <summary>The target objects.  This object's position and orientation will contribute to the 
            /// group's average position and orientation, in accordance with its weight</summary>
            [Tooltip("The target objects.  This object's position and orientation will contribute to the group's average position and orientation, in accordance with its weight")]
            public Transform target;
            /// <summary>How much weight to give the target when averaging.  Cannot be negative</summary>
            [Tooltip("How much weight to give the target when averaging.  Cannot be negative")]
            public float weight;
            /// <summary>The radius of the target, used for calculating the bounding box.  Cannot be negative</summary>
            [Tooltip("The radius of the target, used for calculating the bounding box.  Cannot be negative")]
            public float radius;
        }

        /// <summary>How the group's position is calculated</summary>
        [DocumentationSorting(19.2f, DocumentationSortingAttribute.Level.UserRef)]
        public enum PositionMode
        {
            ///<summary>Group position will be the center of the group's axis-aligned bounding box</summary>
            GroupCenter,
            /// <summary>Group position will be the weighted average of the positions of the members</summary>
            GroupAverage
        }

        /// <summary>How the group's position is calculated</summary>
        [Tooltip("How the group's position is calculated.  Select GroupCenter for the center of the bounding box, and GroupAverage for a weighted average of the positions of the members.")]
        public PositionMode m_PositionMode = PositionMode.GroupCenter;

        /// <summary>How the group's orientation is calculated</summary>
        [DocumentationSorting(19.3f, DocumentationSortingAttribute.Level.UserRef)]
        public enum RotationMode
        {
            /// <summary>Manually set in the group's transform</summary>
            Manual,
            /// <summary>Weighted average of the orientation of its members.</summary>
            GroupAverage
        }

        /// <summary>How the group's orientation is calculated</summary>
        [Tooltip("How the group's rotation is calculated.  Select Manual to use the value in the group's transform, and GroupAverage for a weighted average of the orientations of the members.")]
        public RotationMode m_RotationMode = RotationMode.Manual;

        /// <summary>This enum defines the options available for the update method.</summary>
        public enum UpdateMethod
        {
            /// <summary>Updated in normal MonoBehaviour Update.</summary>
            Update,
            /// <summary>Updated in sync with the Physics module, in FixedUpdate</summary>
            FixedUpdate,
            /// <summary>Updated in MonoBehaviour LateUpdate.</summary>
            LateUpdate
        };

        /// <summary>When to update the group's transform based on the position of the group members</summary>
        [Tooltip("When to update the group's transform based on the position of the group members")]
        public UpdateMethod m_UpdateMethod = UpdateMethod.LateUpdate;

        /// <summary>The target objects, together with their weights and radii, that will
        /// contribute to the group's average position, orientation, and size</summary>
        [NoSaveDuringPlay]
        [Tooltip("The target objects, together with their weights and radii, that will contribute to the group's average position, orientation, and size.")]
        public Target[] m_Targets = new Target[0];

        /// Cache of the last valid radius
        private float m_lastRadius = 0;

        /// <summary>The axis-aligned bounding box of the group, computed using the
        /// targets positions and radii</summary>
        public Bounds BoundingBox
        {
            get
            {
                float averageWeight;
                Vector3 center = CalculateAveragePosition(out averageWeight);
                bool gotOne = false;
                Bounds b = new Bounds(center, new Vector3(m_lastRadius*2, m_lastRadius*2, m_lastRadius*2));
                if (averageWeight > UnityVectorExtensions.Epsilon)
                {
                    for (int i = 0; i < m_Targets.Length; ++i)
                    {
                        if (m_Targets[i].target != null)
                        {
                            float w = m_Targets[i].weight;
                            if (w < averageWeight - UnityVectorExtensions.Epsilon)
                                w = w / averageWeight;
                            else
                                w = 1;
                            float d = m_Targets[i].radius * 2 * w;
                            Vector3 p = Vector3.Lerp(center, m_Targets[i].target.position, w);
                            Bounds b2 = new Bounds(p, new Vector3(d, d, d));
                            if (!gotOne)
                                b = b2;
                            else
                                b.Encapsulate(b2);
                            gotOne = true;
                        }
                    }
                }
                Vector3 r = b.extents;
                m_lastRadius = Mathf.Max(r.x, Mathf.Max(r.y, r.z));
                return b;
            }
        }

        /// <summary>Return true if there are no members with weight > 0</summary>
        public bool IsEmpty 
        {
            get 
            {
                for (int i = 0; i < m_Targets.Length; ++i)
                    if (m_Targets[i].target != null && m_Targets[i].weight > UnityVectorExtensions.Epsilon)
                        return false;
                return true;
            }
        }

        /// <summary>The axis-aligned bounding box of the group, in a specific reference frame</summary>
        /// <param name="mView">The frame of reference in which to compute the bounding box</param>
        /// <returns>The axis-aligned bounding box of the group, in the desired frame of reference</returns>
        public Bounds GetViewSpaceBoundingBox(Matrix4x4 mView)
        {
            Matrix4x4 inverseView = mView.inverse;
            float averageWeight;
            Vector3 center = inverseView.MultiplyPoint3x4(CalculateAveragePosition(out averageWeight));
            bool gotOne = false;
            Bounds b = new Bounds(center, new Vector3(m_lastRadius*2, m_lastRadius*2, m_lastRadius*2));
            if (averageWeight > UnityVectorExtensions.Epsilon)
            {
                for (int i = 0; i < m_Targets.Length; ++i)
                {
                    if (m_Targets[i].target != null)
                    {
                        float w = m_Targets[i].weight;
                        if (w < averageWeight - UnityVectorExtensions.Epsilon)
                            w = w / averageWeight;
                        else
                            w = 1;
                        float d = m_Targets[i].radius * 2;
                        Vector4 p = inverseView.MultiplyPoint3x4(m_Targets[i].target.position);
                        p = Vector3.Lerp(center, p, w);
                        Bounds b2 = new Bounds(p, new Vector3(d, d, d));
                        if (!gotOne)
                            b = b2;
                        else
                            b.Encapsulate(b2);
                        gotOne = true;
                    }
                }
            }
            Vector3 r = b.extents;
            m_lastRadius = Mathf.Max(r.x, Mathf.Max(r.y, r.z));
            return b;
        }

        Vector3 CalculateAveragePosition(out float averageWeight)
        {
            Vector3 pos = Vector3.zero;
            float weight = 0;
            int numTargets = 0;
            for (int i = 0; i < m_Targets.Length; ++i)
            {
                if (m_Targets[i].target != null && m_Targets[i].weight > UnityVectorExtensions.Epsilon)
                {
                    ++numTargets;
                    weight += m_Targets[i].weight;
                    pos += m_Targets[i].target.position * m_Targets[i].weight;
                }
            }
            if (weight > UnityVectorExtensions.Epsilon)
                pos /= weight;
            if (numTargets == 0)
            {
                averageWeight = 0;
                return transform.position;
            }
            averageWeight = weight / numTargets;
            return pos;
        }

        Quaternion CalculateAverageOrientation()
        {
            Quaternion r = Quaternion.identity;
            for (int i = 0; i < m_Targets.Length; ++i)
            {
                if (m_Targets[i].target != null)
                {
                    float w = m_Targets[i].weight;
                    Quaternion q = m_Targets[i].target.rotation;
                    // This is probably bogus
                    r = new Quaternion(r.x + q.x * w, r.y + q.y * w, r.z + q.z * w, r.w + q.w * w);
                }
            }
            return r.Normalized();
        }

        private void OnValidate()
        {
            for (int i = 0; i < m_Targets.Length; ++i)
            {
                if (m_Targets[i].weight < 0)
                    m_Targets[i].weight = 0;
                if (m_Targets[i].radius < 0)
                    m_Targets[i].radius = 0;
            }
        }

        void FixedUpdate()
        {
            if (m_UpdateMethod == UpdateMethod.FixedUpdate)
                UpdateTransform();
        }

        void Update()
        {
            if (!Application.isPlaying || m_UpdateMethod == UpdateMethod.Update)
                UpdateTransform();
        }

        void LateUpdate()
        {
            if (m_UpdateMethod == UpdateMethod.LateUpdate)
                UpdateTransform();
        }

        void UpdateTransform()
        {
            if (IsEmpty)
                return;
            switch (m_PositionMode)
            {
                case PositionMode.GroupCenter:
                    transform.position = BoundingBox.center;
                    break;
                case PositionMode.GroupAverage:
                    float averageWeight;
                    transform.position = CalculateAveragePosition(out averageWeight);
                    break;
            }
            switch (m_RotationMode)
            {
                case RotationMode.Manual:
                    break;
                case RotationMode.GroupAverage:
                    transform.rotation = CalculateAverageOrientation();
                    break;
            }
        }
    }
}
