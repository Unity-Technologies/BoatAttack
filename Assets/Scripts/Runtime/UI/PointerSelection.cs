using UnityEngine;
using UnityEngine.EventSystems;

public class PointerSelection : MonoBehaviour
{
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
