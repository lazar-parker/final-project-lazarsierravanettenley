using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death_menu : MonoBehaviour
{

    GameObject[] deathMenu;

    // Start is called before the first frame update
    void Start()
    {
        deathMenu = GameObject.FindGameObjectsWithTag("DeathElement");
        HideDeath();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            GameObject[] isPlayer = GameObject.FindGameObjectsWithTag("Player");
            if(isPlayer.Length == 0)
            {
                ShowDeath();
            }
        }
    }

    public void ShowDeath()
    {
        if (deathMenu.Length > 0)
        {
            Debug.Log("deathMenu has something in it!");
        }
        foreach (GameObject o in deathMenu)
        {
            o.SetActive(true);
        }
    }

    public void HideDeath()
    {
        foreach (GameObject o in deathMenu)
        {
            Debug.Log("Object hidden");
            o.SetActive(false);
        }

        Debug.Log("deathMenu has " + deathMenu.Length + " objects");
    }

    public void OnDeathReload()
    {
        //Scene scene = SceneManager.GetActiveScene();S
        SceneManager.LoadScene("Level_Test");
    }
}
