using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_actions : MonoBehaviour
{
    public float fMult = 0.7f;

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
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if(Time.timeScale == 1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                playerAttack.localPosition = new Vector3(-1, 0, 0);
                rb.AddForce(fMult * Vector3.left);
            }
            if (Input.GetKey(KeyCode.D))
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
        }
    }
}
