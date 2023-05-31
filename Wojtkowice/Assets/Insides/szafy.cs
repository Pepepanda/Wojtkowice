using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class szafy : MonoBehaviour
{
    void Awake()
    {
        transform.SetParent(GameObject.Find("Szafy").transform); 
    }
}
