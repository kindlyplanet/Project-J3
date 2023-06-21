using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float destroyDelay = 5f; // Tiempo en segundos antes de autodestruirse

    private void Start()
    {
        // Invocar el m�todo de autodestrucci�n despu�s del tiempo especificado
        Invoke("DestroyObject", destroyDelay);
    }

    private void DestroyObject()
    {
        // Destruir el objeto
        Destroy(gameObject);
    }
}
