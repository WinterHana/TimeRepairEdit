using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyController : MonoBehaviour
{
    GameObject left, right, wheel; 
    Rigidbody2D LeftRigid, RightRigid;
    internal Collider2D LeftCollider, RightCollider;

    internal bool Stop = true;
    public bool MovingLeftDown = true;              // �¿� �ö󰡴°� �˷��ִ� flag
    public bool OutOfOrder = false;                 // ������ ���θ� �˷���

    // ������ �������� �̵��� ���� �ߺ��ؼ� �ö��� �ʵ��� �����ϴ� flag �Լ�
    internal bool StopLeftDown = false;
    internal bool StopRightDown = false;

    [SerializeField] float speed = 100.0f;

    SpriteRenderer sprLeft, sprRight, sprWheel;

    void Awake()
    {
        // ��, ���� ���� ��������
        left = transform.GetChild(0).gameObject;
        right = transform.GetChild(1).gameObject;

        LeftRigid = left.GetComponent<Rigidbody2D>();
        RightRigid = right.GetComponent<Rigidbody2D>();

        LeftCollider = left.GetComponent<Collider2D>(); 
        RightCollider = right.GetComponent<Collider2D>();

        // ����ȭ �������� ���� ���ǵ� ��������
        wheel = transform.GetChild(3).gameObject;
    }
    void Start()
    {
        // �� ������ ��������Ʈ ��������
        sprLeft = left.GetComponent<SpriteRenderer>();
        sprRight = right.GetComponent<SpriteRenderer>();
        sprWheel = wheel.GetComponent<SpriteRenderer>();

        if (OutOfOrder == true)
        {
            Color c = sprLeft.material.color;
            c.a = 0.5f;
            sprLeft.material.color = c;
            sprRight.material.color = c;
            sprWheel.material.color = c;
        }
    }

    void FixedUpdate()
    {
        if (OutOfOrder == false)    // ������ �ȳ����� �۵�
        {
            // 1. ����
            if (Stop)
            {
                StopMoving();
            }

            // 1. ���� �Ʒ��� �̵�
            else if (MovingLeftDown == true && StopLeftDown == false)
            {
                LeftDown();
            }

            // 2. ������ �Ʒ��� �̵�
            else if (MovingLeftDown == false && StopRightDown == false)
            {
                RightDown();
            }
        }
  
    }

    // 1. �������� ������
    internal void RightDown()
    {
        LeftRigid.velocity = Vector2.up * speed * Time.deltaTime;
        RightRigid.velocity = Vector2.down * speed * Time.deltaTime; 
    }

    // 2. ������ ������
    internal void LeftDown()
    {
        RightRigid.velocity = Vector2.up * speed * Time.deltaTime;
        LeftRigid.velocity = Vector2.down * speed * Time.deltaTime;
    }

    // 3. ���� : internal�� �����ؼ� ���� ������Ʈ���� �����Ӱ� ���
    internal void StopMoving()
    {
        LeftRigid.velocity = Vector2.zero;
        RightRigid.velocity = Vector2.zero;
    }

    public void OutOfOrderControl()
    {
        OutOfOrder = !OutOfOrder;
        if (OutOfOrder == false)
        {
            Color c = sprLeft.material.color;
            c.a = 1.0f;
            sprLeft.material.color = c;
            sprRight.material.color = c;
            sprWheel.material.color = c;   
        }
        else if (OutOfOrder == true)
        {
            Color c = sprLeft.material.color;
            c.a = 0.5f;
            sprLeft.material.color = c;
            sprRight.material.color = c;
            sprWheel.material.color = c;
        }
    }
}
