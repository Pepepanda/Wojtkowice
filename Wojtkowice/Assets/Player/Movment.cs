using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Movment : MonoBehaviour
{
    private Camera mainCam;
    public float speed = 5f;
    bool facingRight=true;
    public GameObject Hand1;
    public GameObject Hand2;
    public PlayerSounds playerSounds;
    bool isWalking;

    void Start()
    {
       mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        Vector2 pos = transform.position;
        isWalking = false; 
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
            isWalking = true; 
        }
        else if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
            isWalking = true;
        }

        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
            isWalking = true;
        }
        else if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            isWalking = true;
        }

        if(isWalking)
        {
            playerSounds.WalkSound();
        }
        else
        {
            StartCoroutine(playerSounds.StopWalkingSound());
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x > transform.position.x && facingRight)
        {
            flip();
        }
        else if (mousePos.x < transform.position.x && !facingRight)
        {
            flip();
        }
        transform.position = pos;
    }
    void flip()
    {
        facingRight = !facingRight;
        Hand1.transform.Rotate(0f, 180f, 0f);
        transform.Rotate(0f, 180f, 0f);
    }
}
