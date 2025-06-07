using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        rect.DOScale(1.1f, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rect.DOScale(1, 0.5f);
    }
}
