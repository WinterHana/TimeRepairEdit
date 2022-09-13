using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckController : MonoBehaviour
{
    Rigidbody2D rig;
    SpriteRenderer sprite;
    PolygonCollider2D col;
    [SerializeField] bool Fixed = false;
    bool destory = false;           // �ڷ�ƾ ������ bool ����
    bool startDying = false;        // CollisionEnter�� �ѹ��� �Ͼ �� �ֵ��� �ϴ� bool ����
    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<PolygonCollider2D>();
    }
    void Start()
    {
        rig.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void FixedUpdate()
    {
        if (destory == true && startDying == false)
        {
            StartCoroutine(FadeOut(1.5f));
            startDying = true;
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Pulley") && collision.rigidbody.velocity != new Vector2(0, 0))
        {
            rig.constraints = RigidbodyConstraints2D.None;
        }
        if (Fixed == false)
        {
            if (collision.collider.gameObject.CompareTag("Wall") || collision.collider.gameObject.CompareTag("Scaffolding"))
            {
                // Debug.Log("�۵� ����"); 
                destory = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Pulley") && collision.rigidbody.velocity != new Vector2(0, 0))
        {
            rig.constraints = RigidbodyConstraints2D.None;
        }
    }

    IEnumerator FadeOut(float delay)
    {
        float i = delay;
        while (i >= 0.0f)
        {
            i -= delay / 50;
            float f = i / delay;
            Color c = sprite.material.color;
            c.a = f;
            sprite.material.color = c;
            yield return new WaitForSeconds(delay / 50);
        }
        Destroy(gameObject);
    }
}
