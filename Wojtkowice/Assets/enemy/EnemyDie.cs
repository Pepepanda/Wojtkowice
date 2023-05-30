using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public int health = 10;
    public GameObject HealthPrefab;
    public GameObject AmmoPrefab;
    public buildSystem3 build;
    public PlayerSounds playerSounds;

    void Start()
    {
        build = GameObject.Find("Game Manager").GetComponent<buildSystem3>();
        playerSounds = GameObject.Find("Player").GetComponent<PlayerSounds>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            playerSounds.DieEnemySound();
            Die();
        }
        else
        {
            playerSounds.HitEnemySound();
        }
    }
    void Die()
    {
        int randomNum = Random.Range(0, 100);
        switch (build.difficulty)
        {
            case 1:
                if (randomNum <= 50) // 20% ammo chance
                {
                    Instantiate(AmmoPrefab, transform.position, Quaternion.identity);
                }
                if (randomNum >= 80)// 40% health chance
                {
                    Instantiate(HealthPrefab, transform.position, Quaternion.identity);
                }
                break;
            case 2:
                if (randomNum <= 20) // 20% ammo chance
                {
                    Instantiate(AmmoPrefab, transform.position, Quaternion.identity);
                }
                if (randomNum >= 60)// 40% health chance
                {
                    Instantiate(HealthPrefab, transform.position, Quaternion.identity);
                }
                break;
            case 3:
                if (randomNum <= 10) // 20% ammo chance
                {
                    Instantiate(AmmoPrefab, transform.position, Quaternion.identity);
                }
                if (randomNum >= 40)// 40% health chance
                {
                    Instantiate(HealthPrefab, transform.position, Quaternion.identity);
                }
                break;
            default:
                if (randomNum <= 20) // 20% ammo chance
                {
                    Instantiate(AmmoPrefab, transform.position, Quaternion.identity);
                }
                if (randomNum >= 60)// 40% health chance
                {
                    Instantiate(HealthPrefab, transform.position, Quaternion.identity);
                }
                break;
        }
        Destroy(gameObject);
    }
}
