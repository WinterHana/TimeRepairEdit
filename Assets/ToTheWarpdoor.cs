using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTheWarpdoor : MonoBehaviour
{
    bool follow = false;
    public static int a = 0;
    public GameObject sft;

    void Update()
    {
        if (follow && Input.GetKeyDown(KeyCode.LeftShift))
            SceneManager.LoadScene("warpDoor");
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
    void OnTriggerEnter2D(Collider2D PlayerPrefad)
    {
        if (PlayerPrefad.CompareTag("Player"))
        {
            follow = true;
            a = 1;
        }
    }
    void OnTriggerExit2D(Collider2D PlayerPrefad)
    {
        if (PlayerPrefad.CompareTag("Player"))
        {
            follow = false;
            a = 0;
        }
    }
}
