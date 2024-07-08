using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Countdown;
using TMPro;
using static resetGame;

public class Timer : MonoBehaviour
{
    public static readonly int defaultToTimer = 20; 
    public static int timer = defaultToTimer;
    public static bool CanStartToCount = false;
    public TMP_Text countText;
    public static float defaultTime = (float)defaultToTimer;
    void StartCount () {
        var deltaTime = Time.deltaTime;
        
        if (defaultTime > 0) defaultTime -= deltaTime;
        else {
            resetGame.Appear(true);
        }
        
        timer = (int)defaultTime; 
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = timer.ToString();
        if (CanStartToCount) {
            StartCount();
        }
    }
}
