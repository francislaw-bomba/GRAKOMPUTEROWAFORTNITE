using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapBlocker : MonoBehaviour
{
    private logicScript logic;
    private PlayerMovement playerMovement;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            logic.gameOver();
            playerMovement.isAlive = false;
        }
    }
}
