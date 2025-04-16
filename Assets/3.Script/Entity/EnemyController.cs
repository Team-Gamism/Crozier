using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemySO entitySO;
    Rigidbody2D rigid;

    public float CurHp { get { return curHp; }  set { curHp = Mathf.Clamp(value,value,maxHp); if (curHp <= 0) Die(); } }
    float curHp;
    float maxHp;

    Transform target;

    private void Start()
    {
        maxHp = entitySO.maxHp;
        CurHp = maxHp;
        target = GameManager.Instance.player;
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            yield return null;
            rigid.linearVelocity = entitySO.speed * (target.position - transform.position).normalized;
        }
    }

    public void TakeDamage(float damage)
    {
        CurHp -= damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
