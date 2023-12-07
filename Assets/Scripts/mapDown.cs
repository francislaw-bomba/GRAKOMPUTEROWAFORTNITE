using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapDown : MonoBehaviour
{
    [SerializeField] private Transform mapPos;
    [SerializeField] private GameObject downMap;
    [SerializeField] private GameObject collid;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(downMap, new Vector3(mapPos.transform.position.x, mapPos.transform.position.y - 73.6f, 5), Quaternion.identity);
            Destroy(collid);
        }
    }
}
