using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableWall : MonoBehaviour
{
    [SerializeField]
    public int health = 3;

    [SerializeField]
    public UnityEngine.Object destructableRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //testing the breakable wall
       //health at 1000
       /*
       if(health > 0) {
           health--;
       }
       else if(health == 0) {
           ExplodeObject();
       }
       */
    }

    /*
    private void OnCollisionEnter2D(Collider2D collision) {
        if(collision.CompareTag("Weapon")) {
            health--;
            if(health <= 0) {
                //breaks the wall
                ExplodeObject();
            }
        }
    }
    */

    public void ExplodeObject() {
        GameObject destructable = (GameObject)Instantiate(destructableRef);

        destructable.transform.position = transform.position;

        Destroy(gameObject);
    }
}
