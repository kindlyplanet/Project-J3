using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float immunityDuration = 2f; // Duración de la inmunidad en segundos
    private bool isImmune = false; // Indicador de inmunidad

    public GameObject gameOverMenu;
    public SpriteRenderer spriteRenderer;
    public float blinkInterval = 0.1f; // Intervalo de parpadeo en segundos

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (isImmune)
        {
            return; // Si el personaje está en período de inmunidad, no recibe daño adicional
        }

        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartImmunity(); // Iniciar período de inmunidad si el personaje aún está vivo
            StartCoroutine(BlinkSprite()); // Iniciar la corrutina de parpadeo del sprite
        }

        Debug.Log("Player took damage: " + damageAmount); // Depuración para verificar si se está llamando al método
    }

    private void Die()
    {
        // Aquí puedes implementar la lógica de lo que sucede cuando el personaje muere
        Time.timeScale = 0f; // Pausar el juego
        gameOverMenu.SetActive(true); // Mostrar el menú de Game Over
    }

    private void StartImmunity()
    {
        isImmune = true;
        Invoke("EndImmunity", immunityDuration); // Llamar al método EndImmunity después de la duración de inmunidad
    }

    private void EndImmunity()
    {
        isImmune = false;
        spriteRenderer.enabled = true; // Asegurarse de que el sprite esté activado al final de la inmunidad
    }

    private IEnumerator BlinkSprite()
    {
        while (isImmune)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled; // Alternar la visibilidad del sprite

            yield return new WaitForSeconds(blinkInterval);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10);
            }
        }
    }
}
