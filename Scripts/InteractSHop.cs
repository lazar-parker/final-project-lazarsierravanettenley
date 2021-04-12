using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSHop : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange)
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }

    public void hideShop()
    {
        Time.timeScale = 1;
        foreach (GameObject o in pauseMenu)
        {
            o.SetActive(false);
        }
    }

    public void showShop()
    {
        foreach (GameObject o in pauseMenu)
        {
            o.SetActive(true);
        }
    }
}
