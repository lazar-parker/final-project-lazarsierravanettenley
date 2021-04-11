using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    GameObject[] pauseMenu;
    GameObject[] enemyList;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseMenu = GameObject.FindGameObjectsWithTag("PauseElement");
        hidePaused();
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");
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
        Time.timeScale = 1;
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
        //Scene scene = SceneManager.GetActiveScene();S
        SceneManager.LoadScene("Level_Test");
    }

    //Used for the resume button, same logic as within Update
    public void Unpause()
    {
        Time.timeScale = 1;
        hidePaused();
    }

    public void SaveGame()
    {
        Save save = SaveGameState();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
    }

    public Save SaveGameState()
    {
        Save s = new Save();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        s.playerX = player.transform.position.x;
        s.playerY = player.transform.position.y;
        s.playerHealth = player.GetComponent<player_stats>().curHealth;

        return s;
    }

    public void LoadGame()
    {
        if(File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            player.transform.position = new Vector3(save.playerX, save.playerY, 0);
            player.GetComponent<player_stats>().SetHealth(save.playerHealth);

            Unpause();

            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("No Save Game Found");
        }
    }
}
