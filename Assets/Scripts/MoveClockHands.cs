//Lisa Ice
//lice@cnm.edu
//Game Development, CIS 2250
//UIA Chapter 2 Assignment
//Created 1/30/21

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveClockHands : MonoBehaviour
{
    public enum WhichHand
    {
        Hour = 0,
        Minute = 1,
        Second = 2
    }
    public WhichHand timeType = WhichHand.Hour;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        System.DateTime realTime;
        float handRotation;

        //Rotate by apprpopriate amount
        realTime = System.DateTime.Now;
        if(timeType == WhichHand.Hour)
        {
            handRotation = 360 * realTime.Hour / 12+30*realTime.Minute/60;
            //Debug.Log("Hour handRotation is " + handRotation);
            transform.localEulerAngles = new Vector3(0, 0, -handRotation);
            
        }
        else if (timeType == WhichHand.Minute)
        {
            handRotation = 360 * realTime.Minute / 60;
           //Debug.Log("Minute handRotation is " + handRotation);
            transform.localEulerAngles = new Vector3(0, 0, -handRotation);
            
        }
        else //Second
        {
            handRotation = 360 * realTime.Second / 60;
            //Debug.Log("Second handRotation is " + handRotation);
            transform.localEulerAngles = new Vector3(0, 0, -handRotation);
            
        }
    }
}
