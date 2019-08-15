using System;
using Unity.Properties;
using UnityEditor;
using UnityEngine;

namespace Unity.Entities.Editor
{
    internal class IMGUIAdapter : IPropertyVisitorAdapter
    {
        protected static void DoField<TProperty, TContainer, TValue>(TProperty property, ref TContainer container, ref TValue value, ref ChangeTracker changeTracker, Func<GUIContent, TValue, TValue> drawer)
            where TProperty : IProperty<TContainer, TValue>
        {
            EditorGUI.BeginChangeCheck();

            value = drawer(new GUIContent(property.GetName()), value);

            if (EditorGUI.EndChangeCheck())
            {
                changeTracker.MarkChanged();
            }
        }
    }
}
