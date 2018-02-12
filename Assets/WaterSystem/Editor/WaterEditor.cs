using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using WaterSystem;

[CustomEditor(typeof(Water))]
public class WaterEditor : Editor
{
    GUIStyle largeFont = new GUIStyle();
    //Wave editor
    
	[SerializeField]
    ReorderableList waveList;

    private void OnEnable()
    {
        largeFont.fontStyle = FontStyle.Bold;
        if (EditorGUIUtility.isProSkin)
            largeFont.normal.textColor = Color.white;
        else
            largeFont.normal.textColor = Color.black;
        //Reorderable list stuff////////////////////////////////////////////////
        waveList = new ReorderableList(serializedObject, serializedObject.FindProperty("_waves"), false, true, true, true);

        waveList.drawElementCallback =
        (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = waveList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            //Rects
            Rect ampRect = new Rect(rect.x, rect.y, rect.width * 0.5f, EditorGUIUtility.singleLineHeight);
            Rect dirRect = new Rect(ampRect.x + ampRect.width + 2f, rect.y, rect.width * 0.25f, EditorGUIUtility.singleLineHeight);
            Rect lengthRect = new Rect(dirRect.x + dirRect.width + 2f, rect.y, rect.width * 0.25f, EditorGUIUtility.singleLineHeight);

            EditorGUIUtility.labelWidth = 70f;
            var waveAmp = element.FindPropertyRelative("amplitude");
            waveAmp.floatValue = EditorGUI.Slider(ampRect, "Wave Height", waveAmp.floatValue, 0.01f, 8f);
			EditorGUIUtility.labelWidth = 55f;
            var waveDir = element.FindPropertyRelative("direction");
            waveDir.floatValue = EditorGUI.FloatField(dirRect, "Direction", waveDir.floatValue);
			EditorGUIUtility.labelWidth = 55f;
            var waveLen = element.FindPropertyRelative("wavelength");
            waveLen.floatValue = EditorGUI.FloatField(lengthRect, "Length", waveLen.floatValue);
        };
        //On can remove
        waveList.onCanRemoveCallback = (ReorderableList l) =>
        {
            return l.count > 1;
        };
        //On remove
        waveList.onRemoveCallback = (ReorderableList l) =>
        {
            if (EditorUtility.DisplayDialog("Warning!",
                "Are you sure you want to delete the wave?", "Yes", "No"))
            {
                ReorderableList.defaultBehaviours.DoRemoveButton(l);
            }
        };
        //On add
        waveList.onAddCallback = (ReorderableList l) =>
        {
            var index = l.serializedProperty.arraySize;
            if (index < 10)
            {
                l.serializedProperty.arraySize++;
                l.index = index;
                var element = l.serializedProperty.GetArrayElementAtIndex(index);
                element.FindPropertyRelative("amplitude").floatValue = 0.5f;
                element.FindPropertyRelative("direction").floatValue = Random.Range(-10f, 10f);
                element.FindPropertyRelative("wavelength").floatValue = Random.Range(2f, 8f);
            }
            else
            {
                EditorUtility.DisplayDialog("Warning!", "You have reached the limit of 10 waves for this Water.", "Close");
            }
        };
        //Draw header
        waveList.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "Waves");
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        Water w = target as Water;

        //Draw global water settings
        GUILayout.Space(1f);
        EditorGUILayout.LabelField("General Settings", largeFont);

        var maxDepth = serializedObject.FindProperty("_waterMaxDepth");
        EditorGUILayout.PropertyField(maxDepth, new GUIContent("Maximum Visibility", maxDepthTT), true, null);
        var absorpRamp = serializedObject.FindProperty("_absorptionRampRaw");
        EditorGUILayout.PropertyField(absorpRamp, new GUIContent("Absorption Color", colorRampTT), true, null);
        var scatterRamp = serializedObject.FindProperty("_scatterRampRaw");
        EditorGUILayout.PropertyField(scatterRamp, new GUIContent("Scattering Color", colorRampTT), true, null);

        //Draw wave settings
        GUILayout.Space(1f);
        EditorGUILayout.LabelField("Wave Settings", largeFont);

