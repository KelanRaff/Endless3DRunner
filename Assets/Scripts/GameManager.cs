using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;
    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovement PlayerMovement;

    public static event Action WinCondition;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: "+ score;
        //increase player speed
        PlayerMovement.speed += PlayerMovement.speedIncreasePerPoint;
        if(score >= 100){
            NextLevel();
        }
    }

    private void Awake()
    {
        //singleton use case
        inst =this;
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void NextLevel(){
        if(SceneManager.GetActiveScene().buildIndex == 3){
           WinCondition?.Invoke();
        } else {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
