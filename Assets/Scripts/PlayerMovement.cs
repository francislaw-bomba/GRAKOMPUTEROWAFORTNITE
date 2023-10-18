using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 4;
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
            transform.position = transform.position + playerInput.normalized * speed * Time.deltaTime;
        }

        if (isAlive == true && Input.GetKeyDown(KeyCode.W) && pauseMenu.isPaused == false)
        {
            spriteRenderer.sprite = lookUp;
        }
        if (isAlive == true && Input.GetKeyDown(KeyCode.S) && pauseMenu.isPaused == false)
        {
            spriteRenderer.sprite = lookDown;
        }
        if (isAlive == true && Input.GetKeyDown(KeyCode.D) && pauseMenu.isPaused == false)
        {
            spriteRenderer.sprite = lookRight;
        }
        if (isAlive == true && Input.GetKeyDown(KeyCode.A) && pauseMenu.isPaused == false)
        {
            spriteRenderer.sprite = lookLeft;
        }
    }
}
