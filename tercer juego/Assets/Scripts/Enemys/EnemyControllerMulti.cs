using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerMulti : MonoBehaviour
{
    public Transform startPoint;  // Punto inicial del enemigo
    public List<Transform> nextPoint;    // Punto final del enemigo
    public int current = 0;
    public float velocidadMovimiento = 5f;

    void Start()
    {
        // Posicionar al enemigo en el punto inicial
        transform.position = startPoint.position;
    }

    void Update()
    {
        // Calcular la distancia que el enemigo debe moverse en este cuadro
        float distanciaMovimiento = velocidadMovimiento * Time.deltaTime;

        // Mover al enemigo hacia el punto final
        transform.position = Vector3.MoveTowards(transform.position, nextPoint[current].position, distanciaMovimiento);
        float distancia = Vector3.Distance(this.transform.position, nextPoint[current].position);

        if (distancia < 0.1f)
        {
            current += 1;
            if (current >= nextPoint.Count)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
