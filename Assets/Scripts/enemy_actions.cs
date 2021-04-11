using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_actions : MonoBehaviour
{
    // followed a tutorial (blackthornprod) online for this, but it's just a 
    // placeholder so we had something playable

    public int playerDamage = 10; // damage to player
    public float speed; // can change depending on level
                        // ie - sloth, characters go faster? to make the player seem slower?

    // public GameObject other;
    public Transform groundDetection;

    private bool movingRight = true;

    public player_stats ps;

    private void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<player_stats>();
    }


    void Update()
    {
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

    // destroys player when it hits it
    // needs rigidbody 2D and boxcollider 2D, make sure isTriggered is NOT selected
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ps.DamagePlayer(playerDamage);
        }
    }
}
