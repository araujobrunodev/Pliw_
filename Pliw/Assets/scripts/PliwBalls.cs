using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static QuantityCalculation;
using static level;
using static Timer;

public class PliwBalls : MonoBehaviour
{
    public static List<PliwBall> pliwBalls = new List<PliwBall>();
    private GameObject warn;
    public Sprite[] sprites;
    public AudioClip clip;
    private float time = 0f;
    private float StartX, StartY, EndX, EndY;

    public static void RemoveAll () {
        foreach (PliwBall pb in pliwBalls) {
            Destroy(pb.item);
        }

        pliwBalls.Clear();
    }

    public static void Remove (string name) {
        var item = pliwBalls.Find(q => q.name == name);
        pliwBalls.Remove(item);
    }
    
    int ClassifyType () {
        var min = 0;
        var max = 0;
        var random = 0;

        if (level.Level <= 30) {
            max = (int)(level.Level / 5) + 1;
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

    private float RandomPosition (string type) {
        var randomNumber = 0f;

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

    void Flasher () {
        if (pliwBalls.Count == 0) return;

        foreach (PliwBall pb in pliwBalls) {
            if (!pb.flasher) continue;

            if (pb.item.activeSelf) pb.item.SetActive(false);
            else pb.item.SetActive(true);
        }
    }

    void Start () {
        warn = GameObject.Find("warn");
        StartX = GameObject.Find("pointStartX").transform.localPosition.x;
        StartY = GameObject.Find("pointStartY").transform.localPosition.y;
        EndX = GameObject.Find("pointEndX").transform.localPosition.x;
        EndY = GameObject.Find("pointEndY").transform.localPosition.y;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (warn.activeSelf) return; 
        
        if ((int)time % 2 == 0) {
            if (pliwBalls.Count < QuantityCalculation.scoreRequest) Create();
        }

        if ((int)time % 3 == 0) {
            Move();
            Flasher();
        }
    }

    public void Create()
    {
        var index = pliwBalls.Count;
        
        pliwBalls.Add(new PliwBall{
            item = new GameObject(),
            id = index.ToString(),
            positionX = RandomPosition("width"),
            positionY = RandomPosition("height"),
            type = ClassifyType(),
            name = "Pliw ball " + (index + Random.Range(0f,1000f)).ToString()
        });

        var pb = pliwBalls[index] as PliwBall;
        
        pb.CanMoveX = GetCanMove(pb.type, "x");
        pb.CanMoveY = GetCanMove(pb.type, "y");
        pb.flasher = GetFlasher(pb.type);
        
        pb.item.name = pb.name;
        pb.item.transform.SetParent(GameObject.Find("mainArea").transform, false);
        
        pb.item.AddComponent<RectTransform>();
        pb.item.AddComponent<SpriteRenderer>();
        pb.item.AddComponent<CircleCollider2D>();
        pb.item.AddComponent<AudioSource>();
        pb.item.AddComponent<Remove_Item>();
        pb.item.GetComponent<RectTransform>().localPosition = new Vector2(pb.positionX, pb.positionY);
        pb.item.GetComponent<RectTransform>().localScale = new Vector3(125, 125, 0);
        pb.item.GetComponent<SpriteRenderer>().sprite = sprites[pb.type];
        pb.item.GetComponent<AudioSource>().clip = clip;
        pb.item.GetComponent<AudioSource>().pitch = 3;
    }

    void Move () {
        if (pliwBalls.Count == 0) return;
        
        foreach (PliwBall pb in pliwBalls) {
            if (!pb.CanMoveX) continue;

            var moveX = Random.Range(-45f, 45f);
            var moveY = Random.Range(-45f, 45f);
            var canMoveBoth = false;
            var speed = pb.speed;
            if (pb.type >= 5) speed *= 2;

            if (pb.type > 3) canMoveBoth = true;

            var currentPosition = pb.item.transform.localPosition;
            var destination = currentPosition;

            if (!canMoveBoth) {
                var canMoveOne = Random.Range(0,2);
                if (pb.type == 2) canMoveOne = 0;

                if (canMoveOne > 0) {
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
