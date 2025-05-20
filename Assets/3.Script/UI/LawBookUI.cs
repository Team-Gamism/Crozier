using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class LawBookUI : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField]
    GameObject law;

    RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Instantiate(law);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rect.DOScale(1.1f,0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rect.DOScale(1, 0.5f);
    }
}
