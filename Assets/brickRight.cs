using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickRight : MonoBehaviour
{
    bool follow = false;
    public GameObject ob;
    public int movecount = 1;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {


    }

    void Update()
    {
        if (follow && Input.GetKeyDown(KeyCode.LeftShift) && brickLeft.a > -movecount)
        {
            GameObject newpipe = ob;
            newpipe.transform.Translate(speed, 0, 0);
            brickLeft.a -= 1;

        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        follow = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        follow = false;
    }
}
