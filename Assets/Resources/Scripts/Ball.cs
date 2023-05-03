using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb_Ball;
    public int velY;

    Transform paleta;
    float distanceY;


    public bool gameStarted = false;

    int num_points;
    TextMeshProUGUI text_points;

    AudioSource boing;

    GetBlocks list;

    [SerializeField] GameObject powerUp;

    void Awake()
    {
        paleta = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        text_points = GameObject.Find("Canvas/Point").GetComponent<TextMeshProUGUI>();
        boing = GetComponent<AudioSource>();
        list = GameObject.Find("Core").GetComponent<GetBlocks>();
    }
    void Start()
    {
        rb_Ball = GetComponent<Rigidbody2D>();

        distanceY = paleta.position.y - transform.position.y;
        velY = 300;
    }
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id)) { return; }
            if ((touch.phase == TouchPhase.Ended) || (touch.phase == TouchPhase.Canceled)) { return; }
        }
        if (gameStarted == false)
        {
            transform.position = new Vector3(paleta.position.x, paleta.position.y - distanceY, paleta.position.z);

            if (/*Input.GetMouseButtonDown(0)*/Input.touchCount == 1)/// aquí va el touch we
            {
                rb_Ball.isKinematic = false;
                rb_Ball.AddForce(new Vector2(0, velY));
                gameStarted = true;
            }
        }
        if (list.blocks.Count == 0)
        {
            gameStarted = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            gameStarted = false;
        }
        if (collision.tag == "Double")
        {
            num_points += 10;
            UpdateScoreLabel(text_points, num_points);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        boing.Play();
        if (collision.gameObject.tag == "Normal")
        {
            num_points += 5;
            UpdateScoreLabel(text_points, num_points);
        }
        if (collision.gameObject.tag == "OneSide")
        {
            num_points += 25;
            UpdateScoreLabel(text_points, num_points);
        }
    }
    private void UpdateScoreLabel(TextMeshProUGUI label, float points)
    {
        label.text = "Score: " + points.ToString();
    }
}
