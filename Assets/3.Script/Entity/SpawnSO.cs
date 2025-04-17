using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnSO", menuName = "Scriptable Objects/SpawnSO")]
public class SpawnSO : ScriptableObject
{
   
    public List<SpawnLevel> spawnList;

    [Serializable]
    public class SpawnLevel
    {
        public float startSpawnTime;
        public List<MonsterInfo> monsterList;
        public int maxCount;
        public float spawnDelay;
    }
    [Serializable]
    public class MonsterInfo
    {
        public GameObject monster;
        public float probability;
    }
}
