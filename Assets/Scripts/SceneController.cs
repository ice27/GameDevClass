//Lisa Ice
//lice@cnm.edu
//Game Development, CIS 2250
//UIA Chapter 3 Assignment
//Created 2/6/21

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(0, 0.5f, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);

        }
    }
}
