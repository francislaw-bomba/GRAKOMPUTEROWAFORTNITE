using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject zombie;
    public Camera cam;
    private float nextSpawnTime = 0.0f;
    public float spawnDelay = 2.0f;
    public PlayerMovement player;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
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
        float height = cam.orthographicSize + 5;
        float width = cam.orthographicSize * cam.aspect + 10;
        Instantiate(zombie, new Vector3(cam.transform.position.x + Random.Range(-width, width), cam.transform.position.z + height, 1 + Random.Range(10, 30)), Quaternion.identity);
    }
}