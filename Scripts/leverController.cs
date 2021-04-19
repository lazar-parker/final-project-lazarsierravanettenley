using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverController : MonoBehaviour
{

    public bool isOn;
    public Animator animator;

    public GameObject attachment;

    public void isOpen()
    {
        if(!isOn)
        {
            isOn = true;
            Debug.Log("Lever is on");
            animator.SetBool("isOpen", isOn);
        }
    }
}
