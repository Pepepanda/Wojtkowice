using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform bomba;
    public float wielkoscEksplozji;
    public LayerMask enemyLayers;
    public int obrazenia;
    float timer;
    public int sekundy;


    /*private void Start()
    {
        StartCoroutine(CountdownToStart());
    }
    void Explode()
    {
        Collider[] uderz = Physics2D.OverlapCircleAll(bomba.position, wielkoscEksplozji, enemyLayers);
        foreach(Collider2D enemy in uderz)
        {
            enemy.GetComponent<EnemyDie>().TakeDamage(obrazenia);
        }
        foreach (Collider2D player in uderz)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(obrazenia);
        }
    }
    void Update()
    {
        
    }

    void OnDrawGizmosSelected()
    {
        if(bomba == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(bomba.position, wielkoscEksplozji);
    }
    IEnumerator CountdownToStart()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(sekundy);
            timer--;
            Explode();
            
        }
    }*/
}
