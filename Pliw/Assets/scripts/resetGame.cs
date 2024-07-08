using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetGame : MonoBehaviour
{
    private static GameObject obj;
    public static void Appear (bool hidden) {
        obj.SetActive(hidden);
        if (hidden) print("active is true");
    }

    void Start () {
        obj = gameObject;
    }
}
