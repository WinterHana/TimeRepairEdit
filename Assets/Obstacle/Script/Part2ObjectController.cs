using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * �� ������Ʈ�� �±װ� �ʿ���
 * ���� : Scaffolding, �ٴڰ� ���� �ٸ� �� : Wall
 * ��Ϲ��� : Wheel
 * ������ : Pulley
 * ������� : SpiralStairs : ���� ������� ��� ��� �κп� SpiralStairs ���̱�
 */

// ������ �迭 ����
[System.Serializable]
public class ObjectArray
{
    public GameObject[] objects;
}

public class Part2ObjectController : MonoBehaviour
{
    public int maxFixed = 1;                        // �ִ�� ��ĥ �� �ִ� Ƚ��(�ִ� 3��)
    [HideInInspector] public int Fixed = 0;               // ��ģ Ƚ��

    public ObjectArray[] FixedNo;
    SpriteOutline outline;

    private void Awake()
    {
        outline = GetComponent<SpriteOutline>();
        outline.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) outline.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) outline.enabled = false;
    }
    public void OutOfOrderController(GameObject[] Objects)
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            // 1. Walls : ���¿� ���� FadeIn, FadeOut
            if (Objects[i].CompareTag("Scaffolding"))
            {
                // FadeOut�� �ؾ��� �� : ��ü�� ���� ��
                if (Objects[i].GetComponent<WallDeleteController>().FadeOutAccept == true)
                {
                    Objects[i].GetComponent<WallDeleteController>().FadeOutStartControl();
                }

                // FadeIn�� �ؾ��� �� : ��ü�� ���� ��
                else if (Objects[i].GetComponent<WallDeleteController>().FadeOutAccept == false)
                {
                    Objects[i].GetComponent<WallDeleteController>().FadeInStartControl();
                }
            }
            // 2. Wheels
            else if (Objects[i].CompareTag("Wheel"))
            {
                Objects[i].GetComponent<WheelController>().OutOfOrderControl();
            }

            // 3. Pullies
            else if (Objects[i].CompareTag("Pulley"))
            {
                Objects[i].GetComponent<PulleyController>().OutOfOrderControl();
            }

            // 4. SpiralStairs
            else if (Objects[i].CompareTag("SpiralStairs"))
            {
                for (int j = 0; j < Objects[i].transform.childCount; j++)
                {
                    if (Objects[i].transform.GetChild(j).CompareTag("SpiralStairs"))
                    {
                        Objects[i].transform.GetChild(j).GetComponent<SpiralStairsController>().OutOfOrderControl();
                    }
                }
            }
        }
        // Fixed �߰�
        Fixed += 1;
    }

    // �迭�� GameObject�� �߰��ؼ� ���ְų� �߰��� �� �ֵ��� ��
    /*
    [SerializeField] GameObject[] Walls;
    [SerializeField] GameObject[] Wheels;
    [SerializeField] GameObject[] Pullies;
    */

    /*
    public void WallsController()
    {
        // 1. Walls : ���¿� ���� FadeIn, FadeOut
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

    public void WheelsController()
    {
        // 2. Wheels : 
        for (int i = 0; i < Wheels.Length; i++)
        {
            Wheels[i].GetComponent<WheelController>().OutOfOrderControl();
        }
    }

    public void PulliesController()
    {
        // 3. Pullies
        for (int i = 0; i < Pullies.Length; i++)
        {
            Pullies[i].GetComponent<PulleyController>().OutOfOrderControl();
        }
    }
    */


}
