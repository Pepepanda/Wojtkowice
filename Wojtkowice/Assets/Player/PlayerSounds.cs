using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    AudioSource WalkingAudioSource;
    AudioSource ShootingAudioSource;
    public AudioClip WalkingAudioClip;
    public AudioClip ShootingAudioClip;
    Rigidbody2D RB2D;
    float x;
    float y;

    void Start()
    {
        WalkingAudioSource = GetComponent<AudioSource>();
        ShootingAudioSource = gameObject.AddComponent<AudioSource>();
        RB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * speed;
        y = Input.GetAxis("Vertical") * speed;
        RB2D.velocity = new Vector2(x,y);

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
        IEnumerator StopWalkingSound()
        {
            yield return new WaitForSeconds(1f);
            WalkingAudioSource.Stop();
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
        IEnumerator StopShootingSound()
        {
            yield return new WaitForSeconds(1f);
            ShootingAudioSource.Stop();
        }
    }
}
