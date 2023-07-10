using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 10f;  // Velocidad del proyectil
    public int damage = 10;   // Daño infligido por el proyectil
    
    public float lifeDuration = 5f; // Duración de vida de la bala en segundos

    private float lifeTimer; // Temporizador para rastrear el tiempo de vida restante

    private void Start()
    {
        lifeTimer = lifeDuration; // Inicializar el temporizador de vida
    }

    private void Update()
    {
        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        // Verificar si el objeto con el que colisionó tiene el tag "Player"
        if (collider.CompareTag("Player"))
        {
            if(collider.CompareTag("Bullet"))
            {
                return;
            }            
            
            // Obtener el componente de salud del jugador
            PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();

            // Verificar si el objeto con el que colisionó tiene el componente PlayerHealth
            if (playerHealth != null)
            {
                // Infligir daño al jugador
                playerHealth.TakeDamage(damage);
            }
            
            Destroy(gameObject);
        }
        if(collider.CompareTag("Enemy"))
        {
            return;
        }
        // Restablecer el temporizador de vida
        lifeTimer = lifeDuration;

      
    }
}
