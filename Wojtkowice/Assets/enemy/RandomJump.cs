using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomJump : MonoBehaviour
{
    public float moveSpeed = 3f; // Prêdkoœæ poruszania siê wroga

    private Rigidbody2D rb;
    private Vector2 movementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetRandomMovementDirection();
    }

    void Update()
    {
        MoveEnemy();
    }

    void GetRandomMovementDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        movementDirection = new Vector2(randomX, randomY).normalized;
    }

    void MoveEnemy()
    {
        rb.velocity = movementDirection * moveSpeed;
    }
}
