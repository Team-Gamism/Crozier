using System;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemySO entitySO;
    Rigidbody2D rigid;

    public Action dieAction;

    public float CurHp { get { return curHp; }  set { curHp = Mathf.Clamp(value,value,maxHp); if (curHp <= 0) Die(); } }
    float curHp;
    float maxHp;

    Transform target;
    SpriteRenderer sprite;

    private void Start()
    {
        maxHp = entitySO.maxHp;
        CurHp = maxHp;
        target = GameManager.Instance.player;
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            yield return null;
            rigid.linearVelocity = entitySO.speed * (target.position - transform.position).normalized;
            sprite.flipX = (target.position - transform.position).normalized.x > 0;
        }
    }

    public void TakeDamage(float damage)
    {
        CurHp -= damage;
    }

    void Die()
    {
        dieAction.Invoke();
        Destroy(gameObject);
    }
}
