using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 각 오브젝트의 태그가 필요함
 * 발판 : Scaffolding, 바닥과 같은 다른 것 : Wall
 * 톱니바퀴 : Wheel
 * 도르래 : Pulley
 * 나선계단 : SpiralStairs : 새로 만들었을 경우 계단 부분에 SpiralStairs 붙이기
 */

// 이차원 배열 생성
[System.Serializable]
public class ObjectArray
{
    public GameObject[] objects;
}

public class Part2ObjectController : MonoBehaviour
{
    public int maxFixed = 1;                        // 최대로 고칠 수 있는 횟수(최대 3번)
    [HideInInspector] public int Fixed = 0;               // 고친 횟수

    public ObjectArray[] FixedNo;
    SpriteOutline outline;

    private void Awake()
    {
        outline = GetComponent<SpriteOutline>();
        outline.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) outline.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) outline.enabled = false;
    }
    public void OutOfOrderController(GameObject[] Objects)
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            // 1. Walls : 상태에 따라 FadeIn, FadeOut
            if (Objects[i].CompareTag("Scaffolding"))
            {
                // FadeOut을 해야할 때 : 물체가 있을 때
                if (Objects[i].GetComponent<WallDeleteController>().FadeOutAccept == true)
                {
                    Objects[i].GetComponent<WallDeleteController>().FadeOutStartControl();
                }

                // FadeIn을 해야할 때 : 물체가 없을 때
                else if (Objects[i].GetComponent<WallDeleteController>().FadeOutAccept == false)
                {
                    Objects[i].GetComponent<WallDeleteController>().FadeInStartControl();
                }
            }
            // 2. Wheels
            else if (Objects[i].CompareTag("Wheel"))
            {
                Objects[i].GetComponent<WheelController>().OutOfOrderControl();
            }

            // 3. Pullies
            else if (Objects[i].CompareTag("Pulley"))
            {
                Objects[i].GetComponent<PulleyController>().OutOfOrderControl();
            }

            // 4. SpiralStairs
            else if (Objects[i].CompareTag("SpiralStairs"))
            {
                for (int j = 0; j < Objects[i].transform.childCount; j++)
                {
                    if (Objects[i].transform.GetChild(j).CompareTag("SpiralStairs"))
                    {
                        Objects[i].transform.GetChild(j).GetComponent<SpiralStairsController>().OutOfOrderControl();
                    }
                }
            }
        }
        // Fixed 추가
        Fixed += 1;
    }

    // 배열에 GameObject를 추가해서 없애거나 추가할 수 있도록 함
    /*
    [SerializeField] GameObject[] Walls;
    [SerializeField] GameObject[] Wheels;
    [SerializeField] GameObject[] Pullies;
    */

    /*
    public void WallsController()
    {
        // 1. Walls : 상태에 따라 FadeIn, FadeOut
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
    }

    public void WheelsController()
    {
        // 2. Wheels : 
        for (int i = 0; i < Wheels.Length; i++)
        {
            Wheels[i].GetComponent<WheelController>().OutOfOrderControl();
        }
    }

    public void PulliesController()
    {
        // 3. Pullies
        for (int i = 0; i < Pullies.Length; i++)
        {
            Pullies[i].GetComponent<PulleyController>().OutOfOrderControl();
        }
    }
    */


}
