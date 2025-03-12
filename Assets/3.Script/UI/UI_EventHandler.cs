using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler
{
    public Action<PointerEventData> clickAction;

    public void OnPointerClick(PointerEventData eventData)
    {
        clickAction?.Invoke(eventData);
    }
}
