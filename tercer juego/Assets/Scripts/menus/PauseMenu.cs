using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private ScoreManager scoreManager;

    private bool isPaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = ScoreManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        AudioManager.Instance.musicSource.UnPause();
        isPaused = false;
    }


    void Pause()
    {
        pauseMenuUI.SetActive(true);
        AudioManager.Instance.musicSource.Pause();
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        scoreManager.ResetScore();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu Principal");
    }

    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}


