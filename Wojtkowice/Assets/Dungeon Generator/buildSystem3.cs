using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StaticClass
{
    public static string CrossSceneInformation { get; set; }
}

public static class Dificulty
{
    public static int CrossSceneInformation { get; set; }
}

public class buildSystem3 : MonoBehaviour
{

    private System.Random rand = new System.Random();
    public System.Random random;
    public string seed;
    public bool isConsoleWrite;
    public int widthPlusEasy, widthPlusMedium, widthPlusHard, widthMinusEasy, widthMinusMedium, widthMinusHard, heightPlusEasy, heightPlusMedium, heightPlusHard, heightMinusEasy, heightMinusMedium, heightMinusHard; 
    public int widthPlus, widthMinus, heightPlus, heightMinus;
    private int actualx, actualy;
    public int startx, starty;
    public int chance, maxLongSeed;
    public bool isFirstOpen;
    float timer;
    public float startTimerEasy, startTimerMedium, startTimerHard, minutes, seconds;

    [SerializeField]
    public GameObject[] insidesEasy;
    [SerializeField]
    public GameObject[] insidesMedium;
    [SerializeField]
    public GameObject[] insidesHard;
    public GameObject[] insides;
    [SerializeField]
    public GameObject[] bosses;

    public int numberKey;
    [SerializeField]
    public GameObject key;
    public GameObject teleport;

    public int difficulty; 

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
        if(!string.IsNullOrEmpty(StaticClass.CrossSceneInformation))
        {
            seed = StaticClass.CrossSceneInformation;
        }
        if (Dificulty.CrossSceneInformation > 0 && Dificulty.CrossSceneInformation < 4)
        {
            difficulty = Dificulty.CrossSceneInformation;
        }
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

        switch (difficulty)
        {
            case 1:
                timer = startTimerEasy;
                widthPlus = widthPlusEasy;
                widthMinus = widthMinusEasy;
                heightPlus = heightPlusEasy;
                heightMinus = heightMinusEasy;
                insides = insidesEasy; 
                break;
            case 2:
                timer = startTimerMedium;
                widthPlus = widthPlusMedium;
                widthMinus = widthMinusMedium;
                heightPlus = heightPlusMedium;
                heightMinus = heightMinusMedium;
                insides = insidesMedium;
                break;
            case 3:
                timer = startTimerHard;
                widthPlus = widthPlusHard;
                widthMinus = widthMinusHard;
                heightPlus = heightPlusHard;
                heightMinus = heightMinusHard;
                insides = insidesHard;
                break;
            default:
                timer = startTimerMedium;
                widthPlus = widthPlusMedium;
                widthMinus = widthMinusMedium;
                heightPlus = heightPlusMedium;
                heightMinus = heightMinusMedium;
                insides = insidesMedium;
                break;
        }

        isFirstOpen = false; 
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
        actualx = startx + widthMinus;
        actualy = starty + widthMinus;

