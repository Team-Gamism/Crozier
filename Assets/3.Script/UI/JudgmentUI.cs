using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JudgmentUI : MonoBehaviour
{
    public TextMeshProUGUI judgement;

    int fine =0;
    int imprisonment =0;
    int labor =0;

    List<JudgementType> judgementList = new List<JudgementType>();

    private void Start()
    {
        judgement = Util.FindChild<TextMeshProUGUI>(gameObject,"Judgement",true);
        judgement.text = "";
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
                    s += $"구금형 {imprisonment}일";
                    break;
                case JudgementType.Labor:
                    s += $"노동형 {labor}일";
                    break;
            }
            judgementText += s;
        }
        judgement.text = judgementText;
    }

    public void Judge()
    {

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

enum JudgementType
{
    Fine,
    Imprisonment,
    Labor
}
