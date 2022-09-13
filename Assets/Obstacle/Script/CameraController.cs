using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    float CameraZ = -10;
    [SerializeField] bool Test = false;
    [SerializeField] int YpositionControl = 0;      // ��ǥ ����
    float PlayerPositionY;
    float DelayTime;                                // Time.deltaTime ����
    int BaseYpositionControl;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        BaseYpositionControl = YpositionControl;
    }

    // ������ ��� ���� ���
    void FixedUpdate()
    {
        PlayerPositionY = Player.transform.position.y + YpositionControl;

        // ���� �������� ���� : �ٴ��� y��ǥ�� 0�϶� �����ϰ� ��ġ ������ ����
        if (PlayerPositionY <= 4) PlayerPositionY = 4;

        // TestMode �����ؼ� �۵��ϵ��� �ϱ�
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

        // �Ʒ� ȭ��ǥ�� ������ ���� ���� �� �� ����
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
