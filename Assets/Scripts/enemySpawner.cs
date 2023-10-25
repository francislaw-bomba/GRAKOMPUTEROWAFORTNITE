using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Camera mainCamera; 
    public float spawnDelay = 2.0f; 
    public float spawnAreaWidth = 20.0f; 
    public float spawnAreaHeight = 15.0f;
    public PlayerMovement player;
    private float nextSpawnTime = 0.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        mainCamera = Camera.main; 
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime && player.isAlive == true)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void SpawnEnemy()
    {
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        float xMin = mainCamera.transform.position.x - cameraWidth - spawnAreaWidth / 2;
        float xMax = mainCamera.transform.position.x + cameraWidth + spawnAreaWidth / 2;
        float yMin = mainCamera.transform.position.y - cameraHeight - spawnAreaHeight / 2;
        float yMax = mainCamera.transform.position.y + cameraHeight + spawnAreaHeight / 2;

        float spawnX = Random.Range(xMin, xMax);
        float spawnY = Random.Range(yMin, yMax);

        Instantiate(enemyPrefab, new Vector3(spawnX, spawnY, 0), Quaternion.identity);
    }
}