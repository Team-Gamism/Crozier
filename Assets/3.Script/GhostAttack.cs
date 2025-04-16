using UnityEngine;

public class GhostAttack : MonoBehaviour
{
    public float dmg;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.TryGetComponent<EnemyController>(out var enemy))
            if (GhostManager.Instance.isPossessing && GhostManager.Instance.isMoving)
            {
                enemy.TakeDamage(dmg);
            }

    }
}
