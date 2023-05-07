using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movment : MonoBehaviour
{
  private Camera mainCam;
  public float speed = 10f;

   void Start()
   {
       mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
       Time.timeScale = 0f;
   }

  void Update()
  {
      Vector2 pos = transform.position;

      if(Input.GetKey("w")){
         pos.y += speed * Time.deltaTime;
      }
      else if(Input.GetKey("s")){
         pos.y -= speed * Time.deltaTime;
      }

      if(Input.GetKey("d")){
         pos.x += speed * Time.deltaTime;
      }
      else if(Input.GetKey("a")){
         pos.x -= speed * Time.deltaTime;
      }

      transform.position = pos;
   //   mainCam.position = pos;
  }
}
