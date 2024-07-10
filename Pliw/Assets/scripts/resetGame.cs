using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PliwBalls;
using static Statistic;
using TMPro;
using static QuantityCalculation;
using UnityEngine.UI;
using static level;

public class resetGame : MonoBehaviour
{
    public TMP_Text levelText;
    private static string msglevel;
    private static GameObject obj;
    public TMP_Text scoreText;
    public TMP_Text title;
    private static string msgTitle;
    public static string stateKey = ""; 
    public static GameObject placeBoardArrow, placeBoardLevel;

    public static void Appear (bool hidden) {
        obj.SetActive(hidden);
        if (hidden) Reset();
        else stateKey = "";
    }

    private static void State () {
        switch (stateKey) {
            case "lose":
                obj.GetComponent<Image>().color = new Color(255f, 0f, 0f, 255f);
                msgTitle = "You lose";
                msglevel = "Level: " + level.Level;
                break;

            case "win":
                obj.GetComponent<Image>().color = new Color(0f, 43f, 255f, 100f);
                msgTitle = "You win";
                msglevel = "Next level: " + (level.Level + 1).ToString();
                break;
        }
    }

    private static void Reset () {
        PliwBalls.RemoveAll();
        
        if (stateKey != "") return;
        
        Statistic.save();
        placeBoardArrow.SetActive(true);
        placeBoardLevel.SetActive(false);
        Decide();
        State();
    }

    private static void Decide () {
        if (Statistic.score >= QuantityCalculation.scoreRequest) {
            stateKey = "win";
        } else {
            stateKey = "lose";
        }
    }

    void Start () {
        obj = gameObject;
        placeBoardArrow = GameObject.Find("arrow");
        placeBoardLevel = GameObject.Find("LEVEL");

        placeBoardArrow.SetActive(false);
        placeBoardLevel.SetActive(true);
    }

    void Update () {
        scoreText.text = "Score: " + Statistic.score;
        title.text = msgTitle;
        levelText.text = msglevel;
    }
}
