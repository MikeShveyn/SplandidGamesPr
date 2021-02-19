using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    private int startSceneIndex;
    private void Awake() //Singleton pattern 
    {
        int numGameSessions = FindObjectsOfType<ScenePersist>().Length;
        if(numGameSessions > 1){Destroy(gameObject);}
        else{DontDestroyOnLoad(gameObject);}
    }

    private void Start()
    {
        startSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != startSceneIndex)
        {
            Debug.Log("DELETE" + currentSceneIndex);
            Destroy(gameObject);
        }
    }
}
