
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager>
{
    public bool isIntroShown;

    public int reputation;

    public List<bool> completeJudgementList;

    public bool isStartedNewGame;
}
