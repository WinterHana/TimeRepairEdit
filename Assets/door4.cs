using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door4 : MonoBehaviour
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
        if (follow && Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject newpipe = ob;
            newpipe.transform.position = new Vector3(-2.332f, 4.117f, 0);
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
