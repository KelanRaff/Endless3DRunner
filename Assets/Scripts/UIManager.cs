using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;

    void OnEnable(){
        PlayerMovement.OnPlayerDeath += EnableGameOverMenu;
    }

    void OnDisable(){
        PlayerMovement.OnPlayerDeath -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu(){
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("Main Menu");
    }
}
