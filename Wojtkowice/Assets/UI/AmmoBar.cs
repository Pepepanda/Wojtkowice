using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Text ammoText;
    public int ammoBar;
    void Update()
    {
        ammoText.text = "Ammo: " + ammoBar+"/20";
    }
    public void SetAmmo(int ammoPoint)
    {
        ammoBar = ammoPoint;
    }
}
