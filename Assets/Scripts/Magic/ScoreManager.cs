using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    public TextMeshPro ScoreText;

    public void SetScore(int addScore)
    {
        score += addScore;
    }

    public void ViewScore()
    {
        ScoreText.text = $"Score:{score}";
        ScoreText.gameObject.SetActive(true);
    }
}
