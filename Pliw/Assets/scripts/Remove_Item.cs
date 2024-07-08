using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove_Item : MonoBehaviour
{
    void OnMouseDown () {
        print("remove "+ gameObject.name);

        Destroy(gameObject, 1);
    }
}
