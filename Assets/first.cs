using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class first : MonoBehaviour
{
    bool follow = false;
    public static int a = 0;
    public GameObject ob;
    public GameObject sft;
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        if (Input.GetButtonDown("Jump") && follow)
        {

            if (ob.activeSelf)
            {
                ob.SetActive(false);
                wall.SetActive(false);
            }
            else
            {
                ob.SetActive(true);
                wall.SetActive(true);
            }
        }
        if (follow)
        {
            GameObject shift = sft;
            shift.SetActive(true);
        }
        else
        {
            GameObject shift = sft;
            shift.SetActive(false);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        follow = true;
        a = 1;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        follow = false;
        a = 0;
    }
}
