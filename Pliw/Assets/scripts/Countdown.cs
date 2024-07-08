using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static Timer;
using static PliwBalls;

public class Countdown : MonoBehaviour
{
    public TMP_Text obj;
    public static int startTime;
    public static readonly float defaultTime = 4f;
    public static float time = defaultTime;
    public Image warn;
    PliwBalls PB;
    void Count () 
    {
        if (time > 0) time -= Time.deltaTime;
        else {
            Timer.CanStartToCount = true;
            warn.gameObject.SetActive(false);
            PliwBalls.canCreate = true;
        }
    }

    void Update () {
        Count();

        startTime = (int)time;
        obj.text = startTime.ToString();
    }
}



