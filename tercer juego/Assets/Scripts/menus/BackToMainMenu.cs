using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start() 
    {
        scoreManager = ScoreManager.instance;    
    }
    public void MainMenu()
    {
        scoreManager.ResetScore();
        SceneManager.LoadScene("Menu Principal");

    }
}
