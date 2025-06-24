using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class StageUI : MonoBehaviour
{
    public int index;
    public StageSO stageSO;

    public void EnterAction()
    {
        transform.DOScale(1.2f, 0.5f);
    }

    public void ExitAction()
    {
        transform.DOScale(1f, 0.5f);
    }
}
