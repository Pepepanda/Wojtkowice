using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceil : MonoBehaviour
{
    public byte right, left, up, down; //0 - nie wiadomo; 1 - nie ma œciany; 2 - jest œciana
    public ceil(byte r, byte l, byte u, byte d)
    {
        right = r;
        left = l; 
        up = u;
        down = d;
    }
}
