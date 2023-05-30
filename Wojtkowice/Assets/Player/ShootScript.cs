using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShootScript : MonoBehaviour
{
    private Camera mainCam;
    private Vector2 mousePos;
    public bool CanFire;
    public float Timer;
    public float BetweenFiring;
    public Transform Gun;
    public Transform ShootPoint;
    public GameObject Bullet;
    public float BulletSpeed;
    private Vector2 direction;
    public int ammo = 100;
    public int PlayerAmmo;
    public AmmoBar ammoBar;
    public GameObject DieMenu;
    public PlayerSounds playerSounds;
    public GameObject fl;
    public GameObject fl2;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        PlayerAmmo = ammo;
        ammoBar.SetAmmo(PlayerAmmo);
        fl2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;
        FaceMouse();
        if (!DieMenu.activeSelf)
        {
            if (Input.GetMouseButtonDown(0) && CanFire)
            {
                if (PlayerAmmo != 0)
                {
                    CanFire = false;
                    Shoot();
                    playerSounds.ShootSound();
                    int subAmmo = Random.Range(1, 4);
                    PlayerAmmo -= subAmmo;
                    if (PlayerAmmo <= 0)
                    {
                        fl.SetActive(false);
                        fl2.SetActive(true);
                        PlayerAmmo = 0;
                    }
                    ammoBar.SetAmmo(PlayerAmmo);
                }
            }
        }
        if (!CanFire)
        {
            Timer+=Time.deltaTime;
            if(Timer > BetweenFiring)
            {
                CanFire = true;
                Timer = 0;
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
        fl.SetActive(true);
        fl2.SetActive(false);
        PlayerAmmo = ammo;
        ammoBar.SetAmmo(PlayerAmmo);
        playerSounds.GetSound();
    }
}
