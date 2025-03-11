using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public static move instance;

    [SerializeField] private Transform[] mapTile;
    public int idx = 1;

    [SerializeField] private float moveTime;

    public bool isMoving;

    private void Awake()
    {
        instance = this;
    }

    public void MoveButton(int n)
    {
        if (isMoving)
            return;

        StartCoroutine(MoveBlockTime(idx, n));
    }

    private IEnumerator MoveBlockTime(int idxc, int n)
    {
        isMoving = true;
        for (int i = 0; i < n; i++)
        {

            float elapsedTime = 0.0f;

            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = mapTile[idxc % mapTile.Length].position;

            while (elapsedTime < moveTime)
            {
                transform.position = Vector3.Lerp(currentPosition, targetPosition, elapsedTime / moveTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
            idx++;
            idxc++;
        }
        isMoving = false;
    }
}
