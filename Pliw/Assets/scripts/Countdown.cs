using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static Timer;

public class Countdown : MonoBehaviour
{
    public TMP_Text obj;
    public static int startTime;
    public static readonly float defaultTime = 4f;
    public static float time = defaultTime;
    public Image warn;
    void Count () 
    {
        if (time > 0) time -= Time.deltaTime;
        else {
            Timer.CanStartToCount = true;
            warn.gameObject.SetActive(false);
        }
    }

    void Update () {
        Count();

        startTime = (int)time;
        obj.text = startTime.ToString();
    }
}



