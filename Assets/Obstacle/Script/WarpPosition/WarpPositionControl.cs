using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * ���� ������Ʈ�� �����ؼ�, ������ ��� ��ġ�� �̵��� �� �ֵ��� �ϴ� ��ũ��Ʈ
 * �ַ� ������ ������ �� ���ƿ��� �ϴ� ��
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
