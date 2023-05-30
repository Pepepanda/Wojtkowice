using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public PlayerSounds playerSounds;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            buildSystem3 build = GameObject.Find("Game Manager").GetComponent<buildSystem3>();
            playerSounds = GameObject.Find("Player").GetComponent<PlayerSounds>();
            playerSounds.GetSound();
            build.numberKey++;
            Destroy(gameObject); 
        }
    }
}
