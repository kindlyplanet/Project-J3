using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    // Start is called before the first frame update
   private void Start()
{
    int highscore = PlayerPrefs.GetInt("highscore", 0);
    highscoreText.text = highscore.ToString();
}

    
}
