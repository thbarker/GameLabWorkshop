using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject victoryMenu;

    private void OnEnable()
    {
        Victory.OnPlayerVictory += EnableVictoryMenu;
        DeathBarrier.OnPlayerDeath += EnableGameOverMenu;
    }
    private void OnDisable()
    {
        Victory.OnPlayerVictory -= EnableVictoryMenu;
        DeathBarrier.OnPlayerDeath -= EnableGameOverMenu;
    }
    
    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
    public void EnableVictoryMenu()
    {
        victoryMenu.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
