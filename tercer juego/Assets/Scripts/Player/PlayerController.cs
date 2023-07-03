using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float velocidadDisparo = 10f;
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    
    private float movimientoHorizontal = 0f;
    private float movimientoVertical = 0f;
    private Rigidbody2D rb;
    private bool puedeDisparar = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(DispararContinuo());
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            DetenerDisparoContinuo();
        }
    }

    void FixedUpdate()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        movimientoVertical = Input.GetAxisRaw("Vertical");
    
        Vector2 movimiento = new Vector2(movimientoHorizontal, movimientoVertical).normalized;
        rb.velocity = movimiento * velocidadMovimiento;
    }

    IEnumerator DispararContinuo()
    {
        while (Input.GetKey(KeyCode.Space))
        {
            if (puedeDisparar && Time.timeScale > 0f)
            {
                GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
                Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
                rbBala.velocity = puntoDisparo.up * velocidadDisparo;

                Destroy(bala, 2f); // Destruir la bala después de un tiempo

                yield return new WaitForSeconds(0.1f); // Esperar un pequeño intervalo entre cada disparo
            }
            else
            {
                yield return null;
            }
        }
    }

    void DetenerDisparoContinuo()
    {
        StopAllCoroutines();
    }
}
