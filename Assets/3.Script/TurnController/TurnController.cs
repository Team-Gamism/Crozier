using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{
    public static TurnController Instance { get { return instance; } }
    private static TurnController instance;

    List<UnityEvent> enemyEvents;

    public BundleSO dices;
    public Transform[] diceViews;
    private void Awake()
    {
        instance = this;
    }

    int turnCnt = 1;
    public void ChangeTurn()
    {
        turnCnt++;

        if (turnCnt % 2 == 0)
        {
            RollDice();
        }
    }

    public void RollDice()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject obj = Instantiate(dices.objs[Random.Range(0, 6)] as GameObject, transform.position, Quaternion.identity, diceViews[i]);
            obj.transform.localPosition = Vector3.zero;
        }
    }
}
