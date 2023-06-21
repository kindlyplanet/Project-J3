using UnityEngine;

public class ObjectActivation : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public float delayBeforeActivation = 2f;
    public float durationOfActivation = 5f;

    private float activationTimer;
    private float deactivationTimer;
    private bool isActive = false;
    private int currentIndex = 0;

    private void Start()
    {
        activationTimer = delayBeforeActivation;
        deactivationTimer = durationOfActivation;
    }

    private void Update()
    {
        if (!isActive)
        {
            activationTimer -= Time.deltaTime;
            if (activationTimer <= 0f)
            {
                ActivateNextObject();
            }
        }
        else
        {
            deactivationTimer -= Time.deltaTime;
            if (deactivationTimer <= 0f)
            {
                DeactivateObject();
            }
        }
    }

    public void ActivateNextObject()
    {
        // Desactivar el objeto actual
        objectsToActivate[currentIndex].SetActive(false);

        // Calcular el índice del siguiente objeto
        currentIndex++;
        if (currentIndex >= objectsToActivate.Length)
        {
            currentIndex = 0;
        }

        // Activar el siguiente objeto
        objectsToActivate[currentIndex].SetActive(true);

        isActive = true;
        activationTimer = delayBeforeActivation;
        deactivationTimer = durationOfActivation;
    }

    public void DeactivateObject()
    {
        objectsToActivate[currentIndex].SetActive(false);
        isActive = false;
    }
}
