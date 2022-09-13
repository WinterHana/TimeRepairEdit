using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackdoor : MonoBehaviour
{
    bool follow = false;
    public static int a = 0;
    public GameObject ob;
    public GameObject sft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (follow && Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject newpipe = ob;
            newpipe.transform.position = new Vector3(-3.96f, 4.12f, 0);
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
