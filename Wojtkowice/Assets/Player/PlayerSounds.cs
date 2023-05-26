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
        RB2D.velocity = new Vector2(x, RB2D.velocity.y);

        if (RB2D.velocity.x != 0)
        {
            if (!WalkingAudioSource.isPlaying)
            {
                WalkingAudioSource.clip = WalkingAudioClip;
                WalkingAudioSource.Play();
            }
        }
        else
        {
            WalkingAudioSource.Stop();
        }
        if (Input.GetMouseButton(0))
        {
            if (!ShootingAudioSource.isPlaying)
            {
                ShootingAudioSource.clip = ShootingAudioClip;
                ShootingAudioSource.Play();
            }
        }
        else
        {
            ShootingAudioSource.Stop();
        }
    }
}
