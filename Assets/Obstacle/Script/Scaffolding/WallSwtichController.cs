using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwtichController : MonoBehaviour
{
    // 1. 발판 넣기
    [SerializeField] GameObject[] Walls;
    // WallDeleteController[] WallDeleteControllers;

    // 2. 이미지 바꾸기
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
        // * 이걸로 편하게 변수 지정할려고 했는데 안되서 그냥 코드를 좀 길게 적음
        /*
        for (int i = 0; i < Walls.Length; i++)
        {
            WallDeleteControllers[i] = Walls[i].GetComponent<WallDeleteController>();
        }
        */
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // 플레이어가 물체에 닿을 때 : 윤곽선을 만들던지 할 예정
        if (other.tag == "Player")
        {
            Debug.Log("플레이어가 닿았음");
            // 왼쪽 쉬프트를 누를 때 실행 : 상호작용 키로 알고 있음
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("작동 시작");
                // 1. 이미지 바꾸기
                if (spriteRenderer.sprite == sprites[0]) spriteRenderer.sprite = sprites[1];
                else spriteRenderer.sprite = sprites[0];

                // 2. 발판 사라지거나 생기기
                for (int i = 0; i < Walls.Length; i++)
                {
                    // FadeOut을 해야할 때 : 물체가 있을 때
                    if (Walls[i].GetComponent<WallDeleteController>().FadeOutAccept == true)
                    {
                        Walls[i].GetComponent<WallDeleteController>().FadeOutStartControl();
                    }

                    // FadeIn을 해야할 때 : 물체가 없을 때
                    else if (Walls[i].GetComponent<WallDeleteController>().FadeOutAccept == false)
                    {
                        Walls[i].GetComponent<WallDeleteController>().FadeInStartControl();
                    } 
                }
                
            }
        }
    }
}
