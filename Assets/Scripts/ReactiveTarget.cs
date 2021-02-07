//Lisa Ice
//lice@cnm.edu
//Game Development, CIS 2250
//UIA Chapter 3 Assignment
//Created 2/6/21

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        WanderingZombie beh = GetComponent<WanderingZombie>();
        if(behavior != null)
        {
            behavior.SetAlive(false);
        }
        if (beh != null)
        {
            beh.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
