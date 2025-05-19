using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EndChoice : MonoBehaviour,IPointerClickHandler
{
    public Action clickEvent;


    public void OnPointerClick(PointerEventData eventData)
    {
        clickEvent?.Invoke();
    }
}