        createLabirynt();
        activateLabirynt();
        spawnKeys(); 
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            minutes = Mathf.FloorToInt(timer / 60);
            seconds = Mathf.FloorToInt(timer % 60);
        }
        else
        {
            StaticClass.CrossSceneInformation = seed;
            SceneManager.LoadScene("Home");
        }
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
                    ceils[actualx, actualy].which = ceils[actualx + 1, actualy].which + 1; 
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
                        ceils[actualx, actualy].which = ceils[actualx, actualy - 1].which + 1;
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
                            ceils[actualx, actualy].which = ceils[actualx, actualy + 1].which + 1;
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
                                ceils[actualx, actualy].which = ceils[actualx - 1, actualy].which + 1;
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
        int maxWhich = 0;
        for (int i = 0; i <= widthPlus + widthMinus; i++)
        {
            for (int j = 0; j <= heightPlus + heightMinus; j++)
            {
                if (ceils[i, j].which > maxWhich)
                {
                    maxWhich = ceils[i, j].which;
                }
            }
        }

        bool isExit = false; 
        for (int i = 0; i <= widthPlus + widthMinus; i++)
        {
            if(isExit)
            {
                break; 
            }
            for (int j = 0; j <= heightPlus + heightMinus; j++)
            {
                if(isExit)
                {
                    break; 
                }
                if (ceils[i, j].which == maxWhich)
                {
                    ceils[i, j].isBoss = true;
                    isExit = true;
                    break; 
                }
            }
        }

        for (int i = 0; i <= widthPlus + widthMinus; i++)
        {
            for (int j = 0; j <= heightPlus + heightMinus; j++)
            {
                if (ceils[i, j].left)
                {
                    if (ceils[i, j].up)
                    {
                        if (ceils[i, j].down)
                        {
                            if (ceils[i, j].right)
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
        GameObject newCeil; 
        if (nameOfRoom == "LUDR")
        {
            newCeil = Instantiate(roomsLUDR[random.Next(numberRoomsLUDR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else if (nameOfRoom == "LUD")
        {
            newCeil = Instantiate(roomsLUD[random.Next(numberRoomsLUD)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else if (nameOfRoom == "LUR")
        {
            newCeil = Instantiate(roomsLUR[random.Next(numberRoomsLUR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else if (nameOfRoom == "LDR")
        {
            newCeil = Instantiate(roomsLDR[random.Next(numberRoomsLDR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else if (nameOfRoom == "UDR")
        {
            newCeil = Instantiate(roomsUDR[random.Next(numberRoomsUDR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else if (nameOfRoom == "LU")
        {
            newCeil = Instantiate(roomsLU[random.Next(numberRoomsLU)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else if (nameOfRoom == "UR")
        {
            newCeil = Instantiate(roomsUR[random.Next(numberRoomsUR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else if (nameOfRoom == "LD")
        {
            newCeil = Instantiate(roomsLD[random.Next(numberRoomsLD)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else if (nameOfRoom == "DR")
        {
            newCeil = Instantiate(roomsDR[random.Next(numberRoomsDR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else if (nameOfRoom == "UD")
        {
            newCeil = Instantiate(roomsUD[random.Next(numberRoomsUD)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else if (nameOfRoom == "LR")
        {
            newCeil = Instantiate(roomsLR[random.Next(numberRoomsLR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else if (nameOfRoom == "L")
        {
            newCeil = Instantiate(roomsL[random.Next(numberRoomsL)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else if (nameOfRoom == "U")
        {
            newCeil = Instantiate(roomsU[random.Next(numberRoomsU)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else if (nameOfRoom == "D")
        {
            newCeil = Instantiate(roomsD[random.Next(numberRoomsD)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else if (nameOfRoom == "R")
        {
            newCeil = Instantiate(roomsR[random.Next(numberRoomsR)], new Vector2(StartX + (x * 18), StartY + (y * 10)), Quaternion.identity) as GameObject;
        }
        else
        {
            newCeil = null; 
        }

        newCeil.name = string.Format("Ceil({0}, {1})", x, y);
        newCeil.transform.parent = this.transform;

        if (ceils[x + startx + widthMinus, y + starty + heightMinus].isBoss)
        {
            RoomLoad rl = newCeil.GetComponent<RoomLoad>();
            rl.isBoss = true;
        }
    }

    public void spawnKeys()
    {
        int spawnedKey = 0;
        int[] tabX = new int[2];
        int[] tabY = new int[2];
        bool isPosible; 
        while(spawnedKey < 2)
        {
            isPosible = true; 
            int randomX = random.Next(startx + widthMinus + widthPlus + 1);
            int randomY = random.Next(starty + heightMinus + heightPlus + 1);

            for (int i = 0; i <= spawnedKey; i++)
            {
                for (int j = 0; j <= spawnedKey; j++)
                {
                    if (tabX[i] == randomX && tabY[j] == randomY)
                    {
                        isPosible = false;
                    }
                }
            }

            if (isPosible)
            {
                if (ceils[randomX, randomY].isActive && !ceils[randomX, randomY].isBoss)
                {
                    RoomLoad roomLoad = GameObject.Find("Ceil(" + (randomX - widthMinus) + ", " + (randomY - heightMinus) + ")").GetComponent<RoomLoad>();
                    if (!roomLoad.isBoss)
                    {
                        tabX[spawnedKey] = randomX;
                        tabY[spawnedKey] = randomY;

                        GameObject newKey = Instantiate(key, new Vector2((startx * 18) + ((randomX - widthMinus) * 18), ((starty - heightMinus) * 10) + (randomY * 10)), Quaternion.identity) as GameObject;
                        newKey.transform.parent = GameObject.Find("Ceil(" + (randomX - widthMinus) + ", " + (randomY - heightMinus) + ")").transform;
                        SpriteRenderer spriteRenderer = newKey.GetComponent<SpriteRenderer>();
                        spriteRenderer.sortingOrder = 1;

                        spawnedKey++; 
                    }
                }
            }
        }
    }
}
