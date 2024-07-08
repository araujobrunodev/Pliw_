using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuantityCalculation;

public class PliwBalls : MonoBehaviour
{
    public static List<PliwBall> pliwBalls = new List<PliwBall>();
    public static bool canCreate = false;
    private float randomNumber;
    public Sprite[] sprites;
    
    // Start is called before the first frame updateCreate();
    public void Create()
    {
        for (int count = 0; count < QuantityCalculation.limitOfthePliwBall; count++) {
            pliwBalls.Add(new PliwBall{
                CanMoveX = false,
                CanMoveY = false,
                flasher = false,
                item = new GameObject(),
                id = count.ToString(),
                positionX = RandomPosition("width"),
                positionY = RandomPosition("height"),
                type = 0,
                name = "Pliw ball " + count.ToString()
            });

            var pb = pliwBalls[count] as PliwBall;
            
            pb.item.transform.SetParent(GameObject.Find("mainArea").transform, false);
            pb.item.name = pb.name;
            pb.item.AddComponent<RectTransform>();
            pb.item.AddComponent<SpriteRenderer>();
            pb.item.AddComponent<CircleCollider2D>();
            pb.item.AddComponent<Remove_Item>();

            pb.item.GetComponent<RectTransform>().localPosition = new Vector2(pb.positionX, pb.positionY);
            pb.item.GetComponent<RectTransform>().localScale = new Vector3(125, 125, 0);
            pb.item.GetComponent<SpriteRenderer>().sprite = sprites[pb.type];
            
        }

        canCreate = false;
    }

    private float RandomPosition (string type) {
        float StartX = GameObject.Find("pointStartX").transform.localPosition.x;
        float StartY = GameObject.Find("pointStartY").transform.localPosition.y;
        float EndX = GameObject.Find("pointEndX").transform.localPosition.x;
        float EndY = GameObject.Find("pointEndY").transform.localPosition.y;
        
        switch (type) {
            case "width":
                var width = Random.Range(StartX, EndX);
                randomNumber = width;
                break;

            case "height":
                var height = Random.Range(StartY, EndY);
                randomNumber = height;
                break;
        }
        return randomNumber;
    }

    public static void RemoveAll () {
        foreach (PliwBall pb in pliwBalls) {
            Destroy(pb.item, 0.1f);
        }

        pliwBalls.Clear();
    }

    public static void Remove (string name) {
        var item = pliwBalls.Find(q => q.name == name);
        pliwBalls.Remove(item);
    }

    // Update is called once per frame
    void Update()
    {
        if (canCreate) {
            Create();
        }
    }
}

public class PliwBall {
    public string name = "Pliw ball";
    public int type = 0 | 1 | 2 | 3 | 4 | 5 | 6 ;
    public bool CanMoveX = false;
    public bool CanMoveY = false;
    public float positionX;
    public float positionY;
    public float speed;
    public bool flasher = false;
    public string id = "";
    public GameObject item;
}
