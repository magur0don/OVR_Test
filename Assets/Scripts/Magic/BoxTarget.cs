using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTarget : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            scoreManager.SetScore(10);
            this.gameObject.SetActive(false);
        }
    }
}
