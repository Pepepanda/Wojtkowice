using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetHealth(maxHealth);
    }

    //how much damage the player takes 
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        //if the damage takes the player down to zero, then the player will be destroyed
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void GetHealth()
    {
        health +=5;
        healthBar.SetHealth(health);
    }
}
