using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_ups : MonoBehaviour
{
    player_stats ps;
    player_actions pa;
    powerup_hud ph;

    
    // Start is called before the first frame update
    void Start()
    {
        ps = this.GetComponent<player_stats>();
        pa = this.GetComponent<player_actions>();
        ph = this.GetComponent<powerup_hud>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "HealthPickup")
        {
            ps.HealPlayer(20);
        }
        else if(other.tag == "SpeedPickup")
        {
            StartCoroutine(SpeedBoost(20));
        }
        Destroy(other.gameObject);
    }

    IEnumerator SpeedBoost(float waittime)
    {
        ph.ShowElement("SpeedIndicator");
        pa.fMult *= 2;
        yield return new WaitForSeconds(waittime);
        ph.HideElement("SpeedIndicator");
        pa.fMult /= 2;
    }
}
