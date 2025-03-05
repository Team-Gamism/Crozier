using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] private Transform[] mapTile;
    private int idx = 1;

    [SerializeField] private float moveTime;

    Vector3 target;
    bool isMoving;
    public void MoveButton()
    {
        if (isMoving)
            return;

        if (idx >= mapTile.Length - 1)
            idx = 0;
        StartCoroutine(moveBlockTime(idx));
        idx++;
    }

    private IEnumerator moveBlockTime(int idx)
    {
        isMoving = true;

        float elapsedTime = 0.0f;

        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = mapTile[idx].position;

        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.Lerp(currentPosition, targetPosition, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        isMoving = false;
    }
}
