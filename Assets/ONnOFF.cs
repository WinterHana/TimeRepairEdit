using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ONnOFF : MonoBehaviour
{
    bool follow = false;
    public GameObject ob;
    public GameObject Pass;

    // Start is called before the first frame update
    void Start()
    {


    }

    void Update()
    {

        if (follow)
        {
            GameObject sp = ob;
            sp.SetActive(true);

        }
        else
        {
            GameObject sp = ob;
            sp.SetActive(false);
        }

        if (follow && Input.GetButtonDown("Jump"))
        {
            if (Pass.activeSelf)
                Pass.SetActive(false);
            else
                Pass.SetActive(true);
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
