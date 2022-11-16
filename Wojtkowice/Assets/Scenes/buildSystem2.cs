using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildSystem2 : MonoBehaviour
{
    int numberRoomsLUDR = 1; 
    [SerializeField]
    GameObject[] roomsLUDR;
    int numberRoomsLUD = 1;
    [SerializeField]
    GameObject[] roomsLUD; 
    int numberRoomsLUR = 1;
    [SerializeField]
    GameObject[] roomsLUR;
    int numberRoomsLUDR = 1;
    [SerializeField]
    GameObject[] roomsLDR;
    int numberRoomsUDR = 1;
    [SerializeField]
    GameObject[] roomsUDR;
    int numberRoomsLU = 1;
    [SerializeField]
    GameObject[] roomsLU;
    int numberRoomsLD = 1;
    [SerializeField]
    GameObject[] roomsLD;
    int numberRoomsUR = 1;
    [SerializeField]
    GameObject[] roomsUR;
    int numberRoomsDR = 1;
    [SerializeField]
    GameObject[] roomsDR;

    void awake()
    {

    }

    void createRoom(string nameOfRoom, int StartX, int StartY)
    {
        if(nameOfRoom == "LUDR")
        {
            
        }
    }
}
