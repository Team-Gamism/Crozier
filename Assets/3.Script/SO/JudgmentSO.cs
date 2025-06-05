using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JudgmentSO", menuName = "SO/JudgmentSO")]
public class JudgmentSO : ScriptableObject
{
    public List<JudgementResult> judgementResultList;
}

[Serializable]
public class JudgementResult
{
    public List<Condition> conditionList;
    public DialogSO dialogSO;
}

[Serializable]
public class Condition
{
    public JudgementType judgementType;
    public int amount;
    public bool up;
}