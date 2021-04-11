using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_actions : MonoBehaviour
{
    public float health = 1f;

    public float fMult = 0.7f;
    public float maxVelocity = 10f;
    public float jumpPower = 10f;

    public bool onGround = false;

    //use following for attack animation
    //public Animator anim;

    public Transform playerAttack;
    public float attackRange = 0.5f;

    public float attackDelay = 0.5f;
    float attackTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();

        if(Time.timeScale == 1)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                rb.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.A) && Mathf.Abs(rb.velocity.x) <= maxVelocity)
            {
                playerAttack.localPosition = new Vector3(-1, 0, 0);
                rb.AddForce(fMult * Vector3.left);
            }
            if (Input.GetKey(KeyCode.D) && Mathf.Abs(rb.velocity.x) <= maxVelocity)
            {
                playerAttack.localPosition = new Vector3(1, 0, 0);
                rb.AddForce(fMult * Vector3.right);
            }
            
            
        }

        //Setting up attack functionality
        if(Time.time >= attackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
                attackTime = Time.time + 1f / attackDelay;
            }
        }
    }

    void Attack()
    {
        //Setting the animator trigger here will allow us to add
        //  attack animations (once we get to that point)
        //anim.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerAttack.position, attackRange);

        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.CompareTag("BreakableWall"))
            {
                enemy.transform.position = new Vector3(0, -100, 0);
                Destroy(enemy);
            }
            else if(enemy.CompareTag("Enemy"))
            {
                Destroy(enemy.gameObject);
            }
        }
    }

    public void getDamaged(float damage) {
        health -= damage;
        if (health <= 0) {
            death();
        }
    }

    public void getKnockedBacked(float knockBack, Transform enemy) {
        knockBack = knockBack * 100;
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector3 moveDirection = rb.transform.position - enemy.transform.position;
        rb.AddForce(moveDirection.normalized * knockBack);
    }

    void death() {
        print("player is dead");
    }
}
