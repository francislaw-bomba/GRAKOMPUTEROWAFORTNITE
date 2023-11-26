using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject zombie;
    public GameObject zombie2;
    public Camera cam;
    private float nextSpawnTime = 0f;
    public float spawnDelay = 2f;
    public PlayerMovement player;
    public int enemyChanceMax = 10;
    private int enemiesSpawned;

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
                spawnDelay = 1.85f;
                break;
            case 40:
                enemyChanceMax = 8;
                spawnDelay = 1.7f;
                break;
            case 60:
                enemyChanceMax = 7;
                spawnDelay = 1.6f;
                break;
            case 90:
                enemyChanceMax = 6;
                spawnDelay = 1.4f;
                break;
            case 120:
                enemyChanceMax = 5;
                spawnDelay = 1.2f;
                break;
            case 150:
                enemyChanceMax = 4;
                spawnDelay = 1.1f;
                break;
        }
    }

    private void spawnEnemy(GameObject x)
    {
        float height = Random.Range(35, 60);
        float width = Random.Range(35, 60);
        Instantiate(x, new Vector3(cam.transform.position.x + Random.Range(-width, width), cam.transform.position.y + Random.Range(-height, height), 1), Quaternion.identity);
    }
}