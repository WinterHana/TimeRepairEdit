using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEfect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Score.score > 0 && RepairRateScoreUp.a>0)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
