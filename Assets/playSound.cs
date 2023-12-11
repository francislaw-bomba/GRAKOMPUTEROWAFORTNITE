using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    public AudioSource src, player;
    public AudioClip buttonClick, shoot, bulletHit;

    public void buttonClickSound()
    {
        src.clip = buttonClick;
        src.Play();
    }
    public void shootSound()
    {
        player.clip = shoot;
        player.Play();
    }
    public void bulletHitSound()
    {
        src.clip = bulletHit;
        src.Play();
    }
}
