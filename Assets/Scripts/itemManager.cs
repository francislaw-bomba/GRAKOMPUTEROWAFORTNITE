using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    public GameObject carti;
    public logicScript logic;
    public SpriteRenderer playerSprite;
    public Sprite playerRifle;
    public ShootingScript shootingScript;
    public GameObject cartiButton;
    public GameObject rifleButton;
    public Sprite playerShotgun;
    public GameObject shotgunButton;
    public Sprite playerDP;
    public GameObject doublePistolsButton;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        shootingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void buyCarti()
    {
        if (logicScript.playerScore >= 20)
        {
            logic.addScore(-20);
            Instantiate(carti);
            Destroy(cartiButton);
        }
    }

    public void buyRifle()
    {
        if (logicScript.playerScore >= 200)
        {
            logic.addScore(-200);
            playerSprite.sprite = playerRifle;
            shootingScript.weaponUsed = 1;
            Destroy(rifleButton);
        }
    }
    public void buyShotgun()
    {
        if (logicScript.playerScore >= 400)
        {
            logic.addScore(-400);
            playerSprite.sprite = playerShotgun;
            shootingScript.weaponUsed = 2;
            Destroy(shotgunButton);
        }

    }
    public void buyDoublePistols()
    {
        if (logicScript.playerScore >= 300)
        {
            logic.addScore(-300);
            playerSprite.sprite = playerDP;
            shootingScript.weaponUsed = 3;
            Destroy(doublePistolsButton);
        }

    }
}
