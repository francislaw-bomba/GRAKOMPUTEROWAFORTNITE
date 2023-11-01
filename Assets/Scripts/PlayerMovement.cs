using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 4f;
    public logicScript logic;
    public bool isAlive = true;
    public SpriteRenderer spriteRenderer;
    public Sprite lookDown;
    public Sprite lookUp;
    public Sprite lookRight;
    public Sprite lookLeft;
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
