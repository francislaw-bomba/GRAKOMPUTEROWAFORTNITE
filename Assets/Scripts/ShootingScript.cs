using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    private int fireRate;
    private int fireRateCounter;
    public PlayerMovement player;
    private Vector3 mousePos;
    public Camera kamera;

    void Start()
    {
        kamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        fireRate = 30;
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

        if (Input.GetMouseButtonDown(0) && player.isAlive == true && pauseMenu.isPaused == false && fireRateCounter >= fireRate)
        {
            Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
            fireRateCounter = 0;
        }

        fireRateCounter++;
    }
}
