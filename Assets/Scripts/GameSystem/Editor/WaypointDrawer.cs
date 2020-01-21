using UnityEditor;
using UnityEngine;
using Unity.Mathematics;
using UnityEditor.Graphs;
using static BoatAttack.WaypointGroup;

[CustomPropertyDrawer(typeof(Waypoint))]
public class WaypointDrawer : PropertyDrawer
{
    private SerializedProperty posProp;
    private SerializedProperty rotProp;
    private SerializedProperty numProp;
    private SerializedProperty widthProp;
    private SerializedProperty checkProp;

    private readonly float vertLine = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing * 2;
    private readonly float vertHeight = EditorGUIUtility.singleLineHeight;
    
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(rect, GUIContent.none, property);
        var labelWidth = EditorGUIUtility.labelWidth;

        posProp = property.FindPropertyRelative("point");
        rotProp = property.FindPropertyRelative("rotation");
        numProp = property.FindPropertyRelative("index");
        widthProp = property.FindPropertyRelative("width");
        checkProp = property.FindPropertyRelative("isCheckpoint");

        var firstLine = rect.y + EditorGUIUtility.standardVerticalSpacing;
        var secondLine = firstLine + vertLine;
        Rect numRect = new Rect(rect.x, firstLine, 25, vertHeight);
        var dynamicWidth = rect.width - numRect.width;
        Rect posRect = new Rect(rect.x + numRect.width + 4, firstLine, dynamicWidth * 0.666f - 4, vertHeight);
        Rect rotRect = new Rect(posRect.x + posRect.width + 4, firstLine, dynamicWidth * 0.333f - 4, vertHeight);
        Rect widthRect = new Rect(rect.x, secondLine, rect.width * 0.5f, vertHeight);
        Rect checkRect = new Rect(rect.x + widthRect.width + 10, secondLine, rect.width * 0.5f - 10, vertHeight);

        GUI.Button(numRect, label.text.Split(' ')[1]); // get array number
        
        float3 rawPos = posProp.vector3Value;
        EditorGUI.BeginChangeCheck();
        rawPos.xz = EditorGUI.Vector2Field(posRect, GUIContent.none, rawPos.xz);
        if (EditorGUI.EndChangeCheck())
        {
            posProp.vector3Value = math.round(rawPos * 100f) / 100f;;
        }
        
        Quaternion rawRot = rotProp.quaternionValue;
        var rot = rawRot.eulerAngles;
        EditorGUI.BeginChangeCheck();
        EditorGUIUtility.labelWidth = 12;
        rot.y = EditorGUI.FloatField(rotRect, "H", rot.y);
        if (EditorGUI.EndChangeCheck())
        {
            rotProp.quaternionValue = Quaternion.Euler(0f, math.round(rot.y), 0f);
        }

        EditorGUIUtility.labelWidth = 60;
        EditorGUI.PropertyField(widthRect, widthProp, new GUIContent("Width", "Width of this waypoint, AI boats will keep within this and checkpoint gates will scale to this width."));
        checkProp.boolValue = EditorGUI.ToggleLeft(checkRect, new GUIContent("Checkpoint", "Is this waypoint a checkpoint in game."), checkProp.boolValue);

        EditorGUIUtility.labelWidth = labelWidth;
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return vertLine * 2f + EditorGUIUtility.standardVerticalSpacing;
    }
}
