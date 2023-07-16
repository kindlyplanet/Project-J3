using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
   public int maxHealth = 100;
   public int currentHealth;
   public string nextLvl; 
   
   public void Start() 
   {
        currentHealth = maxHealth;
   }

   public void TakeDamage(int damage)
   {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
   }

    public void Die()
    {
        ScoreManager.instance.AddPointBoss();
        Destroy(gameObject);
        SceneManager.LoadScene(nextLvl);   
    }

}

