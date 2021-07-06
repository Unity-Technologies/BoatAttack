using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Graphics;
using UnityEngine.SceneManagement;

public class BoatAttackGraphicsTests
{
    
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, "STATIC_EVERYTHING");
        return null;
    }
    
    
    [UnityTest, Category("BoatAttack")]
    [PrebuildSetup("SetupGraphicsTestCases")]
    [UseGraphicsTestCases]
    public IEnumerator Run(GraphicsTestCase testCase)
    {
        SceneManager.LoadScene(testCase.ScenePath);

        // Always wait one frame for scene load
        yield return null;

        var camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        var settings = Object.FindObjectOfType<BoatAttackGraphicsTestsSettings>();
        if (!settings)
            settings = camera.gameObject.AddComponent<BoatAttackGraphicsTestsSettings>();

        settings.ImageComparisonSettings.UseHDR = true;
        settings.ImageComparisonSettings.UseBackBuffer = true;
        settings.ImageComparisonSettings.ActiveImageTests = ImageComparisonSettings.ImageTests.IncorrectPixelsCount;
        settings.WaitFrames = 5;

        settings.ImageComparisonSettings.TargetWidth = 1280;
        settings.ImageComparisonSettings.TargetWidth = 720;

#if STATIC_EVERYTHING
        Debug.Log("hello, this worked");
#endif
        
        for (int i = 0; i < settings.WaitFrames; i++)
            yield return new WaitForEndOfFrame();

        ImageAssert.AreEqual(testCase.ReferenceImage, camera, settings.ImageComparisonSettings);
    }
    

#if UNITY_EDITOR
    [TearDown]
    public void DumpImagesInEditor()
    {
        UnityEditor.TestTools.Graphics.ResultsUtility.ExtractImagesFromTestProperties(TestContext.CurrentContext.Test);
    }
#endif
    
/*    [TearDown]
    public void TearDown()
    {
        
    }*/
}
