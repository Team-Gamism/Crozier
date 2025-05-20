using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CrozierUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject judgmentUI;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Instantiate(judgmentUI);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.Play("Hold");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.Play("Drop");
    }
}
