using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceil2 : MonoBehaviour
{
    public bool right, left, up, down; 
    public int beforeX, beforeY;
    public bool isActive;
    public ceil2()
    {
        right = false;
        left = false;
        up = false;
        down = false;
        isActive = false; 
    }

    public List<int> before()
    {
        return new List<int>{ beforeX, beforeY }; 
    }
}
