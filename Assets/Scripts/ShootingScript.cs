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
    private int riflelFireRateCounter;
    public PlayerMovement player;
    private Vector3 mousePos;
    public Camera kamera;
    public int weaponUsed = 0; // 0 = pistol, 1 = rifle

    void Start()
    {
        kamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        pistolFireRate = 30;
        rifleFireRate = 10;
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
            pistolFireRateCounter = 0;
        }

        if (Input.GetMouseButton(0) && player.isAlive == true && pauseMenu.isPaused == false && riflelFireRateCounter >= rifleFireRate && weaponUsed == 1)
        {
            Instantiate(bullet, rifleBulletSpawnPoint.position, transform.rotation);
            riflelFireRateCounter = 0;
        }

        pistolFireRateCounter++;
        riflelFireRateCounter++;
    }
}
