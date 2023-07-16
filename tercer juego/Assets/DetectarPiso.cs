using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarPiso : MonoBehaviour
{
    Salto salto;

    private void Start()
    {
        salto = GetComponent<Salto>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            salto.canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Piso"))
        {
            salto.canJump = false;
        }
    }

}
