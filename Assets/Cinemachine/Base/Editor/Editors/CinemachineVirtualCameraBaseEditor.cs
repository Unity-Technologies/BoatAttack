using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using Cinemachine.Utility;

namespace Cinemachine.Editor
{
    /// <summary>
    /// Base class for virtual camera editors.
    /// Handles drawing the header and the basic properties.
    /// </summary>
    public class CinemachineVirtualCameraBaseEditor<T> : BaseEditor<T> where T : CinemachineVirtualCameraBase
    {
        static Type[] sExtensionTypes;  // First entry is null
        static string[] sExtensionNames;

        protected override List<string> GetExcludedPropertiesInInspector()
        {
            var excluded = base.GetExcludedPropertiesInInspector();
            if (Target.m_ExcludedPropertiesInInspector != null)
                excluded.AddRange(Target.m_ExcludedPropertiesInInspector);
            return excluded;
        }

        protected virtual void OnEnable()
        {
            if (sExtensionTypes == null)
            {
                // Populate the extension list
                List<Type> exts = new List<Type>();
                List<string> names = new List<string>();
                exts.Add(null);
                names.Add("(select)");
                var allExtensions
                    = ReflectionHelpers.GetTypesInAllLoadedAssemblies(
                            (Type t) => t.IsSubclassOf(typeof(CinemachineExtension)));
                foreach (Type t in allExtensions)
                {
                    exts.Add(t);
                    names.Add(t.Name);
                }
                sExtensionTypes = exts.ToArray();
                sExtensionNames = names.ToArray();
            }
        }

        protected virtual void OnDisable()
        {
            if (CinemachineBrain.SoloCamera == (ICinemachineCamera)Target)
            {
                CinemachineBrain.SoloCamera = null;
                UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
            }
        }

        public override void OnInspectorGUI()
        {
            BeginInspector();
            DrawHeaderInInspector();
            DrawRemainingPropertiesInInspector();
            DrawExtensionsWidgetInInspector();
        }

        protected void DrawHeaderInInspector()
        {
            List<string> excluded = GetExcludedPropertiesInInspector();
            if (!excluded.Contains("Header"))
            {
                DrawCameraStatusInInspector();
                DrawGlobalControlsInInspector();
            }
            ExcludeProperty("Header");
        }

        protected void DrawTargetsInInspector(
            SerializedProperty followTarget, SerializedProperty lookAtTarget)
        {
            List<string> excluded = GetExcludedPropertiesInInspector();
            EditorGUI.BeginChangeCheck();
            if (!excluded.Contains(followTarget.name))
            {
                if (Target.ParentCamera == null || Target.ParentCamera.Follow == null)
                    EditorGUILayout.PropertyField(followTarget);
                else
                    EditorGUILayout.PropertyField(followTarget, 
                        new GUIContent(followTarget.displayName + " Override"));
                ExcludeProperty(followTarget.name);
            }
            if (!excluded.Contains(lookAtTarget.name))
            {
                if (Target.ParentCamera == null || Target.ParentCamera.LookAt == null)
                    EditorGUILayout.PropertyField(lookAtTarget);
                else
                    EditorGUILayout.PropertyField(lookAtTarget, 
                        new GUIContent(lookAtTarget.displayName + " Override"));
                ExcludeProperty(lookAtTarget.name);
            }
            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
        }

        protected void DrawExtensionsWidgetInInspector()
        {
            List<string> excluded = GetExcludedPropertiesInInspector();
            if (!excluded.Contains("Extensions"))
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Extensions", EditorStyles.boldLabel);
                Rect rect = EditorGUILayout.GetControlRect(true, EditorGUIUtility.singleLineHeight);
                rect = EditorGUI.PrefixLabel(rect, new GUIContent("Add Extension"));

                int selection = EditorGUI.Popup(rect, 0, sExtensionNames);
                if (selection > 0)
                {
                    Type extType = sExtensionTypes[selection];
                    if (Target.GetComponent(extType) == null)
                        Undo.AddComponent(Target.gameObject, extType);
                }
                ExcludeProperty("Extensions");
            }
        }

        protected void DrawCameraStatusInInspector()
        {
            // Is the camera navel-gazing?
            CameraState state = Target.State;
            if (state.HasLookAt && (state.ReferenceLookAt - state.CorrectedPosition).AlmostZero())
                EditorGUILayout.HelpBox(
                    "The camera is positioned on the same point at which it is trying to look.", 
                    MessageType.Warning);

            // Active status and Solo button
            Rect rect = EditorGUILayout.GetControlRect(true);
            Rect rectLabel = new Rect(rect.x, rect.y, EditorGUIUtility.labelWidth, rect.height);
            rect.width -= rectLabel.width;
            rect.x += rectLabel.width;

            Color color = GUI.color;
            bool isSolo = (CinemachineBrain.SoloCamera == (ICinemachineCamera)Target);
            if (isSolo)
                GUI.color = CinemachineBrain.GetSoloGUIColor();

            bool isLive = CinemachineCore.Instance.IsLive(Target);
            GUI.enabled = isLive;
            GUI.Label(rectLabel, isLive ? "Status: Live"
                : (Target.isActiveAndEnabled ? "Status: Standby" : "Status: Disabled"));
            GUI.enabled = true;

            float labelWidth = 0;
            GUIContent updateText = GUIContent.none;
            CinemachineCore.UpdateFilter updateMode = CinemachineCore.Instance.GetVcamUpdateStatus(Target);
            if (Application.isPlaying)
            {
                updateText = new GUIContent(
                    updateMode < CinemachineCore.UpdateFilter.Late ? " Fixed Update" : " Late Update");
                var textDimensions = GUI.skin.label.CalcSize(updateText);
                labelWidth = textDimensions.x;
            }
            rect.width -= labelWidth;
            if (GUI.Button(rect, "Solo", "Button"))
            {
                isSolo = !isSolo;
                CinemachineBrain.SoloCamera = isSolo ? Target : null;
                UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
            }
            GUI.color = color;
            if (isSolo)
                UnityEditorInternal.InternalEditorUtility.RepaintAllViews();

            if (labelWidth > 0)
            {
                GUI.enabled = false;
                rect.x += rect.width; rect.width = labelWidth;
                GUI.Label(rect, updateText);
                GUI.enabled = true;
            }
        }

        protected void DrawGlobalControlsInInspector()
        {
            CinemachineSettings.CinemachineCoreSettings.ShowInGameGuides 
                = EditorGUILayout.Toggle(
                    new GUIContent(
                        "Game Window Guides", 
                        "Enable the display of overlays in the Game window.  You can adjust colours and opacity in Edit/Preferences/Cinemachine."), 
                    CinemachineSettings.CinemachineCoreSettings.ShowInGameGuides);

            SaveDuringPlay.SaveDuringPlay.Enabled 
                = EditorGUILayout.Toggle(
                    new GUIContent(
                        "Save During Play", 
                        "If checked, Virtual Camera settings changes made during Play Mode will be propagated back to the scene when Play Mode is exited."), 
                    SaveDuringPlay.SaveDuringPlay.Enabled);

            if (Application.isPlaying && SaveDuringPlay.SaveDuringPlay.Enabled)
                EditorGUILayout.HelpBox(
                    " Virtual Camera settings changes made during Play Mode will be propagated back to the scene when Play Mode is exited.", 
                    MessageType.Info);
        }
    }
}
