using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite lookDown;
    public Sprite lookUp;
    public Sprite lookRight;
    public Sprite lookLeft;
    public Transform shootingPointDown;
    public Transform shootingPointUp;
    public Transform shootingPointRight;
    public Transform shootingPointLeft;
    public GameObject bulletPrefabDown;
    public GameObject bulletPrefabUp;
    public GameObject bulletPrefabRight;
    public GameObject bulletPrefabLeft;
    public PlayerMovement player;
    public int fireRate;
    private int fireRateCounter;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        fireRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && player.isAlive == true && pauseMenu.isPaused == false && fireRateCounter >= fireRate)
        {
            spriteRenderer.sprite = lookUp;
            Instantiate(bulletPrefabUp, shootingPointUp.position, transform.rotation);
            fireRateCounter = 0;
        }

        if (Input.GetKeyDown(KeyCode.K) && player.isAlive == true && pauseMenu.isPaused == false && fireRateCounter >= fireRate)
        {
            spriteRenderer.sprite = lookDown;
            Instantiate(bulletPrefabDown, shootingPointDown.position, transform.rotation);
            fireRateCounter = 0;
        }

        if (Input.GetKeyDown(KeyCode.L) && player.isAlive == true && pauseMenu.isPaused == false && fireRateCounter >= fireRate)
        {
            spriteRenderer.sprite = lookRight;
            Instantiate(bulletPrefabRight, shootingPointRight.position, transform.rotation);
            fireRateCounter = 0;
        }

        if (Input.GetKeyDown(KeyCode.J) && player.isAlive == true && pauseMenu.isPaused == false && fireRateCounter >= fireRate)
        {
            spriteRenderer.sprite = lookLeft;
            Instantiate(bulletPrefabLeft, shootingPointLeft.position, transform.rotation);
            fireRateCounter = 0;
        }

        fireRateCounter++;
    }
}





