using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public buildSystem3 build;
    public RoomLoad roomLoad; 
    public int x, y;
    public bool isOpen; 
    public int minEnemies, maxEnemies; 
    [SerializeField]
    public GameObject[] enemies;

    void Start()
    {
        isOpen = false; 
        build = GameObject.Find("Game Manager").GetComponent<buildSystem3>();
        string nazwaGameObjectu = transform.parent.gameObject.name;
        string[] liczby = nazwaGameObjectu.Substring(5, nazwaGameObjectu.Length - 6).Split(',');
        if (liczby.Length == 2 && int.TryParse(liczby[0].Trim(), out x) && int.TryParse(liczby[1].Trim(), out y)){}
        roomLoad = GameObject.Find(nazwaGameObjectu).GetComponent<RoomLoad>(); 
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isOpen)
            {
                isOpen = true;
                int random = build.random.Next(minEnemies, maxEnemies + 1);
                for (int i = 0; i < random; i++)
                {
                    GameObject newEnemy = Instantiate(enemies[build.random.Next(enemies.Length)], new Vector2((build.startx * 18) + (x * 18), (build.starty * 10) + (y * 10)), Quaternion.identity) as GameObject;
                    newEnemy.transform.parent = this.transform.parent; 
                    SpriteRenderer spriteRenderer = newEnemy.GetComponent<SpriteRenderer>();
                    spriteRenderer.sortingOrder = 1;
                }
            }
        }
    }
}
