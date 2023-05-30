using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.BuiltIn.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public buildSystem3 builds3;
    // Start is called before the first frame update
    void Start()
    {
        builds3 = GameObject.Find("Game Manager").GetComponent<buildSystem3>();
    }

    // Update is called once per frame
    void Update()
    {
        timer.text= builds3.minutes.ToString()+":"+builds3.seconds.ToString();
    }
}
