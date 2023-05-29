using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> obstaclePrefabList = new List<GameObject>();
    private Vector3 spawnPos = new Vector3(20, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.isGameOver)
        {
            int nLen = obstaclePrefabList.Count;
            int randomIndex = Random.Range(0, nLen);
            Instantiate(obstaclePrefabList[randomIndex], spawnPos, obstaclePrefabList[randomIndex].transform.rotation);
        }
    }
}
