using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatSystem : MonoBehaviour
{
    public Queue<string> sentences;
    public string currentSentance;
    public TextMeshPro text;
    public GameObject quad;

    public void Ondialogue(string[] lines, Transform chatPoint)
    {
        transform.position = chatPoint.position;
        sentences = new Queue<string>();
        sentences.Clear();
        foreach (var line in lines)
        {
            sentences.Enqueue(line);
        }
        StartCoroutine(DialogueFlow(chatPoint));
    }

    IEnumerator DialogueFlow(Transform chatPoint)
    {
        yield return null;
        while (sentences.Count > 0)
        {
            currentSentance = sentences.Dequeue();
            yield return StartCoroutine(Typing(currentSentance, chatPoint));
            
        }
        Destroy(gameObject);
    }

    IEnumerator Typing(string line, Transform chatPoint)
    {
        text.text = "";
        WaitForSeconds typingDelay = new WaitForSeconds(0.1f);
        foreach (char letter in line.ToCharArray())
        {
            text.text += letter;
            float x = text.preferredWidth;
            x = (x > 5) ? 5 : x + 0.3f;
            quad.transform.localScale = new Vector2(x, text.preferredHeight + 0.3f);
            transform.position = new Vector2(chatPoint.position.x, chatPoint.position.y + text.preferredHeight / 2);
            yield return typingDelay;
        }
        yield return new WaitForSeconds(4.0f);
    }
}
