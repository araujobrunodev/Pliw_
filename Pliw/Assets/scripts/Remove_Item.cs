using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Statistic;
using static PliwBalls;

public class Remove_Item : MonoBehaviour
{
    private bool IsDead = false;
    private float timeToRemoveIt = 0.2f;
    void OnMouseDown () {
        if (!IsDead) {
            IsDead = true;
            PliwBalls.Remove(gameObject.name);
            Statistic.score++;
            Destroy(gameObject, timeToRemoveIt);
        }
    }
}
