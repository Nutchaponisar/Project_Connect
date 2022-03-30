using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Spawn : NetworkBehaviour
{
    float spawnCD;
    [SerializeField] public float delay = 10f;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] EnemyController[] enemys;

    private void Update()
    {
        if (isServer == false)
            return;
        CanSpawn();
    }

    void spawn()
    {
        spawnCD = delay;
        Transform spawnPoint = ChooseSpawnPoint();
        EnemyController enemyPrefab = ChooseEnemy();
        EnemyController enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        NetworkServer.Spawn(enemy.gameObject);
    }
    EnemyController ChooseEnemy()
    {
        int randomIndex = UnityEngine.Random.Range(0, enemys.Length);
        var enemy = enemys[randomIndex];
        return enemy;
    }
    Transform ChooseSpawnPoint()
    {
        int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
        var spawnPoint = spawnPoints[randomIndex];
        return spawnPoint;
    }
    private void CanSpawn()
    {
        if (spawnCD <= 0)
        {
            spawn();
            spawnCD -= Time.deltaTime;
        }
        else
        {
            spawnCD -= Time.deltaTime;
        }
    }
}
