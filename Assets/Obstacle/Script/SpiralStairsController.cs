using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * <참고> 
 * 1. https://jrady.tistory.com/7
 * 2. https://ncube-studio.tistory.com/entry/%ED%8E%98%EC%9D%B4%EB%93%9C%EC%9D%B8Fade-In-%ED%8E%98%EC%9D%B4%EB%93%9C%EC%95%84%EC%9B%83Fade-Out-%ED%82%A4%EC%99%80-%EB%B2%84%ED%8A%BC%EC%9C%BC%EB%A1%9C-%EC%98%A4%EB%B8%8C%EC%A0%9D%ED%8A%B8-%ED%88%AC%EB%AA%85%ED%95%98%EA%B2%8C-%EB%A7%8C%EB%93%A4%EA%B8%B0%EC%9C%A0%EB%8B%88%ED%8B%B0-2D%EA%B8%B0%EC%B4%88%EA%B0%95%EC%A2%8C-Unity-C-ScriptAlpha-Opacity
 */
public class SpiralStairsController : MonoBehaviour
{
    [SerializeField] float delay = 5.0f; // 계단이 사리지고 생기는 간격 조절
    [SerializeField] bool OutOfOrder = false;
    SpriteRenderer sprite;
    PolygonCollider2D col;

    float time; // 시간을 알려줌
    bool FadeOutAccept = true; // FadeOut을 해야하는지 알려주는 flag 변수

    void Awake()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        col = this.GetComponent<PolygonCollider2D>();
    }

    void Start()
    {
        if (OutOfOrder)
        {
            Color c = sprite.material.color;
            c.a = 0.0f;
            sprite.material.color = c;
            col.enabled = false;
            time = 0.0f;
        }
    }
    // FadeOut
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
            yield return new WaitForSeconds(delay / 50);
            if (i <= delay / 10 * 2)
            {
                col.enabled = false;
            } 
        }
       
    }

    // FadeIn : FadeOut에서 역순으로 진행
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
            }
        }
    }

    void Update()
    {
        if (OutOfOrder == false)
        {
            time += Time.deltaTime;
            // Debug.Log(time);

            if (time >= delay)
            {
                if (FadeOutAccept == true)
                {
                    StartCoroutine(FadeOut());
                }
                else if (FadeOutAccept == false)
                {
                    StartCoroutine(FadeIn());
                }
                time = 0.0f;
            }
        }
    }

    public void OutOfOrderControl()
    {
        OutOfOrder = !OutOfOrder;

        if (OutOfOrder == false)
        {
            Color c = sprite.material.color;
            c.a = 1.0f;
            sprite.material.color = c;
            FadeOutAccept = true;
        }

        else if (OutOfOrder == true)
        {
            Color c = sprite.material.color;
            c.a = 0.0f;
            sprite.material.color = c;
            time = 0.0f;
        }
    }
}
