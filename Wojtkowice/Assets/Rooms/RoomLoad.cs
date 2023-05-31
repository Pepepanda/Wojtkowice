using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoad : MonoBehaviour
{
    public bool isOpen, isDestroy, isBoss, isTimerStart, isTimerEnd, isGenerateTeleport, isBossOpen;
    public buildSystem3 build;
    public int numberEnemies;
    public int x, y;
    public float timer; 

    void Start()
    {
        isOpen = false;
        isDestroy = false;
        isTimerEnd = false;
        isTimerStart = false;
        isGenerateTeleport = false;
        isBossOpen = false; 
        timer = 1; 
        build = GameObject.Find("Game Manager").GetComponent<buildSystem3>();
        for (int i = 0; i <= transform.childCount - 1; i++)
        {
            /*transform.GetChild(i).gameObject.SetActive(false);*/
        }
        numberEnemies = 0;
        string nazwaGameObjectu = transform.gameObject.name;
        string[] liczby = nazwaGameObjectu.Substring(5, nazwaGameObjectu.Length - 6).Split(',');
        if (liczby.Length == 2 && int.TryParse(liczby[0].Trim(), out x) && int.TryParse(liczby[1].Trim(), out y)) { }
    }

    void Update()
    {
        if (isTimerStart)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                isTimerEnd = true;
                isTimerStart = false; 
            }
        }
        if (isOpen && numberEnemies <= 0)
        {
            transform.Find("doors").gameObject.SetActive(false);
            if (isBoss && isTimerEnd)
            {
                if(!isGenerateTeleport)
                {
                    isGenerateTeleport = true;
                    GameObject newInsides = Instantiate(build.teleport, new Vector2((build.startx * 18) + (x * 18), (build.starty * 10) + (y * 10)), Quaternion.identity) as GameObject;
                    newInsides.transform.parent = this.transform;
                }
            }
        }
        else if(isOpen && numberEnemies > 0)
        {
            transform.Find("doors").gameObject.SetActive(true);
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
            if (isBoss)
            {
                if (!isOpen)
                {
                    isOpen = true;
                }
                if (build.numberKey >= 2 && !isBossOpen)
                {
                    isBossOpen = true; 
                    GameObject newInsides = Instantiate(build.bosses[build.random.Next(build.bosses.Length)], new Vector2((build.startx * 18) + (x * 18), (build.starty * 10) + (y * 10)), Quaternion.identity) as GameObject;
                    newInsides.transform.parent = this.transform;
                    isTimerStart = true; 
                }
            }
            else
            {
                if (!isOpen)
                {
                    isOpen = true;
                    if (!build.isFirstOpen)
                    {
                        build.isFirstOpen = true;
                    }
                    else
                    {
                        GameObject newInsides = Instantiate(build.insides[build.random.Next(build.insides.Length)], new Vector2((build.startx * 18) + (x * 18), (build.starty * 10) + (y * 10)), Quaternion.identity) as GameObject;
                        newInsides.transform.parent = this.transform;
                    }
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
