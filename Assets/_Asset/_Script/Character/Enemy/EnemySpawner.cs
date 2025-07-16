using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval;
    public EnemyWave[] enemyWaves;
    private int currentWave;
    void Start()
    {
        EventDispatcher<bool>.AddListener(Event.EnemySpawn.ToString(), SpawnEnemy);
    }

    private void SpawnEnemy(bool isSpawned)
    {
        var waveInfo = enemyWaves[currentWave];
        var startPosition = waveInfo.movePath[0];
        for (int i = 0; i < waveInfo.enemyNumber; i++)
        {
            var enemy = Instantiate(waveInfo.enemyPrefab, startPosition, Quaternion.identity);
            var movement = enemy.GetComponentInChildren<EnemyStateController>();
            movement.movePath = waveInfo.movePath;
            movement.moveSpeed = waveInfo.speed;
            startPosition += waveInfo.formationOffset;
        }
        if (currentWave < enemyWaves.Length - 1)
        {
            currentWave++;
        }
        else
        {
            currentWave = 0;
        }    
    }
}
[System.Serializable]
public class EnemyWave
{
    public Transform enemyPrefab;
    public int enemyNumber;
    public Vector3 formationOffset;
    public MovePath movePath;
    public float speed;
}

