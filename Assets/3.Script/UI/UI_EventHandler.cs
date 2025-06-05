using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Action<PointerEventData> exitAction;
    public Action<PointerEventData> enterAction;

    public void OnPointerEnter(PointerEventData eventData)
    {
        enterAction?.Invoke(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        exitAction?.Invoke(eventData);
    }
}
