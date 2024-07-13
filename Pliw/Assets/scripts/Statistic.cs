using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class Statistic : MonoBehaviour
{
    public TMP_Text scoreText, bestScoreText, AllClicksText, AllLostText;
    public static int score, bestScore, AllClicks, allLost;
    private static string path = "";
    void load () {
        var json = File.ReadAllText(path);
        var jsonToObj = JsonUtility.FromJson<Statistic_variables>(json) as Statistic_variables;
        
        bestScore = jsonToObj.bestscore;
        AllClicks = jsonToObj.allClicks;
        allLost = jsonToObj.allLost;
    }

    void Start () {
        load();
        path = Application.persistentDataPath + "/savedVariables.json";
        StartCoroutine(call());
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

    IEnumerator call () {
        if (!File.Exists(path)) return;
        
        using (UnityWebRequest server = new UnityWebRequest(path)) {

            yield return server.SendWebRequest();

            print("result: " + server.result);
            print("status: "+ UnityWebRequest.Result.Success);

            if (server.result == UnityWebRequest.Result.Success) {
                print("variables into json: "+ server.downloadHandler.text);
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