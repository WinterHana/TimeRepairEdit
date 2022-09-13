using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    bool follow = false;
    [SerializeField] int SceneNum;
    [SerializeField] bool ShiftControl = false;

    void Update()
    {
        if (ShiftControl)
        {
            if (follow && Input.GetKeyDown(KeyCode.LeftShift))
                SceneManager.LoadScene(SceneNum);
        }
        else 
        {
            if (follow) SceneManager.LoadScene(SceneNum);
        }
    }

    void OnTriggerEnter2D(Collider2D PlayerPrefad)
    {
        if (PlayerPrefad.CompareTag("Player"))
        {
            follow = true;
        }
    }
    void OnTriggerExit2D(Collider2D PlayerPrefad)
    {
        if (PlayerPrefad.CompareTag("Player"))
        {
            follow = false;
        }
    }
}
