using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameoverScreen;

    [ContextMenu("Increment Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = "Score: " + playerScore;
        
        Debug.Log("Score: " + playerScore);
    }

    public void restartGame()
    {
        gameoverScreen = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        if(gameoverScreen != null)
        {
            gameoverScreen.SetActive(true);
        }
        Debug.Log("Game Over!");
    }

    public void GoBackMenu()
    {
        SceneManager.LoadScene(0);

    }
   
}

