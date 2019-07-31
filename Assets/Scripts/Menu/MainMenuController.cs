using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    enum MainMenuAction
    {
        DemoScene = 0,
        Play,
        Exit
    }

    public Button[] MainMenuButtons;

    private void Start()
    {
        for (int i = 0; i < MainMenuButtons.Length; i++)
        {
            TriggerMainMenuAction((MainMenuAction)i);
        }
    }

    private void TriggerMainMenuAction(MainMenuAction menuActionType)
    {
        MainMenuButtons[(int)menuActionType].onClick.AddListener(() =>
        {
            switch (menuActionType)
            {
                case MainMenuAction.DemoScene:
                    break;
                case MainMenuAction.Play:
                    SceneNavigation.Instance.LoadSceneAsyncById(1);
                    break;
                case MainMenuAction.Exit:
                    Application.Quit();
                    break;
            }
        });
    }
}
