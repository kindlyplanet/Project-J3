using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerMulti : MonoBehaviour
{
    public Transform startPoint;           // Punto inicial del enemigo
    public List<Transform> nextPointObjects;     // Lista de objetos que representan los puntos de destino del enemigo
    public float velocidadMovimiento = 5f;

    private List<Vector3> nextPoints;      // Lista de puntos de destino en tiempo de ejecución
    private int currentPointIndex = 0;     // Índice del punto de destino actual

    private void Start()
    {
        // Posicionar al enemigo en el punto inicial
        transform.position = startPoint.position;

        // Inicializar la lista de puntos de destino en tiempo de ejecución
        nextPoints = new List<Vector3>();

        // Obtener las posiciones de los puntos de destino en tiempo de ejecución
        foreach (Transform pointObject in nextPointObjects)
        {
            nextPoints.Add(pointObject.position);
        }
    }

    private void Update()
    {
        // Verificar si hay puntos de destino disponibles
        if (nextPoints.Count == 0)
        {
            Debug.LogWarning("No se han definido puntos de destino para el enemigo.");
            return;
        }

        // Obtener el punto de destino actual
        Vector3 currentPoint = nextPoints[currentPointIndex];

        // Calcular la distancia que el enemigo debe moverse en este cuadro
        float distanciaMovimiento = velocidadMovimiento * Time.deltaTime;

        // Mover al enemigo hacia el punto de destino actual
        transform.position = Vector3.MoveTowards(transform.position, currentPoint, distanciaMovimiento);

        // Verificar si el enemigo ha alcanzado el punto de destino actual
        if (Vector3.Distance(transform.position, currentPoint) < 0.1f)
        {
            // Incrementar el índice del punto de destino
            currentPointIndex++;

            // Verificar si se ha alcanzado el último punto de destino
            if (currentPointIndex >= nextPoints.Count)
            {
                Destroy(gameObject);
            }
        }
    }
}
