using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float speed = 4.5f;
    public GameObject enemy;
    public GameObject target;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 1.0f);
        transform.up = Vector2.MoveTowards(transform.up, target.transform.position, speed * Time.deltaTime);
    }

}
