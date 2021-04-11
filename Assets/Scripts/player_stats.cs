using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_stats : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;

    public HealthBar hb;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        hb.SetHealth(curHealth);
        if(curHealth == 0)
        {
            Destroy(player);
            Time.timeScale = 0;
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
}
