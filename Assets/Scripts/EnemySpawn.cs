using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [System.Serializable]
    public class Enemies
    {
        public string name;
        public GameObject enemy;
        public float spawnRarity;
        public float rarityIncreaseRatio;
        public float maxRarity;
    }

    public List<Enemies> EnemyList = new List<Enemies>();

    public GameObject player;
    public float spawnDistance = 12f;
    public float enemyRate = 10;
    float nextEnemy = 2;
    Vector3 spawnLocation;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        nextEnemy -= Time.deltaTime;
        if (nextEnemy <= 0 && player != null)
        {
            nextEnemy = enemyRate;
            Vector3 offset = Random.onUnitSphere;
            offset.y = 0;
            offset = offset.normalized * spawnDistance;
            spawnLocation = player.transform.position + offset;
            spawnLocation.y = 0;

            Spawn();
        }
    }

    public void Spawn()
    {
        float totalSpawnRange = 0;

        for (int i = 0; i < EnemyList.Count; i++)
        {
            totalSpawnRange += EnemyList[i].spawnRarity;
            EnemyList[i].spawnRarity += EnemyList[i].rarityIncreaseRatio * enemyRate;
            if(EnemyList[i].spawnRarity >= EnemyList[i].maxRarity)
            {
                EnemyList[i].spawnRarity = EnemyList[i].maxRarity;
            }
        }

        float randomValue = Random.Range(0, totalSpawnRange);

        for (int j = 0; j < EnemyList.Count; j++)
        {
            if (randomValue <= EnemyList[j].spawnRarity)
            {
                Instantiate(EnemyList[j].enemy, spawnLocation, Quaternion.identity);
                return;
            }
            randomValue -= EnemyList[j].spawnRarity;
        }
    }
}