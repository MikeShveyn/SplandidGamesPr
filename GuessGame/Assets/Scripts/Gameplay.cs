using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Gameplay : MonoBehaviour
{

    [SerializeField]int max;
    [SerializeField]int min;
    [SerializeField] TextMeshProUGUI guessText;
    int guess;

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
       
        guess = Random.Range(min,max);
        guessText.text = guess.ToString();
        max = max + 1;
    }

    public void onPressHigher()
    {
        min = guess;
        NextGuess();
    }

    public void onPressLower()
    {
        max = guess;
        NextGuess();
    }


    void NextGuess()
    {
        guess = (max + min) / 2;
        guessText.text = guess.ToString();
    }
}

