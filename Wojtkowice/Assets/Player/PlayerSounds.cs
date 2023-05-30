using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    AudioSource WalkingAudioSource;
    AudioSource ShootingAudioSource;
    AudioSource HitAudioSource;
    AudioSource GetAudioSource;
    AudioSource HitEnemyAudioSource;
    AudioSource DieEnemyAudioSource;
    public AudioClip WalkingAudioClip;
    public AudioClip ShootingAudioClip;
    public AudioClip HitAudioClip;
    public AudioClip GetAudioClip;
    public AudioClip HitEnemyAudioClip;
    public AudioClip DieEnemyAudioClip;

    void Start()
    {
        WalkingAudioSource = GetComponent<AudioSource>();
        ShootingAudioSource = gameObject.AddComponent<AudioSource>();
        HitAudioSource = gameObject.AddComponent<AudioSource>();
        GetAudioSource = gameObject.AddComponent<AudioSource>();
        HitEnemyAudioSource = gameObject.AddComponent<AudioSource>();
        DieEnemyAudioSource = gameObject.AddComponent<AudioSource>();
    }
    public void WalkSound()
    {
        if (!WalkingAudioSource.isPlaying)
        {
            WalkingAudioSource.clip = WalkingAudioClip;
            WalkingAudioSource.volume = 0.3f;
            WalkingAudioSource.Play();
            /*StartCoroutine(StopWalkingSound());*/
        }
    }
    public void ShootSound()
    {
        if (!ShootingAudioSource.isPlaying)
        {
            ShootingAudioSource.clip = ShootingAudioClip;
            ShootingAudioSource.volume = 0.3f;
            ShootingAudioSource.Play();
            StartCoroutine(StopShootingSound());
        }
    }
    public void HitSound()
    {
        if (!HitAudioSource.isPlaying)
        {
            HitAudioSource.clip = HitAudioClip;
            HitAudioSource.volume = 0.3f;
            HitAudioSource.Play();
            StartCoroutine(StopHittingSound());
        }
    }
    public void GetSound()
    {
            GetAudioSource.clip = GetAudioClip;
            GetAudioSource.volume = 0.3f;
            GetAudioSource.Play();
    }

    public void HitEnemySound()
    {
        if (!HitEnemyAudioSource.isPlaying)
        {
            HitEnemyAudioSource.clip = HitEnemyAudioClip;
            HitEnemyAudioSource.volume = 0.3f;
            HitEnemyAudioSource.Play();
            StartCoroutine(StopHittingEnemySound());
        }
    }

    public void DieEnemySound()
    {
        if (!DieEnemyAudioSource.isPlaying)
        {
            DieEnemyAudioSource.clip = DieEnemyAudioClip;
            DieEnemyAudioSource.volume = 0.3f;
            DieEnemyAudioSource.Play();
            StartCoroutine(StopDyingEnemySound());
        }
    }
    IEnumerator StopWalkingSound()
    {
        yield return new WaitForSeconds(2f);
        WalkingAudioSource.Stop();
    }
    IEnumerator StopShootingSound()
    {
        yield return new WaitForSeconds(0.18f);
        ShootingAudioSource.Stop();
    }
    IEnumerator StopHittingSound()
    {
        yield return new WaitForSeconds(1f);
        HitAudioSource.Stop();
    }
    IEnumerator StopHittingEnemySound()
    {
        yield return new WaitForSeconds(1.5f);
        HitEnemyAudioSource.Stop();
    }
    IEnumerator StopDyingEnemySound()
    {
        yield return new WaitForSeconds(2f);
        DieEnemyAudioSource.Stop();
    }
}
