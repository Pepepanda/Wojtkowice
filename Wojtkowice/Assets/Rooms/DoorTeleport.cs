using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    public float Px,Py,Cx,Cy;
    Camera mCamera;
    GameObject player;

    void Start()
    {
        mCamera= Camera.main;
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = new Vector3(player.transform.position.x + Px, player.transform.position.y + Py, 0.0f);
            mCamera.transform.position = new Vector3(mCamera.transform.position.x + Cx, mCamera.transform.position.y + Cy, -10.0f);
        }
    }
}
