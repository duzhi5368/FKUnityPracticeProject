using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlloePrototype2 : MonoBehaviour
{
    public float horizontalInput;
    public float moveSpeed = 10.0f;
    public float moveRange = 18.0f;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);

        PositionLimit();
        Shoot();
    }

    private void PositionLimit()
    {
        if(transform.position.x < -moveRange)
        {
            transform.position = new Vector3(-moveRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > moveRange)
        {
            transform.position = new Vector3(moveRange, transform.position.y, transform.position.z);
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (prefab)
            {
                Instantiate(prefab, transform.position, prefab.transform.rotation);
            }
        }
    }
}
