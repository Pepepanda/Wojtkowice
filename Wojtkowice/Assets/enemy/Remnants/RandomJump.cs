using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomJump : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 Last;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(75f * 10f, 3.5f * 10f));
    }

    // Update is called once per frame
    void Update()
    {
        Last = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = Last.magnitude;
        var direction = Vector3.Reflect(Last.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}


