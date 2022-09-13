using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gamemanager : MonoBehaviour
{
    public TextMeshProUGUI talktext;
    public GameObject scanObject;
    public GameObject menuSet;
    public GameObject character;

    private void Awake()
    {
    }
    public void Action(GameObject scanobj)
    {
        scanObject =scanobj;
        talktext.text = "This Object name is" + scanobj.name;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }

    }
    public void GameExit()
    {
        Application.Quit();
    }
    
    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", character.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", character.transform.position.y);
        PlayerPrefs.Save();
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        character.transform.position = new Vector2(x, y);

    }
}
