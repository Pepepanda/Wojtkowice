using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingTowardPlayerScript : MonoBehaviour
{
    public float speed = 5.0f; // The speed of the enemy
    public float bounceHeight = 0.5f; // The height the enemy will bounce
    public float bounceDuration = 0.5f; // The duration of the bounce

    private Rigidbody2D rb; // The Rigidbody2D component of the enemy
    private Vector2 originalPosition; // The original position of the enemy
    private float timeElapsed = 0.0f; // The time elapsed since the last bounce
    private GameObject player; // The player GameObject

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        // If it's been long enough since the last bounce, bounce again
        if (timeElapsed >= bounceDuration)
        {
            timeElapsed = 0.0f;
            StartCoroutine(Bounce());
        }
    }

    IEnumerator Bounce()
    {
        float startY = transform.position.y;
        float endY = startY + bounceHeight;

        Vector2 direction = (player.transform.position - transform.position).normalized;
        float distance = Vector2.Distance(player.transform.position, transform.position);

        // Bounce towards player
        while (transform.position.y < endY && distance > 1f)
        {
            Vector2 newPos = new Vector2(transform.position.x + direction.x * speed * Time.deltaTime, transform.position.y + direction.y * speed * Time.deltaTime);
            rb.MovePosition(newPos);
            distance = Vector2.Distance(player.transform.position, transform.position);
            yield return null;
        }

        // Bounce down
        while (transform.position.y > startY)
        {
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            rb.MovePosition(newPos);
            yield return null;
        }

        // Return to original position
        rb.MovePosition(originalPosition);
    }
}
