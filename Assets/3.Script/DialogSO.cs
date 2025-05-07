using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

/// <summary>
/// ��ȭ ������ �־��ִ� ��ũ��Ʈ
/// </summary>
[CreateAssetMenu(fileName = "DialogSO", menuName = "SO/DialogSO")]
public class DialogSO : ScriptableObject
{
    public List<DialogData> dialogDataList;
}

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
    public AnimationType animationType;

    public bool isLastDialog;
}

public enum AnimationType
{
    Normal,
    
}
