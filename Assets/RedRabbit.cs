using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRabbit : MonoBehaviour
{
    bool follow = false;
    //a�� �Է¼����ϰ� ��й�ȣ�� ��ġ�ҽ� +1�� ����, b�� 4�� �Էµƴ��� Ȯ���ϴ� count��
    int c = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (follow && Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (bluebear.a == c)
                bluebear.a++;
            if (bluebear.b == 0)
            {
                bluebear.b += 1;
                this.transform.localPosition = new Vector3(-6.15f, 1.1f, 0);
            }
            else if (bluebear.b == 1)
            {
                bluebear.b += 1;
                this.transform.localPosition = new Vector3(-4.971f, 1.1f, 0);
            }
            else if (bluebear.b == 2)
            {
                bluebear.b += 1;
                this.transform.localPosition = new Vector3(-3.8f, 1.1f, 0);
            }
            else
            {
                bluebear.b += 1;
                this.transform.localPosition = new Vector3(-2.61f, 1.1f, 0);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        follow = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        follow = false;
    }
}
