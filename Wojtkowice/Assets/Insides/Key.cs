using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            buildSystem3 build = GameObject.Find("Game Manager").GetComponent<buildSystem3>();
            build.numberKey++;
            Destroy(gameObject); 
        }
    }
}
