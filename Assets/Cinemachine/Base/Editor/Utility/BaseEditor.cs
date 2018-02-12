using UnityEditor;
using System;
using System.Collections.Generic;
using Cinemachine.Utility;
using System.Linq.Expressions;

namespace Cinemachine.Editor
{
    public class BaseEditor<T> : UnityEditor.Editor where T : class
    {
        protected T Target { get { return target as T; } }

        protected SerializedProperty FindAndExcludeProperty<TValue>(Expression<Func<T, TValue>> expr)
        {
            SerializedProperty p = FindProperty(expr);
            ExcludeProperty(p.name);
            return p;
        }

        protected SerializedProperty FindProperty<TValue>(Expression<Func<T, TValue>> expr)
        {
            return serializedObject.FindProperty(FieldPath(expr));
        }

        protected string FieldPath<TValue>(Expression<Func<T, TValue>> expr)
        {
            return ReflectionHelpers.GetFieldPath(expr);
        }

        protected virtual List<string> GetExcludedPropertiesInInspector()
        {
            var excluded = new List<string>() { "m_Script" }; 
            if (mAdditionalExcluded != null)
                excluded.AddRange(mAdditionalExcluded);
            return excluded;
        }

        List<string> mAdditionalExcluded;
        protected void ExcludeProperty(string propertyName)
        {
            if (mAdditionalExcluded == null)
                mAdditionalExcluded = new List<string>();
            mAdditionalExcluded.Add(propertyName);
        }

        public override void OnInspectorGUI()
        {
            BeginInspector();
            DrawRemainingPropertiesInInspector();
        }

        protected virtual void BeginInspector()
        {
            mAdditionalExcluded = null;
            serializedObject.Update();
        }

        protected virtual void DrawPropertyInInspector(SerializedProperty p)
        {
            List<string> excluded = GetExcludedPropertiesInInspector();
            if (!excluded.Contains(p.name))
            {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(p);
                if (EditorGUI.EndChangeCheck())
                    serializedObject.ApplyModifiedProperties();
                ExcludeProperty(p.name);
            }
        }

        protected void DrawRemainingPropertiesInInspector()
        {
            EditorGUI.BeginChangeCheck();
            DrawPropertiesExcluding(serializedObject, GetExcludedPropertiesInInspector().ToArray());
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
        }
    }
}
