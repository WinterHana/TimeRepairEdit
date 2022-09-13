using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSwtichController : MonoBehaviour
{
    [SerializeField] GameObject[] Wheels;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i].GetComponent<WheelController>().ReverseDirection();
            }
        }
    }
}
