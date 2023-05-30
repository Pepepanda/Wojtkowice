using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileDie : MonoBehaviour
{

    public int health = 10;
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
        Destroy(gameObject);
    }
}
