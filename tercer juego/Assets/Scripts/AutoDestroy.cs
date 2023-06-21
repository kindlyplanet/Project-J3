using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float destroyDelay = 5f; // Tiempo en segundos antes de autodestruirse

    private void Start()
    {
        // Invocar el método de autodestrucción después del tiempo especificado
        Invoke("DestroyObject", destroyDelay);
    }

    private void DestroyObject()
    {
        // Destruir el objeto
        Destroy(gameObject);
    }
}
