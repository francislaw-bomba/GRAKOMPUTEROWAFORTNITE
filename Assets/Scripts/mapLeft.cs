using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapLeft : MonoBehaviour
{
    [SerializeField] private Transform mapPos;
    [SerializeField] private GameObject leftMap;
    [SerializeField] private GameObject collid;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(leftMap, new Vector3(mapPos.transform.position.x - 86.4f, mapPos.transform.position.y, 5), Quaternion.identity);
            Destroy(collid);
        }
    }
}
