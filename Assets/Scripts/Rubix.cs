using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubix : MonoBehaviour
{
    private short rot_dir;
    private bool isRotating;

    private List<Transform> U = new List<Transform>();
    private List<Transform> R = new List<Transform>();
    private List<Transform> L = new List<Transform>();
    private List<Transform> D = new List<Transform>();
    private List<Transform> F = new List<Transform>();
    private List<Transform> B = new List<Transform>();

    public Transform[] Cubies;
    public Transform TheCenter;
    
    IEnumerator Rotation(Transform v, Vector3 RotVector)
    {
        isRotating = true;
        short _angle = 0;
        while (_angle != 90)
        {
            _angle++;
            v.RotateAround(TheCenter.transform.position,RotVector, 1);
            yield return new WaitForSeconds(Time.fixedDeltaTime/10);
        }

        v.position = new Vector3((int)Mathf.Round(v.position.x),(int)Mathf.Round(v.position.y),(int)Mathf.Round(v.position.z));
        FindPositions(Cubies);
        isRotating = false;
    }

    public bool FindPositions(Transform[] Cubies)
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

    private void Start()
    {
        isRotating = false;
        Cubies = GetComponentsInChildren<Transform>();
        FindPositions(Cubies);
    }

    void Update()
    {
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
                    StartCoroutine(Rotation(v,Vector3.down*rot_dir));
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