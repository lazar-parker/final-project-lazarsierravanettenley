using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretController : MonoBehaviour
{
    public int health = 1;

    //Bullet Variables
    public float fireRate = 1f;
    public float coolDown = 1f;
    public float bulletSpread = 0f;
    private bool isFiring = true;
    [SerializeField]
    public UnityEngine.Object projectile;
    private float nextFire;

    //enemy vision
    public float viewDistance = 1f;
    [Range(0, 360)]
    public float fov = 0;
    public bool lookingRight = false;

    //to keep track of player and obstacles
    public LayerMask player;
    public LayerMask obstacleMask;


    // Start is called before the first frame update
    void Start()
    {
        if(!lookingRight) {
            rotateObject();
        }
        
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

            if(Vector3.Angle(transform.up, dirToTarget) < fov / 2) {
                float dstToTarget = Vector3.Distance(transform.position, playerTarget.position);
                if(!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask)) {
                    playerFound = true;
                }
            }
        }

        return playerFound;

    }

    private void AttackPlayer() {
        if(Time.time > nextFire) {
            Instantiate (projectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    private void Idle() {
        //could be used for animations
    }

    private void rotateObject() {
        transform.rotation = Quaternion.Euler(0,0,90);
    }
}
