using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CrozierUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject judgmentUI;
    [SerializeField] JudgmentSO judgmentSO;
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
            go.GetComponent<JudgmentUI>().judgmentSO = judgmentSO;
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
