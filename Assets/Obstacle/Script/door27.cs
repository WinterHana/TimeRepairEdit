using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door27 : MonoBehaviour
{
    bool follow = false;
    public static int a = 0;
    public GameObject ob;
    [SerializeField] Vector3 pos;
    void Update()
    {
        if (follow && Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject newpipe = ob;
            newpipe.transform.position = pos;
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
