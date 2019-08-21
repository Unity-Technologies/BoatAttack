using System;
using System.Linq;
using Unity.Properties;
using UnityEditor;
using UnityEngine;

namespace Unity.Entities.Editor
{
    internal class EntityIMGUIVisitor : PropertyVisitor
    {
        private class EntityIMGUIAdapter : IMGUIAdapter
            , IVisitAdapter<Entity>
        {
            private GUIStyle s_EntityStyle;

            private readonly EntityDoubleClick m_Callback;

            public EntityIMGUIAdapter(EntityDoubleClick callback)
            {
                m_Callback = callback;
            }

            public VisitStatus Visit<TProperty, TContainer>(IPropertyVisitor visitor, TProperty property, ref TContainer container, ref Entity value, ref ChangeTracker changeTracker) where TProperty : IProperty<TContainer, Entity>
            {
                if (s_EntityStyle == null)
                {
                    s_EntityStyle = new GUIStyle(EditorStyles.label)
                    {
                        normal =
                        {
                            textColor = new Color(0.5f, 0.5f, 0.5f)
                        },
                        onHover =
                        {
                            textColor = new Color(0.0f, 0.7f, 0.7f)
                        }
                    };
                }

                GUI.enabled = true;

                var pos = EditorGUILayout.GetControlRect();

                EditorGUI.LabelField(pos, $"{property.GetName()} Index: {value.Index}, Version: {value.Version}", s_EntityStyle);

                if (Event.current.type == EventType.MouseDown && pos.Contains(Event.current.mousePosition))
                {
                    if (Event.current.clickCount == 2)
                    {
                        Event.current.Use();
                        m_Callback?.Invoke(value);
                    }
                }

                GUI.enabled = false;
                return VisitStatus.Handled;
            }
        }

        public delegate void EntityDoubleClick(Entity entity);

        public EntityIMGUIVisitor(EntityDoubleClick entityDoubleClick)
        {
            AddAdapter(new IMGUIPrimitivesAdapter());
            AddAdapter(new IMGUIMathematicsAdapter());
            AddAdapter(new EntityIMGUIAdapter(entityDoubleClick));
        }

        protected override VisitStatus Visit<TProperty, TContainer, TValue>(TProperty property, ref TContainer container, ref TValue value, ref ChangeTracker changeTracker)
        {
            if (typeof(TValue).IsEnum)
            {
                var options = Enum.GetNames(typeof(TValue)).ToArray();
                var local = value;
                EditorGUILayout.Popup(
                    typeof(TValue).Name,
                    Array.FindIndex(options, name => name == local.ToString()),
                    options);
            }
            else
            {
                GUILayout.Label(property.GetName());
            }

            return VisitStatus.Handled;
        }

        protected override VisitStatus BeginContainer<TProperty, TContainer, TValue>(TProperty property, ref TContainer container, ref TValue value, ref ChangeTracker changeTracker)
        {
            var enabled = GUI.enabled;
            GUI.enabled = true;
            var foldout = ContainerHeader<TValue>(property.GetName());
            GUI.enabled = enabled;

            EditorGUI.indentLevel++;
            return foldout ? VisitStatus.Handled : VisitStatus.Override;
        }

        private static bool ContainerHeader<TValue>(string displayName)
        {
            EditorGUILayout.LabelField(displayName, new GUIStyle(EditorStyles.boldLabel) { fontStyle = FontStyle.Bold });
            return !typeof(IComponentData).IsAssignableFrom(typeof(TValue)) || !TypeManager.IsZeroSized(TypeManager.GetTypeIndex<TValue>());
        }

        protected override void EndContainer<TProperty, TContainer, TValue>(TProperty property, ref TContainer container, ref TValue value, ref ChangeTracker changeTracker)
        {
            EditorGUI.indentLevel--;
        }
    }
}
