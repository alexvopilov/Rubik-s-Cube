using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubix : MonoBehaviour
{
    private bool isRotating;
    private short rot_dir;
    private float speed;
    enum Axis {x,y}
    
    private List<Transform> U = new List<Transform>();
    private List<Transform> R = new List<Transform>();
    private List<Transform> L = new List<Transform>();
    private List<Transform> D = new List<Transform>();
    private List<Transform> F = new List<Transform>();
    private List<Transform> B = new List<Transform>();

    private Transform[] Cubies;
    public Transform TheCenter;
    
    IEnumerator Rotation(Transform v, Vector3 RotVector)
    {
        isRotating = true;
        short _angle = 0;
        while (_angle != 90)
        {
            _angle++;
            v.RotateAround(TheCenter.transform.position,RotVector, 1);
            yield return new WaitForSeconds(Time.deltaTime/5);
        }
        isRotating = false;
        FindPositions(Cubies);
    }

    bool FindPositions(Transform[] Cubies)
    {
        if (isRotating)
            return false;
        
        U = new List<Transform>();
        D = new List<Transform>();
        L = new List<Transform>();
        R = new List<Transform>();
        F = new List<Transform>();
        B = new List<Transform>();
        foreach (var Cubie in Cubies)
        {
            if (Cubie.tag == "Cubie")
            {
                double coord = Math.Round(Cubie.localPosition.y);
                if(coord == 1)
                    U.Add(Cubie);
                else if(coord == -1)
                    D.Add(Cubie);
                
                coord = Math.Round(Cubie.localPosition.x);
                if(coord == 1)
                    R.Add(Cubie);
                else if(coord == -1)
                    L.Add(Cubie);
                
                coord = Math.Round(Cubie.localPosition.z);
                if(coord == 1)
                    B.Add(Cubie);
                else if(coord == -1)
                    F.Add(Cubie);
            }
        }

        return true;
    }

    void CubeRotate(Axis _axis, short direction = 1)
    {
        if(_axis==Axis.x)
            transform.Rotate(new Vector3(direction*speed,0,0),Space.World);
        else if(_axis==Axis.y)
            transform.Rotate(new Vector3(0,direction*speed,0),Space.World);
        FindPositions(Cubies);
    }

    private void Start()
    {
        isRotating = false;
        speed = 0.5f;
        Cubies = GetComponentsInChildren<Transform>();
        FindPositions(Cubies);
    }

    // Update is called once per frame
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
        
        if (Input.GetKey(KeyCode.LeftShift))
            rot_dir = -1;
        else
            rot_dir = 1;

        if (!isRotating)
        {
            if (Input.GetKeyDown(KeyCode.U) && U.Count == 9)
            {
                foreach (Transform v in U)
                    StartCoroutine(Rotation(v,Vector3.up*rot_dir));
            }
            else if (Input.GetKeyDown(KeyCode.D) && D.Count == 9)
            {
                foreach (Transform v in D)
                    StartCoroutine(Rotation(v,Vector3.up*rot_dir));
            }
            else if (Input.GetKeyDown(KeyCode.L) && L.Count == 9)
            {
                foreach (Transform v in L)
                    StartCoroutine(Rotation(v,Vector3.left*rot_dir));
            }
            else if (Input.GetKeyDown(KeyCode.R) && R.Count == 9)
            {
                foreach (Transform v in R)
                    StartCoroutine(Rotation(v,Vector3.right*rot_dir));
            }
            else if (Input.GetKeyDown(KeyCode.F) && R.Count == 9)
            {
                foreach (Transform v in F)
                    StartCoroutine(Rotation(v,Vector3.back*rot_dir));
            }
            else if (Input.GetKeyDown(KeyCode.B) && B.Count == 9)
            {
                foreach (Transform v in B)
                    StartCoroutine(Rotation(v,Vector3.forward*rot_dir));
            }
        }
    }
}