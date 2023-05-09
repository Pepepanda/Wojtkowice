using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= transform.childCount-1; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i <= transform.childCount - 1; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i <= transform.childCount - 1; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
