using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFadeContorller : MonoBehaviour
{
    [SerializeField] GameObject[] Walls;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if문으로 조건 달아서 생성 가능
        /*
        for (int i = 0; i < Walls.Length; i++)
        {
            // FadeOut을 해야할 때 : 물체가 있을 때
            if (Walls[i].GetComponent<WallDeleteController>().FadeOutAccept == true)
            {
                Walls[i].GetComponent<WallDeleteController>().FadeOutStartControl();
            }

            // FadeIn을 해야할 때 : 물체가 없을 때
            else if (Walls[i].GetComponent<WallDeleteController>().FadeOutAccept == false)
            {
                Walls[i].GetComponent<WallDeleteController>().FadeInStartControl();
            }
        }
        */
    }
}
