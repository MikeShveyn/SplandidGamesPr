using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int playerLives = 3;
    [SerializeField] private int playerScore = 0;
    //Change to events
    [SerializeField] private Text livesText;
    [SerializeField] private Text scoreText;
    
    private void Awake() //Singleton pattern 
    {
        int numGameSessions = FindObjectsOfType<GameManager>().Length;
        if(numGameSessions > 1){Destroy(gameObject);}
        else{DontDestroyOnLoad(gameObject);}
    }

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = playerScore.ToString();
    }

    public void PlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGame();
        }
    }

    public void AddScore(int points)
    {
        playerScore += points;
        scoreText.text = playerScore.ToString();
    }
    
    private void TakeLife()
    {
        //Update to events
        playerLives--;
        livesText.text = playerLives.ToString();
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
