using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulleter : MonoBehaviour
{
    private Transform player;
    public float speed;
    private Vector2 target;
    public float timer;
    public int damage;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}