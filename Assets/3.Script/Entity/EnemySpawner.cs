using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject entityObj;
    [SerializeField] int spawnCount;

    int curEntityCount = 0;

    void SpawnEntity()
    {
        for(int i = 0; i < spawnCount ; i++)
        {

        }
    }
}
