using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemyType2Controller : MonoBehaviour
{
    public float health = 1f;
    public float speed = 1f;

    //laser variables
    public float fireRate = 1f;
    public float chargeTime = 1f;
    [SerializeField]
    public UnityEngine.Object projectile;
    private float nextFire;

    //these are for the idle state
    public int distanceTravel = 0;
    public int timeIdle = 0;
    private int time;
    private int timeStopped;
    private bool movingRight = true;

    //view distance of the enemy
    public float viewDistance = 1f;

    //to keep track of player and obstacles
    public LayerMask player;
    public LayerMask obstacleMask;

    //saves the original rotation of the enemy
    private Quaternion originalRotationValue;

    // Start is called before the first frame update
    void Start()
    {
        time = distanceTravel * 100;
        timeStopped = timeIdle * 100;

        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(FindPlayer()) {
            AttackPlayer();
        }
        else {
            Idle();
        }
    }

    private bool FindPlayer() {
        bool playerFound = false;
        Collider2D[] targetInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewDistance, player);

        if(targetInViewRadius.Length > 0) {
            Transform playerTarget = targetInViewRadius[0].transform;
            
            Vector3 dirToTarget = (playerTarget.position - transform.position).normalized;
            float dstToTarget = Vector3.Distance(transform.position, playerTarget.position);

            if(!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask)) {
                    playerFound = true;
            }
        }

        return playerFound;

    }

    private void Idle() {

        transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, Time.time * 1f);

        if(movingRight == true) {
            if(time > 0) {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                time--;
            }
            else if (timeStopped > 0) {
                timeStopped--;
            }
            else {
                movingRight = false;
                time = distanceTravel * 100;
                timeStopped = timeIdle * 100;
            }
        }
        else {
            if(time > 0) {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                time--;
            }
            else if (timeStopped > 0) {
                timeStopped--;
            }
            else {
                movingRight = true;
                time = distanceTravel * 100;
                timeStopped = timeIdle * 100;
            }
            
        }

    }

    private void AttackPlayer() {
        if(Time.time > nextFire) {
            Instantiate (projectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    private void SearchPlayer() {

    }
}