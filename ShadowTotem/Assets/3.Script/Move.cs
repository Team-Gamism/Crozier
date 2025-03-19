using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    Vector2 inputVec;

    public float speed;

    public void OnMove(InputValue inputValue)
    {
        inputVec = inputValue.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(inputVec.x, 0, inputVec.y) * Time.deltaTime * speed);
    }
}
