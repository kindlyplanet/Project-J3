using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    private bool isGameOver = false;

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
        gameOverMenu.SetActive(true); // Muestra el menú de Game Over
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Restablece el tiempo a la normalidad
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena actual
    }
}
