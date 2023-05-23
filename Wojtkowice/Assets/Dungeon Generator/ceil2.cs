using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceil2 : MonoBehaviour
{
    public bool right, left, up, down; 
    public int beforeX, beforeY, which;
    public bool isActive, isBoss;
    public ceil2()
    {
        right = false;
        left = false;
        up = false;
        down = false;
        isActive = false;
        isBoss = false;
        which = 0; 
    }
}
