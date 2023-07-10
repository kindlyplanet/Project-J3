using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //Librería que te permite utilizar los eventos de unity.

public class ConditionEnter : MonoBehaviour
{
    public UnityEvent action1; //Evento public para poder escogerlo desde el inspector.
    public string nameTag; //Nombre del tag que tenga el personaje o enemigo u objeto que entre a este collider, entendiendo que es obligatorio tener un collider en el GameObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(nameTag))
        {
            action1?.Invoke(); //Esta parte pregunta si la action se ejecutará y luego de ello la invoca, es decir, invocará todo lo que haya dentro del UnityEvent;
        }
    }
}
