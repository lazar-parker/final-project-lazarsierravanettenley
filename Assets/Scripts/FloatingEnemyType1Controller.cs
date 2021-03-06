using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemyType1Controller : MonoBehaviour
{
    public int health = 1;
    public int damage = 1;
    public float knockback = 1f;
    public float speed = 1f;
    public float chaseSpeedIncrease = 1f;

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

    private player_stats ps;

    //saves the original rotation of the enemy
    private Quaternion originalRotationValue;

    private bool colorChange = false;
    private int colorTime = 50;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = gameObject.GetComponent<Renderer>().material.GetColor("_Color");
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<player_stats>();

        time = distanceTravel * 100;
        timeStopped = timeIdle * 100;
        
        originalRotationValue = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(colorChange) {
            if(colorTime > 0) {
                colorTime--;
            }
            else {
                colorChange = false;
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", originalColor);
            }
        }

        if(FindPlayer()) {
            AttackPlayer();
        }
        else {
                Idle();
            }
    }

    public void DamageEnemy(int playerDamage) {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        colorChange = true;
        colorTime = 50;
        health = health - playerDamage;
        if (health <= 0) {
            Destroy(gameObject);
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
        Collider2D[] targetInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewDistance, player);
        Transform playerTarget = targetInViewRadius[0].transform;

        RotateTowards(playerTarget.position);
        MoveToward(playerTarget.position);
    }

    private void Attack() {
        Collider2D[] targetInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewDistance, player);
        Transform playerTarget = targetInViewRadius[0].transform;

        playerTarget.GetComponent<player_actions>().getKnockedBacked(knockback, transform);
        ps.DamagePlayer(damage);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Debug.Log("Player destroyed");
            Attack();
        }
    }

    private void RotateTowards(Vector2 target){
        var offset = 90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;       
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    private void MoveToward(Vector2 target) {
        transform.position = Vector2.MoveTowards(transform.position, target, (speed + chaseSpeedIncrease) * Time.deltaTime);
    }

    private void SearchPlayer() {

    }
}
