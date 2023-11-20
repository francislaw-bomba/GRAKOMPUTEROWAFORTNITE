using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject zombie;
    public Camera cam;
    private float nextSpawnTime = 0f;
    public float spawnDelay = 2f;
    public PlayerMovement player;
   
    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

   
    void Update()
    {
        if (Time.time >= nextSpawnTime && player.isAlive == true)
        {
            spawnEnemy();
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    private void spawnEnemy()
    {
        float height = cam.orthographicSize + 10;
        float width = cam.orthographicSize * cam.aspect + 10;
        Instantiate(zombie, new Vector3(cam.transform.position.x + Random.Range(-width, width), cam.transform.position.y + Random.Range(-height, height), 1), Quaternion.identity);
    }
}