using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    private Vector3 lastMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        // 检查鼠标左键是否按下
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        // 检查鼠标左键是否持续按下并移动
        if (Input.GetMouseButton(0))
        {
            Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
            float rotationY =  -deltaMouse.x * rotationSpeed * Time.deltaTime;

            // 根据旋转量来旋转摄像机
            transform.Rotate(0, rotationY, 0);

            lastMousePosition = Input.mousePosition;
        }
    }
}
