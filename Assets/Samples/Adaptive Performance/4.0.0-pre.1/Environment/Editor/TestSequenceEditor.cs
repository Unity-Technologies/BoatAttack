using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(TestSequence))]
public class TestSequenceEditor : Editor
{
    public bool AutoMode = false;
    public bool Loop = false;
    public int LoopCycles = 1;
    private ReorderableList list;
    private void OnEnable()
    {
        list = new ReorderableList(serializedObject,
            serializedObject.FindProperty("orderedLoadLevels"),
            true, true, true, true);
        list.drawElementCallback =
            (Rect rect, int index, bool isActive, bool isFocused) => {
            var element = list.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            EditorGUI.LabelField(new Rect(rect.x, rect.y, 40, EditorGUIUtility.singleLineHeight), "Stage:");
            EditorGUI.PropertyField(
                new Rect(rect.x + 50, rect.y, 60, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("Name"), GUIContent.none);
            EditorGUI.LabelField(new Rect(rect.x + 120, rect.y, 80, EditorGUIUtility.singleLineHeight), "Duration (s):");
            EditorGUI.PropertyField(
                new Rect(rect.x + 200, rect.y, 50, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("Duration"), GUIContent.none);
            EditorGUI.LabelField(new Rect(rect.x + 260, rect.y, 70, EditorGUIUtility.singleLineHeight), "Active: ");
            string payload = "";
            if (element.FindPropertyRelative("isActive").boolValue)
            {
                payload = "►";
            }
            EditorGUI.LabelField(new Rect(rect.x + 330, rect.y, 20, EditorGUIUtility.singleLineHeight), payload);
        };
        list.drawHeaderCallback = (Rect rect) => {
            EditorGUI.LabelField(rect, "Test Sequence");
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("autoMode"));
        AutoMode = serializedObject.FindProperty("autoMode").boolValue;

        if (!AutoMode) EditorGUILayout.PropertyField(serializedObject.FindProperty("loop"));
        Loop = serializedObject.FindProperty("loop").boolValue;
        if (Loop && !AutoMode)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("loopCycles"));
            LoopCycles = serializedObject.FindProperty("loopCycles").intValue;
        }
        EditorStyles.textField.wordWrap = true;
        if (AutoMode)
        {
            EditorGUILayout.TextField("Load levels will loop through defined sequence until test reaches ImminentThrottling thermal state"
                + " at which point target FPS goes down to 45. Timeout is defined in the control script",
                GUILayout.Height(EditorGUIUtility.singleLineHeight * 3),
                GUILayout.MaxWidth(Screen.width));
        }
        else
        {
            string message = "";
            if (Loop)
                message = "Load levels will follow defined sequence and loop for the defined amount of cycles";
            else
                message = "Load levels will follow defined sequence and stop";
            EditorGUILayout.TextField(message,
                GUILayout.Height(EditorGUIUtility.singleLineHeight * 2),
                GUILayout.MaxWidth(Screen.width));
        }
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
