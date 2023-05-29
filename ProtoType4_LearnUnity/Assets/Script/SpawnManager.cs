using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    private int enemyCount;
    private int currentWave = 1;
    void Start()
    {
        GeneratePowerup();
        CreateEnemyByWave(currentWave);
        currentWave++;
    }

    private void CreateEnemyByWave(int wave)
    {
        for(int i = 0; i < wave; i++)
        {
            GenerateEnemy();
        }
    }

    void GeneratePowerup()
    {
        float randomSpawnX = Random.Range(-spawnRange, spawnRange);
        float randomSpawnZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomSpawnPos = new Vector3(randomSpawnX, 0, randomSpawnZ);

        Instantiate(powerupPrefab, randomSpawnPos, powerupPrefab.transform.rotation);
    }
    void GenerateEnemy()
    {
        float randomSpawnX = Random.Range(-spawnRange, spawnRange);
        float randomSpawnZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomSpawnPos = new Vector3(randomSpawnX, 0, randomSpawnZ);

        Instantiate(enemyPrefab, randomSpawnPos, enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount <= 0)
        {
            GeneratePowerup();
            CreateEnemyByWave(currentWave);
            currentWave++;
        }
    }
}
