using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleySwtichController : MonoBehaviour
{
    [SerializeField] GameObject[] Pulleies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < Pulleies.Length; i++)
            {
                if (Pulleies[i].GetComponent<PulleyController>().OutOfOrder == false)       // 고장이 안났을 때만 작동
                {
                    Pulleies[i].GetComponent<PulleyController>().Stop = false;
                } 
            }
        }
    }
}
