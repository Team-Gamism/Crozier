using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

/// <summary>
/// 대화 정보를 넣어주는 스크립트
/// </summary>
[CreateAssetMenu(fileName = "DialogSO", menuName = "SO/DialogSO")]
public class DialogSO : ScriptableObject
{
    public List<DialogData> dialogDataList;
}

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
    public AnimationType animationType;

    public bool isLastDialog;
}

public enum AnimationType
{
    Normal,
    
}
