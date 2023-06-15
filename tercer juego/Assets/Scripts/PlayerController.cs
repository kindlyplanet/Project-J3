using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    private float movimientoHorizontal= 0f;
    private float movimientoVertical= 0f;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontal = Input.GetAxis("Horizontal");
        movimientoVertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
{
    Vector2 movimiento = new Vector2(movimientoHorizontal, movimientoVertical);
    rb.velocity = movimiento * velocidadMovimiento;
}



}
