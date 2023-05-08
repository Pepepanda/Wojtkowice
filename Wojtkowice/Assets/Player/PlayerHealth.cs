using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health=10;
    public int Playerhealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        Playerhealth = health;
        healthBar.SetHealth(Playerhealth);
    }
    //how much damage the player takes 
    public void TakeDamage(int damage)
    {
        Playerhealth -= damage;
        healthBar.SetHealth(Playerhealth);
        //if the damage takes the player down to zero, then the player will be destroyed
        if(Playerhealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void GetHealth()
    {
        Playerhealth +=5;
        if (Playerhealth > 20)
        {
            Playerhealth = 20;
        }
        healthBar.SetHealth(Playerhealth);
    }
}
