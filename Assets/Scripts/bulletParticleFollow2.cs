using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletParticleFollow2 : MonoBehaviour
{
    public ShootingScript shooting;

    // Start is called before the first frame update
    void Start()
    {
        shooting = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting.weaponUsed == 3)
        {
            transform.position = shooting.doubleBulletSpawnPoint2.transform.position;
        }
    }
}
