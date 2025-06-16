using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectButtonTextUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(0, 0, 0, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(0, 0, 0, 0f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        image.color = new Color(0, 0, 0, 0f);
    }
}
