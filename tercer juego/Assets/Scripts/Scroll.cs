using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
   public float velocidadScroll= 2f ;
   public Vector2 direccionScroll = Vector2.down;
   public Vector2 posicionDestino;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float desplazamiento = velocidadScroll * Time.deltaTime;
        transform.Translate(direccionScroll * desplazamiento);

       if (Vector2.Distance(transform.position, posicionDestino) < 0.1f)
        {
            enabled = false;
        }

    }
}
