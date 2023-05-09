using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoad : MonoBehaviour
{
    public bool isOpen, isDestroy;
    public buildSystem3 build;
    public int x, y;
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

        string nazwaGameObjectu = gameObject.name;
        string[] liczby = nazwaGameObjectu.Substring(5, nazwaGameObjectu.Length - 6).Split(',');
        if (liczby.Length == 2 && int.TryParse(liczby[0].Trim(), out x) && int.TryParse(liczby[1].Trim(), out y))
        {

        }
    }

    void Update()
    {
        if(!isDestroy && isOpen && numberEnemies == 0)
        {
            isDestroy = true; 
            Destroy(transform.Find("doors").gameObject); 
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i <= transform.childCount - 1; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            if(!isOpen)
            {
                isOpen = true;
                if (!build.isFirstOpen)
                {
                    build.isFirstOpen = true;
                }
                else
                {
                    int random = build.random.Next(build.minEnemies, build.maxEnemies + 1);
                    for (int i = 0; i < random; i++)
                    {
                        GameObject newEnemy = Instantiate(build.enemies[build.random.Next(build.numberEnemies)], new Vector2((build.startx * 18) + (x * 18), (build.starty * 10) + (y * 10)), Quaternion.identity) as GameObject;
                        newEnemy.transform.parent = this.transform;
                    }
                    numberEnemies = random;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            numberEnemies--; 
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
