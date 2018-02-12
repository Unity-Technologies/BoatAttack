using UnityEditor;
using UnityEngine;
using Cinemachine.Utility;
using System.Collections.Generic;

namespace Cinemachine.Editor
{
    [CustomEditor(typeof(CinemachineMixingCamera))]
    internal sealed class CinemachineMixingCameraEditor 
        : CinemachineVirtualCameraBaseEditor<CinemachineMixingCamera>
    {
        protected override List<string> GetExcludedPropertiesInInspector()
        {
            List<string> excluded = base.GetExcludedPropertiesInInspector();
            for (int i = 0; i < CinemachineMixingCamera.MaxCameras; ++i)
                excluded.Add(WeightPropertyName(i));
            return excluded;
        }

        static string WeightPropertyName(int i) { return "m_Weight" + i; }

        public override void OnInspectorGUI()
        {
            BeginInspector();
            DrawHeaderInInspector();
            DrawRemainingPropertiesInInspector();

            float totalWeight = 0;
            CinemachineVirtualCameraBase[] children = Target.ChildCameras;
            int numCameras = Mathf.Min(CinemachineMixingCamera.MaxCameras, children.Length);
            for (int i = 0; i < numCameras; ++i)
                if (children[i].isActiveAndEnabled)
                    totalWeight += Target.GetWeight(i);

            if (numCameras == 0)
                EditorGUILayout.HelpBox("There are no Virtual Camera children", MessageType.Warning);
            else 
            {
                EditorGUILayout.Separator();
                EditorGUILayout.LabelField("Child Camera Weights", EditorStyles.boldLabel);
                for (int i = 0; i < numCameras; ++i)
                {
                    SerializedProperty prop = serializedObject.FindProperty(WeightPropertyName(i));
                    if (prop != null)
                        EditorGUILayout.PropertyField(prop, new GUIContent(children[i].Name));
                }
                serializedObject.ApplyModifiedProperties();

                if (totalWeight <= UnityVectorExtensions.Epsilon)
                    EditorGUILayout.HelpBox("No input channels are active", MessageType.Warning);

                if (children.Length > numCameras)
                    EditorGUILayout.HelpBox(
                        "There are " + children.Length 
                        + " child cameras.  A maximum of " + numCameras + " is supported.", 
                        MessageType.Warning);

                // Camera proportion indicator
                EditorGUILayout.Separator();
                EditorGUILayout.LabelField("Mix Result", EditorStyles.boldLabel);
                DrawProportionIndicator(children, numCameras, totalWeight);
            }

            // Extensions
            DrawExtensionsWidgetInInspector();
        }

        void DrawProportionIndicator(
            CinemachineVirtualCameraBase[] children, int numCameras, float totalWeight)
        {
            GUIStyle style = EditorStyles.centeredGreyMiniLabel;
            Color bkg = new Color(0.27f, 0.27f, 0.27f); // ack! no better way than this?
            Color fg = Color.Lerp(CinemachineBrain.GetSoloGUIColor(), bkg, 0.8f);
            float totalHeight = (style.lineHeight + style.margin.vertical) * numCameras;
            Rect r = EditorGUILayout.GetControlRect(true, totalHeight);
            r.height /= numCameras; r.height -= 1;
            float fullWidth = r.width;
            for (int i = 0; i < numCameras; ++i)
            {
                float p = 0;
                string label = children[i].Name;
                if (totalWeight > UnityVectorExtensions.Epsilon)
                {
                    if (children[i].isActiveAndEnabled)
                        p = Target.GetWeight(i) / totalWeight;
                    else
                        label += " (disabled)";
                }
                r.width = fullWidth * p;
                EditorGUI.DrawRect(r, fg);

                Rect r2 = r;
                r2.x += r.width;
                r2.width = fullWidth - r.width;
                EditorGUI.DrawRect(r2, bkg);

                r.width = fullWidth;
                EditorGUI.LabelField(r, label, style);

                r.y += r.height + 1;
            }
        }
    }
}
