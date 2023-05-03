using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    float deltaX;
    Rigidbody2D rb;
    [SerializeField]GameObject[] ball;
    [SerializeField] Health health;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = Resources.LoadAll<GameObject>("Prefabs/Balls");
        health = GameObject.Find("Walls/Down").GetComponent<Health>();
    }

    void Update()
    {
        #region PC
        /*
        Vector3 mouseP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(Mathf.Clamp(mouseP.x, -2f, 2f), transform.position.y, transform.position.z);
        */
        #endregion

        #region Phone
        
        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id)) { return; }
            if ((touch.phase == TouchPhase.Ended) || (touch.phase == TouchPhase.Canceled)) { return; }
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.95f, 1.95f),
            transform.position.y, transform.position.z);
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    break;

                case TouchPhase.Moved:
                    rb.MovePosition(new Vector2(touchPos.x - deltaX, 0));
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;

            }
        }
        #endregion
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = collision.contacts[0].point;
            Vector3 paddleCenter = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

            ballRb.velocity = Vector2.zero;

            float difference = paddleCenter.x - hitPoint.x;

            if(hitPoint.x < paddleCenter.x)
            {
                ballRb.AddForce(new Vector2(-(Mathf.Abs(difference * 200)), 300));
            }
            else
            {
                ballRb.AddForce(new Vector2(Mathf.Abs(difference * 200), 300));                
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HealthUp")
        {
            health.extraHealth += 1;
            health.lifes += 1;
            health.Up();
            Destroy(collision.gameObject, 0.1f);
        }
    }
}
