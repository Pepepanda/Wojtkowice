using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBulleter : MonoBehaviour
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
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
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
