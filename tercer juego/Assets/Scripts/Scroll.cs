using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float velocidadScroll = 2f;
    public Vector2 direccionScroll = Vector2.down;
    public Vector2 posicionDestino;
    public float distanciaUmbral = 0.1f;

    private ObjectActivation objectActivation;

    void Start()
    {
        objectActivation = GetComponent<ObjectActivation>();
    }

    void Update()
    {
        float desplazamiento = velocidadScroll * Time.deltaTime;
        transform.Translate(direccionScroll * desplazamiento);

        if (Vector2.Distance(transform.position, posicionDestino) < distanciaUmbral)
        {
            objectActivation.enabled = false;
            enabled = false;
        }
    }
}
