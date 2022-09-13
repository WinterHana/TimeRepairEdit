using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * 1. 메인 메뉴에서 start를 눌렀을 때, 씬 이름을 통해 게임 화면으로 이동한다.
 * 2. 현재 씬에서 다음 번호의 씬으로 넘어가도록 설정했으므로
 *    file > setting build 에서 씬 순서를 적절히 배치해야 한다.
 */ 
public class GateSceneManager : MonoBehaviour
{
    // 1. 바로 전환하기
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("씬 이동");
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // 비동기로 불러옴
            // SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    // 2. 로딩 씬을 띄우고 전환하기 : 220803 현재는 하나의 씬으로 밖에 이동을 못하는데 연구할 예정
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("씬 이동");
        if (collision.CompareTag("Player"))
        {
            SceneLoader.Instance.LoadScene("PlayScene2");
        }
    }
    */
}
