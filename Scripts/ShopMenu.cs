using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{


    public GameObject weap1Slot;
    public GameObject weap2Slot;
    // Start is called before the first frame update
    void Start()
    { 
        int slot1 = Random.Range(0, 10);
        int slot2 = Random.Range(0, 10);

        GameObject sl1 =  lootTable(slot1);
        GameObject sl2 = lootTable(slot2);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void leave(string sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }


    public GameObject lootTable(int n)
    {



        return null;
    }
}
