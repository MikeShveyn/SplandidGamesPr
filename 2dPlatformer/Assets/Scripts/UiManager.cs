using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public void StartFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void StartMenuLevel()
    {
        SceneManager.LoadScene(0);
    }
}
