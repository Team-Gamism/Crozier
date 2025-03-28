using System.Collections;
using TMPro;
using UnityEngine;

public class GhostMove : MonoBehaviour, IMovable
{
    bool isMoving;
    public float speed;

    Vector3 dirVec;
    Vector3 targetPos;

    Possess possess;

    private void Start()
    {
        possess = GetComponent<Possess>();
    }

    public void Move()
    {
        if (Input.GetMouseButtonDown(0) && !PossessManager.Instance.isPossessing)
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos = new Vector3(targetPos.x, targetPos.y);

            isMoving = true;
            dirVec = GetDirVec();
        }

        if (isMoving)
        {
            transform.Translate(dirVec * speed * Time.deltaTime);

            if (Vector3.Distance(targetPos, transform.position) <= 0.1f)
            {
                isMoving = false;
                transform.position = targetPos;

                possess.DetectPossessableObject();
            }
        }
    }
    Vector3 GetDirVec()
    {
        return (targetPos - transform.position).normalized;
    }
}
