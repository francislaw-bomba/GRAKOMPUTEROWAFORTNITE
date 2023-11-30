using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public Transform rifleBulletSpawnPoint;
    private int pistolFireRate;
    private int pistolFireRateCounter;
    private int rifleFireRate;
    private int rifleFireRateCounter;
    private int shotgunFireRate;
    private int shotgunFireRateCounter;
    public Transform doubleBulletSpawnPoint1;
    public Transform doubleBulletSpawnPoint2;
    public PlayerMovement player;
    private Vector3 mousePos;
    public Camera kamera;
    public GameObject bulletBoom;
    public GameObject bulletBoom2;
    public int weaponUsed = 0; // 0 = pistol, 1 = rifle, 2 = shotgun, 3 = double pistols

    void Start()
    {
        kamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        pistolFireRate = 25;
        rifleFireRate = 10;
        shotgunFireRate = 40;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isAlive == true && pauseMenu.isPaused == false)
        {
            mousePos = kamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }

        if (Input.GetMouseButtonDown(0) && player.isAlive == true && pauseMenu.isPaused == false && pistolFireRateCounter >= pistolFireRate && weaponUsed == 0) 
        {
            Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
            Instantiate(bulletBoom, bulletSpawnPoint.position, transform.rotation);
            pistolFireRateCounter = 0;
        }

        if (Input.GetMouseButton(0) && player.isAlive == true && pauseMenu.isPaused == false && rifleFireRateCounter >= rifleFireRate && weaponUsed == 1)
        {
            Instantiate(bullet, rifleBulletSpawnPoint.position, transform.rotation);
            Instantiate(bulletBoom, rifleBulletSpawnPoint.position, transform.rotation);
            rifleFireRateCounter = 0;
        }

        if (Input.GetMouseButtonDown(0) && player.isAlive == true && pauseMenu.isPaused == false && shotgunFireRateCounter >= shotgunFireRate && weaponUsed == 2)
        {
            Instantiate(bullet, rifleBulletSpawnPoint.position, transform.rotation);
            Instantiate(bullet, rifleBulletSpawnPoint.position, transform.rotation);
            Instantiate(bullet, rifleBulletSpawnPoint.position, transform.rotation);
            Instantiate(bullet, rifleBulletSpawnPoint.position, transform.rotation);
            Instantiate(bulletBoom, rifleBulletSpawnPoint.position, transform.rotation);
            shotgunFireRateCounter = 0;
        }

        if (Input.GetMouseButtonDown(0) && player.isAlive == true && pauseMenu.isPaused == false && pistolFireRateCounter >= pistolFireRate && weaponUsed == 3)
        {
            Instantiate(bullet, doubleBulletSpawnPoint1.position, transform.rotation);
            Instantiate(bullet, doubleBulletSpawnPoint2.position, transform.rotation);
            Instantiate(bulletBoom, doubleBulletSpawnPoint1.position, transform.rotation);
            Instantiate(bulletBoom2, doubleBulletSpawnPoint2.position, transform.rotation);
            pistolFireRateCounter = 0;
        }

        pistolFireRateCounter++;
        rifleFireRateCounter++;
        shotgunFireRateCounter++;
    }
}
