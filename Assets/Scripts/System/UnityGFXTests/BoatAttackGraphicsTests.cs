using System.Collections;
using NUnit.Framework;
using UnityEditor.Compilation;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.TestTools.Graphics;
#endif
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Graphics;
using UnityEngine.SceneManagement;

public class BoatAttackGraphicsTests : IPrebuildSetup, IPostBuildCleanup
{
    const string defineKey = "BoatAttackKey";
    
    public void Setup()
    {
        var defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
        EditorPrefs.SetString(defineKey, defines);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, "STATIC_EVERYTHING;LWRP_DEBUG_STATIC_POSTFX");
        SetupGraphicsTestCases.Setup();
    }
    
    
    [UnityTest, Category("BoatAttack")]
    //[PrebuildSetup("SetupGraphicsTestCases")]
    [UseGraphicsTestCases]
    public IEnumerator Run(GraphicsTestCase testCase)
    {
        SceneManager.LoadScene(testCase.ScenePath);
        
        // Always wait one frame for scene load
        yield return null;

        var ts = Time.timeScale;
        Time.timeScale = 0f;
        
        var camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        var settings = Object.FindObjectOfType<BoatAttackGraphicsTestsSettings>();
        if (!settings)
            settings = camera.gameObject.AddComponent<BoatAttackGraphicsTestsSettings>();

        settings.ImageComparisonSettings.UseHDR = true;
        settings.ImageComparisonSettings.UseBackBuffer = true;
        settings.ImageComparisonSettings.ActiveImageTests = ImageComparisonSettings.ImageTests.IncorrectPixelsCount;
        settings.ImageComparisonSettings.IncorrectPixelsThreshold = 0.001f;
        settings.WaitFrames = 10;

        settings.ImageComparisonSettings.TargetWidth = 1920;
        settings.ImageComparisonSettings.TargetWidth = 1080;

#if STATIC_EVERYTHING
        Debug.Log("hello, this worked");
#endif
        
        for (int i = 0; i < settings.WaitFrames; i++)
            yield return new WaitForEndOfFrame();

        ImageAssert.AreEqual(testCase.ReferenceImage, camera, settings.ImageComparisonSettings);

        Time.timeScale = ts;
    }
    

#if UNITY_EDITOR
    [TearDown]
    public void DumpImagesInEditor()
    {
        UnityEditor.TestTools.Graphics.ResultsUtility.ExtractImagesFromTestProperties(TestContext.CurrentContext.Test);
    }
#endif
    
    public void Cleanup()
    {
        EditorApplication.delayCall += Call;
    }

    static void Call()
    {
        PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, EditorPrefs.GetString(defineKey));
    }
}
