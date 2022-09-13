using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * 1. ���� �޴����� start�� ������ ��, �� �̸��� ���� ���� ȭ������ �̵��Ѵ�.
 * 2. ���� ������ ���� ��ȣ�� ������ �Ѿ���� ���������Ƿ�
 *    file > setting build ���� �� ������ ������ ��ġ�ؾ� �Ѵ�.
 */ 
public class GateSceneManager : MonoBehaviour
{
    // 1. �ٷ� ��ȯ�ϱ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�� �̵�");
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // �񵿱�� �ҷ���
            // SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    // 2. �ε� ���� ���� ��ȯ�ϱ� : 220803 ����� �ϳ��� ������ �ۿ� �̵��� ���ϴµ� ������ ����
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�� �̵�");
        if (collision.CompareTag("Player"))
        {
            SceneLoader.Instance.LoadScene("PlayScene2");
        }
    }
    */
}
