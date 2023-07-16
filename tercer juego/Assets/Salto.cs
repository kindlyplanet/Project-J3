using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpPower;
    public bool canJump = false;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        Saltar();
    }

    void Saltar()
    {
        if(canJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jumpPower * 20);
            }
        }
        
    }


}
