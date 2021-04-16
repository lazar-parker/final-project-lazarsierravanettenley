using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_actions : MonoBehaviour
{
    // followed a tutorial (blackthornprod) online for this, but it's just a 
    // placeholder so we had something playable

    public int health = 10; //health of the enemy
    public int damage = 10; // damage to player
    public float knockback = 0f;
    public float speed; // can change depending on level
                        // ie - sloth, characters go faster? to make the player seem slower?

    // public GameObject other;
    public Transform groundDetection;

    private bool movingRight = true;

    private player_stats ps;
    private GameObject player;

    private bool colorChange = false;
    private int colorTime = 50;

    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<player_stats>();
        player = GameObject.Find("Player");
    }

    void Update()
    {

        if(!colorChange) {
            if(colorTime > 0) {
                colorTime--;
            }
            else {
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            }
        }

        // keeps the enemy moving, but from falling off the edge
        // a 'ray' is used to detect the edge and turns the enemy around
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    //damages and knockbacks player
    // needs rigidbody 2D and boxcollider 2D, make sure isTriggered is NOT selected
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.GetComponent<player_actions>().getKnockedBacked(knockback, transform);
            ps.DamagePlayer(damage);
        }
    }

    public void DamageEnemy(int damage) {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        colorTime = 50;
        health = health - damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
