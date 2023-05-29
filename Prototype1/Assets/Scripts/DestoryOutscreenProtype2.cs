using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOutscreenProtype2 : MonoBehaviour
{
    private float topBound = 30;
    private float downBound = -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBound)
        {
            Destroy(gameObject, 1);
        } else if(transform.position.z < downBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject, 1);
        }
    }
}
