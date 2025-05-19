using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class DialogData
{
    [Header("대화 내용 삽입")]
    public string textData;

    [Header("타이핑 시간")]
    public float typingTime;

    [Header("대화 캐릭터 이름")]
    public string speakerName;

    [Header("캐릭터 애니메이션")]
    public bool isUsedAnimation;
    public AnimationType animationType;

    [Header("다음 다이얼로그 Index")]
    public NextDialogMethod nextDialogMethod;
    public int nextDialogIndex;

    [Header("다이얼로그 타입")]
    public DialogType dialogType;
    public List<ChoiceData> choiceList;

    [Space(10)]
    public bool isLastDialog;
}
