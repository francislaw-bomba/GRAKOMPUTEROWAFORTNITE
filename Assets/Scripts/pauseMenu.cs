using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject shopPanel;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == false)
            {
                pauseGame();
            }
            else
            {
                resumeGame();
            }
            shopPanel.SetActive(false);
        }
    }

    public void pauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void resumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void backToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
