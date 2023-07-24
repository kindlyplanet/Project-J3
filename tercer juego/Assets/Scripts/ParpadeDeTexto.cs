using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ParpadeDeTexto : MonoBehaviour
{
    public float blinkInterval = 0.5f; // Intervalo de tiempo entre los cambios de visibilidad
    public float displayDuration = 3f; // Duración total para mostrar el texto antes de desactivarlo

    public List<TextMeshProUGUI> textMeshProTextsToBlink = new List<TextMeshProUGUI>();

    private void Start()
    {
        // Inicia el parpadeo para todos los textos seleccionados
        foreach (TextMeshProUGUI textMeshProText in textMeshProTextsToBlink)
        {
            StartCoroutine(BlinkAndDisableText(textMeshProText));
        }
    }

    private IEnumerator BlinkAndDisableText(TextMeshProUGUI textMeshProComponent)
    {
        // Parpadea el texto durante la duración deseada
        float displayTimer = 0f;
        while (displayTimer < displayDuration)
        {
            // Cambiar la visibilidad del texto
            textMeshProComponent.enabled = !textMeshProComponent.enabled;

            // Esperar el intervalo de tiempo antes de cambiar la visibilidad nuevamente
            yield return new WaitForSeconds(blinkInterval);

            // Incrementar el temporizador de visualización
            displayTimer += blinkInterval;
        }

        // Desactivar el texto después de que termine la duración de visualización
        textMeshProComponent.enabled = false;
    }
}
