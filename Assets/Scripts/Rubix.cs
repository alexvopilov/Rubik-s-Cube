using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
