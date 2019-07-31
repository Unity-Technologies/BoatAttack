using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneNavigation : MonoBehaviour
{
    public static SceneNavigation Instance = null;

    public Image SceneTransitionImg = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        SceneTransitionImg.CrossFadeAlpha(0f, 0f, true);
        SceneTransitionImg.enabled = true;
    }

    public void LoadSceneAsyncById(int sceneId, LoadSceneMode mode = LoadSceneMode.Single)
    {
        StartCoroutine(LoadSceneAsync_crt(sceneId, mode));
    }

    private IEnumerator LoadSceneAsync_crt(int sceneId, LoadSceneMode mode = LoadSceneMode.Single)
    {
        SceneTransitionImg.CrossFadeAlpha(1.0f, 0.5f, true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneId);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneTransitionImg.CrossFadeAlpha(0.0f, 0.5f, true);
    }
}
