using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLaserScript : MonoBehaviour
{
    public int laserDamage = 5;
    //public float laserKnockback = 1f;

    public float speed = 10f;

    Rigidbody2D rb;

    private GameObject enemy;

    Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        //print("created laser");
        GameObject player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        //moveDirection = (transform.position).normalized * speed;

        bool isFacingRight = player.GetComponent<player_actions>().getIsFacingRight();

        if(isFacingRight) {
            rb.velocity = new Vector2(1f * speed, 0);
        }
        else {
            rb.velocity = new Vector2(-1f * speed, 0);
        }
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.layer == 8) {
            Destroy(gameObject);
        }
        else if(col.CompareTag("Enemy")){
            col.GetComponent<enemy_actions>().DamageEnemy(laserDamage);
            Destroy(gameObject);
        }
        else if(col.CompareTag("FlyingEnemyMelee")) {
            col.GetComponent<FloatingEnemyType1Controller>().DamageEnemy(laserDamage);
            Destroy(gameObject);
        }
        else if(col.CompareTag("FlyingEnemyRanged")) {
            col.GetComponent<FloatingEnemyType2Controller>().DamageEnemy(laserDamage);
            Destroy(gameObject);
        }
        else if(col.CompareTag("Turret")) {
            col.GetComponent<turretController>().DamageEnemy(laserDamage);
            Destroy(gameObject);
        }
    }
}
