using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonGameOff : MonoBehaviour
{
    public Canvas MenuCanvas;
    void Start()
    {
        MenuCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
