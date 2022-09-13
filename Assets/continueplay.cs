using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class continueplay : MonoBehaviour
{
    public void ContitnueGame()
    {
        SceneManager.LoadScene("Playscene");
    }
}
