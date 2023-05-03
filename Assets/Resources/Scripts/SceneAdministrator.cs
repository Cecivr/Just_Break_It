using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAdministrator : MonoBehaviour
{
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
