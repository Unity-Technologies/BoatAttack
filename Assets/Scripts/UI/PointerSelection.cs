using UnityEngine;
using UnityEngine.EventSystems;

public class PointerSelection : MonoBehaviour
{
    public static void NullSelection()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
    
    public static void SetSelection(GameObject gameObject)
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}
