using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildSystem3 : MonoBehaviour
{

    private System.Random rand = new System.Random();
    System.Random random;
    public string seed;
    public int widthPlus, widthMinus, heightPlus, heightMinus;
    public int actualx, actualy;
    private int startx, starty; 

    int numberRoomsLUDR;
    [SerializeField]
    GameObject[] roomsLUDR;
    int numberRoomsLUD;
    [SerializeField]
    GameObject[] roomsLUD;
    int numberRoomsLUR;
    [SerializeField]
    GameObject[] roomsLUR;
    int numberRoomsLDR;
    [SerializeField]
    GameObject[] roomsLDR;
    int numberRoomsUDR;
    [SerializeField]
    GameObject[] roomsUDR;
    int numberRoomsLU;
    [SerializeField]
    GameObject[] roomsLU;
    int numberRoomsLD;
    [SerializeField]
    GameObject[] roomsLD;
    int numberRoomsUD;
    [SerializeField]
    GameObject[] roomsUD;
    int numberRoomsUR;
    [SerializeField]
    GameObject[] roomsUR;
    int numberRoomsLR;
    [SerializeField]
    GameObject[] roomsLR;
    int numberRoomsDR;
    [SerializeField]
    GameObject[] roomsDR;
    int numberRoomsR;
    [SerializeField]
    GameObject[] roomsR;
    int numberRoomsD;
    [SerializeField]
    GameObject[] roomsD;
    int numberRoomsU;
    [SerializeField]
    GameObject[] roomsU;
    int numberRoomsL;
    [SerializeField]
    GameObject[] roomsL;

    public ceil2[,] ceils;

    void Awake()
    {
        random = new System.Random((!string.IsNullOrEmpty(seed)) ? seed.GetHashCode() : System.Guid.NewGuid().GetHashCode());
        numberRoomsLUDR = roomsLUDR.Length;
        numberRoomsLUD = roomsLUD.Length;
        numberRoomsLUR = roomsLUR.Length;
        numberRoomsLDR = roomsLDR.Length;
        numberRoomsUDR = roomsUDR.Length;
        numberRoomsLU = roomsLU.Length;
        numberRoomsLD = roomsLD.Length;
        numberRoomsUR = roomsUR.Length;
        numberRoomsDR = roomsDR.Length;
        numberRoomsUD = roomsUD.Length;
        numberRoomsLR = roomsLR.Length;
        numberRoomsL = roomsL.Length;
        numberRoomsD = roomsD.Length;
        numberRoomsU = roomsU.Length;
        numberRoomsR = roomsR.Length;
        ceils = new ceil2[widthPlus + widthMinus + 1, heightPlus + heightMinus + 1];
        createEmptyCeils(widthPlus + widthMinus + 1, heightPlus + heightMinus + 1);
        startx = actualx;
        starty = actualy; 
    }

    void createLabirynt()
    {
        do
        {

        } while (actualx == startx && actualy == starty); 
    }

    void createEmptyCeils(int width, int height)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                ceils[x, y] = new ceil2();
            }
        }
    }

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
        else if (nameOfRoom == "UD")
        {
            GameObject newCeil = Instantiate(roomsUD[rand.Next(numberRoomsUD)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
        else if (nameOfRoom == "LR")
        {
            GameObject newCeil = Instantiate(roomsLR[rand.Next(numberRoomsLR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
        else if (nameOfRoom == "L")
        {
            GameObject newCeil = Instantiate(roomsL[rand.Next(numberRoomsL)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
        else if (nameOfRoom == "U")
        {
            GameObject newCeil = Instantiate(roomsU[rand.Next(numberRoomsU)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
        else if (nameOfRoom == "D")
        {
            GameObject newCeil = Instantiate(roomsD[rand.Next(numberRoomsD)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
        else if (nameOfRoom == "R")
        {
            GameObject newCeil = Instantiate(roomsR[rand.Next(numberRoomsR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
            newCeil.name = string.Format("Ceil({0}, {1})", x, y);
            newCeil.transform.parent = this.transform;
        }
    }
}
