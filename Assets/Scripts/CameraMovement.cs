using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private PlayerMovement player;
    public GameObject target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, player.playerSpeed * Time.deltaTime);
    }
}
