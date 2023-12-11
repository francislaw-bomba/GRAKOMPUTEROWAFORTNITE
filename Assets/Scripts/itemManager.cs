using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemManager : MonoBehaviour
{
    public Transform shop;
    private playerHealthBar playerHealthBar;
    public logicScript logic;
    public SpriteRenderer playerSprite;
    public Sprite playerRifle;
    public ShootingScript shootingScript;
    public GameObject rifleButton;
    public Sprite playerShotgun;
    public GameObject shotgunButton;
    public Sprite playerDP;
    public GameObject doublePistolsButton;
    public Sprite playerPistol;

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

    public Image healButtonImage;
    public Sprite healButtonSprite2;
    public Sprite healButtonSprite3;
    public GameObject healButton;
    private int healPrice = 250;

    public GameObject equipPistolButton;
    public GameObject equipRifleButton;
    public GameObject equipShotgunButton;
    public GameObject equipDPButton;
    public Image equipPistolButtonImage;
    public Image equipRifleButtonImage;
    public Image equipShotgunButtonImage;
    public Image equipDPButtonImage;
    public Sprite equip;
    public Sprite equipped;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();      
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        shootingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingScript>();
        playerHealthBar = GameObject.FindGameObjectWithTag("playerHealthBar").GetComponent<playerHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (shootingScript.weaponUsed)
        {
            case 0:
                equipPistolButtonImage.sprite = equipped;
                equipRifleButtonImage.sprite = equip;
                equipShotgunButtonImage.sprite = equip;
                equipDPButtonImage.sprite = equip;
                playerSprite.sprite = playerPistol;
                break;
            case 1:
                equipPistolButtonImage.sprite = equip;
                equipRifleButtonImage.sprite = equipped;
                equipShotgunButtonImage.sprite = equip;
                equipDPButtonImage.sprite = equip;
                playerSprite.sprite = playerRifle;
                break;
            case 2:
                equipPistolButtonImage.sprite = equip;
                equipRifleButtonImage.sprite = equip;
                equipShotgunButtonImage.sprite = equipped;
                equipDPButtonImage.sprite = equip;
                playerSprite.sprite = playerShotgun;
                break;
            case 3:
                equipPistolButtonImage.sprite = equip;
                equipRifleButtonImage.sprite = equip;
                equipShotgunButtonImage.sprite = equip;
                equipDPButtonImage.sprite = equipped;
                playerSprite.sprite = playerDP;
                break;
        }
    }
    public void equipPistol()
    {
        shootingScript.weaponUsed = 0;
    }
    public void buyRifle()
    {
        if (logicScript.playerScore >= 900)
        {
            var x = rifleButton.transform.position;          
            logic.addScore(-900);
            playerSprite.sprite = playerRifle;
            shootingScript.weaponUsed = 1;
            //Instantiate(equipRifleButton, x, Quaternion.identity, shop);
            Destroy(rifleButton);
            equipRifleButtonImage = GameObject.FindGameObjectWithTag("riflebutton").GetComponent<Image>();
        }
    }
    public void equipRifle()
    {
        shootingScript.weaponUsed = 1;
    }
    public void buyShotgun()
    {
        if (logicScript.playerScore >= 600)
        {
            var x = shotgunButton.transform.position;
            logic.addScore(-600);
            playerSprite.sprite = playerShotgun;
            shootingScript.weaponUsed = 2;
            //Instantiate(equipShotgunButton, x, Quaternion.identity, shop);
            Destroy(shotgunButton);
            equipShotgunButtonImage = GameObject.FindGameObjectWithTag("shotgunbutton").GetComponent<Image>();
        }
    }
    public void equipShotgun()
    {
        shootingScript.weaponUsed = 2;
    }
    public void buyDoublePistols()
    {
        if (logicScript.playerScore >= 300)
        {
            var x = doublePistolsButton.transform.position;
            logic.addScore(-300);
            playerSprite.sprite = playerDP;
            shootingScript.weaponUsed = 3;
            //Instantiate(equipDPButton, x, Quaternion.identity, shop);
            Destroy(doublePistolsButton);       
            equipDPButtonImage = GameObject.FindGameObjectWithTag("dpbutton").GetComponent<Image>();
        }
    }
    public void equipDoublePistols()
    {
        shootingScript.weaponUsed = 3;
    }
    public void accuracyUpgrade()
    {      
            if (logicScript.playerScore >= accuracyPrice)
            {
                logic.addScore(-accuracyPrice);
                accuracyPrice = accuracyPrice + 250;
                bulletUp.bulletSpread = bulletUp.bulletSpread - 0.4f;
            }

        switch (accuracyPrice)
        {
            case 500:
                accuracyButtonImage.sprite = accuracyButtonSprite2;
                break;
            case 750:
                accuracyButtonImage.sprite = accuracyButtonSprite3;
                break;
            case 1000:
                Destroy(accuracyButton);
                break;
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

        switch (speedPrice)
        {
            case 500:
                speedButtonImage.sprite = speedButtonSprite2;
                break;
            case 750:
                speedButtonImage.sprite = speedButtonSprite3;
                break;
            case 1000:
                Destroy(speedButton);
                break;
        }
    }
    public void Heal()
    {
        if (logicScript.playerScore >= healPrice && PlayerMovement.playerHealth < 3)
        {
            logic.addScore(-healPrice);
            healPrice = healPrice + 250;
            PlayerMovement.playerHealth = PlayerMovement.playerHealth + 1;
            playerHealthBar.updatePlayerHealthBar(PlayerMovement.playerHealth, 3);
        }

        switch (healPrice)
        {
            case 500:
                healButtonImage.sprite = healButtonSprite2;
                break;
            case 750:
                healButtonImage.sprite = healButtonSprite3;
                break;
            case 1000:
                Destroy(healButton);
                break;
        }
    }
}
