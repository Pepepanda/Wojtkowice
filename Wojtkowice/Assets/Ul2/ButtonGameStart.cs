using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonGameStart : MonoBehaviour
{
    public Canvas MenuCanvas;
    void Start()
    {
        MenuCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }
    public void OnStartButtonClicked()
    {
        MenuCanvas.enabled = false;
        SceneManager.LoadScene("Home");
    }
}
