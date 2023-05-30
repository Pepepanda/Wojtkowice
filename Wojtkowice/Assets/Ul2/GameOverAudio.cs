using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAudio : MonoBehaviour
{
    public AudioClip GameOverAudioClip;
    AudioSource GameOverAudioSource;

    private void Start()
    {
        GameOverAudioSource = gameObject.AddComponent<AudioSource>();
        GameOverSound();
    }
    public void GameOverSound()
    {
        if (!GameOverAudioSource.isPlaying)
        {
            GameOverAudioSource.clip = GameOverAudioClip;
            GameOverAudioSource.volume = 0.02f;
            GameOverAudioSource.Play();
            StartCoroutine(StopGameOverSound());
        }
    }
    IEnumerator StopGameOverSound()
    {
        yield return new WaitForSeconds(0.25f);
        GameOverAudioSource.Stop();
    }
}
