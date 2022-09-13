using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyRightController : MonoBehaviour
{
    GameObject Right;            // Right �����ͼ�
    PulleyController Pulley;    // �� Right�� �θ��� Pulley�� ��ũ��Ʈ�� ������ ��

    void Awake()
    {
        Right = transform.parent.gameObject;
        Pulley = Right.transform.parent.GetComponent<PulleyController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Pulley.OutOfOrder == false)             // ������ �ȳ��� ���� �۵�
        {
            if (collision.collider.gameObject.CompareTag("Player"))
            {
                // ���� �Ʒ��� �̵�
                Pulley.Stop = false;
                Pulley.MovingLeftDown = false;
            }
        }

    }
}
