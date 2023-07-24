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
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(MoveAndActivateObjects());
    }

    private IEnumerator MoveAndActivateObjects()
    {
        while (currentWaypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            Vector3 direction = (targetPosition - transform.position).normalized;


            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
                yield return null;
            }

           
            // Activar el GameObject si se proporcionó uno
            if (objectToActivate != null)
                objectToActivate.SetActive(true);

            // Esperar hasta que la animación del otro GameObject termine
            if (otherObjectAnimator != null && !string.IsNullOrEmpty(otherObjectAnimationName))
            {
                yield return new WaitForSeconds(0.1f); // Pequeño tiempo de espera para asegurar que la animación del otro objeto comience

                while (otherObjectAnimator.GetCurrentAnimatorStateInfo(0).IsName(otherObjectAnimationName))
                {
                    yield return null;
                }

                yield return new WaitForSeconds(0.1f); // Pequeño tiempo de espera adicional para asegurar que la animación termine completamente
            }

            // Desactivar el GameObject si se proporcionó uno
            if (objectToActivate != null)
                objectToActivate.SetActive(false);

            // Mover al siguiente waypoint
            currentWaypointIndex++;

            // Esperar antes de continuar al siguiente waypoint
            yield return new WaitForSeconds(1f);
        }

        // Después de llegar a todos los waypoints, el GameObject se desactiva
        gameObject.SetActive(false);
    }
}
