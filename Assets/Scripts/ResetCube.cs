using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResetCube : MonoBehaviour
{
    private Button that;
    private GameObject current;
    public GameObject Rubic;
    
    void Start()
    {
        that = GetComponent<Button>();
        current = GameObject.FindWithTag("Rubix");
        that.onClick.AddListener(Click);
    }

    void Click()
    {
        Instantiate(Rubic,new Vector3(0, -1, 0),
            new Quaternion(0,0,0,current.transform.rotation.w));
        Destroy(current);
        current = GameObject.FindWithTag("Rubix");
    }
}
