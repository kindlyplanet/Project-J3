using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    public float destroyDelay;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject",destroyDelay);
    }

    void DestroyObject ()
    {
        Destroy(gameObject);
    }
}
