using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFixedController : MonoBehaviour
{
    Rigidbody2D rig;

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (x == 0)
        {
            rig.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else 
        {
            rig.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
