using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeScript : MonoBehaviour
{

    public float damage  = 1f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
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
            player.GetComponent<player_actions>().getDamaged(damage);
        }
    }
}
