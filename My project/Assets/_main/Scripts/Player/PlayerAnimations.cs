using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private Animator animator;

    void Update()
    {
        ActualizarAnimaciondeMovimiento();
        ActualizarAnimaciondeSalto();
    }

    private void ActualizarAnimaciondeMovimiento()
    {
        bool IsRunning = playerController.ValordeMovimiento.sqrMagnitude > 0.01f;

        animator.SetBool("IsRunning", IsRunning);
    }

    private void ActualizarAnimaciondeSalto()
    {
        bool IsJumping = playerController.estaSaltando;

        animator.SetBool("IsJumping", IsJumping);

        animator.SetBool("IsGround", groundCheck.EsSuelo);

        if (playerController.estaSaltando == false && groundCheck.EsSuelo == false)
        {
            animator.SetBool("IsRunning", false);
        }
    }

    public void ActivarAnimaciondeVelocidad()
    {
        animator.speed = 1.5f;
    }

    public void DesactivarAnimaciondeVelocidad()
    {
        animator.speed = 1f;
    }
}