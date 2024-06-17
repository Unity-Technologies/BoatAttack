using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class FocusUI : MonoBehaviour
{
    public Color debugColor = Color.green; // Color for the debug draw

    void Update()
    {
        UpdateSelectedUIElement();
    }

    void UpdateSelectedUIElement()
    {
        Selectable currentSelected = EventSystem.current.currentSelectedGameObject?.GetComponent<Selectable>();
        if (currentSelected == null || !currentSelected.gameObject.activeInHierarchy || !IsVisible(currentSelected))
        {
            List<Selectable> visibleSelectables = GetVisibleSelectables();
            Selectable upperLeftSelectable = FindUpperLeftSelectable(visibleSelectables);
            if (upperLeftSelectable != null)
            {
                EventSystem.current.SetSelectedGameObject(upperLeftSelectable.gameObject);
                Debug.Log(upperLeftSelectable.gameObject.name + " is now selected.");
            }
        }
    }

    List<Selectable> GetVisibleSelectables()
    {
        Selectable[] allSelectables = FindObjectsByType<Selectable>(FindObjectsSortMode.None);
        List<Selectable> visibleSelectables = new List<Selectable>();

        foreach (Selectable selectable in allSelectables)
        {
            if (selectable.gameObject.activeInHierarchy && IsVisible(selectable))
            {
                visibleSelectables.Add(selectable);
            }
        }

        return visibleSelectables;
    }

    bool IsVisible(Selectable selectable)
    {
        RectTransform rectTransform = selectable.GetComponent<RectTransform>();
        Rect screenBounds = new Rect(0f, 0f, Screen.currentResolution.width, Screen.currentResolution.height); // Screen space bounds (assumes camera renders across the entire screen)
        return screenBounds.Contains(rectTransform.position);
    }

    Selectable FindUpperLeftSelectable(List<Selectable> selectables)
    {
        Selectable upperLeftSelectable = null;
        Vector2 upperLeftPosition = new Vector2(float.MaxValue, float.MinValue);

        foreach (Selectable selectable in selectables)
        {
            RectTransform rectTransform = selectable.GetComponent<RectTransform>();
            var canvasPoint = rectTransform.position;
            if (canvasPoint.y > upperLeftPosition.y || 
                (canvasPoint.y >= upperLeftPosition.y && canvasPoint.x < upperLeftPosition.x))
            {
                upperLeftPosition = canvasPoint;
                upperLeftSelectable = selectable;
            }
        }

        return upperLeftSelectable;
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        List<Selectable> visibleSelectables = GetVisibleSelectables();
        foreach (Selectable selectable in visibleSelectables)
        {
            if (selectable.gameObject.activeInHierarchy)
            {
                RectTransform rectTransform = selectable.GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    Vector3[] worldCorners = new Vector3[4];
                    rectTransform.GetWorldCorners(worldCorners);
                    DrawRectDebug(worldCorners);
                    DrawPositionDebug(rectTransform);
                }
            }
        }
    }

    void DrawRectDebug(Vector3[] corners)
    {
        Debug.DrawLine(corners[0], corners[1], debugColor);
        Debug.DrawLine(corners[1], corners[2], debugColor);
        Debug.DrawLine(corners[2], corners[3], debugColor);
        Debug.DrawLine(corners[3], corners[0], debugColor);
    }

    void DrawPositionDebug(RectTransform rectTransform)
    {
#if UNITY_EDITOR
        Vector3 position = rectTransform.position;
        Handles.Label(position, $"Canvas Pos: {position}");
#endif
    }
}
