using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyTwoController : MonoBehaviour
{
    private float speed = 4.8f;
    public Transform target;
    public GameObject enemy;
    public logicScript logic;
    public PlayerMovement playerMovement;
    private int enemyHealth = 5;
    public GameObject blood;
    public GameObject smallBlood;
    private bool isStunned = false;
    private enemyHealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<enemyHealthBar>();
    }
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
        if (isStunned == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, 1.0f);
            transform.up = Vector2.MoveTowards(transform.up, target.transform.position, speed * Time.deltaTime);
        }

        if (enemyHealth <= 0)
        {
            logic.addScore(50);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(enemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            enemyHealth = enemyHealth - 1;
            healthBar.updateHealthBar(enemyHealth, 5);
            Stun();
            Instantiate(smallBlood, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("Player"))
        {
            Destroy(enemy);
            logic.gameOver();
            playerMovement.isAlive = false;
            Instantiate(blood, target.transform.position, Quaternion.identity);
        }
    }

    public void Stun()
    {
        isStunned = true;
        Invoke("unStun", 0.1f);
    }
    public void unStun()
    {
        isStunned = false;
    }
}
