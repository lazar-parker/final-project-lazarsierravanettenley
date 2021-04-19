using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour
{
    public void ChangeScene()
    {
        Debug.Log("The button was clicked!");
        SceneManager.LoadScene("Scene_Tutorial");
    }


    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
