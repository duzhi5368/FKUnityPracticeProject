using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Rigidbody rb;
    private float maxForceRange = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Random.Range(-maxForceRange, maxForceRange), Random.Range(-maxForceRange, maxForceRange), Random.Range(-maxForceRange, maxForceRange), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
