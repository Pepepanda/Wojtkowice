using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 Last;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(waiter());
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
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.25f);
        int x = Random.Range(300, 600) + 1;
        int y = Random.Range(300, 600) + 1;
        rb.AddForce(new Vector2(x, y));
    }
}