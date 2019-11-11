using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuLayout : MonoBehaviour
{
    public UIPopOpen[] catergories;
    public VerticalLayoutGroup layoutGroup;

    private void OnEnable()
    {
        foreach (var popOpen in catergories)
        {
            popOpen.button.onClick.AddListener(delegate { ClickedButton(popOpen); });
        }
    }

    private void OnDisable()
    {
        foreach (var popOpen in catergories)
        {
            popOpen.button.onClick.RemoveListener(delegate { ClickedButton(popOpen); });
        }
    }

    void ClickedButton(UIPopOpen catergory)
    {
        foreach (var cat in catergories)
        {
            if (cat == catergory)
            {
                cat.state = !cat.state;
                cat.panel.sizeDelta = cat.state ? new Vector2(1080f, 600f) : Vector2.zero;
                layoutGroup.padding = new RectOffset(50, 50, cat.state ? 0 : 150, 0);
            }
        }
    }

    [Serializable]
    public class UIPopOpen
    {
        public Button button;
        public RectTransform panel;
        public bool state;
    }
}
