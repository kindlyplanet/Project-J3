using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelSelect : MonoBehaviour
{
    public void SelecionDeNivel(int levelnum)
    {
        SceneManager.LoadScene(levelnum);
        
        if(levelnum == 1)
        {
            AudioManager.Instance.PlayMusic("StageTheme");
        }
    }
}
