using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonGame : MonoBehaviour
{
    //Start menu buttons
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void OnSettingsButtonClicked()
    {
        SceneManager.LoadScene(2);
    }
    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
    //Die menu buttons
    public void OnReloadButtonClicked()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void OnReturnToMenuButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
