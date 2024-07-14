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
    private static extern int getWidth();
    [DllImport("__Internal")]

    private static extern int getHeight();
    [DllImport("__Internal")]
    private static extern void getScreen();
    void load () {
        var json = File.ReadAllText(path);
        
        if (json == null) return;
        
        var jsonToObj = JsonUtility.FromJson<Statistic_variables>(json) as Statistic_variables;
        
        bestScore = jsonToObj.bestscore;
        AllClicks = jsonToObj.allClicks;
        allLost = jsonToObj.allLost;
    }

    void Start () {
        Screen.SetResolution(getWidth(), getHeight(), false);
        getScreen();

        path = Application.persistentDataPath + "/savedVariables.json";
        PlatformType();
    }

    private void PlatformType () {
        var type = Application.platform;

        if (type == RuntimePlatform.WebGLPlayer) StartCoroutine(call(path));
        else load();
    }
    void Update()
    {
        scoreText.text = "Current score: " + score;
        bestScoreText.text = "best score: " + bestScore;
        AllClicksText.text = "All clicks: " + AllClicks;
        AllLostText.text = "All lost: " + allLost;
    }

    public static void save () {
        var obj = new Statistic_variables();
        if (bestScore < score) bestScore = score;
        allLost++;
        
        obj.score = score;
        obj.bestscore = bestScore;
        obj.allLost = allLost;
        obj.allClicks = AllClicks;

        var objJSON = JsonUtility.ToJson(obj);

        File.WriteAllText(path, objJSON);
        print(File.ReadAllText(path));
    }

    IEnumerator call (string source) {
        using (UnityWebRequest server = new UnityWebRequest(source)) {
            yield return server.SendWebRequest();
            
            if (server.result == UnityWebRequest.Result.Success) {
                print("variables into json: "+ server.downloadHandler.text);
                load();
            } else {
                print("cant receive file");
            }
        }   
    }
}


class Statistic_variables {
    public int score; 
    public int bestscore;
    public int allClicks;
    public int allLost;
}