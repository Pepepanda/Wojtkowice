using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulleter : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public int damage;
    GameObject target;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
<<<<<<< Updated upstream
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 move = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(move.x, move.y);
        Destroy(rb, 5f);
=======
        target = GameObject.Find("Player");
        Vector2 move = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(move.x, move.y);
        Destroy(this.gameObject, 5f);
>>>>>>> Stashed changes
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
