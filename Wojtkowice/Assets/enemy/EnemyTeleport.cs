using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeleport : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(cooldown);
        Vector2 move = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.position = move;
        StartCoroutine(waiter());
    }
}
