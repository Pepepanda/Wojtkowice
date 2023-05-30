using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour

{
    public float moveSpeed = 3f; // Pr�dko�� poruszania si� wroga
    public float chaseSpeed = 6f; // Pr�dko�� �cigania gracza
    public float chaseDistance = 5f; // Odleg�o��, z kt�rej wrogowie zaczynaj� �ciga� gracza
    public Transform[] patrolPoints; // Punkty patrolowe, kt�re wrogowie b�d� porusza�

    private int currentPointIndex = 0;
    private Transform target; // Aktualny cel wroga (gracz)
    private bool isChasing = false;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // Pobierz transformacj� gracza jako cel
    }

    private void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget <= chaseDistance)
        {
            isChasing = true; // Je�li gracz jest wystarczaj�co blisko, zaczynamy go �ciga�
        }

        if (isChasing)
        {
            // Je�li �cigamy gracza, zmie� pr�dko�� poruszania
            float step = chaseSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else
        {
            // Je�li nie �cigamy gracza, poruszaj si� do kolejnego punktu patrolowego
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, step);

            // Sprawd�, czy dotarli�my do aktualnego punktu patrolowego
            if (transform.position == patrolPoints[currentPointIndex].position)
            {
                currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length; // Przejd� do nast�pnego punktu patrolowego
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = false; // Przestajemy �ciga� gracza, gdy opu�ci on nasze pole widzenia
        }
    }
}