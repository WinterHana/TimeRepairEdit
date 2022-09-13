using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f; //�޸��� �ӵ�
    public float power; // ���� �ӵ�
    public Rigidbody2D rigid;

    private int Multikey = 0;
    private float FirstDir = 0f;
    
    public float Laydistance; //���� ���� ������


    SpriteRenderer spriteRenderer;
    Animator anim;

    // �Ҹ�
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
        //�÷��̾� �̵�
        // �ƹ��͵� �ȴ����� 0 ��ȯ, ������ ������ -1�� ��ȯ, �������� ������ 1�� ��ȯ.
        var xx = GetNewAxisRaw(KeyCode.LeftArrow, KeyCode.RightArrow);
        // Debug.Log(xx);

        if (xx == 0)//������ ���� �� �ִϸ��̼�
        {
            anim.SetBool("walking", false);
        }else
        {
            anim.SetBool("walking", true); 
            if (xx == -1) //�����϶� ĳ���� �¿����
                spriteRenderer.flipX = true;
            else if (xx == 1) //�������� �� ĳ���� �̹��� ����
                spriteRenderer.flipX = false;
        }

        //��ǥ�̵�
        // transform.Translate(xx * Vector2.right * speed * Time.deltaTime);

        //Debug.DrawRay(rigid.position, Vector3.down * Laydistance, new Color(0, 1, 0));
        //RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, Laydistance, LayerMask.GetMask("ground"));

        //�÷��̾� ����
        if (Input.GetKeyDown(KeyCode.UpArrow) && !anim.GetBool("jumping") /*&& rayHit.collider != null*/)
        {
            aud.PlayOneShot(JumpSound);
            rigid.velocity = Vector2.up * power;
            anim.SetBool("jumping", true);
        }

        if (rigid.velocity.y < 0)//ĳ���Ͱ� ������ ��
        {
            Debug.DrawRay(rigid.position, Vector3.down * Laydistance, new Color(0, 1, 0));//�������� �׸���
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, Laydistance, LayerMask.GetMask("ground"));//ground ���̾�� ����� �Ǻ�
            if (rayHit.collider != null) //���̳� �������� ����
            {
                anim.SetBool("jumping", false); //������ ����(�ϴ�����)
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

        //���ϵ� ���� ����
        var ReturnDir = 0f;

        //�Ͻ����� ����, Ű �Է� ó��x
        if(Time.timeScale == 0f)
            return ReturnDir;
            
        //k1 ������ -1
        if (Input.GetKey(k1))
        {
            //���� ����ó��
            ReturnDir = -1;
         
            //Ű�� �������� üũ
            if (Input.GetKeyDown(k1))
                Multikey++;

            //�¿� ���� Ű�� ���� ���� Ű ó��
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
