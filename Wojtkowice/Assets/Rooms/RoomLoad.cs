using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoad : MonoBehaviour
{
    public bool isOpen, isDestroy;
    public buildSystem3 build;
    public int numberEnemies; 

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        isDestroy = false; 
        build = GameObject.Find("Game Manager").GetComponent<buildSystem3>();
        for (int i = 0; i <= transform.childCount - 1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        numberEnemies = 0; 
    }

    void Update()
    {
        if(!isDestroy && isOpen && numberEnemies <= 0)
        {
            isDestroy = true; 
            Destroy(transform.Find("doors").gameObject); 
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            numberEnemies++;
        }
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i <= transform.childCount - 1; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            if (!isOpen)
            {
                isOpen = true;
                if (!build.isFirstOpen)
                {
                    build.isFirstOpen = true;
                    numberEnemies = 0;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            numberEnemies -= 1; 
        }
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i <= transform.childCount - 1; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
