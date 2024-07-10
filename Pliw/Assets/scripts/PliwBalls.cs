using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuantityCalculation;
using static level;

public class PliwBalls : MonoBehaviour
{
    public static List<PliwBall> pliwBalls = new List<PliwBall>();
    public static bool canCreate = false;
    private float randomNumber;
    public Sprite[] sprites;
    private float time = 0f;
    
    int ClassifyType () {
        var min = 0;
        var max = 0;
        var random = 0;

        if (level.Level <= 35) {
            max = (int)(level.Level / 5);
        } else max = 7;

        random = Random.Range(min, max);

        return random;
    }

    bool GetCanMove (int type, string position) {
        var can = false;
        var posX = false;
        var posY = false;

        if (type > 1) posX = true;
        if (type > 2) posY = true;
        
        if (position == "x") can = posX;
        else if (position == "y") can = posY;

        return can;
    }

    bool GetFlasher (int type) {
        var flasher = false;

        if (type == 6) flasher = true;

        return flasher;
    }

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
                type = ClassifyType(),
                name = "Pliw ball " + count.ToString()
            });

            var pb = pliwBalls[count] as PliwBall;
            pb.CanMoveX = GetCanMove(pb.type, "x");
            pb.CanMoveY = GetCanMove(pb.type, "y");
            pb.flasher = GetFlasher(pb.type);
            
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

    void Move () {
        if (pliwBalls.Count == 0) return;
        
        foreach (PliwBall pb in pliwBalls) {
            if (!pb.CanMoveX) continue;

            float StartX = GameObject.Find("pointStartX").transform.localPosition.x;
            float StartY = GameObject.Find("pointStartY").transform.localPosition.y;
            float EndX = GameObject.Find("pointEndX").transform.localPosition.x;
            float EndY = GameObject.Find("pointEndY").transform.localPosition.y;

            var moveX = Random.Range(-45f, 45f);
            var moveY = Random.Range(-45f, 45f);
            var canMoveBoth = false;
            var speed = pb.speed;
            if (pb.type >= 5) speed *= 2;

            if (pb.type > 3) canMoveBoth = true;

            var currentPosition = pb.item.transform.localPosition;
            var destination = currentPosition;

            if (!canMoveBoth) {
                var canMoveOne = Random.Range(0,1);
                if (pb.type == 2) canMoveOne = 0;

                if (canMoveOne >= 0.5) {
                    if (currentPosition.x >= EndX) destination.x -= (Mathf.Abs(moveX) * 2);
                    else if (currentPosition.x <= StartX) destination.x += (Mathf.Abs(moveX) * 2);
                    else destination.x += moveX;
                } else {
                    if (currentPosition.y <= EndY) destination.y += (Mathf.Abs(moveY) * 2);
                    else if (currentPosition.y >= StartY) destination.y -= (Mathf.Abs(moveY) * 2);
                    else destination.y += moveY;
                }
            } else {
                if (currentPosition.x >= EndX) destination.x -= (Mathf.Abs(moveX) * 2);
                else if (currentPosition.x <= StartX) destination.x += (Mathf.Abs(moveX) * 2);
                else destination.x += moveX;

                if (currentPosition.y <= EndY) destination.y += (Mathf.Abs(moveY) * 2);
                else if (currentPosition.y >= StartY) destination.y -= (Mathf.Abs(moveY) * 2);
                else destination.y += moveY;
            }

            pb.item.transform.localPosition = Vector2.Lerp(currentPosition, destination, speed);
        }
    }

    void Flasher () {
        foreach (PliwBall pb in pliwBalls) {
            if (!pb.flasher) continue;

            if (pb.item.activeSelf) pb.item.SetActive(false);
            else pb.item.SetActive(true);
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        if ((int)time % 5 == 0 && !canCreate) {
            Move();
            Flasher();
        }
        
        if (canCreate) Create();
    }
}

public class PliwBall {
    public string name = "Pliw ball";
    public int type = 0 | 1 | 2 | 3 | 4 | 5 | 6 ;
    public bool CanMoveX = false;
    public bool CanMoveY = false;
    public float positionX;
    public float positionY;
    public float speed = 0.2f;
    public bool flasher = false;
    public string id = "";
    public GameObject item; 
}
