using System.Collections;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] DialogSO dialogSO;
    [SerializeField] TypingText textUI;
    bool canDoNextDialog = false;
    bool isLastDialog = false;
    int dialogIndex = 0;
    private void Start()
    {
        textUI.lastDialogAction = EndDialog;

        StartDialog();
        StartCoroutine(CInputNextDialog());
    }

    void EndDialog()
    {
        canDoNextDialog = true;
    } 

    void StartDialog()
    {
        textUI.TypeingText(dialogSO.dialogDataList[dialogIndex]);
    }

    void NextDialog()
    {
        dialogIndex++;
        if(dialogIndex + 1 == dialogSO.dialogDataList.Count)
            isLastDialog = true;

        textUI.TypeingText(dialogSO.dialogDataList[dialogIndex]);
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
            if (canDoNextDialog)
                continue;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X))
            {
                if (!isLastDialog)
                    NextDialog();
                else
                    Disappear();
            }
        }
    }
}
