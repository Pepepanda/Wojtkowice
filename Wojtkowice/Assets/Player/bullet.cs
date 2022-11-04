using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        EnemyDie EnemyDie = hitinfo.GetComponent<EnemyDie>();
        if(EnemyDie != null)
        {
            EnemyDie.TakeDamage(2);
        }
        Destroy(gameObject);
    }
}
