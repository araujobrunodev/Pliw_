using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Statistic;
public class Score : MonoBehaviour
{
    static public TMP_Text scoreText;
    // Start is called before the first frame update
    static void Update()
    {
        scoreText.text = "Score: " + Statistic.score;
    }
}
