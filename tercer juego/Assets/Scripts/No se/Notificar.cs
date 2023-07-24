using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notificar : MonoBehaviour
{
    public GameObject alerta;
    public float duracion;

    private void OnEnable()
    {
      StartCoroutine(ActivarObjetoTemporalmente());
      AudioManager.Instance.PlaySFX("Alert");
    }

    private IEnumerator ActivarObjetoTemporalmente()
    {
        alerta.SetActive(true);

        yield return new WaitForSeconds(duracion);

        alerta.SetActive(false);
    
    }
     
}
