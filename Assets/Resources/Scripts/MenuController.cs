using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void OnRestart()
    {
        Debug.Log("Hello world");
        SceneManager.LoadScene("Main");
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
