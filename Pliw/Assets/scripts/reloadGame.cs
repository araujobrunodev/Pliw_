using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static resetGame;
using static level;
using static Statistic;
using static Timer;
using static Countdown;

public class reloadGame : MonoBehaviour
{
    public GameObject countdown; 
    void Update () {
        var size = gameObject.GetComponent<RectTransform>().sizeDelta;
        gameObject.GetComponent<BoxCollider2D>().size = size;
    }
    void OnMouseDown () {
        switch (resetGame.stateKey) {
            case "lose":
                level.Level = 1;
                break;
            

            case "win":
                level.Level++;
                break;
        }

        resetGame.placeBoardArrow.SetActive(false);
        resetGame.placeBoardLevel.SetActive(true);
        Statistic.score = 0;
        Countdown.time = Countdown.defaultTime;
        Timer.CanStartToCount = false;
        Timer.timer = Timer.defaultToTimer;
        Timer.defaultTime = (float)Timer.defaultToTimer;
        countdown.SetActive(true);
        resetGame.Appear(false);
    }
}
