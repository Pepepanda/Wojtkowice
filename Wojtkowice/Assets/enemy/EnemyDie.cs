using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public int health = 10;
    public GameObject HealthPrefab;
    public GameObject AmmoPrefab;
    // Start is called before the first frame update
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        int randomNum = Random.Range(0, 100);
        if (randomNum < 50) // 50% ammo chance
        {
            Instantiate(AmmoPrefab, transform.position, Quaternion.identity);
        }
        else // 50% health chance
        {
            Instantiate(HealthPrefab, transform.position, Quaternion.identity);
        }
    }
}
