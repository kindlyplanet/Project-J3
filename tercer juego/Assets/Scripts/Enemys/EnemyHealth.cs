using UnityEngine;
using System.Collections;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private Color normalColor;
    public Color damageColor;
    public float damageColorDuration = 0.2f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
        normalColor = spriteRenderer.color;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(ChangeColorTemporarily(damageColor, damageColorDuration));

            Debug.Log("Enemy took damage: " + damageAmount);
        }
    }

    private IEnumerator ChangeColorTemporarily(Color color, float duration)
    {
        spriteRenderer.color = color;

        yield return new WaitForSeconds(duration);

        spriteRenderer.color = normalColor;
    }

    private void Die()
    {
        // Implementa aquí la lógica para el comportamiento de muerte del enemigo
        // Por ejemplo, reproducir una animación, otorgar puntos al jugador, etc.
        ScoreManager.instance.AddPoint();
        Destroy(gameObject);
    }
}
