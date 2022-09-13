using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSentence : MonoBehaviour
{
    public string[] sentences;
    public Transform chatTr;
    public GameObject chatBoxPrefab;

    bool startDialog = false;
    bool stopCoroutine = false;
    void TalkNpc()
    {
        GameObject go = Instantiate(chatBoxPrefab);
        go.GetComponent<ChatSystem>().Ondialogue(sentences, chatTr);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && startDialog == false)
        {
            startDialog = true;
            TalkNpc();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (startDialog == true && stopCoroutine == false)
        {
            StartCoroutine(dialogDelay());
            stopCoroutine = true;
        }
    }

    IEnumerator dialogDelay()
    {
        yield return new WaitForSeconds(10.0f);
        startDialog = false;
        stopCoroutine = false;
    }
}
