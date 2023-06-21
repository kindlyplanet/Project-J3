using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform startPoint;  // Punto inicial del enemigo
    public Transform endPoint;    // Punto final del enemigo
    public float velocidadMovimiento = 5f;

    private float distanciaRecorrida = 0f;
    private float distanciaTotal;

    void Start()
    {
        // Posicionar al enemigo en el punto inicial
        transform.position = startPoint.position;

        // Calcular la distancia total que el enemigo debe recorrer
        distanciaTotal = Vector3.Distance(startPoint.position, endPoint.position);
    }

    void Update()
    {
        // Verificar si el enemigo aún no ha alcanzado el punto final
        if (distanciaRecorrida < distanciaTotal)
        {
            // Calcular la distancia que el enemigo debe moverse en este cuadro
            float distanciaMovimiento = velocidadMovimiento * Time.deltaTime;

            // Mover al enemigo hacia el punto final
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, distanciaMovimiento);

            // Actualizar la distancia recorrida
            distanciaRecorrida += distanciaMovimiento;
        }
        else
        {
            // El enemigo ha alcanzado el punto final, destruir el objeto del enemigo
            Destroy(gameObject);
        }
    }
}
