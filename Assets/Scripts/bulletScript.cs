using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float bulletDamage = 1f;
    public float bulletKnockback = 1f;

    public float speed = 10f;

    Rigidbody2D rb;

    private GameObject player;

    Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        rb = GetComponent<Rigidbody2D>();
        moveDirection = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name.Equals("Player")) {
            player.GetComponent<player_actions>().getDamaged(bulletDamage);
            player.GetComponent<player_actions>().getKnockedBacked(bulletKnockback, transform);
            Destroy(gameObject);
        }
    }
}
