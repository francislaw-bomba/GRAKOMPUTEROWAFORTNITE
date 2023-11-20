using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Image accuracyButtonImage;
    public Sprite accuracyButtonSprite2;
    public Sprite accuracyButtonSprite3;
    public GameObject accuracyButton;
    private int accuracyPrice = 250;
    public Image speedButtonImage;
    public Sprite speedButtonSprite2;
    public Sprite speedButtonSprite3;
    public GameObject speedButton;
    private int speedPrice = 250;

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
    public void accuracyUpgrade()
    {      
            if (logicScript.playerScore >= accuracyPrice)
            {
                logic.addScore(-accuracyPrice);
                accuracyPrice = accuracyPrice + 250;
                bulletUp.bulletSpread = bulletUp.bulletSpread - 0.4f;
            }

            if (accuracyPrice == 500)
            {
                accuracyButtonImage.sprite = accuracyButtonSprite2;
            }

            if (accuracyPrice == 750)
            {
                accuracyButtonImage.sprite = accuracyButtonSprite3;
            }  
            
            if (accuracyPrice > 750)
            {
                Destroy(accuracyButton);
            }
    }
    public void speedUpgrade()
    {
        if (logicScript.playerScore >= speedPrice)
        {
            logic.addScore(-speedPrice);
            speedPrice = speedPrice + 250;
            PlayerMovement.playerSpeed = PlayerMovement.playerSpeed + 0.3f;
        }

        if (speedPrice == 500)
        {
            speedButtonImage.sprite = speedButtonSprite2;
        }

        if (speedPrice == 750)
        {
            speedButtonImage.sprite = speedButtonSprite3;
        }

        if (speedPrice > 750)
        {
            Destroy(speedButton);
        }
    }
}
