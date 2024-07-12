using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static level;

public class QuantityCalculation : MonoBehaviour
{
    public TMP_Text ExceedText;
    public static int scoreRequest;
    void Limit () {
        var width = GameObject.Find("pointStartX").GetComponent<RectTransform>().rect.x;
        var height = GameObject.Find("pointStartY").GetComponent<RectTransform>().rect.y;

        float result = (Mathf.Abs((width + height)) / 2) + (level.Level - 1);
        scoreRequest = (int)result;
    }

    void Update()
    {
        Limit();
        ExceedText.text = "Exceed " + scoreRequest + " in the score";
    }
}
