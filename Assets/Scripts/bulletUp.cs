using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletUp : MonoBehaviour
{
    private float speed = 15; 
    private Rigidbody2D rb;
    public GameObject bullet;
    private Vector3 mousePos;
    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 kierunek = mousePos - transform.position;
        rb.velocity = new Vector2(kierunek.x, kierunek.y).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(bullet, 1);
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
