using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Transform[] mapTile;
    private int idx = 1;

    [SerializeField] private float moveTime;

    bool isMoving;
    public void MoveButton()
    {
        if (isMoving)
            return;

        if (idx >= mapTile.Length)
            idx = 0;
        StartCoroutine(MoveBlockTime(idx));
        idx++;
    }

    private IEnumerator MoveBlockTime(int idx)
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
