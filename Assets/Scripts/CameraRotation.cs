using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    enum Axis {x,y}

    public Rubix Rubic;
    
    void CubeRotate(Axis _axis, short direction = 1)
    {
        if(_axis==Axis.x)
            transform.RotateAround(Rubic.TheCenter.position,Vector3.left*(Rubic.speed*direction), 1);
        else if(_axis==Axis.y)
            transform.RotateAround(Rubic.TheCenter.position,Vector3.up*(Rubic.speed*direction),1);
        Rubic.FindPositions(Rubic.Cubies);
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            CubeRotate(Axis.x);
        else if (Input.GetKey(KeyCode.DownArrow))
            CubeRotate(Axis.x,-1);
        if (Input.GetKey(KeyCode.LeftArrow))
            CubeRotate(Axis.y);
        else if (Input.GetKey(KeyCode.RightArrow))
            CubeRotate(Axis.y,-1);
    }
}
