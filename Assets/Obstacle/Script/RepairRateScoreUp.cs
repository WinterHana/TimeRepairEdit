using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RepairRateScoreUp : MonoBehaviour
{
    bool follow = false;
    public static int a = 0;
    Part2ObjectController part;
    GameObject Shift;

    void Awake()
    {
        part = GetComponent<Part2ObjectController>();
        Shift = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (follow && Score.score > 0)
        {
            Shift.SetActive(true);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                // GetComponent<AudioSource>().Play();
                RepairRate.score1 += 1;
                Score.score -= 1;

                // 상호작용
                if (part.FixedNo.Length == 0)
                {
                    part.Fixed += 1;
                }
                else
                {
                    part.OutOfOrderController(part.FixedNo[part.Fixed].objects);
                }

                if (part.Fixed >= part.maxFixed)
                {
                    // 삭제
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            Shift.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            follow = true;
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            follow = false;
        }
    }
}