        var customWaves = serializedObject.FindProperty("_customWaves");
        customWaves.boolValue = EditorGUILayout.Toggle("Custom Waves", customWaves.boolValue);
        if (customWaves.boolValue)
        {
            waveList.DoLayoutList();
        }
        else
        {
            var waveSetting = serializedObject.FindProperty("_basicWaveSettings");
            var waveNum = waveSetting.FindPropertyRelative("numWaves");
            waveNum.intValue = EditorGUILayout.Popup("Number of Wave Layers", waveNum.intValue, numWavesOptions);
            var waveRough = waveSetting.FindPropertyRelative("amplitude");
            waveRough.floatValue = EditorGUILayout.Slider(new GUIContent("Wave Height(Average)"), waveRough.floatValue, 0.1f, 8f);
            var waveDir = waveSetting.FindPropertyRelative("direction");
            waveDir.floatValue = EditorGUILayout.Slider(new GUIContent("Wind Direction"), waveDir.floatValue, 0f, 360f);
            var waveLen = waveSetting.FindPropertyRelative("wavelength");
            waveLen.floatValue = EditorGUILayout.Slider(new GUIContent("Wavelength(Average)"), waveLen.floatValue, 2f, 30f);
            if (GUILayout.Button("Randomize Waves"))
            {
                var randSeed = serializedObject.FindProperty("randomSeed");
                randSeed.intValue = System.DateTime.Now.Millisecond;
            }
        }

        var waveDebug = serializedObject.FindProperty("_debugMode");
        EditorGUILayout.PropertyField(waveDebug);

        serializedObject.ApplyModifiedProperties();

        if(GUI.changed)
        {
            w.ToggleBasicWaves(customWaves.boolValue);
            w.Init();
        }
    }

    void OnSceneGUI()
    {
        Water w = target as Water;
        Camera cam = SceneView.currentDrawingSceneView.camera;
        var waveDebug = serializedObject.FindProperty("_debugMode");
        if (cam && waveDebug.intValue != 0)
        {
            Vector3 pos = Vector3.zero;
            float dist = 10f;
            if (waveDebug.intValue == 2)
            {
                Plane p = new Plane(Vector3.zero, Vector3.forward, Vector3.right);
                
                Ray r = Camera.current.ViewportPointToRay(new Vector2(0.25f, 0.25f));
                if (p.Raycast(r, out dist))
                {
                    pos = Camera.current.ViewportToWorldPoint(new Vector3(0.25f, 0.25f, dist));
                }
            }

            for (int i = w._waves.Count - 1; i >= 0; i--)
            {
                Water.Wave wave = w._waves[i];
                Random.InitState(i);
                Color c = Color.HSVToRGB(Random.Range(0f, 1f), 1f, 1f);
                c.a = Mathf.Clamp01(0.01f * dist - 0.1f) * 0.5f;
                Handles.color = c;
                pos.y = wave.amplitude;
                DrawWaveGizmo(pos, wave.direction, wave.amplitude, wave.wavelength);
            }
        }
    }
    
    void DrawWaveGizmo(Vector3 pos, float angle, float size, float length)
    {
        Handles.DrawSolidDisc(pos, Vector3.up, length / 2f);
        Handles.ArrowHandleCap(0, pos, Quaternion.AngleAxis(angle, Vector3.up), -length / 1.75f, EventType.Repaint);
    }

    string[] numWavesOptions = new string[] { "1 wave(low)", "2 waves(low)", "3 waves(low)", "4 waves(medium)", "5 waves(medium)", "6 waves(default)", "7 waves(high)", "8 waves(high)", "9 waves(high)", "10 waves(max)" };

    //Tooltips/////////////////////////////////////////////////
    private string maxDepthTT = "This controls the max depth of the waters transparency, it also controls the visual color of the water based on depth.";
private string colorRampTT = "This gradient controls the colour of the water from shallow to deep, this will generate a ramp texture in the background and apply it to the water shader.";
private string waveDebugTT = "Debug settings for the waves, debug mode helps to visualize wave direction(arrow), wavelength(circle radius) and wave ampliture(Y offset).\nNone=No debug gizmos\nStatic=Draws wave debug gizmos at the world origin\nScreen=Draws the gizmos in the corner of the screen, they still keep world scale";

}
