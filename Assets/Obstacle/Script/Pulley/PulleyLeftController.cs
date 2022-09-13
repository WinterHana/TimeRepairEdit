using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyLeftController : MonoBehaviour
{
    GameObject Left;            // Left �����ͼ�
    PulleyController Pulley;    // �� Left�� �θ��� Pulley�� ��ũ��Ʈ�� ������ ��

    void Awake()
    {
        Left = transform.parent.gameObject;
        Pulley = Left.transform.parent.GetComponent<PulleyController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Pulley.OutOfOrder == false)             // ������ �ȳ��� ���� �۵�
        {
            if (collision.collider.gameObject.CompareTag("Player"))
            {
                // ���� �Ʒ��� �̵�
                Pulley.Stop = false;
                Pulley.MovingLeftDown = true;
            }
        }

    }
}
