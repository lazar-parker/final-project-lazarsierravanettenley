using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_actions : MonoBehaviour
{
    public float fMult = 0.7f;
    public Rigidbody2D rb;
    public bool onGround =  false;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(fMult * Vector3.left);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(fMult * Vector3.right);
      
    }

      void Jump()
      {
        rb = GetComponent<Rigidbody2D>();
          if(Input.GetKeyDown(KeyCode.W) && Mathf.Abs(rb.velocity.y) < 0.001f)
          {
              rb.AddForce(new Vector2(0f,7f),ForceMode2D.Impulse);
          }
          return;
      }
    


}
