using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class NextEndingScene : MonoBehaviour
{
    VideoPlayer vp;

    void Awake()
    {
        vp = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (vp.time > 3.0f && !(vp.isPlaying))
        {
            // Å©·¹µ÷ ¾ÀÀ¸·Î ÀÌµ¿
            // SceneManager.LoadScene("Credit");
        }
    }
}
