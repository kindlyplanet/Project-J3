using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public Transform target;
    public float velocidad = 5f;

    public void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion =(target.position - transform.position).normalized;
        
        Vector3 velocidadMovimiento = direccion * velocidad * Time.deltaTime;
        
        transform.position += velocidadMovimiento;
    }
}
