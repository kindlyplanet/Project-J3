using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class VidaRelated
{
    public int maxHealth = 50;
    public int currentHealth;
    public float immunityDuration = 2f; // Duración de la inmunidad en segundos
    [HideInInspector] public bool isImmune = false; // Indicador de inmunidad
}

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida del jugador y inmunidad")]
    [SerializeField] private VidaRelated vidaEInmunidad;

    [Header("Damage del jugador y Pantalla de muerte")]
    public GameObject gameOverMenu;
    public SpriteRenderer spriteRenderer;
    public float blinkInterval = 0.1f; // Intervalo de parpadeo en segundos

    [Header("Imagenes de la vida del jugador")]
    public Image[] healthImages;

    private void Start()
    {
        vidaEInmunidad.currentHealth = vidaEInmunidad.maxHealth;

        for (int i = 0; i < healthImages.Length; i++)
        {
            healthImages[i].enabled = true;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (vidaEInmunidad.isImmune)
        {
            return; // Si el personaje está en período de inmunidad, no recibe daño adicional
        }

        vidaEInmunidad.currentHealth -= damageAmount;

        if (vidaEInmunidad.currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartImmunity(); // Iniciar período de inmunidad si el personaje aún está vivo
            StartCoroutine(BlinkSprite()); // Iniciar la corrutina de parpadeo del sprite
            AudioManager.Instance.PlaySFX("Hit1");
            int healthSegmentIndex = vidaEInmunidad.currentHealth / (vidaEInmunidad.maxHealth / healthImages.Length);
            healthImages[healthSegmentIndex].enabled = false;
        }

        Debug.Log("Player took damage: " + damageAmount); // Depuración para verificar si se está llamando al método
    }

    public void Die()
    {
        // Aquí puedes implementar la lógica de lo que sucede cuando el personaje muere
        Time.timeScale = 0f; // Pausar el juego
        AudioManager.Instance.musicSource.Stop();
        gameOverMenu.SetActive(true); // Mostrar el menú de Game Over
        AudioManager.Instance.musicSource.Play();
        AudioManager.Instance.PlayMusic("GameOverTheme");
    }

    private void StartImmunity()
    {
        vidaEInmunidad.isImmune = true;
        Invoke("EndImmunity", vidaEInmunidad.immunityDuration); // Llamar al método EndImmunity después de la duración de inmunidad
    }

    private void EndImmunity()
    {
        vidaEInmunidad.isImmune = false;
        spriteRenderer.enabled = true; // Asegurarse de que el sprite esté activado al final de la inmunidad
    }

    private IEnumerator BlinkSprite()
    {
        while (vidaEInmunidad.isImmune)
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
