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
        // if������ ���� �޾Ƽ� ���� ����
        /*
        for (int i = 0; i < Walls.Length; i++)
        {
            // FadeOut�� �ؾ��� �� : ��ü�� ���� ��
            if (Walls[i].GetComponent<WallDeleteController>().FadeOutAccept == true)
            {
                Walls[i].GetComponent<WallDeleteController>().FadeOutStartControl();
            }

            // FadeIn�� �ؾ��� �� : ��ü�� ���� ��
            else if (Walls[i].GetComponent<WallDeleteController>().FadeOutAccept == false)
            {
                Walls[i].GetComponent<WallDeleteController>().FadeInStartControl();
            }
        }
        */
    }
}
