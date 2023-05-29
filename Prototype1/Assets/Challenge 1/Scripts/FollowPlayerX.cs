using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;

    private Vector3 offset = new Vector3(65, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (plane)
        {
            transform.position = plane.transform.position + offset;
            transform.LookAt(plane.transform);
        }
    }
}
