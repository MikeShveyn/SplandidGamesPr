using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private float waitTime = 2f;
    [SerializeField] private float slowMotion = 0.4f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))//ADD CHECK
        {
            StartCoroutine(WaitToExit(waitTime));
        }
    }


    IEnumerator WaitToExit(float waitTime)
    {
        Time.timeScale = slowMotion; //slow motion
        yield return new WaitForSecondsRealtime(waitTime);
        Time.timeScale = 1f;
        
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
