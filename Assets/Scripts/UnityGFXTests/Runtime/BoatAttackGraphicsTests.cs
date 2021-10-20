using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Graphics;
using UnityEngine.SceneManagement;

public class BoatAttackGraphicsTests
{

    [UnityTest, Category("BoatAttack")]
    [UseGraphicsTestCases]
    public IEnumerator Run(GraphicsTestCase testCase)
    {
        SceneManager.LoadScene(testCase.ScenePath);
        // Always wait one frame for scene load
        yield return null;
        
        // set time scale again just in case game have changed it
        Time.timeScale = 0f;
        // set the static keyword
        Shader.EnableKeyword("_STATIC_SHADER");
        
        // grab the main camera
        var camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        // add graphics settings if does not exist in the scene
        var settings = Object.FindObjectOfType<BoatAttackGraphicsTestsSettings>();
        if (!settings)
            settings = camera.gameObject.AddComponent<BoatAttackGraphicsTestsSettings>();

        settings = SetTestSettings(settings);

        for (var i = 0; i < settings.WaitFrames; i++)
            yield return new WaitForEndOfFrame();

        ImageAssert.AreEqual(testCase.ReferenceImage, camera, settings.ImageComparisonSettings);
    }

    private static BoatAttackGraphicsTestsSettings SetTestSettings(BoatAttackGraphicsTestsSettings settings)
    {
        settings.ImageComparisonSettings.UseHDR = true;
        settings.ImageComparisonSettings.UseBackBuffer = true;
        settings.ImageComparisonSettings.ActiveImageTests = ImageComparisonSettings.ImageTests.IncorrectPixelsCount;
        settings.ImageComparisonSettings.IncorrectPixelsThreshold = 0.01f;
        settings.WaitFrames = 10;
        settings.ImageComparisonSettings.TargetWidth = 1920;
        settings.ImageComparisonSettings.TargetWidth = 1080;
        return settings;
    }

#if UNITY_EDITOR
    [TearDown]
    public void DumpImagesInEditor()
    {
        UnityEditor.TestTools.Graphics.ResultsUtility.ExtractImagesFromTestProperties(TestContext.CurrentContext.Test);
    }
#endif
}
