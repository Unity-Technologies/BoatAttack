using System.Collections;
using System.Collections.Generic;
using UnityEditor;

namespace Unity.Entities.Editor
{

    internal class ScriptTemplates
    {
        public const string TemplatesRoot = "Packages/com.unity.entities/Unity.Entities.Editor/ScriptTemplates";
        
        [MenuItem("Assets/Create/ECS/Runtime Component Type")]
        public static void CreateRuntimeComponentType()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(
                $"{TemplatesRoot}/RunTimeComponent.txt",
                "NewComponent.cs");
        }
        
        [MenuItem("Assets/Create/ECS/Authoring Component Type")]
        public static void CreateAuthoringComponentType()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(
                $"{TemplatesRoot}/AuthoringComponent.txt",
                "NewComponent.cs");
        }

        [MenuItem("Assets/Create/ECS/System")]
        public static void CreateSystem()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(
                $"{TemplatesRoot}/System.txt",
                "NewSystem.cs");
        }
    }

}