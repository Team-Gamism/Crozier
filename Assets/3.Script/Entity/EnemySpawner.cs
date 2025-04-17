using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] SpawnSO spawnSO;

    Transform player;

    [SerializeField]
    float minDistance;
    [SerializeField]
    float maxDistance;

    [SerializeField]
    int curEnemyCount = 0;
    [SerializeField]
    float curTime = 0;
    int spawnLevel = 0;

    private void Start()
    {
        player = GameManager.Instance.player;
        StartCoroutine(TimeControl());
        StartCoroutine(NormalSpawn());
    }

    IEnumerator TimeControl()
    {
        while (true)
        {
           yield return null;
           curTime += Time.deltaTime;
            if (spawnSO.spawnList.Count - 1 == spawnLevel)
                continue;
            if (spawnSO.spawnList[spawnLevel + 1].startSpawnTime <= curTime)
                spawnLevel++;
        }
    }

    IEnumerator NormalSpawn()
    {
        while(true)
        {
            yield return null;
            if (curEnemyCount >= spawnSO.spawnList[spawnLevel].maxCount)
                continue;
            SpawnRandomMonster();
            yield return new WaitForSeconds(spawnSO.spawnList[spawnLevel].spawnDelay);
        }
    }

    void SpawnRandomMonster()
    {
        int randomIndex = Random.Range(1, 101);
        float num = 0;
        for (int i = 0; i < spawnSO.spawnList[spawnLevel].monsterList.Count; i++)
        {
            if (num < randomIndex && randomIndex <= num + spawnSO.spawnList[spawnLevel].monsterList[i].probability)
            {
                GameObject monster = Instantiate(spawnSO.spawnList[spawnLevel].monsterList[i].monster);
                monster.GetComponent<EnemyController>().dieAction += MinusEnemyCount;
                SetRandomPosition(monster.transform);
                curEnemyCount++;
                if (curEnemyCount >= spawnSO.spawnList[spawnLevel].maxCount)
                    break;
            }
            num += spawnSO.spawnList[spawnLevel].monsterList[i].probability;
        }
    }

   void MinusEnemyCount()
    {
        curEnemyCount--;
    }

    void SetRandomPosition(Transform monster)
    {
        float angle = Mathf.PI * Random.Range(0f, 360f) / 180;
        float radius = Random.Range(minDistance, maxDistance);
        monster.transform.position = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0) + player.transform.position;
    }
}
