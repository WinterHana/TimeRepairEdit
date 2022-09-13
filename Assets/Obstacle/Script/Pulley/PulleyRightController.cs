using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyRightController : MonoBehaviour
{
    GameObject Right;            // Right 가져와서
    PulleyController Pulley;    // 그 Right의 부모인 Pulley의 스크립트를 가져올 것

    void Awake()
    {
        Right = transform.parent.gameObject;
        Pulley = Right.transform.parent.GetComponent<PulleyController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Pulley.OutOfOrder == false)             // 고장이 안났을 때만 작동
        {
            if (collision.collider.gameObject.CompareTag("Player"))
            {
                // 왼쪽 아래로 이동
                Pulley.Stop = false;
                Pulley.MovingLeftDown = false;
            }
        }

    }
}
