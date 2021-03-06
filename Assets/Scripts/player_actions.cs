using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_actions : MonoBehaviour
{
    public float fMult = 0.7f;
    public float maxVelocity = 10f;
    public float jumpPower = 10f;

    public bool onGround = false;

    //use following for attack animation
    //public Animator anim;

    public Transform playerAttack;
    public int damage = 5;
    public float attackRange = 0.5f;

    public float attackDelay = 0.5f;
    float attackTime = 0f;

    //sword slash object
    public GameObject swordSlash;
    private bool swordSlashActivated = false;
    private float swordSlashTime;

    //projectile for ranged attack
    public UnityEngine.Object projectile;
    public float fireRate = 1;
    private float fireTime;
    private bool isFacingRight = true; //for projectile

    // Start is called before the first frame update
    void Start()
    {
        fireTime = Time.time;
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
                swordSlash.transform.localPosition = new Vector3(-1.58f, 0, 0);
                swordSlash.transform.localScale = new Vector3(-0.1782713f, 0.1782713f, 0.1782713f);
                rb.AddForce(fMult * Vector3.left);

                isFacingRight = false;
            }
            if (Input.GetKey(KeyCode.D) && Mathf.Abs(rb.velocity.x) <= maxVelocity)
            {
                playerAttack.localPosition = new Vector3(1, 0, 0);
                swordSlash.transform.localPosition = new Vector3(1.58f, 0, 0);
                swordSlash.transform.localScale = new Vector3(0.1782713f, 0.1782713f, 0.1782713f);
                rb.AddForce(fMult * Vector3.right);

                isFacingRight = true;
            }
            
        }

        //Setting up attack functionality
        if(Time.time >= attackTime)
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J))
            {
                Attack();
                attackTime = Time.time + attackDelay;
            }
            
        }

        if(swordSlashActivated) {
            if(Time.time > swordSlashTime) {
                swordSlash.GetComponent<swordSlashScript>().deactivateSwordSlash();
                swordSlashActivated = false;
            }
        }

        if(Time.time > fireTime) {
            if (Input.GetKeyDown(KeyCode.K)) {
                RangedAttack();
                fireTime = Time.time + fireRate;
            }
        }
    }

    void Attack()
    {
        //Setting the animator trigger here will allow us to add
        //  attack animations (once we get to that point)
        //anim.SetTrigger("Attack");

        //activates the sword slash image.
        swordSlash.GetComponent<swordSlashScript>().activateSwordSlash();
        swordSlashTime = Time.time + 0.1f;
        swordSlashActivated = true;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerAttack.position, attackRange);

        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.CompareTag("BreakableWall"))
            {
                enemy.GetComponent<breakableWall>().ExplodeObject();
            }
            else if(enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<enemy_actions>().DamageEnemy(damage);
            }
            else if(enemy.CompareTag("FlyingEnemyMelee")) {
                enemy.GetComponent<FloatingEnemyType1Controller>().DamageEnemy(damage);
            }
            else if(enemy.CompareTag("FlyingEnemyRanged")) {
                enemy.GetComponent<FloatingEnemyType2Controller>().DamageEnemy(damage);
            }
            else if(enemy.CompareTag("Turret")) {
                enemy.GetComponent<turretController>().DamageEnemy(damage);
            }
        }
    }

    void RangedAttack() {
        Instantiate (projectile, transform.position, Quaternion.identity);
    }

    public void getKnockedBacked(float knockBack, Transform enemy) {
        //print("entered");
        knockBack = knockBack * 100;
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector3 moveDirection = rb.transform.position - enemy.transform.position;
        rb.AddForce(moveDirection.normalized * knockBack);
    }

    public bool getIsFacingRight() {
        return isFacingRight;
    }
}
