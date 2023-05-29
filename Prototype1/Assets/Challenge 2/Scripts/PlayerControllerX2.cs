using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX2 : MonoBehaviour
{
    public GameObject dogPrefab;
    public float idleTime = 2;
    private float lastInstanTime = 0.0f;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastInstanTime >= idleTime)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                lastInstanTime = Time.time;
            }
        }
    }
}
