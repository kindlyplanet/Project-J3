using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Transform tr;
    public float velocidad;
   
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
            Moverse();
    }


    void Moverse()
    {      
            if (Input.GetKey(KeyCode.A))
            {
                tr.position -= tr.right * velocidad * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                tr.position += tr.right * velocidad * Time.deltaTime;
            }
    }


}

