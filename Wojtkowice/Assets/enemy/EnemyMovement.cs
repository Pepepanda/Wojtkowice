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
        player = GameObject.Find("Player");
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
    }
}