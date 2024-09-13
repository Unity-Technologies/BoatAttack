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

    bool IsCurrentSelectedInvalid()
    {
        Selectable currentSelected = EventSystem.current.currentSelectedGameObject?.GetComponent<Selectable>();
        return currentSelected == null || !currentSelected.gameObject.activeInHierarchy || !IsVisible(currentSelected);
    }

    void UpdateSelectedUIElement()
    {
        if (IsCurrentSelectedInvalid())
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
        Canvas[] allCanvases = FindObjectsByType<Canvas>(FindObjectsSortMode.None);
        List<Selectable> visibleSelectables = new List<Selectable>();

        foreach (Canvas canvas in allCanvases)
        {
            if (canvas.gameObject.activeInHierarchy == false)
                continue;

            RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
            Selectable[] selectables = canvas.GetComponentsInChildren<Selectable>();

            foreach (Selectable selectable in selectables)
            {
                RectTransform selectableRectTransform = selectable.GetComponent<RectTransform>();
                if (selectable.gameObject.activeInHierarchy && IsWithinBounds(selectableRectTransform, canvasRectTransform))
                    visibleSelectables.Add(selectable);
            }
        }

        return visibleSelectables;
    }

    public bool IsWithinBounds(RectTransform child, RectTransform parent)
    {
        Vector3[] childCorners = new Vector3[4];
        Vector3[] parentCorners = new Vector3[4];

        child.GetWorldCorners(childCorners);
        parent.GetWorldCorners(parentCorners);

        // Convert corners into a bounding box (Rect) in screen space
        Rect childRect = GetScreenSpaceRect(childCorners);
        Rect parentRect = GetScreenSpaceRect(parentCorners);

        return childRect.Overlaps(parentRect);
    }

    private Rect GetScreenSpaceRect(Vector3[] corners)
    {
        Vector3 bottomLeft = corners[0];
        Vector3 topRight = corners[2];

        return new Rect(bottomLeft.x, bottomLeft.y, topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);
    }

    bool IsVisible(Selectable selectable)
    {
        RectTransform childRectTransform = selectable.GetComponent<RectTransform>();
        RectTransform parentRectTransform = selectable.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        return IsWithinBounds(childRectTransform, parentRectTransform);
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
