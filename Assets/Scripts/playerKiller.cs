using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerKiller : MonoBehaviour
{
    private Transform trans;
    private float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        trans = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, trans.transform.position, speed * Time.deltaTime);
    }
}
