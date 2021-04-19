using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    private Rigidbody2D rb;

    public float dashSpeed;
    private float dashTime;
    public float sDashTime;
    private int direction;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = sDashTime;
    }

    void Update()
    {
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.D))
            {
                direction = 1;
            }
            if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.LeftShift))
            {
                direction = 2;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = sDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
                if (direction == 2)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
            }
        }
    }
}
