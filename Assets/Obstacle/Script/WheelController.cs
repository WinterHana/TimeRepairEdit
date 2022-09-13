using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] float WheSpeed = 100.0f;   // ȸ�� �ӵ�
    [SerializeField] bool ClockWise = false;    // ó�� ȸ�� ����
    float BaseSpeed;                            // ������ �ӵ� ���� 

    public bool OutOfOrder = false;      // ������ ���θ� �˷���
    bool isStop = false;        // ���ߴ� ������ Ȯ��
    bool isReverse = false;     // ������ �ٲ�� �ϴ��� Ȯ��
    bool ReverseDir = false;    // �Լ� ���� ����

    SpriteRenderer spr;

    void Awake()
    {
        if (transform.childCount > 0)
        {
            spr = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        }
        else
        {
            spr = gameObject.GetComponent<SpriteRenderer>();
        }
        
    }
    
    void Start()
    {
        BaseSpeed = WheSpeed;
        if (OutOfOrder)
        {
            WheSpeed = 0.0f;

            // ���峭 ���� �������ϰ� �����ֱ�
            Color c = spr.material.color;
            c.a = 0.5f;
            spr.material.color = c;
        }
            
    }

    void FixedUpdate()
    {       
        move();
        if (ReverseDir)
        {
            ReverseRot();
        }
    }

    void move()
    {
        if (ClockWise == false)
        {
            transform.Rotate(new Vector3(0, 0, 1), WheSpeed * Time.deltaTime);
        }
        else if(ClockWise == true)
        {
            transform.Rotate(new Vector3(0, 0, -1), WheSpeed * Time.deltaTime);
        }
    }

    // 1. ȸ�� ���߱�
    void RotStop()
    {
        // ���߰� ������ �˷��ִ� flag
        if (isStop == false && WheSpeed == BaseSpeed)
        {
            isStop = true;
            isReverse = false;          // �ʱ�ȭ
            Debug.Log("���ߴ� ��..");
        }

        // ����
        if (isStop == true && WheSpeed > 3.0f)
        {
            WheSpeed *= 0.98f;
        }

        else if (isStop == true)
        {
            WheSpeed = 0.0f;
            isStop = false;
            isReverse = true;
            Debug.Log("���߱� �Ϸ�");
        }

    }
    
    // 2. ȸ�� �����ϱ�
    void RotStart()
    {
        // ������ �ٲ�� �Ѵٸ�, ���� �ݴ� �������� �ٲٱ�
        if (isReverse == true)
        {
            Debug.Log("���� ��ȯ");
            ClockWise = !ClockWise;
            isReverse = false;
        }

        // ����
        if (isStop == false && WheSpeed < BaseSpeed)
        {
            Debug.Log("���� ��");
            WheSpeed = WheSpeed * 1.02f + 0.1f;
        }
        else
        {
            Debug.Log("���� ��ȯ �Ϸ�");
            WheSpeed = BaseSpeed;
            ReverseDir = false;              // ��ȯ ������ flag
        }
    }

    // 3. ���� ��ȯ�ϴ� ���� �� ���� ��
    void ReverseRot()
    {
        RotStop();
        StartCoroutine(RotDelay());
        
    }

    // 3. �� ���� Coroutine
    IEnumerator RotDelay()
    {
        // WheSpeed�� 0�� �� ������ ��� >> �� �ȵ�
        // yield return new WaitUntil(() => isReverse == true);

        // Ȯ�强�� ������ �ð����� �ϱ�
        yield return new WaitForSeconds(4.0f);
        RotStart();
    }

    // �ܺηκ��� �Է� �ޱ�
    public void ReverseDirection()
    {   
        ReverseDir = true;
    }

    public void OutOfOrderControl()
    {
        OutOfOrder = !OutOfOrder;

        if (OutOfOrder == false)
        {
            Color c = spr.material.color;
            c.a = 1.0f;
            spr.material.color = c;
            // ���� ������
            WheSpeed = BaseSpeed;
        }

        else if (OutOfOrder == true)
        {
            Color c = spr.material.color;
            c.a = 0.5f;
            spr.material.color = c;
            // ���� ������
            WheSpeed = 0.0f;
        }
    }
}
