
using System.Collections.Generic;
using UnityEngine;

public class JudgmentUI_Choice : MonoBehaviour
{
    [SerializeField] GameObject judgementDialogUI;
    [SerializeField] List<DialogSO> judgments;
    [SerializeField] List<int> reputationAmountList;
    UI_Fade fadeUI;
    private void Start()
    {
        fadeUI = FindAnyObjectByType<UI_Fade>();
    }

    public void Choice(int index)
    {
        DialogManager dialogManager = Instantiate(judgementDialogUI).GetComponent<DialogManager>();
        dialogManager.dialogSO = judgments[index];
        SingleTon<GameManager>.Instance.reputation += reputationAmountList[index];
        dialogManager.dialogDisappearAction = GoMain;
        Destroy(gameObject);
    }
    void GoMain()
    {
        fadeUI.FadeIn("Map");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
