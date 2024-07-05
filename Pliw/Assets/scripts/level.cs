using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class level : MonoBehaviour
{
    public TMP_Text levelText;
    private static int Level;

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level: " + Level;
    }
}
