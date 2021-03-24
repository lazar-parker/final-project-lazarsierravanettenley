using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_actions : MonoBehaviour
{
    public float fMult = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.A))
            rb.AddForce(fMult * Vector3.left);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(fMult * Vector3.right);
    }
}
