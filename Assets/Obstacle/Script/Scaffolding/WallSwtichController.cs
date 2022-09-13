using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwtichController : MonoBehaviour
{
    // 1. ���� �ֱ�
    [SerializeField] GameObject[] Walls;
    // WallDeleteController[] WallDeleteControllers;

    // 2. �̹��� �ٲٱ�
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
        // * �̰ɷ� ���ϰ� ���� �����ҷ��� �ߴµ� �ȵǼ� �׳� �ڵ带 �� ��� ����
        /*
        for (int i = 0; i < Walls.Length; i++)
        {
            WallDeleteControllers[i] = Walls[i].GetComponent<WallDeleteController>();
        }
        */
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // �÷��̾ ��ü�� ���� �� : �������� ������� �� ����
        if (other.tag == "Player")
        {
            Debug.Log("�÷��̾ �����");
            // ���� ����Ʈ�� ���� �� ���� : ��ȣ�ۿ� Ű�� �˰� ����
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("�۵� ����");
                // 1. �̹��� �ٲٱ�
                if (spriteRenderer.sprite == sprites[0]) spriteRenderer.sprite = sprites[1];
                else spriteRenderer.sprite = sprites[0];

                // 2. ���� ������ų� �����
                for (int i = 0; i < Walls.Length; i++)
                {
                    // FadeOut�� �ؾ��� �� : ��ü�� ���� ��
                    if (Walls[i].GetComponent<WallDeleteController>().FadeOutAccept == true)
                    {
                        Walls[i].GetComponent<WallDeleteController>().FadeOutStartControl();
                    }

                    // FadeIn�� �ؾ��� �� : ��ü�� ���� ��
                    else if (Walls[i].GetComponent<WallDeleteController>().FadeOutAccept == false)
                    {
                        Walls[i].GetComponent<WallDeleteController>().FadeInStartControl();
                    } 
                }
                
            }
        }
    }
}
