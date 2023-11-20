using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;

    private void Start()
    {
        
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, PlayerMovement.playerSpeed * Time.deltaTime);
    }
}
