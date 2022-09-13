using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class laodcentup : MonoBehaviour
{
    bool follow = false;
    public static int a = 0;
    public GameObject sft;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (follow && Input.GetKeyDown(KeyCode.LeftShift))
            SceneManager.LoadScene("center_UP");
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
