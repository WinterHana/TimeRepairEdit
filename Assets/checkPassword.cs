using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPassword : MonoBehaviour
{
    bool follow = false;
    public GameObject passwordPrefab;
    public GameObject ob2;
    public GameObject BB;
    public GameObject RR;
    public GameObject GS;
    public GameObject YC;

    // Start is called before the first frame update
    void Start()
    {


    }

    void Update()
    {


        if (bluebear.a==4 && Input.GetKeyDown(KeyCode.LeftShift) && follow)
        {
            GameObject PP = passwordPrefab;
            PP.SetActive(false);
            GameObject stairs = ob2;
            stairs.SetActive(true);
            bluebear.a = 0;
        }

        else if(bluebear.a == 3 && Input.GetKeyDown(KeyCode.LeftShift) && follow || bluebear.a == 2 && Input.GetKeyDown(KeyCode.LeftShift) && follow || bluebear.a == 1 && Input.GetKeyDown(KeyCode.LeftShift) && follow || bluebear.a == 0 && Input.GetKeyDown(KeyCode.LeftShift) && follow)
        {
            GetComponent<AudioSource>().Play();
            bluebear.a = 0;
            bluebear.b = 0;
            GameObject bb = BB;
            GameObject rr = RR;
            GameObject gs = GS;
            GameObject v = YC;
            bb.transform.localPosition = new Vector3(-5.8607f, -2.17f, 0);
            rr.transform.localPosition = new Vector3(-4.956f, -2.17f, 0);
            gs.transform.localPosition = new Vector3(-4.067374f, -2.17f, 0);
            v.transform.localPosition = new Vector3(-3.161374f, -2.17f, 0);
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
