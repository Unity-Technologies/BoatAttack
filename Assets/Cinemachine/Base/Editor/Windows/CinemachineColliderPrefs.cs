using UnityEngine;
using UnityEditor;

using Cinemachine.Editor;

namespace Cinemachine
{
    [InitializeOnLoad]
    internal static class CinemachineColliderPrefs
    {
        private static bool SettingsFoldedOut
        {
            get { return EditorPrefs.GetBool(kColliderSettingsFoldoutKey, false); }
            set
            {
                if (value != SettingsFoldedOut)
                {
                    EditorPrefs.SetBool(kColliderSettingsFoldoutKey, value);
                }
            }
        }

        public static Color FeelerHitColor
        {
            get
            {
                return CinemachineSettings.UnpackColour(EditorPrefs.GetString(kFeelerHitColourKey, CinemachineSettings.PackColor(Color.yellow)));
            }

            set
            {
                if (value != FeelerHitColor)
                {
                    EditorPrefs.SetString(kFeelerHitColourKey, CinemachineSettings.PackColor(value));
                }
            }
        }

        public static Color FeelerColor
        {
            get
            {
                return CinemachineSettings.UnpackColour(EditorPrefs.GetString(kFeelerColourKey, CinemachineSettings.PackColor(Color.gray)));
            }

            set
            {
                if (value != FeelerColor)
                {
                    EditorPrefs.SetString(kFeelerColourKey, CinemachineSettings.PackColor(value));
                }
            }
        }

        private const string kColliderSettingsFoldoutKey  = "CNMCN_Collider_Foldout";
        private const string kFeelerHitColourKey          = "CNMCN_Collider_FeelerHit_Colour";
        private const string kFeelerColourKey             = "CNMCN_Collider_Feeler_Colour";

        static CinemachineColliderPrefs()
        {
            Cinemachine.Editor.CinemachineSettings.AdditionalCategories += DrawColliderSettings;
        }

        private static void DrawColliderSettings()
        {
            SettingsFoldedOut = EditorGUILayout.Foldout(SettingsFoldedOut, "Collider Settings");
            if (SettingsFoldedOut)
            {
                EditorGUI.indentLevel++;

                EditorGUI.BeginChangeCheck();

                FeelerHitColor   = EditorGUILayout.ColorField("Feeler Hit", FeelerHitColor);
                FeelerColor = EditorGUILayout.ColorField("Feeler", FeelerColor);

                if (EditorGUI.EndChangeCheck())
                {
                    UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
                }

                EditorGUI.indentLevel--;
            }
        }
    }
}
