//Lisa Ice
//lice@cnm.edu
//Game Development, CIS 2250
//UIA Chapter 2 Assignment
//Created 1/17/21

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0);
    }
}
