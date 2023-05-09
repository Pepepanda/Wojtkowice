using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildSystem3 : MonoBehaviour
{

    private System.Random rand = new System.Random();
    public System.Random random;
    public string seed;
    public bool isConsoleWrite; 
    public int widthPlus, widthMinus, heightPlus, heightMinus;
    private int actualx, actualy;
    public int startx, starty;
    public int chance, maxLongSeed;
    public bool isFirstOpen;
    public int minEnemies, maxEnemies; 

    public int numberEnemies; 
    [SerializeField]
    public GameObject[] enemies;

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
        if (string.IsNullOrEmpty(seed))
        {
            int longSeed = rand.Next(2, maxLongSeed), randomNumber;
            char current;
            for (int i = 0; i < longSeed; i++)
            {
                randomNumber = rand.Next(33, 127); 
                current = (char)randomNumber;
                seed += current;
            }
        }

        isFirstOpen = false; 
        random = new System.Random((!string.IsNullOrEmpty(seed)) ? seed.GetHashCode() : System.Guid.NewGuid().GetHashCode());
        numberEnemies = enemies.Length;
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
        actualx = startx + widthMinus;
        actualy = starty + widthMinus;

        createLabirynt();
        activateLabirynt(); 
    }

    void createLabirynt()
    {
        while(true)
        {
            ceils[actualx, actualy].isActive = true;

            if (isConsoleWrite) UnityEngine.Debug.Log($"createLabirynt(), actualx: {actualx}, actualy: {actualy}, w lewo: {isActive(-1, 0)}, w g�r�: {isActive(0, 1)}, " +
                $"w d�: {isActive(0, -1)}, w prawo: {isActive(1, 0)}, beforeX: {ceils[actualx, actualy].beforeX}, beforeY: {ceils[actualx, actualy].beforeY} "); 

            int ile = 0;
            if (isActive(-1, 0)) ile++;
            if (isActive(0, 1)) ile++;
            if (isActive(0, -1)) ile++;
            if (isActive(1, 0)) ile++;
            if(ile == 0)
            {
                int newActualX = ceils[actualx, actualy].beforeX;
                int newActualY = ceils[actualx, actualy].beforeY;
                actualx = newActualX;
                actualy = newActualY;
                if (isConsoleWrite) UnityEngine.Debug.Log($"createLabirynt(), cofnięcie do poprzedniego z powodu braku możliwości iścia dalej, actualx: {actualx}, actualy: {actualy} ");
            }
            else
            {
                int isZero = random.Next(0, chance); 
                if(isZero == 0)
                {
                    int newActualX = ceils[actualx, actualy].beforeX;
                    int newActualY = ceils[actualx, actualy].beforeY;
                    actualx = newActualX;
                    actualy = newActualY;
                    if (isConsoleWrite) UnityEngine.Debug.Log($"createLabirynt(), cofnięcie do poprzedniego z powodu wylosowania takiej wartości, actualx: {actualx}, actualy: {actualy} ");
                }
                int ran = random.Next(1, ile + 1);
                ile = 0;
                if (isActive(-1, 0)) ile++;
                if(ran == ile)
                {
                    ceils[actualx, actualy].left = true;
                    actualx -= 1;
                    ceils[actualx, actualy].right = true;
                    ceils[actualx, actualy].beforeX = actualx + 1;
                    ceils[actualx, actualy].beforeY = actualy;
                    if (isConsoleWrite) UnityEngine.Debug.Log($"createLabirynt(), w lewo: actualx: {actualx}, actualy: {actualy}, newBeforeX: {ceils[actualx, actualy].beforeX}, newBeforeY: {ceils[actualx, actualy].beforeY} ");
                }
                else
                {
                    if (isActive(0, 1)) ile++;
                    if (ran == ile)
                    {
                        ceils[actualx, actualy].up = true;
                        actualy += 1;
                        ceils[actualx, actualy].down = true;
                        ceils[actualx, actualy].beforeX = actualx;
                        ceils[actualx, actualy].beforeY = actualy - 1;
                        if (isConsoleWrite) UnityEngine.Debug.Log($"createLabirynt(), w g�r�: actualx: {actualx}, actualy: {actualy}, newBeforeX: {ceils[actualx, actualy].beforeX}, newBeforeY: {ceils[actualx, actualy].beforeY} ");
                    }
                    else
                    {
                        if (isActive(0, -1)) ile++;
                        if (ran == ile)
                        {
                            ceils[actualx, actualy].down = true;
                            actualy -= 1;
                            ceils[actualx, actualy].up = true;
                            ceils[actualx, actualy].beforeX = actualx;
                            ceils[actualx, actualy].beforeY = actualy + 1;
                            if (isConsoleWrite) UnityEngine.Debug.Log($"createLabirynt(), w d�: actualx: {actualx}, actualy: {actualy}, newBeforeX: {ceils[actualx, actualy].beforeX}, newBeforeY: {ceils[actualx, actualy].beforeY} ");
                        }
                        else
                        {
                            if (isActive(1, 0)) ile++;
                            if (ran == ile)
                            {
                                ceils[actualx, actualy].right = true;
                                actualx += 1;
                                ceils[actualx, actualy].left = true;
                                ceils[actualx, actualy].beforeX = actualx - 1;
                                ceils[actualx, actualy].beforeY = actualy;
                                if (isConsoleWrite) UnityEngine.Debug.Log($"createLabirynt(), w prawo: actualx: {actualx}, actualy: {actualy}, newBeforeX: {ceils[actualx, actualy].beforeX}, newBeforeY: {ceils[actualx, actualy].beforeY} ");
                            }
                            else
                            {
                                //UnityEngine.Debug.Log("Coś poszlo nie tak");
                                int newActualX = ceils[actualx, actualy].beforeX;
                                int newActualY = ceils[actualx, actualy].beforeY;
                                actualx = newActualX;
                                actualy = newActualY;
                                if (isConsoleWrite) UnityEngine.Debug.Log($"createLabirynt(), cofni�cie do poprzedniego z powodu nieznanego b��du :(, actualx: {actualx}, actualy: {actualy} ");
                            }
                        }
                    }
                }
            }
            if(actualx == startx + widthMinus && actualy == starty + widthMinus)
            {
                break; 
            }
        }
    }

    void createEmptyCeils(int width, int height)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                ceils[x, y] = gameObject.AddComponent<ceil2>();
                ceils[x, y].beforeX = startx + widthMinus;
                ceils[x, y].beforeY = starty + widthMinus; 
            }
        }
    }

    bool isActive(int x, int y)
    {
        if (x > 0 && widthPlus + widthMinus == actualx) return false;
        if (x < 0 && actualx == 0) return false;
        if (y > 0 && heightPlus + heightMinus == actualy) return false;
        if (y < 0 && actualy == 0) return false;
        if (ceils[actualx + x, actualy + y].isActive) return false;
        return true; 
    }

    void activateLabirynt()
    {
        for(int i = 0; i <= widthPlus + widthMinus; i++)
        {
            for(int j = 0; j <= heightPlus + heightMinus; j++)
            {
                if(ceils[i, j].left)
                {
                    if(ceils[i, j].up)
                    {
                        if(ceils[i, j].down)
                        {
                            if(ceils[i, j].right)
                            {
                                createRoom("LUDR", i - widthMinus, j - heightMinus, startx * 18, starty * 10); 
                            }
                            else
                            {
                                createRoom("LUD", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                        }
                        else
                        {
                            if (ceils[i, j].right)
                            {
                                createRoom("LUR", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                            else
                            {
                                createRoom("LU", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                        }
                    }
                    else
                    {
                        if (ceils[i, j].down)
                        {
                            if (ceils[i, j].right)
                            {
                                createRoom("LDR", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                            else
                            {
                                createRoom("LD", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                        }
                        else
                        {
                            if (ceils[i, j].right)
                            {
                                createRoom("LR", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                            else
                            {
                                createRoom("L", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                        }
                    }
                }
                else
                {
                    if (ceils[i, j].up)
                    {
                        if (ceils[i, j].down)
                        {
                            if (ceils[i, j].right)
                            {
                                createRoom("UDR", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                            else
                            {
                                createRoom("UD", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                        }
                        else
                        {
                            if (ceils[i, j].right)
                            {
                                createRoom("UR", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                            else
                            {
                                createRoom("U", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                        }
                    }
                    else
                    {
                        if (ceils[i, j].down)
                        {
                            if (ceils[i, j].right)
                            {
                                createRoom("DR", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                            else
                            {
                                createRoom("D", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                        }
                        else
                        {
                            if (ceils[i, j].right)
                            {
                                createRoom("R", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                            else
                            {
                                UnityEngine.Debug.Log("pusty pokuj"); 
                                createRoom("", i - widthMinus, j - heightMinus, startx * 18, starty * 10);
                            }
                        }
                    }
                }
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
