using System.Collections;
using UnityEngine;

public class MovementAndAnimation : MonoBehaviour
{
    public Transform[] waypoints; // Lista de posiciones a las que se moverá el GameObject
    public float moveSpeed = 5f; // Velocidad de movimiento del GameObject
    public GameObject objectToActivate; // GameObject que se activará cuando se llegue a la posición
    public Animator otherObjectAnimator; // Animator del otro GameObject
    public string otherObjectAnimationName; // Nombre de la animación que se verificará para la espera

    private int currentWaypointIndex = 0;
    private bool hasActivatedObject = false;

    private void Start()
    {
        StartCoroutine(MoveAndActivateObjects());
    }

    private IEnumerator MoveAndActivateObjects()
    {
        while (currentWaypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            Vector3 direction = (targetPosition - transform.position).normalized;

            // Mover hacia la posición del waypoint actual
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
                yield return null;
            }

            // Activar el GameObject si se proporcionó uno y aún no se ha activado
            if (objectToActivate != null && !hasActivatedObject)
            {
                objectToActivate.SetActive(true);
                hasActivatedObject = true;

                // Esperar unos momentos antes de continuar
                yield return new WaitForSeconds(1f);
            }

            // Verificar si el otro objeto tiene animación y se proporcionó un nombre de animación
            if (otherObjectAnimator != null && !string.IsNullOrEmpty(otherObjectAnimationName))
            {
                // Reproducir la animación del otro objeto solo si es el primer waypoint
                if (currentWaypointIndex == 0)
                    otherObjectAnimator.Play(otherObjectAnimationName);

                // Esperar a que la animación del otro objeto termine solo si es el primer waypoint
                if (currentWaypointIndex == 0)
                    yield return new WaitForSeconds(otherObjectAnimator.GetCurrentAnimatorStateInfo(0).length);
            }

            // Desactivar el GameObject si se proporcionó uno y se llegó al segundo waypoint
            if (objectToActivate != null && currentWaypointIndex == 1)
                objectToActivate.SetActive(false);

            // Mover al siguiente waypoint
            currentWaypointIndex++;
        }

        // Después de llegar a todos los waypoints, el GameObject se desactiva
        gameObject.SetActive(false);
    }
}
