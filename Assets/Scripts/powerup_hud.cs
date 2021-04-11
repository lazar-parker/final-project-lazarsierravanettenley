using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup_hud : MonoBehaviour
{
    GameObject[] hud;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindGameObjectsWithTag("HudElement");
        HideHud();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideHud()
    {
        foreach(GameObject o in hud)
        {
            o.SetActive(false);
        }
    }

    public void ShowElement(string element)
    {
        foreach(GameObject o in hud)
        {
            if(o.name == element)
            {
                o.SetActive(true);
            }
        }
    }

    public void HideElement(string element)
    {
        foreach (GameObject o in hud)
        {
            if (o.name == element)
            {
                o.SetActive(false);
            }
        }
    }
}
