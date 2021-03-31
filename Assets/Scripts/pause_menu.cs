using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    GameObject[] pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseMenu = GameObject.FindGameObjectsWithTag("PauseElement");
        hidePaused();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            } else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }

    public void hidePaused()
    {
        foreach(GameObject o in pauseMenu)
        {
            o.SetActive(false);
        }
    }

    public void showPaused()
    {
        foreach (GameObject o in pauseMenu)
        {
            o.SetActive(true);
        }
    }

    public void Reload()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    //Used for the resume button, same logic as within Update
    public void Unpause()
    {
        Time.timeScale = 1;
        hidePaused();
    }
}
