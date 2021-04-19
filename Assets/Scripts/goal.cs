using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goal : MonoBehaviour
{
    public Text score;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
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
            if(level > SceneManager.sceneCount)
            {
                SceneManager.LoadScene("_Scene_Menu");
            }
            else
            {
                SceneManager.LoadScene(level);
            }
        }
    }
}
