using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyCheckHeightController : MonoBehaviour
{
    PulleyController Pulley;

    void Awake()
    {
        Pulley = transform.parent.GetComponent<PulleyController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Pulley.OutOfOrder == false)             // 고장이 안났을 때만 작동
        {
            if (collision == Pulley.LeftCollider) // || collision == parent.RightCollider)
            {
                Debug.Log("왼쪽이 닿아서 멈춤");
                Pulley.Stop = true;
                Pulley.MovingLeftDown = true;   // 다음에 움직일 순서 : 왼쪽 아래
                Pulley.StopRightDown = true;   // flag 조절 : 최적화 할 때 간략화 가능할 듯
                Pulley.StopLeftDown = false;
            }

            else if (collision == Pulley.RightCollider)
            {
                Debug.Log("오른쪽이 닿아서 멈춤");
                Pulley.Stop = true;
                Pulley.MovingLeftDown = false;  // 다음에 움직일 순서 : 오른쪽 아래
                Pulley.StopRightDown = false;    // flag 조절 
                Pulley.StopLeftDown = true;
            }
        }

    }
}
