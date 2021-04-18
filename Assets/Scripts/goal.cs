using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goal : MonoBehaviour
{
    public Text score;
    private int level;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        score.text = "Current Level: " + level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("hit it");
            level++;
            Debug.Log(level.ToString());
            score.text = "Current Level: " + level.ToString();
            LoadLevel(level);
        }
    }

    public int SaveLevel()
    {
        return level;
    }

    public void LoadLevel(int i)
    {
        if(i == 1)
        {
            SceneManager.LoadScene("Level_Test");
        }
        else
        {
            SceneManager.LoadScene("_Scene_Menu");
        }
        /*
        else if(i == 2)
        {
            SceneManager.LoadScene("Enemy_Test");
        }
        */
    }
}
