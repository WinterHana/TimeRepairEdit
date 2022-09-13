using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    float CameraZ = -10;
    [SerializeField] bool Test = false;
    [SerializeField] int YpositionControl = 0;      // 좌표 조절
    float PlayerPositionY;
    float DelayTime;                                // Time.deltaTime 저장
    int BaseYpositionControl;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        BaseYpositionControl = YpositionControl;
    }

    // 프레임 상관 없이 출력
    void FixedUpdate()
    {
        PlayerPositionY = Player.transform.position.y + YpositionControl;

        // 밑을 못보도록 고정 : 바닥의 y좌표가 0일때 적절하게 수치 조절을 했음
        if (PlayerPositionY <= 4) PlayerPositionY = 4;

        // TestMode 구별해서 작동하도록 하기
        if (Test == true)
        {
            Vector3 TargetPos = new Vector3(Player.transform.position.x, PlayerPositionY, CameraZ);
            transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 3f);
        }
        else if (Test == false)
        {
            Vector3 TargetPos = new Vector3(0, PlayerPositionY, CameraZ);
            transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 3f);
        }

        // 아래 화살표를 누르면 밑을 보게 할 수 있음
        if (Input.GetKey(KeyCode.DownArrow))
        {
            DelayTime += Time.deltaTime;
            if (DelayTime >= 0.5f)
            {
                YpositionControl = -5;
            }
        }

        else
        {
            DelayTime = 0.0f;
            YpositionControl = BaseYpositionControl;
        }
    }
}
