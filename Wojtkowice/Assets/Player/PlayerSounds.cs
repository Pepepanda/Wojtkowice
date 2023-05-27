using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    AudioSource WalkingAudioSource;
    AudioSource ShootingAudioSource;
    AudioSource HitAudioSource;
    AudioSource GameOverAudioSource;
    public AudioClip WalkingAudioClip;
    public AudioClip ShootingAudioClip;
    public AudioClip HitAudioClip;
    public AudioClip GameOverAudioClip;
    Rigidbody2D RB2D;
    float x;
    float y;
    PlayerHealth PlayerCurrentHealth;

    void Start()
    {
        WalkingAudioSource = GetComponent<AudioSource>();
        ShootingAudioSource = gameObject.AddComponent<AudioSource>();
        HitAudioSource = gameObject.AddComponent<AudioSource>();
        GameOverAudioSource = gameObject.AddComponent<AudioSource>();
        RB2D = GetComponent<Rigidbody2D>();
        PlayerCurrentHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * speed;
        y = Input.GetAxis("Vertical") * speed;
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
        }
        if (Input.GetMouseButton(0))
        {
            if (!ShootingAudioSource.isPlaying)
            {
                ShootingAudioSource.clip = ShootingAudioClip;
                ShootingAudioSource.volume = 0.3f;
                ShootingAudioSource.Play();
                StartCoroutine(StopShootingSound());
            }
        }
        if (PlayerCurrentHealth.playerHealth <= 0)
        {
            if (!GameOverAudioSource.isPlaying)
            {
                GameOverAudioSource.clip = GameOverAudioClip;
                GameOverAudioSource.volume = 0.3f;
                GameOverAudioSource.Play();
                StartCoroutine(StopGameOverSound());
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!HitAudioSource.isPlaying)
            {
                HitAudioSource.clip = HitAudioClip;
                HitAudioSource.volume = 0.3f;
                HitAudioSource.Play();
                StartCoroutine(StopHittingSound());
            }
        }
    }
    IEnumerator StopWalkingSound()
    {
        yield return new WaitForSeconds(1f);
        WalkingAudioSource.Stop();
    }
    IEnumerator StopShootingSound()
    {
        yield return new WaitForSeconds(1f);
        ShootingAudioSource.Stop();
    }
    IEnumerator StopHittingSound()
    {
        yield return new WaitForSeconds(1f);
        HitAudioSource.Stop();
    }
    IEnumerator StopGameOverSound()
    {
        yield return new WaitForSeconds(1f);
        GameOverAudioSource.Stop();
    }
}
