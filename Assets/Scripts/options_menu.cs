using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class options_menu : MonoBehaviour
{
    private GameObject[] optionsMenu;
    private pause_menu pm;
    public Dropdown rd;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        optionsMenu = GameObject.FindGameObjectsWithTag("OptionElement");
        HideOptions();
        pm = GameObject.FindGameObjectWithTag("PauseMenu").GetComponentInChildren<pause_menu>();

        resolutions = Screen.resolutions;
        rd.ClearOptions();

        List<string> rl = new List<string>();
        for(int i = 0; i < resolutions.Length; i++)
        {
            string o = resolutions[i].width + " x " + resolutions[i].height;
            rl.Add(o);
        }

        rd.AddOptions(rl);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowOptions()
    {
        pm.hidePaused();
        Time.timeScale = 0;
        foreach(GameObject o in optionsMenu)
        {
            o.SetActive(true);
        }
    }

    public void HideOptions()
    {
        foreach(GameObject o in optionsMenu)
        {
            o.SetActive(false);
        }
        if(Time.timeScale == 0)
        {
            pm.showPaused();
        }
    }
}
