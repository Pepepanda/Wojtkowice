using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonGame : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void OnSettingsButtonClicked()
    {
        SceneManager.LoadScene(2);
    }
    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
