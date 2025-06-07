using DG.Tweening;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrialRecord : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    GameObject law;

    GameObject recordObj;

    RectTransform rect;

    public List<string> dialogDatas = new List<string>();

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (recordObj == null)
            recordObj = Instantiate(law);
        else
            recordObj.SetActive(true);
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
