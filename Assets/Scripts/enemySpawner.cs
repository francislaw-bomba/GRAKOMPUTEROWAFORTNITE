using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject zombie;
    public GameObject zombie2;
    public Camera cam;
    private float nextSpawnTime = 0f;
    public float spawnDelay = 3;
    public PlayerMovement player;
    public int enemyChanceMax = 10;
    private int enemiesSpawned;
    public List<int> numbers = new List<int>();

    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }


    void Update()
    {
        int enemyChance = Random.Range(0, enemyChanceMax);

        if (Time.time >= nextSpawnTime && player.isAlive == true)
        {
            switch (enemyChance)
            {
                default:
                    spawnEnemy(zombie);
                    nextSpawnTime = Time.time + spawnDelay;
                    enemiesSpawned++;
                    break;
                case 1:
                    spawnEnemy(zombie2);
                    nextSpawnTime = Time.time + spawnDelay;
                    enemiesSpawned++;
                    break;
            }
        }

        switch (enemiesSpawned)
        {
            default:
                break;
            case 15:
                enemyChanceMax = 9;
                spawnDelay = 2.5f;
                break;
            case 40:
                enemyChanceMax = 8;
                spawnDelay = 2.3f;
                break;
            case 60:
                enemyChanceMax = 7;
                spawnDelay = 2.15f;
                break;
            case 90:
                enemyChanceMax = 6;
                spawnDelay = 1.8f;
                break;
            case 120:
                enemyChanceMax = 5;
                spawnDelay = 1.6f;
                break;
            case 150:
                enemyChanceMax = 4;
                spawnDelay = 1.3f;
                break;
        }
    }

    private void spawnEnemy(GameObject x)
    {
        Instantiate(x, new Vector3(cam.transform.position.x + getNumbers(), cam.transform.position.y + getNumbers(), 1), Quaternion.identity);
    }

    public int getNumbers()
    {
        if (numbers.Count < 50)
        {
            int x = Random.Range(-40, -15);
            int y = Random.Range(15, 40);
            numbers.Add(x);
            numbers.Add(y);
            int randomIndex = Random.Range(0, numbers.Count);
            int number = numbers[randomIndex];
            return number;
        }
        else
        {
            int randomIndex = Random.Range(0, numbers.Count);
            int number = numbers[randomIndex];
            return number;
        }
    }
}