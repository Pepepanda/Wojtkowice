using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;

public class buildSystem2 : MonoBehaviour
{
    private System.Random rand = new System.Random();
    System.Random random;
    public string seed; 
    public GameObject prefab;
    public int nwidth, nheight; 

    int numberRoomsLUDR = 1; 
    [SerializeField]
    GameObject[] roomsLUDR;
    int numberRoomsLUD = 1;
    [SerializeField]
    GameObject[] roomsLUD; 
    int numberRoomsLUR = 1;
    [SerializeField]
    GameObject[] roomsLUR;
    int numberRoomsLDR = 1;
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

    public ceil[,] ceils; 

    void Awake()
    {
        //createRoom("LUD", 0, 0);
        //createRoom("LUR", 18, 0);
        //createRoom("LDR", 0, 10);
        //createRoom("UDR", 18, 10);
        //createRoom("LU", 0, 0);
        //createRoom("UR", 18, 0);
        //createRoom("LD", 0, 10);
        //createRoom("DR", 18, 10);
        //createHause(8, 7, 0, 0);
        random = new System.Random((!string.IsNullOrEmpty(seed)) ? seed.GetHashCode() : System.Guid.NewGuid().GetHashCode());
        ceils = new ceil[nwidth, nheight]; 
    }
    void Start()
    {
        //createHause(8, 7, -36, -20);
        createLabirynt(nwidth, nheight, 0, 0); 
    }
    void createLabirynt(int width, int height, int StartX, int StartY)
    {
        createEmptyCeils(width, height);
        int x = 0, y = 0;
        ceils[x, y].right = 1; 
    }
    void createEmptyCeils(int width, int height)
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                //ceil[x, y] = Instantiate(prefab, new Vector2(x * 18 + StartX, y * 10 + StartY), Quaternion.identity) as GameObject;
                //ceil[x, y].name = string.Format("Ceil({0}, {1})", x, y);
                //ceil[x, y].transform.parent = this.transform;
                ceils[x, y] = new ceil(0, 0, 0, 0); 
            }
        }
    }
    void createHause(int width, int height, int StartX, int StartY)
    {
        for(int x = 0; x < width; x++)
        {
            for( int y = 0; y < height; y++)
            {
                if (x == 0 && y == 0)
                {
                    createRoom("UR", StartX, StartY);
                }
                else if (x == 0 && y == height - 1)
                {
                    createRoom("DR", StartX, StartY + (y * 10));
                }
                else if (x == width - 1 && y == 0)
                {
                    createRoom("LU", StartX + (x * 18), StartY);
                }
                else if (x == width - 1 && y == height - 1)
                {
                    createRoom("LD", StartX + (x * 18), StartY + (y * 10));
                }
                else if (x == 0)
                {
                    createRoom("UDR", StartX, StartY + (y * 10));
                }
                else if (x == width - 1)
                {
                    createRoom("LUD", StartX + (x * 18), StartY + (y * 10));
                }
                else if (y == 0)
                {
                    createRoom("LUR", StartX + (x * 18), StartY);
                }
                else if (y == height - 1)
                {
                    createRoom("LDR", StartX + (x * 18), StartY + (y * 10));
                }
                else
                {
                    createRoom("LUDR", StartX + (x * 18), StartY + (y * 10)); 
                }
            }
        }
    }

    void createRoom(string nameOfRoom, int x, int y)
    {
        if (nameOfRoom == "LUDR")
        {
            Instantiate(roomsLUDR[rand.Next(numberRoomsLUDR)], new Vector2(x, y), Quaternion.identity);
        }
        else if (nameOfRoom == "LUD")
        {
            Instantiate(roomsLUD[rand.Next(numberRoomsLUD)], new Vector2(x, y), Quaternion.identity);
        }
        else if (nameOfRoom == "LUR")
        {
            Instantiate(roomsLUR[rand.Next(numberRoomsLUR)], new Vector2(x, y), Quaternion.identity);
        }
        else if (nameOfRoom == "LDR")
        {
            Instantiate(roomsLDR[rand.Next(numberRoomsLDR)], new Vector2(x, y), Quaternion.identity);
        }
        else if (nameOfRoom == "UDR")
        {
            Instantiate(roomsUDR[rand.Next(numberRoomsUDR)], new Vector2(x, y), Quaternion.identity);
        }
        else if (nameOfRoom == "LU")
        {
            Instantiate(roomsLU[rand.Next(numberRoomsLU)], new Vector2(x, y), Quaternion.identity);
        }
        else if (nameOfRoom == "UR")
        {
            Instantiate(roomsUR[rand.Next(numberRoomsUR)], new Vector2(x, y), Quaternion.identity);
        }
        else if (nameOfRoom == "LD")
        {
            Instantiate(roomsLD[rand.Next(numberRoomsLD)], new Vector2(x, y), Quaternion.identity);
        }
        else if (nameOfRoom == "DR")
        {
            Instantiate(roomsDR[rand.Next(numberRoomsDR)], new Vector2(x, y), Quaternion.identity);
        }
    }
}
