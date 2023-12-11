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
    private playerHealthBar playerHealthBar;
    public playSound sound;

    private void Awake()
    {
        healthBar = GetComponentInChildren<enemyHealthBar>();
    }
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        sound = GameObject.FindGameObjectWithTag("Logic").GetComponent<playSound>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerHealthBar = GameObject.FindGameObjectWithTag("playerHealthBar").GetComponent<playerHealthBar>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStunned == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, 1.0f);
            var offset = 90f;
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
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
            sound.bulletHitSound();
            Stun();
            Instantiate(smallBlood, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("Player"))
        {
            PlayerMovement.playerHealth = PlayerMovement.playerHealth - 1;
            playerHealthBar.updatePlayerHealthBar(PlayerMovement.playerHealth, 3);
            Destroy(enemy);
            Instantiate(smallBlood, target.transform.position, Quaternion.identity);
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
