using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float playerSpeed = 3.3f;
    public logicScript logic;
    public bool isAlive = true;
    public SpriteRenderer spriteRenderer;
    public Sprite lookRight;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        transform.position = new Vector3(transform.position.x, transform.position.y, 1.0f);
    }

    void Update()
    {
        if (isAlive == true)
        {
            Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            transform.position = transform.position + playerInput.normalized * playerSpeed * Time.deltaTime;
        }
    }
}
