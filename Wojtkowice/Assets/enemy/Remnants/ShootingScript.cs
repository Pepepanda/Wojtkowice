using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject target; // Reference to the player object
    public float szybkosc;
    public float predkoscPocisku;// Reference to the bullet prefab
    private Rigidbody2D rb;
    public float NajlepszyDystansDoWystrzeleniaPocisku;
    public Transform firingPoint;
    private float kiedyStrzelic;
    public Object bulletPrefab;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        NajlepszyDystansDoWystrzeleniaPocisku = predkoscPocisku;
    }
    private void Update()
    {
        if (!target)
        {
            GetTarget();

        }

        /*if (target != null && Vector2.Distance(target.transform.position, transform.position) <= NajlepszyDystansDoWystrzeleniaPocisku)
        {
            Shoot();
        }*/
        else
        {
            Shoot();
            Debug.Log("eeee");
        }

    }
    private void Shoot()
    {
        if (kiedyStrzelic <= 0f)
        {
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            kiedyStrzelic = predkoscPocisku;
        }
        else
        {
            kiedyStrzelic -= Time.deltaTime;

        }
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }
}






