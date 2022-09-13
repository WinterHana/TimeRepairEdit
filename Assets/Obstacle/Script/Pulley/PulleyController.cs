using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyController : MonoBehaviour
{
    GameObject left, right, wheel; 
    Rigidbody2D LeftRigid, RightRigid;
    internal Collider2D LeftCollider, RightCollider;

    internal bool Stop = true;
    public bool MovingLeftDown = true;              // 좌우 올라가는거 알려주는 flag
    public bool OutOfOrder = false;                 // 고장의 여부를 알려줌

    // 일정한 수준으로 이동한 다음 중복해서 올라가지 않도록 조절하는 flag 함수
    internal bool StopLeftDown = false;
    internal bool StopRightDown = false;

    [SerializeField] float speed = 100.0f;

    SpriteRenderer sprLeft, sprRight, sprWheel;

    void Awake()
    {
        // 좌, 우의 발판 가져오기
        left = transform.GetChild(0).gameObject;
        right = transform.GetChild(1).gameObject;

        LeftRigid = left.GetComponent<Rigidbody2D>();
        RightRigid = right.GetComponent<Rigidbody2D>();

        LeftCollider = left.GetComponent<Collider2D>(); 
        RightCollider = right.GetComponent<Collider2D>();

        // 투명화 목적으로 위에 발판도 가져오기
        wheel = transform.GetChild(3).gameObject;
    }
    void Start()
    {
        // 각 모형의 스프라이트 가져오기
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
        if (OutOfOrder == false)    // 고장이 안날때만 작동
        {
            // 1. 멈춤
            if (Stop)
            {
                StopMoving();
            }

            // 1. 왼쪽 아래로 이동
            else if (MovingLeftDown == true && StopLeftDown == false)
            {
                LeftDown();
            }

            // 2. 오른쪽 아래로 이동
            else if (MovingLeftDown == false && StopRightDown == false)
            {
                RightDown();
            }
        }
  
    }

    // 1. 오른쪽이 밑으로
    internal void RightDown()
    {
        LeftRigid.velocity = Vector2.up * speed * Time.deltaTime;
        RightRigid.velocity = Vector2.down * speed * Time.deltaTime; 
    }

    // 2. 왼쪽이 밑으로
    internal void LeftDown()
    {
        RightRigid.velocity = Vector2.up * speed * Time.deltaTime;
        LeftRigid.velocity = Vector2.down * speed * Time.deltaTime;
    }

    // 3. 멈춤 : internal로 선언해서 동일 프로젝트에만 자유롭게 사용
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
