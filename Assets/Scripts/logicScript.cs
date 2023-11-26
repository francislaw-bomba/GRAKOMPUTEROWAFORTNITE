using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    static public int playerScore;
    public Text scoreText;
    public GameObject scrText;
    public GameObject gameOverScreen;

    public void addScore(int x)
    {
        playerScore = playerScore + x;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [ContextMenu("gameOver")]
    public void gameOver()
    {
        playerScore = 0;
        scoreText.text = playerScore.ToString();
        gameOverScreen.SetActive(true);
        scrText.SetActive(false);
    }

    [ContextMenu("FREESIANO")]
    public void freeSiano()
    {
        playerScore = playerScore + 100000;
        scoreText.text = playerScore.ToString();
    }
}
