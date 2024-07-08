using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static resetGame;

public class ChangePage : MonoBehaviour
{
    public Image HomePage;
    public Image PlayPage;
    private static bool homePageActive = false;
    private static bool playPageActive = false;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        resetGame.Appear(false);
        homePageActive = true;
        playPageActive = false;
        button.onClick.AddListener(Change);
        receive();
    }

    void receive () {
        HomePage.gameObject.SetActive(homePageActive);
        PlayPage.gameObject.SetActive(playPageActive);
    }

    void Change () {
        if (homePageActive) {
            homePageActive = false;
            playPageActive = true;
        } else {
            homePageActive = true;
            playPageActive = false;
        }

        receive();
    }
}
