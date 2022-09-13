using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door2 : MonoBehaviour
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
            newpipe.transform.position = new Vector3(-3.612f, 1.674f, 0);
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
