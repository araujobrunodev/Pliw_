using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Statistic : MonoBehaviour
{
    public TMP_Text scoreText, bestScoreText, AllClicksText, AllTheDeathsText;
    public static int score, bestScore, AllClicks, AllTheDeaths;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Current score: " + score;
        bestScoreText.text = "best score: " + bestScore;
        AllClicksText.text = "All clicks: " + AllClicks;
        AllTheDeathsText.text = "All the deaths: " + AllTheDeaths;
    }
}
