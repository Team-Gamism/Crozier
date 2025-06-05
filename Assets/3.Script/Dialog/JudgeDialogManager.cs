using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JudgeDialogManager : MonoBehaviour
{
    public List<DialogData> dialogList;

    TextMeshProUGUI nameText;
    DialogData curDialogData;
    [SerializeField] TypingText textUI;

    int dialogIndex = 0;
    bool canDoNextDialog;

    private void Start()
    {
        nameText = Util.FindChild<TextMeshProUGUI>(gameObject, "NameText", true);


        textUI.endDialogAction += EndDialog;

        SetDialogData(dialogIndex);
        StartDialog();
        StartCoroutine(CInputNextDialog());
    }

    void EndDialog()
    {
        canDoNextDialog = true;
    }

    void StartDialog()
    {
        textUI.StopDialogSign();
       
        textUI.TypeingText(curDialogData);
        SetName();

    }

    void NextDialog()
    {
        canDoNextDialog = false;

        dialogIndex++;
       
        SetDialogData(dialogIndex);
        StartDialog();
    }

    void SetDialogData(int dialogIndex)
    {
        curDialogData = dialogList[dialogIndex];
    }

    void Disappear()
    {
        gameObject.SetActive(false);
    }

    IEnumerator CInputNextDialog()
    {
        while (true)
        {
            yield return null;
            if (!canDoNextDialog)
                continue;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X))
            {
                if (!curDialogData.isLastDialog)
                    NextDialog();
                else
                    Disappear();
            }
        }
    }

    void SetName()
    {
        nameText.text = curDialogData.speakerName;
    }
}
