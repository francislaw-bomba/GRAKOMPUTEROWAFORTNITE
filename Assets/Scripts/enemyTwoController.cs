using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyTwoController : MonoBehaviour
{
    private float speed = 5.0f;
    public Transform target;
    public GameObject enemy;
    public logicScript logic;
    public PlayerMovement playerMovement;
    private int enemyHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 1.0f);
        transform.up = Vector2.MoveTowards(transform.up, target.transform.position, speed * Time.deltaTime);

        if (enemyHealth <= 0)
        {
            logic.addScore(50);
            Destroy(enemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            enemyHealth = enemyHealth - 1;
        }

        if (other.CompareTag("Player"))
        {
            Destroy(enemy);
            logic.gameOver();
            playerMovement.isAlive = false;
        }
    }
}
