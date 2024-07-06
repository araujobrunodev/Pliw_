using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Countdown;
using TMPro;

public class Timer : MonoBehaviour
{
    public static int timer = 30;
    public static bool CanStartToCount = false;
    public TMP_Text countText;
    private float defaultTime = (float)timer;
    void StartCount () {
        if (defaultTime > 0) defaultTime -= Time.deltaTime;
        else print("call resetGame");
        
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
