using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public ShootingScript script;
    private void Start()
    {
        script = GameObject.Find("Player").GetComponent<ShootingScript>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyDie EnemyDie = collision.GetComponent<EnemyDie>();
        if (EnemyDie != null)
        {
            EnemyDie.TakeDamage(2);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
