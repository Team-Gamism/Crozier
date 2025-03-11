using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{
    public static TurnController Instance { get { return instance; } }
    private static TurnController instance;

    private int maxStamina = 4;
    public int Stamina
    {
        get => stamina;
        set
        {
            stamina = Mathf.Clamp(value, 0, maxStamina);
            staminaBar.value = Stamina;
        }
    }
    private int stamina;

    List<UnityEvent> enemyEvents;

    public BundleSO dices;
    public Transform[] diceViews;

    [SerializeField] Slider staminaBar;

    private void Awake()
    {
        instance = this;
        Stamina = maxStamina;
    }

    int turnCnt = 1;
    public void ChangeTurn()
    {
        turnCnt++;

        if (turnCnt % 2 == 0)
        {
            RollDice();

            Stamina = maxStamina;
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
