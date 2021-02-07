//Lisa Ice
//lice@cnm.edu
//Game Development, CIS 2250
//UIA Chapter 3 Assignment
//Created 2/6/21

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingZombie : MonoBehaviour
{

    public float speed = .4f;
    public float obstacleRange = .5f;
    [SerializeField] private float playerRange = 2.5f;
    private bool _alive;
    public int damage = 1;

    private GameObject _player;


    // Start is called before the first frame update
    void Start()
    {
        _alive = true;
        _player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime); //move
            
            
            //Determine whether distance is within obstacleRange

            Vector3 playerPos = _player.transform.position;

            if (Vector3.Distance(playerPos, transform.position) < obstacleRange+.5f)
            {
                //hurt the player
                _player.GetComponent<PlayerCharacter>().Hurt(damage);
                Destroy(this.gameObject);
            }

            //Determine whether distance is within playerRange
            else if (Vector3.Distance(_player.transform.position, transform.position) < playerRange)
            {
                //Calculate direction between Zombie and player
                Vector3 vectorToPlayer = _player.transform.position - transform.position;
                //Get direction Zombie is facing
                Vector3 forward = transform.TransformDirection(Vector3.forward);
                if (Vector3.Dot(forward, vectorToPlayer) > 0.87) //if they are within ~30 degrees of the same direction
                {
                    //face the player
                    transform.rotation = Quaternion.LookRotation(vectorToPlayer.normalized);
                    //Debug.Log("Turned: Distance: " + Vector3.Distance(_player.transform.position, transform.position));
                }
            }

          



            //hitting obstacles behavior
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

           if (Physics.SphereCast(ray, .25f, out hit))

            {
                GameObject hitObject = hit.transform.gameObject;

                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                    //Debug.Log("Turned because it hit something - hit.distance: " + hit.distance);
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
