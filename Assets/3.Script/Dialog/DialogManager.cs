using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField]public DialogSO dialogSO;
    [SerializeField] TypingText textUI;
    [SerializeField] GameObject choice;
    [SerializeField] GameObject endChoice;

    [SerializeField]
    Animator anim;

    TextMeshProUGUI nameText;

    Transform choiceGrid;

    List<ChoiceData> choiceList = new List<ChoiceData>();

    bool addedChoices;

    #region Actions
    public Action dialogStartAction;
    public Action dialogDisappearAction;
    #endregion

    bool canDoNextDialog = false;
    int dialogIndex = 0;

    private DialogData curDialogData; 

    private void Start()
    {
        choiceGrid = Util.FindChild(gameObject,"ChoiceGrid",true).transform;
        nameText = Util.FindChild<TextMeshProUGUI>(gameObject,"NameText",true);


        textUI.endDialogAction += EndDialog;

        SetDialogData(dialogIndex);
        StartDialog();
        StartCoroutine(CInputNextDialog());
    }

    void EndDialog()
    {
        if (curDialogData.dialogType == DialogType.Choice)
        {
            Make_Choice();
        }
        else
        {
            canDoNextDialog = true;
        }
    } 

    void StartDialog()
    {
        textUI.StopDialogSign();
        if (curDialogData.dialogType == DialogType.Choice)
        {
            Remove_AllChoice();
            Add_ChoicList();
            textUI.TypeingText(curDialogData);
        }
        else
        {
            textUI.TypeingText(curDialogData);
        }
        SetName();

        //여기서 curDialogData.textData랑 curDialogData.speakerName
    }

    void NextDialog()
    {
        canDoNextDialog = false;

        if (curDialogData.nextDialogMethod == NextDialogMethod.CountUp)
            dialogIndex++;
        else
            dialogIndex = curDialogData.nextDialogIndex;
        SetDialogData(dialogIndex);
        StartDialog();
    }

    void SetDialogData(int dialogIndex)
    {
        curDialogData = dialogSO.dialogDataList[dialogIndex];
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

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
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

    #region 선택지
    void Add_ChoicList()
    {
        if (addedChoices)
            return;
        for (int i = 0; i < curDialogData.choiceList.Count; i++)
        {
            choiceList.Add(curDialogData.choiceList[i]);
        }
        addedChoices = true;
    }
    void Make_Choice()
    {
        for (int i = 0; i < choiceList.Count; i++)
        {
            Choice _choice = Instantiate(choice, choiceGrid).GetComponent<Choice>();
            _choice.choiceData = choiceList[i];
            _choice.Init();
            _choice.clickEvent = ClickChoiceEvent;
        }
        Make_EndChoic();
    }

    void Remove_AllChoiceList()
    {
        choiceList = new List<ChoiceData>();
    }

    void Remove_AllChoice()
    {
       foreach(Transform child in choiceGrid.transform)
        {
            Destroy(child.gameObject);
        }
    }

    //질문이 없을 때 누르는 선택지
    void Make_EndChoic()
    {
        EndChoice _choice = Instantiate(endChoice, choiceGrid).GetComponent<EndChoice>();
        _choice.clickEvent = ClickEndChoiceEvent;
    }

    void ClickChoiceEvent(ChoiceData choice)
    {
        dialogIndex = choice.startDialogIndex;
        choiceList.Remove(choice);
        InvisibleChoice();
        SetDialogData(dialogIndex);
        StartDialog();
    }

    void ClickEndChoiceEvent()
    {
        Remove_AllChoice();
        Remove_AllChoiceList();
        dialogIndex = curDialogData.nextDialogIndex;
        addedChoices = false;
        SetDialogData(dialogIndex);
        StartDialog();
    }

    void InvisibleChoice()
    {
        foreach (Transform child in choiceGrid.transform)
        {
            if (child.TryGetComponent<Choice>(out var choice))
            {
                if (!choiceList.Contains(choice.choiceData))
                    child.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
                else
                    child.GetComponent<Image>().color = new Color32(0, 0, 0, 0);

                choice.clickEvent = null;
            }
            else
            {
                child.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                child.GetComponent<EndChoice>().clickEvent = null;
            }
        }
    }
    #endregion

}
