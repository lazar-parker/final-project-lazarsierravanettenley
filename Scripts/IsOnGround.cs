using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnGround : MonoBehaviour
{

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.tag == "Terrain")
        {
            player.GetComponent<player_actions>().onGround = true;
        }
    }

    private void OnCollisionExit(Collision coll)
    {
        if (coll.collider.tag == "Terrain")
        {
            player.GetComponent<player_actions>().onGround = false;
        }
    }
}
