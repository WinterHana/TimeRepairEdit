using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f; //달리는 속도
    public float power; // 점프 속도
    public Rigidbody2D rigid;

    private int Multikey = 0;
    private float FirstDir = 0f;
    
    public float Laydistance; //점프 판정 레이저


    SpriteRenderer spriteRenderer;
    Animator anim;

    // 소리
    [SerializeField] AudioClip JumpSound;
    AudioSource aud;
    bool isMoving = false;

    private void Awake()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
        rigid=GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
    }

    
    void Update()
    {   
        //플레이어 이동
        // 아무것도 안누르면 0 반환, 왼쪽을 누르면 -1을 반환, 오른쪽을 누르면 1을 반환.
        var xx = GetNewAxisRaw(KeyCode.LeftArrow, KeyCode.RightArrow);
        // Debug.Log(xx);

        if (xx == 0)//가만히 있을 때 애니메이션
        {
            anim.SetBool("walking", false);
        }else
        {
            anim.SetBool("walking", true); 
            if (xx == -1) //왼쪽일때 캐릭터 좌우반전
                spriteRenderer.flipX = true;
            else if (xx == 1) //오른쪽일 때 캐릭터 이미지 상태
                spriteRenderer.flipX = false;
        }

        //좌표이동
        // transform.Translate(xx * Vector2.right * speed * Time.deltaTime);

        //Debug.DrawRay(rigid.position, Vector3.down * Laydistance, new Color(0, 1, 0));
        //RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, Laydistance, LayerMask.GetMask("ground"));

        //플레이어 점프
        if (Input.GetKeyDown(KeyCode.UpArrow) && !anim.GetBool("jumping") /*&& rayHit.collider != null*/)
        {
            aud.PlayOneShot(JumpSound);
            rigid.velocity = Vector2.up * power;
            anim.SetBool("jumping", true);
        }

        if (rigid.velocity.y < 0)//캐릭터가 떨어질 때
        {
            Debug.DrawRay(rigid.position, Vector3.down * Laydistance, new Color(0, 1, 0));//레이저를 그린다
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, Laydistance, LayerMask.GetMask("ground"));//ground 레이어와 닿는지 판별
            if (rayHit.collider != null) //땅이나 구조물에 닿음
            {
                anim.SetBool("jumping", false); //점프를 끈다(일단점프)
                //Debug.Log(rayHit.collider.name);

            }
        }
    }
    private void FixedUpdate()
    {
        MoveX();
    }

    void MoveX()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        rigid.velocity = new Vector2(x, rigid.velocity.y);
        
        if (rigid.velocity.x != 0) isMoving = true;
        else isMoving = false;

        if (isMoving)
        {
            if (!aud.isPlaying) aud.Play();
        }
        else
        {
            aud.Stop();
        }

    }

    private float GetNewAxisRaw(KeyCode k1, KeyCode k2)
    {

        //리턴될 방향 변수
        var ReturnDir = 0f;

        //일시정지 상태, 키 입력 처리x
        if(Time.timeScale == 0f)
            return ReturnDir;
            
        //k1 누르면 -1
        if (Input.GetKey(k1))
        {
            //뱡향 왼쪽처리
            ReturnDir = -1;
         
            //키가 눌렀음을 체크
            if (Input.GetKeyDown(k1))
                Multikey++;

            //좌우 방향 키중 먼저 눌린 키 처리
            if(Multikey == 1)
                FirstDir = -1;
                
        }

        if (Input.GetKey(k2))
        {
            ReturnDir = 1;

            if (Input.GetKeyDown(k2))
                Multikey++;

            if (Multikey == 1)
                FirstDir = 1;
               
        }


        if (Multikey == 2) {
            ReturnDir = -FirstDir;
        }
            

            

        if(Input.GetKeyUp(k1))
            Multikey--;

        if (Input.GetKeyUp(k2))
            Multikey--;

        if (Multikey == 0)
            FirstDir = 0f;

  
        return ReturnDir;

    }


}
