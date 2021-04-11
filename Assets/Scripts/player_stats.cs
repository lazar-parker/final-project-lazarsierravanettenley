using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_stats : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;

    public float invulnerableTime = 1f;
    private float invulnerable;

    public HealthBar hb;

    private GameObject player;
    private player_inventory pi;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        pi = new player_inventory();

        invulnerable = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damage)
    {

        if (Time.time > invulnerable) {
            curHealth -= damage;
            hb.SetHealth(curHealth);
            if(curHealth == 0)
            {
                Destroy(player);
                Time.timeScale = 0;
            }
            invulnerable = Time.time + invulnerableTime;
        }
    }

    public void HealPlayer(int health)
    {
        if(curHealth+health >= maxHealth)
        {
            curHealth = maxHealth;
        }
        else
        {
            curHealth += health;
        }

        hb.SetHealth(curHealth);
    }

    //Used for setting the health on load, so that the health bar displays properly
    public void SetHealth(int health)
    {
        curHealth = health;
        hb.SetHealth(curHealth);
    }
}
