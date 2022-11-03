using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerSelection : MonoBehaviour
{
    public enum Mode
    {
        None,
        OnStart,
        OnEnable,
    }
    
    public Mode autoMode = Mode.None;

    private void Start()
    {
        if (autoMode == Mode.OnStart)
        {
            SetSelection(gameObject);
        }
    }

    private void OnEnable()
    {
        if (autoMode == Mode.OnEnable)
        {
            SetSelection(gameObject);
        }
    }

    public static void NullSelection()
    {
        if(EventSystem.current)
            EventSystem.current.SetSelectedGameObject(null);
    }
    
    public static void SetSelection(GameObject gameObject)
    {
        if(EventSystem.current)
            EventSystem.current.SetSelectedGameObject(gameObject ? gameObject : null);
    }
}
