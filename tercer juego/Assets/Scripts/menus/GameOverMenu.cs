using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    private bool isGameOver = false;
    
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = ScoreManager.instance;
    }
   
    private void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; // Pausa el tiempo en la escena
        gameOverMenu.SetActive(true); // Muestra el men� de Game Over
        
    }

    public void RestartLevel()
    {
        scoreManager.ResetScore();
        Time.timeScale = 1f; // Restablece el tiempo a la normalidad
        AudioManager.Instance.PlayMusic("StageTheme");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena actual
    }

    public void Continue()
    {
        Time.timeScale = 1f;
    }
}
