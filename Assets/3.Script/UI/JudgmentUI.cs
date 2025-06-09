using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JudgmentUI : MonoBehaviour
{
    public TextMeshProUGUI judgement;
    public JudgmentSO judgmentSO;
    [SerializeField] GameObject judgementDialogUI;
    UI_Fade fadeUI;

    int fine =0;
    int imprisonment =0;
    int labor =0;

    List<JudgementType> judgementList = new List<JudgementType>();

    private void Start()
    {
        judgement = Util.FindChild<TextMeshProUGUI>(gameObject,"Judgement",true);
        judgement.text = "";
        fadeUI = FindAnyObjectByType<UI_Fade>();
    }

    public void PlusFine()
    {
        if (fine == 0)
            judgementList.Add(JudgementType.Fine);
        fine++;
        fine = Mathf.Clamp(fine, 0, 99);
        SetJudgementText();
    }

    public void MinusFine()
    {
        if (fine == 1)
            judgementList.Remove(JudgementType.Fine);
        fine--;
        fine = Mathf.Clamp(fine, 0, 99);
        SetJudgementText();
    }

    public void PlusImprisonment()
    {
        if (imprisonment == 0)
            judgementList.Add(JudgementType.Imprisonment);
        imprisonment++;
        imprisonment = Mathf.Clamp(imprisonment, 0, 99);
        SetJudgementText();
    }

    public void MinusImprisonment()
    {
        if (imprisonment == 1)
            judgementList.Remove(JudgementType.Imprisonment);
        imprisonment--;
        imprisonment = Mathf.Clamp(imprisonment, 0, 99);
        SetJudgementText();
    }

    public void PlusLabor()
    {
        if (labor == 0)
            judgementList.Add(JudgementType.Labor);
        labor++;
        labor = Mathf.Clamp(labor, 0, 99);
        SetJudgementText();
    }

    public void MinusLabor()
    {
        if (labor == 1)
            judgementList.Remove(JudgementType.Labor);
        labor--;
        labor = Mathf.Clamp(labor, 0, 99);
        SetJudgementText();
    }

    void SetJudgementText()
    {
        string judgementText = "";
        for(int i = 0; i < judgementList.Count; i++)
        {
            string s = "";
            if (i != 0)
                s = " + ";

            switch (judgementList[i])
            {
                case JudgementType.Fine:
                    s += $"벌금 {fine}데나로";
                    break;
                case JudgementType.Imprisonment:
                    s += $"구금형 {imprisonment}개월";
                    break;
                case JudgementType.Labor:
                    s += $"노동형 {labor}개월";
                    break;
            }
            judgementText += s;
        }
        judgement.text = judgementText;
    }

    public void Judge()
    {
        bool conditionComleted;
        List<JudgementResult> judgementResults = judgmentSO.judgementResultList;
        for (int i = 0;i < judgementResults.Count;i++)
        {
            conditionComplete = 0;
            for (int j = 0;j < judgementResults[i].conditionList.Count;j++)
            {
                switch (judgementResults[i].conditionList[j].judgementType)
                {
                    case JudgementType.Fine:
                        conditionComleted = JudgeFine(judgementResults[i].conditionList[j], judgementResults[i]);
                        if (conditionComleted)
                            return;
                        break;
                    case JudgementType.Imprisonment:
                        conditionComleted = JudgeImprisonment(judgementResults[i].conditionList[j], judgementResults[i]);
                        if (conditionComleted)
                            return;
                        break;
                    case JudgementType.Labor:
                        conditionComleted = JudgeLabor(judgementResults[i].conditionList[j], judgementResults[i]);
                        if (conditionComleted)
                            return;
                        break;
                }
            }
        }
    }

    int conditionComplete = 0;

    bool JudgeFine(Condition condition,JudgementResult judgement)
    {
        if (condition.up)
        {
            if (condition.amount < fine)
            {
                conditionComplete++;
                if (conditionComplete != judgement.conditionList.Count)
                    return false;
                DialogManager dialogManager = Instantiate(judgementDialogUI).GetComponent<DialogManager>();
                dialogManager.dialogSO = judgement.dialogSO;
                dialogManager.dialogDisappearAction = GoMain;
                Destroy(gameObject);
                return true;
            }
            return false;
        }
        else
        {
            if (condition.amount > fine)
            {
                conditionComplete++;
                if (conditionComplete != judgement.conditionList.Count)
                    return false;
                DialogManager dialogManager = Instantiate(judgementDialogUI).GetComponent<DialogManager>();
                dialogManager.dialogSO = judgement.dialogSO;
                dialogManager.dialogDisappearAction = GoMain;
                Destroy(gameObject);
                return true;
            }
            return false;
        }
    }

    bool JudgeImprisonment(Condition condition, JudgementResult judgement)
    {
        if (condition.up)
        {
                if (condition.amount < imprisonment)
                {
                conditionComplete++;
                if (conditionComplete != judgement.conditionList.Count)
                    return false;
                DialogManager dialogManager = Instantiate(judgementDialogUI).GetComponent<DialogManager>();
                dialogManager.dialogSO = judgement.dialogSO;
                dialogManager.dialogDisappearAction = GoMain;
                Destroy(gameObject);
                return true;
            }
            return false;
        }
        else
        {
            if (condition.amount > imprisonment)
            {
                conditionComplete++;
                if (conditionComplete != judgement.conditionList.Count)
                    return false;
                DialogManager dialogManager = Instantiate(judgementDialogUI).GetComponent<DialogManager>();
                dialogManager.dialogSO = judgement.dialogSO;
                dialogManager.dialogDisappearAction = GoMain;
                Destroy(gameObject);
                return true;
            }
            return false;
        }
    }

    bool JudgeLabor(Condition condition, JudgementResult judgement)
    {
        if (condition.up)
        {
            if (condition.amount < labor)
            {
                conditionComplete++;
                if (conditionComplete != judgement.conditionList.Count)
                    return false;
                DialogManager judgeDialogManager = Instantiate(judgementDialogUI).GetComponent<DialogManager>();
                judgeDialogManager.dialogSO = judgement.dialogSO;
                judgeDialogManager.dialogDisappearAction = GoMain;
                Destroy(gameObject);
                return true;
            }
            return false;
        }
        else
        {
            if (condition.amount > labor)
            {
                conditionComplete++;
                if (conditionComplete != judgement.conditionList.Count)
                    return false;
                DialogManager judgeDialogManager = Instantiate(judgementDialogUI).GetComponent<DialogManager>();
                judgeDialogManager.dialogSO = judgement.dialogSO;
                judgeDialogManager.dialogDisappearAction = GoMain;
                Destroy(gameObject);
                return true;
            }
            return false;
        }
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

public enum JudgementType
{
    Fine,
    Imprisonment,
    Labor
}
