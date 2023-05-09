using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    public int playerHealth;
    public HealthBar healthBar;
    public GameObject DieMenu;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("Health").GetComponent<HealthBar>();
        playerHealth = health;
        healthBar.SetHealth(playerHealth);
    }
    //how much damage the player takes 
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        healthBar.SetHealth(playerHealth);
        //if the damage takes the player down to zero, then the player will be destroyed
        if(playerHealth <= 0)
        {
            Time.timeScale = 0f;
            DieMenu.SetActive(true);
        }
    }
    public void GetHealth()
    {
        playerHealth +=5;
        if (playerHealth > 20)
        {
            playerHealth = 20;
        }
        healthBar.SetHealth(playerHealth);
    }
}