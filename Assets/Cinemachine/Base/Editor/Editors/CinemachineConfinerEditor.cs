using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

namespace Cinemachine.Editor
{
    [CustomEditor(typeof(CinemachineConfiner))]
    public sealed class CinemachineConfinerEditor : BaseEditor<CinemachineConfiner>
    {
        protected override List<string> GetExcludedPropertiesInInspector()
        {
            List<string> excluded = base.GetExcludedPropertiesInInspector();
            CinemachineBrain brain = CinemachineCore.Instance.FindPotentialTargetBrain(Target.VirtualCamera);
            bool ortho = brain != null ? brain.OutputCamera.orthographic : false;
            if (!ortho)
                excluded.Add(FieldPath(x => x.m_ConfineScreenEdges));
            if (Target.m_ConfineMode == CinemachineConfiner.Mode.Confine2D)
                excluded.Add(FieldPath(x => x.m_BoundingVolume));
            else
                excluded.Add(FieldPath(x => x.m_BoundingShape2D));
            return excluded;
        }

        public override void OnInspectorGUI()
        {
            BeginInspector();
            if (Target.m_ConfineMode == CinemachineConfiner.Mode.Confine2D)
            {
                if (Target.m_BoundingShape2D == null)
                    EditorGUILayout.HelpBox("A Bounding Shape is required.", MessageType.Warning);
                else if (Target.m_BoundingShape2D.GetType() != typeof(PolygonCollider2D)
                    && Target.m_BoundingShape2D.GetType() != typeof(CompositeCollider2D))
                {
                    EditorGUILayout.HelpBox(
                        "Must be a PolygonCollider2D or CompositeCollider2D.", 
                        MessageType.Warning);
                }
                else if (Target.m_BoundingShape2D.GetType() == typeof(CompositeCollider2D))
                {
                    CompositeCollider2D poly = Target.m_BoundingShape2D as CompositeCollider2D;
                    if (poly.geometryType != CompositeCollider2D.GeometryType.Polygons)
                    {
                        EditorGUILayout.HelpBox(
                            "CompositeCollider2D geometry type must be Polygons", 
                            MessageType.Warning);
                    }
                }
            }
            else
            {
                if (Target.m_BoundingVolume == null)
                    EditorGUILayout.HelpBox("A Bounding Volume is required.", MessageType.Warning);
                else if (Target.m_BoundingVolume.GetType() != typeof(BoxCollider)
                    && Target.m_BoundingVolume.GetType() != typeof(SphereCollider)
                    && Target.m_BoundingVolume.GetType() != typeof(CapsuleCollider))
                {
                    EditorGUILayout.HelpBox(
                        "Must be a BoxCollider, SphereCollider, or CapsuleCollider.", 
                        MessageType.Warning);
                }
            }
            DrawRemainingPropertiesInInspector();
        }

        [DrawGizmo(GizmoType.Active | GizmoType.Selected, typeof(CinemachineConfiner))]
        private static void DrawColliderGizmos(CinemachineConfiner confiner, GizmoType type)
        {
            CinemachineVirtualCameraBase vcam = (confiner != null) ? confiner.VirtualCamera : null;
            if (vcam != null && confiner.IsValid)
            {
                Matrix4x4 oldMatrix = Gizmos.matrix;
                Color oldColor = Gizmos.color;
                Gizmos.color = Color.yellow;

                if (confiner.m_ConfineMode == CinemachineConfiner.Mode.Confine3D)
                {
                    Transform t = confiner.m_BoundingVolume.transform;
                    Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, t.lossyScale);

                    Type colliderType = confiner.m_BoundingVolume.GetType();
                    if (colliderType == typeof(BoxCollider))
                    {
                        BoxCollider c = confiner.m_BoundingVolume as BoxCollider;
                        Gizmos.DrawWireCube(c.center, c.size);
                    }
                    else if (colliderType == typeof(SphereCollider))
                    {
                        SphereCollider c = confiner.m_BoundingVolume as SphereCollider;
                        Gizmos.DrawWireSphere(c.center, c.radius);
                    }
                    else if (colliderType == typeof(CapsuleCollider))
                    {
                        CapsuleCollider c = confiner.m_BoundingVolume as CapsuleCollider;
                        Vector3 size = Vector3.one * c.radius * 2;
                        switch (c.direction)
                        {
                            case 0: size.x = c.height; break;
                            case 1: size.y = c.height; break;
                            case 2: size.z = c.height; break;
                        }
                        Gizmos.DrawWireCube(c.center, size);
                    }
                    else if (colliderType == typeof(MeshCollider))
                    {
                        MeshCollider c = confiner.m_BoundingVolume as MeshCollider;
                        Gizmos.DrawWireMesh(c.sharedMesh);
                    }
                    else
                    {
                        // Just draw an AABB - not very nice!
                        Gizmos.matrix = oldMatrix;
                        Bounds bounds = confiner.m_BoundingVolume.bounds;
                        Gizmos.DrawWireCube(t.position, bounds.extents * 2);
                    }
                }
                else 
                {
                    Transform t = confiner.m_BoundingShape2D.transform;
                    Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, t.lossyScale);

                    Type colliderType = confiner.m_BoundingShape2D.GetType();
                    if (colliderType == typeof(PolygonCollider2D))
                    {
                        PolygonCollider2D poly = confiner.m_BoundingShape2D as PolygonCollider2D;
                        for (int i = 0; i < poly.pathCount; ++i)
                            DrawPath(poly.GetPath(i), -1);
                    }
                    else if (colliderType == typeof(CompositeCollider2D))
                    {
                        CompositeCollider2D poly = confiner.m_BoundingShape2D as CompositeCollider2D;
                        Vector2[] path = new Vector2[poly.pointCount];
                        for (int i = 0; i < poly.pathCount; ++i)
                        {
                            int numPoints = poly.GetPath(i, path);
                            DrawPath(path, numPoints);
                        }
                    }
                }
                Gizmos.color = oldColor;
                Gizmos.matrix = oldMatrix;
            }
        }

        static void DrawPath(Vector2[] path, int numPoints)
        {
            if (numPoints < 0)
                numPoints = path.Length;
            if (numPoints > 0)
            {
                Vector2 v0 = path[numPoints-1];
                for (int j = 0; j < numPoints; ++j)
                {
                    Vector2 v = path[j];
                    Gizmos.DrawLine(v0, v);
                    v0 = v;
                }
            }
        }
    }
}
