using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public buildSystem3 build;

    void Start()
    {
        build = GameObject.Find("Game Manager").GetComponent<buildSystem3>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            build.numberKey++;
            Destroy(gameObject); 
        }
    }
}
