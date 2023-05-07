using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthText;
    public int healthBar;
    public Slider slider;
    void Update()
    {
        healthText.text = "HEALTH: " + healthBar;
        slider.value = healthBar;
    }
    public void SetHealth(int healthPoint)
    {
        healthBar = healthPoint;
    }
}
