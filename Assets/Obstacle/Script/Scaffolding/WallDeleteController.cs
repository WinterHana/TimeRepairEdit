using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* SpiralStairsController�� ������ �ڵ�
 * ������ ������ ���� ������ ������⵵ �ϰ� ����⵵ ��
 * �ٸ� ������Ʈ���� ������ �����ϳ�, � �ݶ��̴��� �������� ���� col�� �ڷ����� �ٲ�� ��
 * ex) ����� ���� �ݶ��̴��� �޾ƾ� ��
 */
public class WallDeleteController : MonoBehaviour
{
    SpriteRenderer sprite;
    Collider2D col;
    const float delay = 1.0f;                           // ������� ������ �����ϴ� ���
    [HideInInspector] public bool FadeOutAccept = true; // FadeOut�� �ؾ��ϴ��� �˷��ִ� flag ����
    // PolygonCollider2D[] ChildCol;

    // int childCount;
    // FadeOut�� FadeIn�� �����Ű�� bool ����
    bool FadeOutStart = false;          
    bool FadeInStart = false;

    // ó���� ������ ������ִ� �������� �ƴ��� �˷��ִ� bool ����
    [SerializeField] bool OnDelete = false;

    int childCount;
    Collider2D[] Children;

    void Awake()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        col = this.GetComponent<Collider2D>();

    }

    private void Start()
    {
        childCount = transform.childCount;
        if(childCount > 0) Children = gameObject.GetComponentsInChildren<Collider2D>();

        if (OnDelete)
        {
            FadeOutAccept = false;
            col.enabled = false;
            
            if (childCount > 0)
            {
                foreach (Collider2D i in Children)
                {
                    i.enabled = false;
                }
            }
            

            Color c = sprite.material.color;
            c.a = 0.0f;
            sprite.material.color = c;
        }
    }

    IEnumerator FadeOut()
    {
        FadeOutAccept = false;
        float i = delay;
        while (i >= 0.0f)
        {
            i -= delay / 50;
            float f = i / delay;
            Color c = sprite.material.color;
            c.a = f;
            sprite.material.color = c;
            yield return new WaitForSeconds(delay/ 50);
            if (i <= delay / 10 * 2)
            {
                col.enabled = false;

                if (childCount > 0)
                {
                    foreach (Collider2D j in Children)
                    {
                        j.enabled = false;
                    }
                }

            }
        } 
    }

    IEnumerator FadeIn()
    {
        FadeOutAccept = true;
        float i = 0.0f;
        while (i <= delay)
        {
            i += delay / 50; 
            float f = i / delay;
            Color c = sprite.material.color;
            c.a = f;
            sprite.material.color = c;
            yield return new WaitForSeconds(delay / 50);
            if (i >= delay / 10 * 8)
            {
                col.enabled = true;

                if (childCount > 0)
                {
                    foreach (Collider2D j in Children)
                    {
                        j.enabled = true;
                    }
                }
            }
        }
    }

    // �� �Լ��� FadeIn, FadeOut ������ ��
    public void FadeOutStartControl()
    {
        FadeOutStart = true;
    }

    public void FadeInStartControl()
    {
        FadeInStart = true; 
    }

    private void FixedUpdate()
    {
        if (FadeOutStart)
        {
            StartCoroutine(FadeOut());
            FadeOutStart = false;
        }

        if (FadeInStart)
        {
            StartCoroutine(FadeIn());
            FadeInStart = false;
        }
    }
}
