using UnityEngine;
using UnityEngine.EventSystems;

public class CrozierUI_Choice : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject judgmentUI;
    GameObject go;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (go == null)
        {
            go = Instantiate(judgmentUI);
        }
        else
            go.SetActive(true);
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
