using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour

{
    public float moveSpeed = 3f; // Prêdkoœæ poruszania siê wroga
    public float chaseSpeed = 6f; // Prêdkoœæ œcigania gracza
    public float chaseDistance = 5f; // Odleg³oœæ, z której wrogowie zaczynaj¹ œcigaæ gracza
    public Transform[] patrolPoints; // Punkty patrolowe, które wrogowie bêd¹ poruszaæ

    private int currentPointIndex = 0;
    private Transform target; // Aktualny cel wroga (gracz)
    private bool isChasing = false;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // Pobierz transformacjê gracza jako cel
    }

    private void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget <= chaseDistance)
        {
            isChasing = true; // Jeœli gracz jest wystarczaj¹co blisko, zaczynamy go œcigaæ
        }

        if (isChasing)
        {
            // Jeœli œcigamy gracza, zmieñ prêdkoœæ poruszania
            float step = chaseSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else
        {
            // Jeœli nie œcigamy gracza, poruszaj siê do kolejnego punktu patrolowego
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, step);

            // SprawdŸ, czy dotarliœmy do aktualnego punktu patrolowego
            if (transform.position == patrolPoints[currentPointIndex].position)
            {
                currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length; // PrzejdŸ do nastêpnego punktu patrolowego
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = false; // Przestajemy œcigaæ gracza, gdy opuœci on nasze pole widzenia
        }
    }
}