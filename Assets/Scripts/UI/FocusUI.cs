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
        List<Selectable> visibleSelectables = GetVisibleSelectables();

        Selectable currentSelected = EventSystem.current.currentSelectedGameObject?.GetComponent<Selectable>();

        if (currentSelected == null || !currentSelected.gameObject.activeInHierarchy || !IsVisible(currentSelected))
        {
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
        Selectable[] allSelectables = FindObjectsOfType<Selectable>();
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
        if(rectTransform.position.x < 0)
            return false;
        Rect screenBounds = new Rect(0f, 0f, Screen.width, Screen.height); // Screen space bounds (assumes camera renders across the entire screen)
        Vector3[] objectCorners = new Vector3[4];
        //rectTransform.GetWorldCorners(objectCorners);

        //Vector3 tempScreenSpaceCorner; // Cached
        //for (var i = 0; i < objectCorners.Length; i++) // For each corner in rectTransform
        {
            //tempScreenSpaceCorner = Camera.main.WorldToScreenPoint(objectCorners[i]); // Transform world space position of corner to screen space
            if (screenBounds.Contains(rectTransform.position)) // If the corner is inside the screen
            {
                // At least one corner of the UI element is visible in the canvas
                return true;
            }
        }

        return false;
    }

    Selectable FindUpperLeftSelectable(List<Selectable> selectables)
    {
        Selectable upperLeftSelectable = null;
        Vector2 upperLeftPosition = new Vector2(float.MinValue, float.MinValue);

        foreach (Selectable selectable in selectables)
        {
            RectTransform rectTransform = selectable.GetComponent<RectTransform>();
            Vector3[] worldCorners = new Vector3[4];
            rectTransform.GetWorldCorners(worldCorners);

            foreach (Vector3 corner in worldCorners)
            {
                Vector2 viewportPoint = Camera.main.WorldToViewportPoint(corner);
                Vector2 canvasPoint = new Vector2(viewportPoint.x * Screen.width, viewportPoint.y * Screen.height);

                if (canvasPoint.y > upperLeftPosition.y ||
                     (canvasPoint.y == upperLeftPosition.y && canvasPoint.x < upperLeftPosition.x))
                {
                    upperLeftPosition = canvasPoint;
                    upperLeftSelectable = selectable;
                }
            }
        }

        return upperLeftSelectable;
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Selectable[] allSelectables = FindObjectsOfType<Selectable>();
        foreach (Selectable selectable in allSelectables)
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
