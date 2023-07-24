using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{ 
    public GameObject prefabBullet;
    public float disparosPorsegundos;
    public float tiempoDeRafaga;
    public float balasDisparadas;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Rafaga());
    }

    IEnumerator Rafaga()
    {
        while (true) //While siempre ser� true, y mientras sea true pasar� todo lo que se le pida dentro. Esto es un loop infinito. Para detenerlo debe colocar un Break, de lo contrario seguir�.
        {
            yield return new WaitForSeconds(tiempoDeRafaga);
            while (true)
            {
                for (int i = 0; i < balasDisparadas; i++)
                {
                    yield return new WaitForSeconds(disparosPorsegundos);
                    GameObject bullet = Instantiate(prefabBullet, transform.position, transform.rotation);
                    bullet.transform.parent = null;
                }
                break; //Esta es la palabra clave para romper un while. 
            }
        }
       
    }

    //En este caso hay un while dentro de un while, lo cual sirve para pedir cierto tiempo para volver a realizar el while que est� adentro. El while de adentro se quiebra (Break) y luego espera
    //los segundos del while de afuera para volver a empezar. Si el while de afuera llevara un break esto se romper�a y ya no empezar�a m�s.
}
