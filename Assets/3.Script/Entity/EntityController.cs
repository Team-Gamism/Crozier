using System.Collections;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public EntitySO entitySO;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public float CurHp { get { return curHp; }  set { curHp = Mathf.Clamp(value,value,maxHp); if (curHp <= 0) Die(); } }
    float curHp;
    public float maxHp;

    Vector3 spawnPos;
    Vector3 moveTarget;

    private void Start()
    {
        maxHp = entitySO.maxHp;
        CurHp = maxHp;
        spawnPos = transform.position;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        StartCoroutine(Move());
    }

    private void UpdateState()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        yield return new WaitForSeconds(Random.Range(4f,6f));
        moveTarget = spawnPos + new Vector3(Random.Range(-2f,2f), Random.Range(-2f, 2f));
        anim.Play("Move");

        while ((transform.position - moveTarget).magnitude > 0.03f)
        {
            spriteRenderer.flipX = (transform.position - moveTarget).x >= 0;
            rigid.linearVelocity = (moveTarget - transform.position).normalized * entitySO.speed;
            yield return null;
        }

        anim.Play("Idle");
        rigid.linearVelocity = Vector2.zero;
        UpdateState();
        yield break;
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
