using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehavior : MonoBehaviour
{
    public void changeScene(string sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }


    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
