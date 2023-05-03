using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    SceneAdministrator admin;
    public Image[] hearts;
    public int lifes = 3;

    AudioSource lose;

    public int extraHealth;

    TextMeshProUGUI text_extraLife;
    void Start()
    {
        hearts = GameObject.Find("Canvas/Health/WholeHearts").GetComponentsInChildren<Image>();
        lose = GetComponent<AudioSource>();
        admin = GameObject.Find("Core").GetComponent<SceneAdministrator>();
        text_extraLife = GameObject.Find("Canvas/ExtraLife_Text").GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        CheckLife();
        UpdateText();
    }
    void CheckLife()
    {
        if(lifes <= 0)
        {
            admin.changeScene("GameOver");
        }
    }
    public void Damage()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (lifes - 1 < i)
            {
                hearts[i].gameObject.SetActive(false);
            }
        }       
    }
    public void Up()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (lifes > i)
            {
                hearts[i].gameObject.SetActive(true);
            }
        }       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Ball")
        {
            if (lifes <= 3)
            {
                lifes--;
                //lose.Play();
                extraHealth--;
                Damage();
            }if(lifes > 3)
            {
                extraHealth--;
                lifes--;
            }
        }
    }
    void UpdateText()
    {
        if (extraHealth > 0)
        {
            text_extraLife.text = "+" + extraHealth;
        }
        if(extraHealth == 0)
        {
            text_extraLife.text = "";
        }
    }
}
