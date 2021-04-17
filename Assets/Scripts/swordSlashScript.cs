using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordSlashScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateSwordSlash() {
        gameObject.SetActive(true);
    }

    public void deactivateSwordSlash() {
        gameObject.SetActive(false);
    }
}
