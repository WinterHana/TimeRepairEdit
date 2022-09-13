using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* SpiralStairsController를 응용한 코드
 * 일정한 반응이 오면 발판이 사라지기도 하고 생기기도 함
 * 다른 오브젝트에도 응용이 가능하나, 어떤 콜라이더를 쓰는지에 따라 col의 자료형을 바꿔야 함
 * ex) 계단은 엣지 콜라이더로 받아야 함
 */
public class WallDeleteController : MonoBehaviour
{
    SpriteRenderer sprite;
    Collider2D col;
    const float delay = 1.0f;                           // 사라지는 딜레이 조절하는 상수
    [HideInInspector] public bool FadeOutAccept = true; // FadeOut을 해야하는지 알려주는 flag 변수
    // PolygonCollider2D[] ChildCol;

    // int childCount;
    // FadeOut과 FadeIn을 실행시키는 bool 변수
    bool FadeOutStart = false;          
    bool FadeInStart = false;

    // 처음에 발판이 사라져있는 상태인지 아닌지 알려주는 bool 변수
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

    // 이 함수로 FadeIn, FadeOut 조절할 것
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
