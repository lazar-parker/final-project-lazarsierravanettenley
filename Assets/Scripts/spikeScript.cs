using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeScript : MonoBehaviour
{

    public float damage  = 1f;

    private player_stats ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<player_stats>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //continously damage player when player is on the spikes
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ps.DamagePlayer(playerDamage);
        }
    }
}
