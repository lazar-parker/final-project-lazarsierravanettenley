using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;
    public float speed = 0.125f;
    public Vector3 offset;

    void LateUpdate ()
    {
        if(target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
