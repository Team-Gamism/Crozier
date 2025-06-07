using System;
using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// 대화 정보를 넣어주는 스크립트
/// </summary>
[CreateAssetMenu(fileName = "DialogSO", menuName = "SO/DialogSO")]
public class DialogSO : ScriptableObject
{
    [SerializeField]
    public List<DialogData> dialogDataList = new List<DialogData>();
}

public enum AnimationType
{
    Normal,
    
}

public enum NextDialogMethod
{
    CountUp,
    Set
}

public enum DialogType
{
    Default,
    Choice,
    Quest,
    Answer
}
