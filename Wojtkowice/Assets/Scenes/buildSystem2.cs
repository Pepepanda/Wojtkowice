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
    public int nwidth, nheight, chance;
    byte r2; 

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
        starta(nwidth, nheight, 0, 0);
    }
    void starta(int width, int height, int StartX, int StartY)
    {
        createEmptyCeils(width, height);
        createLabirynt(width, height, StartX - width * 9, StartY - height * 5);
    }
    void createLabirynt(int width, int height, int StartX, int StartY)
    {
        int startx = width / 2, starty = height / 2;
        int x = startx, y = starty;
        while (ceils[x, y].state != 2)
        {
            if (x > 0 && y > 0 && x < width && y < height)
            {
                int r = random.Next(0, 4); // 0 - prowo; 1 - lewo; 2 - góra; 3 - dó³
                switch (r)
                {
                    case 0:
                        if (x < width - 1)
                        {
                            if (ceils[x, y].right == 0)
                            {
                                int r1 = random.Next(1, chance);
                                if (r1 != 2)
                                {
                                    r2 = 1;
                                }
                                Debug.Log(string.Format("ceils[{0}, {1}].right = {2}", x, y, r2));
                                ceils[x, y].right = r2;
                                x++;
                                Debug.Log(string.Format("ceils[{0}, {1}].left = {2}", x, y, r2));
                                ceils[x, y].left = r2;
                                if(r2 == 2)
                                {
                                    x--; 
                                }
                                else
                                {
                                    ceils[x, y].beforeX = x - 1;
                                    ceils[x, y].beforeY = y; 
                                }
                            }
                            else
                            {
                                if (ceils[x, y].right != 0 && ceils[x, y].left != 0 && ceils[x, y].up != 0 && ceils[x, y].down != 0)
                                {
                                    int newX = ceils[x, y].beforeX;
                                    y = ceils[x, y].beforeY;
                                    x = newX;
                                }
                            }
                        }
                        else
                        {
                            Debug.Log(string.Format("ceils[{0}, {1}].right = 2", x, y)); 
                            ceils[x, y].right = 2;
                        }
                        break;
                    case 1:
                        if (x > 0)
                        {
                            if (ceils[x, y].left == 0)
                            {
                                int r1 = random.Next(1, chance);
                                if (r1 != 2)
                                {
                                    r2 = 1;
                                }
                                Debug.Log(string.Format("ceils[{0}, {1}].left = {2}", x, y, r2));
                                ceils[x, y].left = r2;
                                x--;
                                Debug.Log(string.Format("ceils[{0}, {1}].right = {2}", x, y, r2));
                                ceils[x, y].right = r2;
                                if(r2 == 2)
                                {
                                    x++;
                                }
                                else
                                {
                                    ceils[x, y].beforeX = x + 1;
                                    ceils[x, y].beforeY = y;
                                }
                            }
                            else
                            {
                                if (ceils[x, y].right != 0 && ceils[x, y].left != 0 && ceils[x, y].up != 0 && ceils[x, y].down != 0)
                                {
                                    int newX = ceils[x, y].beforeX;
                                    y = ceils[x, y].beforeY;
                                    x = newX;
                                }
                            }
                        }
                        else
                        {
                            Debug.Log(string.Format("ceils[{0}, {1}].left = 2", x, y));
                            ceils[x, y].left = 2;
                        }
                        break;
                    case 2:
                        if (y < height - 1)
                        {
                            if (ceils[x, y].up == 0)
                            {
                                int r1 = random.Next(1, chance);
                                if (r1 != 2)
                                {
                                    r2 = 1;
                                }
                                Debug.Log(string.Format("ceils[{0}, {1}].up = {2}", x, y, r2));
                                ceils[x, y].up = r2;
                                y++;
                                Debug.Log(string.Format("ceils[{0}, {1}].down = {2}", x, y, r2));
                                ceils[x, y].down = r2;
                                if(r2 == 2)
                                {
                                    y--;
                                }
                                else
                                {
                                    ceils[x, y].beforeX = x;
                                    ceils[x, y].beforeY = y - 1;
                                }
                            }
                            else
                            {
                                if (ceils[x, y].right != 0 && ceils[x, y].left != 0 && ceils[x, y].up != 0 && ceils[x, y].down != 0)
                                {
                                    int newX = ceils[x, y].beforeX;
                                    y = ceils[x, y].beforeY;
                                    x = newX;
                                }
                            }
                        }
                        else
                        {
                            Debug.Log(string.Format("ceils[{0}, {1}].up = 2", x, y));
                            ceils[x, y].up = 2;
                        }
                        break;
                    case 3:
                        if (y > 0)
                        {
                            if (ceils[x, y].down == 0)
                            {
                                int r1 = random.Next(1, chance);
                                if (r1 != 2)
                                {
                                    r2 = 1;
                                }
                                Debug.Log(string.Format("ceils[{0}, {1}].down = {2}", x, y, r2));
                                ceils[x, y].down = r2;
                                y--;
                                Debug.Log(string.Format("ceils[{0}, {1}].up = {2}", x, y, r2));
                                ceils[x, y].up = r2;
                                if(r2 == 2)
                                {
                                    y++;
                                }
                                else
                                {
                                    ceils[x, y].beforeX = x;
                                    ceils[x, y].beforeY = y + 1;
                                }
                            }
                            else
                            {
                                if (ceils[x, y].right != 0 && ceils[x, y].left != 0 && ceils[x, y].up != 0 && ceils[x, y].down != 0)
                                {
                                    int newX = ceils[x, y].beforeX;
                                    y = ceils[x, y].beforeY;
                                    x = newX; 
                                }
                            }
                        }
                        else
                        {
                            Debug.Log(string.Format("ceils[{0}, {1}].down = 2", x, y));
                            ceils[x, y].down = 2;
                        }
                        break;
                    default:
                        Debug.Log("inna wartoœæ");
                        break;
                }
                /*bool isFull = true; 
                for(int i = 0; i < width; i++)
                {
                    for(int j = 0; j < height; j++)
                    {
                        if(ceils[i, j].right == 0 || ceils[i, j].left == 0 || ceils[i, j].up == 0 || ceils[i, j].down == 0)
                        {
                            isFull = false;
                            break; 
                        }
                    }
                }
                if (isFull)
                {
                    ceils[x, y].state = 2;
                }*/
                if(ceils[startx, starty].right != 0 && ceils[startx, starty].left != 0 && ceils[startx, starty].up != 0 && ceils[startx, starty].down != 0)
                {
                    ceils[x, y].state = 2; 
                }
            }
            else
            {
                x = 0;
                y = 0;
                ceils[x, y].state = 2;
            }
        }
        for (x = 0; x<width; x++)
        {
            for (y = 0; y<height; y++)
            {
                if(ceils[x, y].left == 1 && ceils[x, y].up == 1 && ceils[x, y].down == 1 && ceils[x, y].right == 1)
                {
                    createRoom("LUDR", x, y, StartX, StartY);
                }
                else if (ceils[x, y].left == 1 && ceils[x, y].up == 1 && ceils[x, y].down == 1)
                {
                    createRoom("LUD", x, y, StartX, StartY);
                }
                else if (ceils[x, y].left == 1 && ceils[x, y].up == 1 && ceils[x, y].right == 1)
                {
                    createRoom("LUR", x, y, StartX, StartY);
                }
                else if (ceils[x, y].left == 1 && ceils[x, y].down == 1 && ceils[x, y].right == 1)
                {
                    createRoom("LDR", x, y, StartX, StartY);
                }
                else if (ceils[x, y].up == 1 && ceils[x, y].down == 1 && ceils[x, y].right == 1)
                {
                    createRoom("UDR", x, y, StartX, StartY);
                }
                else if(ceils[x, y].right == 1 || ceils[x, y].left == 1 || ceils[x, y].up == 1 || ceils[x, y].down == 1)
                {
                    createRoom("LU", x, y, StartX, StartY); 
                }
                else if(ceils[x, y].right == 2 || ceils[x, y].left == 2 || ceils[x, y].up == 2 || ceils[x, y].down == 2)
                {
                    createRoom("DR", x, y, StartX, StartY);
                }
            }
        }
    }
    void createEmptyCeils(int width, int height)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                ceils[x, y] = new ceil(0, 0, 0, 0);
            }
        }
    }
    /*void createHause(int width, int height, int StartX, int StartY)
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
    }*/

    void createRoom(string nameOfRoom, int x, int y, int StartX, int StartY)
    {
        if (nameOfRoom == "LUDR")
        {
            GameObject newCeil = Instantiate(roomsLUDR[rand.Next(numberRoomsLUDR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
        else if (nameOfRoom == "LUD")
        {
            GameObject newCeil = Instantiate(roomsLUD[rand.Next(numberRoomsLUD)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
        else if (nameOfRoom == "LUR")
        {
            GameObject newCeil = Instantiate(roomsLUR[rand.Next(numberRoomsLUR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
        else if (nameOfRoom == "LDR")
        {
            GameObject newCeil = Instantiate(roomsLDR[rand.Next(numberRoomsLDR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
        else if (nameOfRoom == "UDR")
        {
            GameObject newCeil = Instantiate(roomsUDR[rand.Next(numberRoomsUDR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
        else if (nameOfRoom == "LU")
        {
            GameObject newCeil = Instantiate(roomsLU[rand.Next(numberRoomsLU)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
        else if (nameOfRoom == "UR")
        {
            GameObject newCeil = Instantiate(roomsUR[rand.Next(numberRoomsUR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
        else if (nameOfRoom == "LD")
        {
            GameObject newCeil = Instantiate(roomsLD[rand.Next(numberRoomsLD)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
        else if (nameOfRoom == "DR")
        {
            GameObject newCeil = Instantiate(roomsDR[rand.Next(numberRoomsDR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
    }
}
