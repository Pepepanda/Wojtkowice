using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public float distanceBetween;

    private float distance;
    void Start()
    {

    }

    void Update()
    {
        //funkcja Vector2.Distance znajduje dystans pomiedzy transform.option(pozycja bia³ej kwadratu) i player.transform.position (pozycja gracza) , wtedy zwraca zmienna jako float
        distance = Vector2.Distance(transform.position, player.transform.position);//zeby ten wróg nie za szybko z³apal gracza stosujemy te dwie zmienne
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}