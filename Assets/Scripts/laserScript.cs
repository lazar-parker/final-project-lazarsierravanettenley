using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    public int laserDamage = 1;
    public float laserKnockback = 1f;

    public float speed = 10f;

    Rigidbody2D rb;

    private GameObject player;

    private player_stats ps;

    Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<player_stats>();

        player = GameObject.Find("Player");
        RotateTowards(player.transform.position);

        rb = GetComponent<Rigidbody2D>();
        moveDirection = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name.Equals("Player")) {
            //print("entered");
            player.GetComponent<player_actions>().getKnockedBacked(laserKnockback, transform);
            ps.DamagePlayer(laserDamage);
            Destroy(gameObject);
        }
    }

    private void RotateTowards(Vector2 target){
        var offset = 90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;       
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
