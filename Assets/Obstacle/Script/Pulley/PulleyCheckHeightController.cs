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
        if (Pulley.OutOfOrder == false)             // ������ �ȳ��� ���� �۵�
        {
            if (collision == Pulley.LeftCollider) // || collision == parent.RightCollider)
            {
                Debug.Log("������ ��Ƽ� ����");
                Pulley.Stop = true;
                Pulley.MovingLeftDown = true;   // ������ ������ ���� : ���� �Ʒ�
                Pulley.StopRightDown = true;   // flag ���� : ����ȭ �� �� ����ȭ ������ ��
                Pulley.StopLeftDown = false;
            }

            else if (collision == Pulley.RightCollider)
            {
                Debug.Log("�������� ��Ƽ� ����");
                Pulley.Stop = true;
                Pulley.MovingLeftDown = false;  // ������ ������ ���� : ������ �Ʒ�
                Pulley.StopRightDown = false;    // flag ���� 
                Pulley.StopLeftDown = true;
            }
        }

    }
}
