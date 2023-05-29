using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerPrototype2 : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnRangeX = 16;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // SpawnRandomAnimal();
    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX),
            0, spawnPosZ);
        int animalIndex = Random.Range(0, objectPrefabs.Length);
        Instantiate(objectPrefabs[animalIndex], spawnPos,
            objectPrefabs[animalIndex].transform.rotation);
    }
}
