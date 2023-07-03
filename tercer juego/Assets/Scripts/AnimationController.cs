using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public GameObject objectToActivate;

    private void Start()
    {
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        animator.SetTrigger("StartAnimation"); // Inicia la animación

        // Desactiva el objeto que se activará al final de la animación
        objectToActivate.SetActive(false);

        // Espera la duración de la animación y luego activa el objeto
        float animationDuration = GetAnimationDuration("Puntofinal1"); // Reemplaza "YourAnimationName" por el nombre de tu animación
        Invoke("ActivateObject", animationDuration);
    }

    private float GetAnimationDuration(string animationName)
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clips)
        {
            if (clip.name == animationName)
            {
                return clip.length;
            }
        }

        return 0f;
    }

    private void ActivateObject()
    {
        objectToActivate.SetActive(true);
    }
}
