using System;
using UnityEngine;

[Serializable]
public class ChoiceData
{
    [Header("선택 했을 때 시작할 대화 index")]
    public int startDialogIndex;

    [Header("선택지 Text")]
    public string choiceText;
}
