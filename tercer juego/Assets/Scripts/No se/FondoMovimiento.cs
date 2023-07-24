using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
   [SerializeField] private Vector2 velocidadMovimento;
   private Vector2 offset;
   private Material material;

   private void Awake() 
   {
        material = GetComponent<SpriteRenderer>().material;
   }

   private void Update() 
   {
        offset = velocidadMovimento * Time.deltaTime;
        material.mainTextureOffset += offset; 
   }
}
