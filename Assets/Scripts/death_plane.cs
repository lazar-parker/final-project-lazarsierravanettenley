using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_plane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Debug.Log("Player destroyed");
            Destroy(col.gameObject);
            Time.timeScale = 0;
        }
    }
}
