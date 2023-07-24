using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    int score = 0;
    int highscore = 0;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);       
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore",0);
        scoreText.text = score.ToString();
        highscoreText.text = highscore.ToString();
    }

    public void AddPoint()
{
    score += 100;
    if (score > highscore) // Verificar si el score es mayor que el highscore actual
    {
        highscore = score; // Actualizar el highscore si es mayor
        PlayerPrefs.SetInt("highscore", highscore); // Guardar el nuevo highscore en PlayerPrefs
        highscoreText.text = highscore.ToString(); // Actualizar el texto del highscore en la interfaz
    }
    scoreText.text = score.ToString(); // Actualizar el texto del score en la interfaz
}


    
public void AddPointBoss()
{
    score += 2000;
    if (score > highscore)
    {
        highscore = score;
        PlayerPrefs.SetInt("highscore", highscore);
        highscoreText.text = highscore.ToString();
    }
    scoreText.text = score.ToString();
}
    
    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    } 
}
