using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    LineRenderer lineR;
    Vector2 startPos;
    [SerializeField] GameObject endObejct;

    void Start()
    {
        lineR = GetComponent<LineRenderer>();
        lineR.startWidth = 0.05f;
        lineR.endWidth = 0.05f;
        lineR.startColor = Color.black;
        lineR.endColor = Color.black;
        startPos = gameObject.GetComponent<Transform>().position;
    }

    void Update()
    {
        lineR.SetPosition(0, startPos);
        lineR.SetPosition(1, endObejct.GetComponent<Transform>().position);
    }
}
