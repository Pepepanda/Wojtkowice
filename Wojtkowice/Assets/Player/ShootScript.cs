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
    public int maxAmmo = 20;
    public int ammo;
    public AmmoBar ammoBar;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        ammo = maxAmmo;
        //ammoBar.SetAmmo(ammo);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;
        FaceMouse();
        if (Input.GetMouseButtonDown(0))
        {
            if (ammo != 0)
            {
                Shoot();
                ammo--;
                //ammoBar.SetAmmo(ammo);
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
        Destroy(BulletIns,1);
    }
    public void GetAmmo()
    {
        ammo = maxAmmo;
        ammoBar.SetAmmo(ammo);
    }
}
