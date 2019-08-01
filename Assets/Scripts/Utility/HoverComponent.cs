using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    private TextMeshProUGUI _targetText = null;

    private void Start()
    {
        _targetText = this.GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Behave(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Behave(false);
    }

    public void OnSelect(BaseEventData baseData)
    {
        Behave(true);
    }

    public void OnDeselect(BaseEventData baseData)
    {
        Behave(false);
    }

    void Behave(bool scale)
    {
        _targetText.transform.localScale = scale ? new Vector3(1.1f, 1.1f, 1.1f) : Vector3.one;
    }
}
