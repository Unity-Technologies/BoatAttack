using Unity.Mathematics;
using Unity.Properties;
using UnityEditor;

namespace Unity.Entities.Editor
{
    internal class IMGUIMathematicsAdapter : IMGUIAdapter
        , IVisitAdapter<quaternion>
        , IVisitAdapter<float2>
        , IVisitAdapter<float3>
        , IVisitAdapter<float4>
        , IVisitAdapter<float2x2>
        , IVisitAdapter<float3x3>
        , IVisitAdapter<float4x4>
    {
        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref quaternion value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, quaternion>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => new quaternion(EditorGUILayout.Vector4Field(label, val.value)));
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref float2 value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, float2>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => EditorGUILayout.Vector2Field(label, val));
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref float3 value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, float3>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => EditorGUILayout.Vector3Field(label, val));
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref float4 value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, float4>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => EditorGUILayout.Vector4Field(label, val));
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref float2x2 value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, float2x2>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) =>
            {
                val.c0 = EditorGUILayout.Vector2Field(property.GetName(), val.c0);
                val.c1 = EditorGUILayout.Vector2Field(" ", val.c1);

                return val;
            });

            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref float3x3 value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, float3x3>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) =>
            {
                val.c0 = EditorGUILayout.Vector3Field(property.GetName(), val.c0);
                val.c1 = EditorGUILayout.Vector3Field(" ", val.c1);
                val.c2 = EditorGUILayout.Vector3Field(" ", val.c2);

                return val;
            });

            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref float4x4 value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, float4x4>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) =>
            {
                val.c0 = EditorGUILayout.Vector4Field(property.GetName(), val.c0);
                val.c1 = EditorGUILayout.Vector4Field(" ", val.c1);
                val.c2 = EditorGUILayout.Vector4Field(" ", val.c2);
                val.c3 = EditorGUILayout.Vector4Field(" ", val.c3);

                return val;
            });

            return VisitStatus.Handled;
        }
    }
}
