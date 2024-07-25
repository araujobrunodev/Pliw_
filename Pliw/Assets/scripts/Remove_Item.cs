using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Statistic;
using static PliwBalls;

public class Remove_Item : MonoBehaviour
{
    private bool IsDead = false;
    void OnMouseDown () {
        if (!IsDead) {
            var audio = GetComponent<AudioSource>();
            IsDead = true;
            audio.Play();
            PliwBalls.Remove(gameObject.name);
            Statistic.AllClicks++;
            Statistic.score++;
            Destroy(gameObject,(float)audio.clip.length);
        }
    }
}
