using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceil : MonoBehaviour
{
    public byte right, left, up, down; //0 - nie wiadomo; 1 - nie ma �ciany; 2 - jest �ciana
    public ceil(byte r, byte l, byte u, byte d)
    {
        right = r;
        left = l; 
        up = u;
        down = d;
    }
}
