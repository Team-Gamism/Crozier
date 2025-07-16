using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_OutMap : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] UI_Fade fadeUI;
    RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        fadeUI.FadeIn("MainScene");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rect.DOScale(1.5f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rect.DOScale(1f, 0.3f);
    }
}
