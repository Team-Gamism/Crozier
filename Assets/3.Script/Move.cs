using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [Header("Reference")]
    Rigidbody2D rigid;

    [Header("Value")]
    Vector2 inputVec;
    [SerializeField] float speed = 3;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>().normalized;

        Vector3 scale = transform.localScale;

        if (inputVec.x > 0.01f)
            scale.x = -1;
        else if (inputVec.x < -0.01f)
            scale.x = 1;

        transform.localScale = scale;
    }

    private void FixedUpdate()
    {
        rigid.linearVelocity = inputVec * speed;
    }
}
