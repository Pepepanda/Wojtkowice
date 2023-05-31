using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeysAndBattery : MonoBehaviour
{
    public Text keys,battery;
    public buildSystem3 builds3;
    public ShootScript ShootScript;
    // Start is called before the first frame update
    void Start()
    {
        builds3 = GameObject.Find("Game Manager").GetComponent<buildSystem3>();
        ShootScript = GameObject.Find("Player").GetComponent<ShootScript>();
    }

    // Update is called once per frame
    void Update()
    {
        keys.text = "x" + builds3.numberKey.ToString();
        battery.text = "x" + ShootScript.bateries.ToString();
    }
}
