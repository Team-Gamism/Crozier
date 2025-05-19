using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class DialogData
{
    [Header("��ȭ ���� ����")]
    public string textData;

    [Header("Ÿ���� �ð�")]
    public float typingTime;

    [Header("��ȭ ĳ���� �̸�")]
    public string speakerName;

    [Header("ĳ���� �ִϸ��̼�")]
    public bool isUsedAnimation;
    public AnimationType animationType;

    [Header("���� ���̾�α� Index")]
    public NextDialogMethod nextDialogMethod;
    public int nextDialogIndex;

    [Header("���̾�α� Ÿ��")]
    public DialogType dialogType;
    public List<ChoiceData> choiceList;

    [Space(10)]
    public bool isLastDialog;
}
