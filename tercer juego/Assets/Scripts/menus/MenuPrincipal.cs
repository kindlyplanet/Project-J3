using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    private ScoreManager scoreManager;
    void Start()
    {
        scoreManager = ScoreManager.instance;
        
        AudioManager.Instance.musicSource.UnPause();
        AudioManager.Instance.PlayMusic("MainTheme");
    }
    
    public void  Play()
    {
        scoreManager.ResetScore();
        AudioManager.Instance.PlayMusic("StageTheme");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("Salir");
        Application.Quit();
    }


}

