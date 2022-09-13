using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ah : MonoBehaviour
{
    public GameObject talk;
    bool follow = false;
    public static int a = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (follow && Input.GetButtonDown("Jump"))
        {
            if (talk.activeSelf)
                talk.SetActive(false);
            else
                talk.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D character)
    {
        follow = true;
        a = 1;
    }
    void OnTriggerExit2D(Collider2D character)
    {
        follow = false;
        a = 0;
    }
}
