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
        instance = this;    
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
        score+=100;
        scoreText.text = score.ToString();
        if(highscore<score)
        {
            PlayerPrefs.SetInt("highscore" , score);
        }
        
    }
}