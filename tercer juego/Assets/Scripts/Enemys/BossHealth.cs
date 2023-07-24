using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
   public int maxHealth = 100;
   public int currentHealth;
   public Image[] bossHealthImage;
   
   private Color normalColor;
   public Color damageColor;
   public float damageColorDuration = 0.2f;

   private SpriteRenderer spriteRenderer;
   
   public string nextLvl; 
   
   public void Start() 
   {
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
        
        for (int i = 0; i < bossHealthImage.Length; i++)
        {
            bossHealthImage[i].enabled = true;
        }
        normalColor = spriteRenderer.color;
   }

   public void TakeDamage(int damage)
   {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(ChangeColorTemporarily(damageColor, damageColorDuration));
            AudioManager.Instance.PlaySFX("Hit2");
            int bossSegmentIndex = currentHealth / (maxHealth/bossHealthImage.Length);
            bossHealthImage[bossSegmentIndex].enabled = false;
            
        }
   }

  private IEnumerator ChangeColorTemporarily(Color color, float duration)
    {
        spriteRenderer.color = color;

        yield return new WaitForSeconds(duration);

        spriteRenderer.color = normalColor;
    }

    public void Die()
    {
        ScoreManager.instance.AddPointBoss();
        Destroy(gameObject);
        SceneManager.LoadScene(nextLvl);   
    }

}

