using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class second : MonoBehaviour
{
    bool follow = false;
    public static int a = 0;
    public GameObject ob;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        if (Input.GetButtonDown("Jump") && follow)
        {
            GetComponent<AudioSource>().Play();
            if (ob.activeSelf)
            {
                ob.SetActive(false);
            }
            else
            {
                ob.SetActive(true);
            }
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
