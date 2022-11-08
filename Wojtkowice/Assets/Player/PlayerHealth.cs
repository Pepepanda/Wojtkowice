using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    //how much damage the player takes 
    public void TakeDamage(int damage)
    {
        health -= damage;
        //if the damage takes the player down to zero, then the player will be destroyed
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
