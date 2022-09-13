using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 각종 오브젝트에 적용해서, 닿으면 어느 위치에 이동할 수 있도록 하는 스크립트
 * 주로 밑으로 빠졌을 때 돌아오게 하는 것
 * 
 */ 
public class WarpPositionControl : MonoBehaviour
{
    [SerializeField] GameObject WarpObject;
    Vector2 pos;
    private void Awake()
    {
        pos = WarpObject.transform.position;  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = pos;
        }
    }
}
