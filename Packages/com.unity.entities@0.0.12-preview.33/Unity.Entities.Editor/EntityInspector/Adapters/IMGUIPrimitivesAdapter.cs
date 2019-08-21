using System.Linq;
using Unity.Properties;
using UnityEditor;

namespace Unity.Entities.Editor
{
    internal class IMGUIPrimitivesAdapter : IMGUIAdapter,
        IVisitAdapterPrimitives
    {
        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref sbyte value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, sbyte>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => (sbyte) EditorGUILayout.IntField(label, val));
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref short value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, short>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => (short) EditorGUILayout.IntField(label, val));
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref int value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, int>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => EditorGUILayout.IntField(label, val));
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref long value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, long>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => EditorGUILayout.LongField(label, val));
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref byte value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, byte>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => (byte) EditorGUILayout.IntField(label, val));
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref ushort value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, ushort>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => (ushort) EditorGUILayout.IntField(label, val));
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref uint value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, uint>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => (uint) EditorGUILayout.LongField(label, val));
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref ulong value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, ulong>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) =>
            {
                EditorGUILayout.TextField(label, text: val.ToString());
                return val;
            });
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref float value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, float>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => EditorGUILayout.FloatField(label, val));
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref double value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, double>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => EditorGUILayout.DoubleField(label, val));
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref bool value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, bool>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => EditorGUILayout.Toggle(label, val));
            return VisitStatus.Handled;
        }

        public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref char value, ref ChangeTracker changeTracker)
            where TProperty : IProperty<TContainer, char>
        {
            DoField(property, ref container, ref value, ref changeTracker, (label, val) => EditorGUILayout.TextField(label, val.ToString()).FirstOrDefault());
            return VisitStatus.Handled;
        }
    }
}
