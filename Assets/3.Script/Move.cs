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
    }

    private void Update()
    {
        rigid.linearVelocity = inputVec * speed;
    }
}
