using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public player_stats pHealth;

    // Start is called before the first frame update
    void Start()
    {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<player_stats>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = pHealth.maxHealth;
        healthBar.value = pHealth.maxHealth;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}
