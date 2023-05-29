using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    AudioSource WalkingAudioSource;
    AudioSource ShootingAudioSource;
    AudioSource HitAudioSource;
    public AudioClip WalkingAudioClip;
    public AudioClip ShootingAudioClip;
    public AudioClip HitAudioClip;
    Rigidbody2D RB2D;
    float x, y;

    void Start()
    {
        WalkingAudioSource = GetComponent<AudioSource>();
        ShootingAudioSource = gameObject.AddComponent<AudioSource>();
        HitAudioSource = gameObject.AddComponent<AudioSource>();
        /*GameOverAudioSource = gameObject.AddComponent<AudioSource>();*/
        RB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*x = transform.position.x;
        y = transform.position.y;
        RB2D.velocity = new Vector2(x, y);

        if (RB2D.velocity.magnitude > 0)
        {
            if (!WalkingAudioSource.isPlaying)
            {
                WalkingAudioSource.clip = WalkingAudioClip;
                WalkingAudioSource.volume = 0.3f;
                WalkingAudioSource.Play();
                StartCoroutine(StopWalkingSound());
            }
        }*/
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
}
