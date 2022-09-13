using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 사진을 filp 했는데 콜라이더가 filp이 안될 때 적용하는 스크립트
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
