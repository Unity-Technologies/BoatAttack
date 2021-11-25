using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Graphics;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.TestTools.Graphics;

public class BoatAttackGraphicsTestsEditor : IPrebuildSetup, IPostBuildCleanup
{
    private const string DefineKey = "BoatAttack_Tests_ScriptingDefines";
    private static float _oldTimeScale = 1.0f; // give default of 1 just in case

    public void Setup()
    {
        // save current scription defines and set both STATIC_EVERYTHING and LWRP_DEBUG_STATIC_POSTFX
        var defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
        EditorPrefs.SetString(DefineKey, defines);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, "STATIC_EVERYTHING;LWRP_DEBUG_STATIC_POSTFX");
        // store current timescale and set it to 0
        _oldTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        // run base graphics test setup
        SetupGraphicsTestCases.Setup();
    }

    
    public void Cleanup()
    {
        EditorApplication.delayCall += FinalCall;
        Time.timeScale = _oldTimeScale;
        Shader.DisableKeyword("_STATIC_SHADER");
    }

    private static void FinalCall()
    {
        PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, EditorPrefs.GetString(DefineKey));
        EditorPrefs.DeleteKey(DefineKey);
    }
}
