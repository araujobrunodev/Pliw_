using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuantityCalculation : MonoBehaviour
{
    public TMP_Text ExceedText;
    public static int limitOfthePliwBall;
    public GameObject MainArea;
    void Limit () {
        Vector2 value = MainArea.GetComponent<RectTransform>().sizeDelta;
        float width = value[0];
        float height = value[1];
        float result = Mathf.Abs((width - height) / 15);
        limitOfthePliwBall = (int)result;
    }

    void Start () {
        Limit();
    }
    // Update is called once per frame
    void Update()
    {
        ExceedText.text = "Exceed " + limitOfthePliwBall + " in the score";
    }
}
