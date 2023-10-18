using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDown : MonoBehaviour
{
    private float speed = 15;
    private Rigidbody2D rb;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed;
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
    }
}
