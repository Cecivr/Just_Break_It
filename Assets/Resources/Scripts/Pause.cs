using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [HideInInspector]public bool gamePaused = false;
    GameObject Panel_Pausa;
    GameObject Pausa1;
    [SerializeField] string panel;
    private void Awake()
    {
        Panel_Pausa = GameObject.Find("Panel");
        Pausa1 = Panel_Pausa.transform.Find(panel).gameObject;       
        Pausa1.SetActive(false);
    }
    public void Pausa()
    {
        if (Time.timeScale == 1)
        {
            gamePaused = true;
            Pausa1.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Continue()
    {
        if (Time.timeScale == 0)
        {
            Pausa1.SetActive(false);
            Time.timeScale = 1;
            gamePaused = false;
        }
    }
}
