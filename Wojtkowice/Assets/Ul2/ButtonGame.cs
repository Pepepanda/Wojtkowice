using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonGame : MonoBehaviour
{
    public GameObject mm, dm;
    private void Start()
    {
        dm.SetActive(false);
    }
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(1);
        Time.timeScale=1f;
    }
    public void OnSettingsButtonClicked()
    {
        mm.SetActive(false);
        dm.SetActive(true);
    }
    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
    public void Back()
    {
        dm.SetActive(false);
        mm.SetActive(true);
    }
}
