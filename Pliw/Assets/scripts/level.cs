using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class level : MonoBehaviour
{
    public TMP_Text levelText;
    public static int Level = 1;

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level: " + Level;
    }
}
