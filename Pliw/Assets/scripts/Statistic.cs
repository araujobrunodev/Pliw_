using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Statistic : MonoBehaviour
{
    public TMP_Text scoreText, bestScoreText, AllClicksText, AllLostText;
    public static int score, bestScore, AllClicks, allLost;
    private static string path = "./Assets/load/savedVariables.json";
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Current score: " + score;
        bestScoreText.text = "best score: " + bestScore;
        AllClicksText.text = "All clicks: " + AllClicks;
        AllLostText.text = "All lost: " + allLost;
    }

    public static void save () {
        var obj = new Statistic_variables();
        if (bestScore < score) bestScore = score;
        allLost++;
        
        obj.score = score;
        obj.bestscore = bestScore;
        obj.allLost = allLost;
        obj.allClicks = AllClicks;

        var objJSON = JsonUtility.ToJson(obj);
        
        System.IO.File.WriteAllText(path, objJSON);
    }
}


class Statistic_variables {
    public int score; 
    public int bestscore;
    public int allClicks;
    public int allLost;
}