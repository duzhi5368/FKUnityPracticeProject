using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
        CheckDestorySelf();
    }

    void ChasePlayer()
    {
        Vector3 lookDirection = (playerObj.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }

    void CheckDestorySelf()
    {
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
