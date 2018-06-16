using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void OnRestart()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
