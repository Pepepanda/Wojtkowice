using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGameStart : MonoBehaviour
{
    public Canvas MenuCanvas;
    public GameObject player;
    void Start()
    {
        MenuCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        player = GameObject.Find("Player");
    }
    public void OnStartButtonClicked()
    {
        MenuCanvas.enabled = false;
        Time.timeScale = 1f;
    }
}
