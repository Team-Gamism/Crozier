using System.Collections;
using UnityEngine;

public class PossessMove : MonoBehaviour, IMovable
{
    public float speed = 3f;
    Rigidbody2D rigid;

    [SerializeField] 
    private float power;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Move()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(HoldToPower());
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            Vector3 dirVec = (targetPos - transform.position).normalized;

            rigid.AddForce(dirVec * speed * power, ForceMode2D.Impulse);
        }
    }

    IEnumerator HoldToPower()
    {
        power = 0f;
        for (int i = 1; i <= 100; i++)
        {
            yield return new WaitForSeconds(0.001f);
            power = i * 0.03f;
        }
    }
}
