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
                if (Pulleies[i].GetComponent<PulleyController>().OutOfOrder == false)       // ������ �ȳ��� ���� �۵�
                {
                    Pulleies[i].GetComponent<PulleyController>().Stop = false;
                } 
            }
        }
    }
}
