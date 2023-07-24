using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform firePoint;          // Punto de disparo del enemigo
    public GameObject projectilePrefab;  // Prefab del proyectil del enemigo
    public float projectileSpeed = 10f;  // Velocidad del proyectil
    public float fireRate = 2f;          // Tasa de disparo en segundos

    private float nextFireTime;          // Tiempo para el próximo disparo

    private void Start()
    {
        nextFireTime = Time.time;  // Inicializar el tiempo para el próximo disparo
    }

    private void Update()
    {
        // Verificar si ha pasado el tiempo suficiente para disparar
        if (Time.time >= nextFireTime)
        {
            FireProjectile();  // Disparar el proyectil
            nextFireTime = Time.time + 1f / fireRate;  // Actualizar el tiempo para el próximo disparo
        }
    }

    private void FireProjectile()
{
    // Instanciar el proyectil en el punto de disparo
    GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

    // Obtener el componente EnemyProjectile del proyectil
    EnemyProjectile enemyProjectile = projectile.GetComponent<EnemyProjectile>();

    // Obtener la dirección hacia el jugador
    Vector2 directionToPlayer = GetDirectionToPlayer();

    // Establecer la dirección del proyectil
    enemyProjectile.SetDirection(directionToPlayer);
}


    private Vector2 GetDirectionToPlayer()
    {
        // Obtener la posición del jugador
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Calcular la dirección hacia el jugador
        Vector2 directionToPlayer = playerTransform.position - transform.position;
        directionToPlayer.Normalize();

        return directionToPlayer;
    }
}
