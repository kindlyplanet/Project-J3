using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public string selectMusic;

    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }    
    }
   
    private void Start()
    {
        PlayMusic(selectMusic);
    }

   
    public void PlayMusic (string name)
    {
        Sound s = Array.Find(musicSounds, x=> x.name == name);

        if(s == null)
        {
            Debug.Log("Sound Not found");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x=> x.name == name);

        if(s == null)
        {
            Debug.Log("Sound Not found");
        }

        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
