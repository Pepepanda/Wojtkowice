using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Text ammoText;
    public int ammoBar;
    public Slider slider;
    void Update()
    {
        ammoText.text = ""+ammoBar;
        slider.value = ammoBar;
    }
    public void SetAmmo(int ammoPoint)
    {
        ammoBar = ammoPoint;
    }
}
