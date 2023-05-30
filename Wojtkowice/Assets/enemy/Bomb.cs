using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionDamage = 10f;
    public float explosionDelay = 2f;

    private bool exploded = false;


    void Start()
    {
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !exploded)
        {
            exploded = true;
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(explosionDelay);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                enemy.TakeDamage(explosionDamage);
            }
            else if (collider.CompareTag("Player"))
            {
                Player player = collider.GetComponent<Player>();
                player.TakeDamage(explosionDamage);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
