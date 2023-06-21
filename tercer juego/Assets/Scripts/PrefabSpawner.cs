using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;   // Prefab a instanciar
    public Transform spawnPoint;       // Punto de spawn del prefab
    public float spawnInterval = 2f;    // Intervalo de tiempo entre cada instancia

    private float spawnTimer;           // Temporizador para controlar las instancias

    private void Start()
    {
        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        // Actualizar el temporizador
        spawnTimer -= Time.deltaTime;

        // Verificar si ha pasado el tiempo suficiente para hacer una nueva instancia
        if (spawnTimer <= 0f)
        {
            // Hacer la instancia del prefab en el spawnPoint
            Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

            // Reiniciar el temporizador
            spawnTimer = spawnInterval;
        }
    }
}
