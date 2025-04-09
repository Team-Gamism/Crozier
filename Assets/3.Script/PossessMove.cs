using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PossessMove : MonoBehaviour, IMovable
{
    public float speed = 3f;
    Coroutine holdCoroutine;

    Rigidbody2D rigid;
    Slider powerSlider;


    public GameObject gameObj;

    [SerializeField]
    private float power;
    private Vector3 dirVec;
    private float angle;
    private Vector3 targetPos;
    private bool isHolding;

    protected float Power
    {
        get => power;
        set
        {
            power = value;
            powerSlider.value = power / 3f;
        }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        powerSlider = GetComponentInChildren<Slider>();
        powerSlider.gameObject.SetActive(false);
    }
    public void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            holdCoroutine = StartCoroutine(HoldToPower());
            gameObj.SetActive(true);
            isHolding = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            targetPos.z = 0;

            rigid.AddForce(dirVec * speed * power, ForceMode2D.Impulse);

            gameObj.SetActive(false);
            isHolding = false;

            powerSlider.gameObject.SetActive(false);
            GhostManager.Instance.isMoving = true;

            if (holdCoroutine != null)
                StopCoroutine(holdCoroutine);
        }

        if (!GhostManager.Instance.isMoving)
            return;

        if (Vector3.Distance(rigid.linearVelocity, Vector3.zero) <= 0.1f)
            GhostManager.Instance.isMoving = false;

    }

    void Update()
    {
        if (isHolding) targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        dirVec = (targetPos - transform.position).normalized;
        angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg - 90;
        gameObj.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    IEnumerator HoldToPower()
    {
        powerSlider.gameObject.SetActive(true);

        Power = 0f;
        for (int i = 1; i <= 100; i++)
        {
            yield return new WaitForSeconds(0.001f);
            Power = i * 0.03f;
        }
    }
}
