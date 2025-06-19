using DG.Tweening;
using System.IO;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TrialRecordController : MonoBehaviour
{
    public TextMeshProUGUI trialRecordText;

    private const int maxLine = 15;

    private int page;
    public int Page
    {
        get => page;
        set
        {
            page = Mathf.Clamp(value, 0, datas.Length / maxLine);
            DisplayRecord();
        }
    }

    TrialRecord trial;
    private string[] datas;

    private void Start()
    {
        trial = GameObject.Find("TrialRecord").GetComponent<TrialRecord>();

        datas = trial.dialogDatas.ToArray();
        Page = 0;

        DisplayRecord();
    }

    void DisplayRecord()
    {
        trialRecordText.text = "";
        for (int i = (Page == 0 ? 1 : (Page * maxLine)); i < Mathf.Clamp((Page == 0 ? 1 : (Page * maxLine)) + maxLine, maxLine, datas.Length); i++)
        {
            trialRecordText.text += datas[i - 1] + "\n";
        }
    }



    public void NextPage()
    {
        Page++;

    }
    public void PrePage()
    {
        Page--;
    }

    public void Hide()
    {
        transform.root.gameObject.SetActive(false);
    }
}
