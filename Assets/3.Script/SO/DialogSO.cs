using System;
using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// ��ȭ ������ �־��ִ� ��ũ��Ʈ
/// </summary>
[CreateAssetMenu(fileName = "DialogSO", menuName = "SO/DialogSO")]
public class DialogSO : ScriptableObject
{
    public List<DialogData> dialogDataList;
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
    Choice
}
