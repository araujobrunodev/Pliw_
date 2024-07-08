using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Statistic;

public class Remove_Item : MonoBehaviour
{
    private bool IsDead = false;
    private float timeToRemoveIt = 0.2f;
    void OnMouseDown () {
        if (!IsDead) {
            Statistic.score++;
            Destroy(gameObject, timeToRemoveIt);
            IsDead = true;
        }
    }
}
