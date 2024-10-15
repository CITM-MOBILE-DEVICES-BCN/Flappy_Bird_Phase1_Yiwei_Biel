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
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject StartScreen;

    public static event Action<bool> OnGamePaused;
    public static event Action<bool> OnGameStartState;

    private bool isPaused = false;
    


    [ContextMenu("Increment Score")]

    private void Start()
    {
         StartState();
    }

    public void StartState()
    {
        Time.timeScale = 0;
        StartScreen.SetActive(true);
        OnGameStartState?.Invoke(true);
        Debug.Log("In Start State");
    }


   public void StartGame()
    {
        Time.timeScale = 1;
        StartScreen.SetActive(false);
        OnGameStartState?.Invoke(false);
        Debug.Log("Game Started");
    }

    public void AddScore(int scoreToAdd)
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
            Invoke("restartGame", 3f);
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            Time.timeScale = 0;
            PauseScreen.SetActive(true);

        }
        else
        {
            Time.timeScale = 1;
            PauseScreen.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.Space) && gameoverScreen.activeSelf == false)
        {
            StartGame();
        }
    }

}



