using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartiScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Transform target;
    private float speed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        transform.position = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 1.0f);
    }
}
