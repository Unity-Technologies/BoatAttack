using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.Entities;
using Unity.Profiling;
using UnityEditor;
using UnityEngine;

namespace Unity.Scenes.Editor
{
    [InitializeOnLoad]
    class ConversionWarningsGui
    {
        static ProfilerMarker ms_ConversionWarningsMarker = new ProfilerMarker("ConversionWarningsGUI.ConversionWarnings");

        static ConversionWarningsGui()
        {
            UnityEditor.Editor.finishedDefaultHeaderGUI += Callback;
        }

        public static void Callback(UnityEditor.Editor editor)
        {
            ms_ConversionWarningsMarker.Begin();
            var warning = GetWarning(editor);
            
            if (warning != null)
                EditorGUILayout.HelpBox(warning, MessageType.Error, true);
            ms_ConversionWarningsMarker.End();
        }
        
        static string GetWarning(UnityEditor.Editor editor)
        {            
            var gameobject = editor.target as GameObject;
            if (gameobject == null)
                return null;

            return GetWarnings(gameobject);
        }

        public static string GetWarnings(GameObject gameobject)
        {
            var isSubScene = EditorEntityScenes.IsEntitySubScene(gameobject.scene);
            var convertToEntity = gameobject.GetComponentInParent<ConvertToEntity>() != null;

            var willBeConverted = convertToEntity | isSubScene;

            if (!willBeConverted)
            {
                Type convertType = null;
                foreach (var behaviour in gameobject.GetComponents<MonoBehaviour>())
                {
                    if (behaviour != null && behaviour.GetType().GetCustomAttribute<RequiresEntityConversionAttribute>(true) != null)
                    {
                        convertType = behaviour.GetType();
                        break;
                    }
                }

                if (convertType != null)
                    return $"The {convertType.Name} component on '{gameobject.name}' is meant for entity conversion, but it is not part of a SubScene or ConvertToEntity component.\nPlease move the game object to a SubScene or add the ConvertToEntity component.";
            }

            if (isSubScene && convertToEntity)
                return $"'{gameobject.name}' will be converted due to being in a SubScene. ConvertToEntity will have no effect.\nPlease remove the ConvertToEntity component.";
            
            if (isSubScene && gameobject.GetComponent<GameObjectEntity>() != null)
                return $"'{gameobject.name}' will be converted due to being in a SubScene. GameObjectEntity will have no effect the game object will not be loaded.\nPlease remove the GameObjectEntity component";

            if (convertToEntity && gameobject.GetComponent<GameObjectEntity>() != null)
                return $"'{gameobject.name}' will be converted due to being in a ConvertToEntity hierarchy. GameObjectEntity will have no effect.\nPlease remove the GameObjectEntity component.";

            return null;
        }
    }
}
