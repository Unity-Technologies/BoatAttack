using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEditor.TestTools.CodeCoverage;
using UnityEngine.SceneManagement;

public class GenerateCodeCoverage : MonoBehaviour
{
    public static string[] scenes;

    public static void SceneBasedCoverage()
    {
        EditorSettings.enterPlayModeOptionsEnabled = true;
        EditorSettings.enterPlayModeOptions = EnterPlayModeOptions.DisableDomainReload;

        scenes = GetScenes();

        EditorApplication.update += Processing;

        EditorApplication.EnterPlaymode();
        CodeCoverage.StartRecording();
    }
    private static string[] GetScenes()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        scenes = new string[sceneCount];
        for (int i = 0; i < sceneCount; i++)
        {
            scenes[i] = SceneUtility.GetScenePathByBuildIndex(i);
        }
        return scenes;
    }

    private static void Processing()
    {
        if (EditorApplication.isPlaying && !EditorApplication.isPaused)
        {
            if (scenes.Length > 0)
            {
                CodeCoverage.UnpauseRecording();
                SceneManager.LoadScene(scenes[0]);

                while (!SceneManager.GetActiveScene().isLoaded) {}

                CodeCoverage.PauseRecording();
                scenes = scenes.Where(w => w != scenes[0]).ToArray();
            }
            else
            {
                EditorApplication.ExitPlaymode();
                CodeCoverage.PauseRecording();

                EditorApplication.update -= Processing;
                
                EditorSettings.enterPlayModeOptionsEnabled = false;

                EditorApplication.Exit(0);
            }
        }
    }
}