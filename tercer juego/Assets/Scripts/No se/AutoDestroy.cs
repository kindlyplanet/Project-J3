using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour
{
    public float destroyDelay = 5f; // Tiempo en segundos antes de autodestruirse

    private void Start()
    {
        StartCoroutine(WaitToDestroy());
    }

    
    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(destroyDelay);

        Destroy(gameObject);
    }
}
