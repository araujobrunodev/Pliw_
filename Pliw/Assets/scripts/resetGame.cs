using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PliwBalls;
using static Statistic;
using TMPro;
using static QuantityCalculation;
using UnityEngine.UI;

public class resetGame : MonoBehaviour
{
    private static GameObject obj;
    public TMP_Text scoreText;
    public TMP_Text title;
    private static string msgTitle;
    private static string stateKey = ""; 
    public static void Appear (bool hidden) {
        obj.SetActive(hidden);
        if (hidden) {Reset();}
    }

    private static void State () {
        switch (stateKey) {
            case "lose":
                msgTitle = "You lose";
                break;

            case "win":
                obj.GetComponent<Image>().color = new Color(0f, 43f, 255f, 100f);
                msgTitle = "You win";
                break;
        }
    }

    private static void Reset () {
        PliwBalls.RemoveAll();
        Decide();
        State();
    }

    private static void Decide () {
        if (Statistic.score >= QuantityCalculation.limitOfthePliwBall) {
            stateKey = "win";
        } else {
            stateKey = "lose";
        }
    }

    void Start () {
        obj = gameObject;
    }

    void Update () {
        scoreText.text = "Score: " + Statistic.score;
        title.text = msgTitle;
    }
}
