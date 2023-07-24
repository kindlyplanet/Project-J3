using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
    public float multipier;
    public float duration; 
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            StartCoroutine(PickUp());
        }
    }

    IEnumerator PickUp()
    {
        PlayerController stat = GetComponent<PlayerController>();
        stat.velocidadMovimiento *= multipier;
        
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        
        yield return new WaitForSeconds(duration);
        stat.velocidadMovimiento /= multipier;

        Destroy(gameObject);
    }
}
