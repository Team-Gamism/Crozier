using UnityEngine;

public class Test : MonoBehaviour
{
    public Enemy enemy;
    public void Attack()
    {
        enemy.TakeDamage(1);

    }
}
