using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonGame : MonoBehaviour
{
    public GameObject mm, dm;
    AudioSource ClickAudioSource;
    public AudioClip ClickAudioClip;
    void Start()
    {
        dm.SetActive(false);
        ClickAudioSource = gameObject.AddComponent<AudioSource>();
    }
    public void OnStartButtonClicked()
    {
        ClickSound();
        SceneManager.LoadScene(1);
        Time.timeScale=1f;
    }
    public void OnClickEasy()
    {
        Dificulty.CrossSceneInformation = 1;
        OnStartButtonClicked();
    }
    public void OnClickMedium()
    {
        Dificulty.CrossSceneInformation = 2;
        OnStartButtonClicked();
    }
    public void OnClickHard()
    {
        Dificulty.CrossSceneInformation = 3;
        OnStartButtonClicked();
    }
    public void OnSettingsButtonClicked()
    {
        ClickSound();
        mm.SetActive(false);
        dm.SetActive(true);
    }
    public void OnExitButtonClicked()
    {
        ClickSound();
        Application.Quit();
    }
    public void Back()
    {
        ClickSound();
        dm.SetActive(false);
        mm.SetActive(true);
    }
    //Die menu buttons
    public void OnReloadButtonClicked()
    {
        ClickSound();
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void OnReturnToMenuButtonClicked()
    {
        ClickSound();
        SceneManager.LoadScene(0);
    }
    public void ClickSound()
    {
        if (!ClickAudioSource.isPlaying)
        {
            ClickAudioSource.clip = ClickAudioClip;
            ClickAudioSource.volume = 0.3f;
            ClickAudioSource.Play();
            StartCoroutine(StopClickingSound());
        }
    }
    IEnumerator StopClickingSound()
    {
        yield return new WaitForSeconds(1f);
        ClickAudioSource.Stop();
    }
}