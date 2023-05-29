using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerAndRotate : MonoBehaviour
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
        if (player)
        {
            transform.position = player.transform.position + offset;
            transform.Rotate(player.transform.rotation.x, 
                player.transform.rotation.y,
                player.transform.rotation.z);
        }
    }
}
