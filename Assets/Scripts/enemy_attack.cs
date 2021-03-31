using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack : MonoBehaviour
{
    GameObject other;
    int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // attach to player's weapon, kills enemy objects
    // make sure to attach the tag "Enemy" to any object that's an enemy
    void OnTriggerEnter2D (Collider2D col)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject); // "kills" enemy object
        }
    }
}
