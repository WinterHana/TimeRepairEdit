using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ������ filp �ߴµ� �ݶ��̴��� filp�� �ȵ� �� �����ϴ� ��ũ��Ʈ
 * 
 */
public class FilpColliderController : MonoBehaviour
{
    void Start()
    {
        Vector3 scale = transform.localScale;

        scale.x = Mathf.Abs(scale.x);

        transform.localScale = -scale;
    }

}
