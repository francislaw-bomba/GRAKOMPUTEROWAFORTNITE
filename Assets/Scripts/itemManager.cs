using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour
{
    public GameObject carti;
    public logicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
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
        }
    }
}
