using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Tooltip("A game object that our camera to follow")]
    public GameObject player;

    public Vector3 offset = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (player)
        {
            transform.position = player.transform.position + offset;
            //Debug.Log("position = " + player.transform.position);
            //Debug.Log("offset = " + offset);
            //Debug.Log("final = " + transform.position);
        }
    }
}
