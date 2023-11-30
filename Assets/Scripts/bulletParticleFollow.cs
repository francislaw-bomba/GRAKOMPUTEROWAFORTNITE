using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletParticleFollow : MonoBehaviour
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
       switch (shooting.weaponUsed)
        {
            case 0:
                transform.position = shooting.bulletSpawnPoint.transform.position;
                break;
            case 1:
                transform.position = shooting.rifleBulletSpawnPoint.transform.position;
                break;
            case 2:
                transform.position = shooting.rifleBulletSpawnPoint.transform.position;
                break;
            case 3:
                transform.position = shooting.doubleBulletSpawnPoint1.transform.position;
                break;
        }
    }
}
