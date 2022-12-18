using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountdownTimer : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public float currentTime = 0;
    float startingTime = 0;

    [SerializeField] Text countdownText;

    void Start(){
        currentTime = startingTime;
    }

    void Update(){
        currentTime+=1 * Time.deltaTime;
        countdownText.text = "Time: " + currentTime.ToString("0");
        if(currentTime <= 0){
            currentTime = 0;
            
        }

        if(currentTime >= 0){
            OnPlayerDeath?.Invoke();
        }
    }
}
