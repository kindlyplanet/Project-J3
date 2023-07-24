using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float velocidadScroll = 2f;
    public Vector2 direccionScroll = Vector2.down;
    public Vector2 posicionDestino;
    public float distanciaUmbral = 0.01f;

    private ObjectActivation[] objectActivations; // Cambio: Array de ObjectActivation

    private PrefabSpawner[] spawners;

    private bool haLlegadoAlDestino = false;

    void Start()
    {
        objectActivations = GetComponentsInChildren<ObjectActivation>(); // Cambio: Obtén todos los componentes ObjectActivation
        spawners = FindObjectsOfType<PrefabSpawner>(); // Obtén todas las referencias a los spawners en la escena
    }

    void Update()
    {
        if (haLlegadoAlDestino)
            return;

        float desplazamiento = velocidadScroll * Time.deltaTime;
        Vector2 nuevaPosicion = (Vector2)transform.position + direccionScroll * desplazamiento;
        transform.position = nuevaPosicion;

        if (Vector2.Distance(transform.position, posicionDestino) < distanciaUmbral)
        {
            haLlegadoAlDestino = true;

            // Desactiva los spawners
            foreach (PrefabSpawner spawner in spawners)
            {
                spawner.enabled = false;
            }

            // Desactiva todos los componentes ObjectActivation
            foreach (ObjectActivation objectActivation in objectActivations)
            {
                objectActivation.enabled = false;
            }

            enabled = false;
        }
    }
}
