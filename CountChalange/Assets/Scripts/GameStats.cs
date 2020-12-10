using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text scoreDisplay = null;

    public static int Score;
    // Update is called once per frame
    private void Start()
    {
        Score = 0;
        
    }

    private void Update()
    {
        scoreDisplay.text = Score.ToString();
    }
}
