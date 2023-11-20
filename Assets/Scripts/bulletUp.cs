using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletUp : MonoBehaviour
{
    private float speed = 20; 
    private Rigidbody2D rb;
    public GameObject bullet;
    private Vector3 mousePos;
    private Camera mainCam;
    public Transform player;
    private ShootingScript shootingScript;
    public float bulletSpread;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpread = 1.2f;

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        shootingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingScript>();

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 kierunek = mousePos - player.transform.position;
        if (shootingScript.weaponUsed == 0 || shootingScript.weaponUsed == 1 || shootingScript.weaponUsed == 3)
        {
            rb.velocity = new Vector2(kierunek.x + Random.Range(-bulletSpread, bulletSpread), kierunek.y + Random.Range(-bulletSpread, bulletSpread)).normalized * speed;
        }
        if (shootingScript.weaponUsed == 2)
        {
            rb.velocity = new Vector2(kierunek.x + Random.Range(-1, 1), kierunek.y + Random.Range(-1, 1)).normalized * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(bullet, 1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(bullet);
        }

        if (other.CompareTag("Environment"))
        {
            Destroy(bullet);
        }
    }
}
