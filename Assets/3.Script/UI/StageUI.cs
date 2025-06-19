using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class StageUI : MonoBehaviour
{
    public StageSO stageSO;

    private void Start()
    {
        UI_EventHandler evt = GetComponent<UI_EventHandler>();
        evt.enterAction += (PointerEventData p) => { transform.DOScale(1.2f, 0.5f); };
        evt.exitAction += (PointerEventData p) => { transform.DOScale(1f, 0.5f); };
    }


}
