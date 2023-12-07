using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapRight : MonoBehaviour
{
    [SerializeField] private Transform mapPos;
    [SerializeField] private GameObject rightMap;
    [SerializeField] private GameObject collid;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(rightMap, new Vector3(mapPos.transform.position.x + 86.4f, mapPos.transform.position.y, 5), Quaternion.identity);
            Destroy(collid);
        }
    }
}
