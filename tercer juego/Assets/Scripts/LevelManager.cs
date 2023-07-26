using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Image blackScreen;
    public float velocityFade;
    public bool activeFade;
    private bool activeStart;
    private bool activeEnd;
    private ScoreManager scoreManager;
    private string nameOfLevel;

    
    void Start()
    {
        scoreManager = ScoreManager.instance;
        if (activeFade)
        { 
          if (blackScreen == null)
          {
            blackScreen = GameObject.Find("blackScreen").GetComponent<Image>();
          }
          if (blackScreen.enabled == false)
          {
            blackScreen.enabled = true;
            blackScreen.transform.SetAsLastSibling();
            blackScreen.raycastTarget = false;
            blackScreen.color = Color.black;
            blackScreen.transform.localScale = new Vector2(25,25);
            activeStart = true;
          }  
        }
        AudioManager.Instance.musicSource.UnPause();
        AudioManager.Instance.PlayMusic("MainTheme");
    }
    
   private void Update() 
   {
        if(activeFade)
        {
            if(activeStart && blackScreen.color.a > 0)
            {
                float alpha = blackScreen.color.a-(velocityFade * Time.deltaTime);
                alpha = Mathf.Clamp01(alpha);
                blackScreen.color = new Color(0,0,0,alpha);
                if (alpha <= 0)
                {
                    activeStart = false; 
                }
            }
            if (activeEnd && blackScreen.color.a < 1 )
            {
                activeStart = false;
                float alpha = blackScreen.color.a +(velocityFade*Time.deltaTime);
                blackScreen.color = new Color(0,0,0,alpha);
                if (alpha >= 1)
                {
                    SceneManager.LoadScene(nameOfLevel);
                    activeEnd = false;
                }
            }
        }
   }
   
    public void  Play(string nameLevel)
    {
        
        nameOfLevel = nameLevel;
        activeEnd = true;
        
    }

    public void Quit()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

}
