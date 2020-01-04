using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

namespace WaterSystem
{
    [CustomEditor(typeof(BuoyantObject))]
    public class BuoyantObjectEditor : Editor
    {
        private BuoyantObject obj;
        
        private void OnEnable()
        {
            obj = serializedObject.targetObject as BuoyantObject;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.BeginFoldoutHeaderGroup(true, "Debug Info");

            EditorGUILayout.LabelField("Height Values", EditorStyles.boldLabel);
            if (obj.Heights != null)
            {
                for (int i = 0; i < obj.Heights.Length; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    float3 h = obj.Heights[i];
                    EditorGUILayout.LabelField($"{i})Wave(heights):", $"X:{h.x:00.00} Y:{h.y:00.00} Z:{h.z:00.00}");
                    EditorGUILayout.EndHorizontal();
                }
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
        }
    }
}
