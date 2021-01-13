using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private Vector3 localRotation;
    private float speed = 15;

    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            localRotation.x += Input.GetAxis("Mouse X") * speed;
            localRotation.y += Input.GetAxis("Mouse Y") * -speed;
            localRotation.y = Mathf.Clamp(localRotation.y, -90, 90);
        }
        
        Quaternion q = Quaternion.Euler(localRotation.y, localRotation.x, 0);
        transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, q, Time.deltaTime * speed);
    }
}
