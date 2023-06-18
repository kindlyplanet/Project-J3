using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{ 
    public float tiempoVida = 2f; // Tiempo en segundos antes de que la bala se autodestruya

    void Start()
    {
        // Destruir la bala después de cierto tiempo
        Destroy(gameObject, tiempoVida);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si la bala ha colisionado con otro objeto
        // Aquí puedes agregar la lógica que deseas cuando la bala colisiona con algo
        // Por ejemplo, si quieres que la bala desaparezca al colisionar, puedes usar Destroy(gameObject);
    }
}

