using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulleter : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public int damage;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        Vector2 move = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(move.x, move.y);
        Destroy(rb, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }

}