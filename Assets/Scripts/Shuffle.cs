using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shuffle : MonoBehaviour
{
    private Button that;
    private Image img;
    private Rubix current;
    private Vector3[] steps =
    {
        Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.back, Vector3.forward
    };

    void Start()
    {
        that = GetComponent<Button>();
        img = GetComponent<Image>();
        that.onClick.AddListener(Click);
    }
    
    public IEnumerator DoShuffle()
    {
        short random_step;
        short random_dir;
        
        for (int i = 0; i < Random.Range(15,30); i++)
        {
            random_step = (short)Random.Range(0, steps.Length);
            random_dir = (short)(Random.Range(0, 2)*2-1);

            foreach (var v in current.sides[random_step])
                StartCoroutine(current.Rotation(v,steps[random_step]*random_dir));
            yield return new WaitForSeconds(1);
        }
        img.color = Color.white;
    }
    
    void Click()
    {
        current = GameObject.FindWithTag("Rubix").GetComponent<Rubix>();
        img.color = Color.red;
        StartCoroutine(DoShuffle());
    }
}
