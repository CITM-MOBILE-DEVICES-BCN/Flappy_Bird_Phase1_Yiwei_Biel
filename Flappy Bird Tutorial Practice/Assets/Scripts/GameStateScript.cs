using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.CompilerServices;

public class GameStateScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameoverScreen;
    [SerializeField] private GameObject pauseScreen;

    public static event Action<bool> OnGamePaused;

    private bool isPaused = false;

    [ContextMenu("Increment Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = "Score: " + playerScore;
        
        Debug.Log("Score: " + playerScore);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Game Restarted");
    }

    public void GameOver()
    {
        if (gameoverScreen != null)
        {
            gameoverScreen.SetActive(true);
            Debug.Log("Game Over!");
        }
    }

    public void GoBackMenu()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        Debug.Log("Back to Menu");
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
        OnGamePaused?.Invoke(isPaused);
        Debug.Log("PauseStateToggled");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && gameoverScreen.activeSelf == false)
        {
            TogglePause();
        }
    }

}



