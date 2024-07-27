using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;

public class pliwTrack : MonoBehaviour
{
    public AudioClip clip;
    static bool paused = false;
    static AudioSource audio;
    string path = "";
    
    public static void Play () {
        paused = false;
        audio.pitch = 3f;
        audio.Play();
    }

    public static void Pause (string state) {
        if (paused || state == "win") return;

        var lessPitch = 0.1f * Time.deltaTime;
        audio.pitch -= lessPitch;

        if (audio.pitch <= 1) {
            audio.Pause();
            paused = true;
        }
    }

    void Start () {
        audio = GetComponent<AudioSource>();
        audio.volume = 1;
        audio.loop = true;
        audio.clip = clip;
    }
}
