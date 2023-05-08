using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    private Camera mainCam;
    private Vector2 mousePos;
    public Transform Gun;
    public Transform ShootPoint;
    public GameObject Bullet;
    public float BulletSpeed;
    private Vector2 direction;
    public int ammo = 20;
    public int PlayerAmmo;
    public AmmoBar ammoBar;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        PlayerAmmo = ammo;
        ammoBar.SetAmmo(PlayerAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;
        FaceMouse();
            if (Input.GetMouseButtonDown(0))
            {
                if (PlayerAmmo != 0)
                {
                    Shoot();
                    int subAmmo=Random.Range(1,4);
                    PlayerAmmo-=subAmmo;
                    if (PlayerAmmo<0)
                    {
                        PlayerAmmo=0;
                    }
                    ammoBar.SetAmmo(PlayerAmmo);
                }
            }
    }
    void FaceMouse()
    {
        Gun.transform.right = direction;
    }
    void Shoot()
    {
            GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
            BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
            Destroy(BulletIns, 1);
    }
    public void GetAmmo()
    {
        PlayerAmmo = ammo;
        ammoBar.SetAmmo(PlayerAmmo);
    }
}
