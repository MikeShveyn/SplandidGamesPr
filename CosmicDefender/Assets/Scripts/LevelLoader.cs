using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    [SerializeField] float delayEnd = 1f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadMainLevel()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(DelayLoad());
          
    }

    IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(delayEnd);
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
