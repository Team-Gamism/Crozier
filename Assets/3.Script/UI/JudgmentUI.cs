using TMPro;
using UnityEngine;

public class JudgmentUI : MonoBehaviour
{
    [SerializeField]
    GameObject judgment;
    [SerializeField]
    JudgmentSO judgmentSO;

    Transform choiceGrid;
    void Start()
    {
        choiceGrid = Util.FindChild(gameObject, "ChoiceGrid", true).transform;
        ShowJudgment();
    }

    void ShowJudgment()
    {
        for (int i = 0; i < judgmentSO.judgmentList.Count; i++)
        {
            SetJudgment(Instantiate(judgment,choiceGrid), judgmentSO.judgmentList[i]);
        }
        SetJudgment(Instantiate(judgment,choiceGrid), "좀 더 고민한다");
    }

    void SetJudgment(GameObject go,string detail)
    {
        TextMeshProUGUI textUI = Util.FindChild<TextMeshProUGUI>(go);
        textUI.text = detail;
    }
}
