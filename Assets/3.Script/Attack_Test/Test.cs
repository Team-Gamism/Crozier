using UnityEngine;

public class Test : MonoBehaviour
{
    public Enemy enemy;
    public void Attack()
    {

        if (TurnController.Instance.Stamina == 0)
            return;

        TurnController.Instance.Stamina--;
        enemy.TakeDamage(1);

    }
}
