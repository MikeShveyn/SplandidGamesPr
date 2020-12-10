using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour

{

    //configur
    GameStatus gamestatus;
    
   public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {

        gamestatus = FindObjectOfType<GameStatus>();
        gamestatus.ResetGame();
        SceneManager.LoadScene(0);
        
        

    }

    public void EndGame()
    {
        Application.Quit();
    }
 
}
