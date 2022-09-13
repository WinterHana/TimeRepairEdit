using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Score.score += 1;
            this.gameObject.SetActive(false);
        }
    }
}
