using UnityEngine;

public class Bala : MonoBehaviour
{
    public float tiempoVida = 2f; // Tiempo en segundos antes de que la bala se autodestruya
    public int damageAmount = 10; // Cantidad de daño que causa la bala

    void Start()
    {
        // Destruir la bala después de cierto tiempo
        Destroy(gameObject, tiempoVida);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Obtener una referencia al componente EnemyHealth del objeto con el que colisionó la bala
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            // Si el objeto tiene el componente EnemyHealth, le hace daño llamando al método TakeDamage
            enemy.TakeDamage(damageAmount);
            Destroy(gameObject); // Destruir la bala al impactar
        }

        // Obtener una referencia al componente BossHealth del objeto con el que colisionó la bala
        BossHealth boss = other.GetComponent<BossHealth>();
        if (boss != null)
        {
            // Si el objeto tiene el componente BossHealth, le hace daño llamando al método TakeDamage
            boss.TakeDamage(damageAmount);
            Destroy(gameObject); // Destruir la bala al impactar
        }
    }
}
