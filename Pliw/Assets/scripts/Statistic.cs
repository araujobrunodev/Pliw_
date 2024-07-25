using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;
using UnityEngine.Networking;

public class Statistic : MonoBehaviour
{
    public TMP_Text scoreText, bestScoreText, AllClicksText, AllLostText;
    public static int score, bestScore, AllClicks, allLost;
    private static string path = "";
    [DllImport("__Internal")]
    private static extern int loadBestscore();
    [DllImport("__Internal")]
    private static extern int loadAllClicks();
    [DllImport("__Internal")]
    private static extern int loadAllLost();
    [DllImport("__Internal")]
    private static extern void saveGame(int score, int bestscore, int allClicks, int allLost);

    void load () {
        if (PlatformType()) {
            bestScore = loadBestscore();
            AllClicks = loadAllClicks();
            allLost = loadAllLost();

        } else {
            var json = File.ReadAllText(path);
            if (json == null) return;

            var jsonToObj = JsonUtility.FromJson<Statistic_variables>(json) as Statistic_variables;

            bestScore = jsonToObj.bestscore;
            AllClicks = jsonToObj.allClicks;
            allLost = jsonToObj.allLost;
        }
    }

    void Start () {
        path = Application.persistentDataPath + "/savedVariables.json";
        
        load();
    }

    private static bool PlatformType () {
        var type = Application.platform;
        var result = false;

        if (type == RuntimePlatform.WebGLPlayer) {
            result = true;
        } 

        return result;
    }
    void Update()
    {
        scoreText.text = "Current score: " + score;
        bestScoreText.text = "best score: " + bestScore;
        AllClicksText.text = "All clicks: " + AllClicks;
        AllLostText.text = "All lost: " + allLost;
    }

    public static void save () {
        if (bestScore < score) bestScore = score;
        
        if (PlatformType()) saveGame(score, bestScore, AllClicks, allLost);
        else {
            var obj = new Statistic_variables() {
                score = score,
                allClicks = AllClicks,
                allLost = allLost,
                bestscore = bestScore
            };

            File.WriteAllText(path, JsonUtility.ToJson(obj));
        }
    }
}


class Statistic_variables {
    public int score; 
    public int bestscore;
    public int allClicks;
    public int allLost;
}