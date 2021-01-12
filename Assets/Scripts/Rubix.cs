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
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
