using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
{
    currentHealth -= damageAmount;

    if (currentHealth <= 0)
    {
        Die();
    }

    Debug.Log("Enemy took damage: " + damageAmount); // Depuración para verificar si se está llamando al método
}


    private void Die()
    {
        // Implementa aquí la lógica para el comportamiento de muerte del enemigo
        // Por ejemplo, reproducir una animación, otorgar puntos al jugador, etc.
        Destroy(gameObject);
    }
}
